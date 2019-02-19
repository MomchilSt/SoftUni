-- 1 --
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName, LastName 
FROM Employees
WHERE Salary > 35000

-- 2 --
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@GivenSalary DECIMAL(18,4))
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @GivenSalary

-- 3 --
CREATE PROC usp_GetTownsStartingWith (@GivenLetter VARCHAR(50))
AS
SELECT [Name]
FROM Towns
WHERE [Name] LIKE @GivenLetter + '%'

-- 4 --
CREATE PROC usp_GetEmployeesFromTown (@GivenTown VARCHAR(50))
AS
SELECT e.FirstName, e.LastName 
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
WHERE t.[Name] = @GivenTown

-- 5 --
CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	SET @SalaryLevel =
		CASE
			WHEN @Salary < 30000 THEN 'Low'
			WHEN @Salary <= 50000 THEN 'Average'
			ELSE 'High'
		END
	RETURN @SalaryLevel
END

-- 6 --
CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
SELECT FirstName, LastName 
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

-- 7 --
CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT AS
BEGIN
	DECLARE @WordLength INT = LEN(@word)
	DECLARE @Index INT = 1

	WHILE (@Index <= @WordLength)
	BEGIN
		IF (CHARINDEX(SUBSTRING(@word, @Index, 1), @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		SET @Index += 1
	END

	RETURN 1
END

-- 8 --
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM Employees
WHERE DepartmentID = @departmentId

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*) 
FROM Employees
WHERE DepartmentID = @departmentId

-- 9 --
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
FROM AccountHolders

-- 10 --
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Salary DECIMAL(16, 2))
AS
SELECT k.FirstName, k.LastName
FROM (
SELECT ah.FirstName, ah.LastName
 FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY ah.Id, ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @Salary ) AS k
ORDER BY k.FirstName, k.LastName

-- 11 --
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(16, 2), @Interest FLOAT, @Years INT) 
RETURNS DECIMAL(20, 4) AS
BEGIN
	DECLARE @FutureValue DECIMAL(20, 4) = @Sum * POWER(1 + @Interest, @Years)
	RETURN @FutureValue
END

-- 12 --
CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT) AS
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id AND a.Id = @AccountID

-- 13 --
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE AS
RETURN	SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNum FROM UsersGames AS ug
		JOIN Games AS g
		ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS AllGameRows
WHERE RowNum % 2 = 1

-- 14 --
CREATE TABLE Logs (
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
OldSum DECIMAL(18, 2),
NewSum DECIMAL(18, 2),
)

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
DECLARE @accountId INT = (SELECT Id FROM inserted)

INSERT INTO Logs(AccountId, NewSum, OldSum)
VALUES
(@accountId, @newSum, @oldSum)

-- 15 --

CREATE TABLE NotificationEmails (
Id INT PRIMARY KEY IDENTITY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
Subject NVARCHAR(50) NOT NULL,
Body NVARCHAR(100) NOT NULL, 
)

CREATE TRIGGER tr_EmailNotification
ON Logs
AFTER INSERT
AS 
BEGIN
    INSERT INTO NotificationEmails (Recipient, Subject, Body)
         SELECT i.AccountId,
                CONCAT('Balance change for account: ', i.AccountId),
                CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, ' to ', i.NewSum, '.')
           FROM INSERTED i
END

-- 16 --
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
    BEGIN TRANSACTION
        UPDATE Accounts
           SET Balance += @MoneyAmount
         WHERE Id = @AccountId
    COMMIT
END

-- 17 --
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
    BEGIN TRANSACTION
        UPDATE Accounts
           SET Balance -= @MoneyAmount
         WHERE Id = @AccountId
    COMMIT
END

-- 18 --
CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN
    BEGIN TRANSACTION
        IF (@Amount <= 0)
        BEGIN
            RAISERROR('Amount cannot be negative or zero', 16, 1)
            ROLLBACK
            RETURN
        END
        EXEC usp_DepositMoney @ReceiverId, @Amount
        EXEC usp_WithdrawMoney @SenderId, @Amount
        COMMIT
END

-- 20 --
DECLARE @userName NVARCHAR(max) = 'Stamat'
DECLARE @gameName NVARCHAR(max) = 'Safflower'
DECLARE @userID INT = (
                        SELECT Id 
                          FROM Users 
                         WHERE Username = @userName
                      )
DECLARE @gameID INT = (
                        SELECT Id 
                          FROM Games 
                         WHERE Name = @gameName
                      )
DECLARE @userMoney MONEY = (
                        SELECT Cash 
                          FROM UsersGames
                         WHERE UserId = @userID AND GameId = @gameID
                      )
DECLARE @itemsTotalPrice MONEY
DECLARE @userGameID int = (
                        SELECT Id 
                          FROM UsersGames 
                         WHERE UserId = @userID AND GameId = @gameID
                      )

BEGIN TRANSACTION
      SET @itemsTotalPrice = (SELECT SUM(Price) 
     FROM Items 
    WHERE MinLevel BETWEEN 11 AND 12)

    IF(@userMoney - @itemsTotalPrice >= 0)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (
                        SELECT Id 
                          FROM Items 
                         WHERE MinLevel BETWEEN 11 AND 12
                      )

        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END

SET @userMoney = (
                    SELECT Cash 
                      FROM UsersGames 
                     WHERE UserId = @userID AND GameId = @gameID
                 )
BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

    IF(@userMoney - @itemsTotalPrice >= 0)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (
                        SELECT Id 
                          FROM Items 
                         WHERE MinLevel BETWEEN 19 AND 21
                      )

        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END

  SELECT Name AS [Item Name]
    FROM Items
   WHERE Id IN (
                SELECT ItemId 
                  FROM UserGameItems 
                 WHERE UserGameId = @userGameID
               )
ORDER BY [Item Name]

-- 21 --
CREATE PROC usp_AssignProject(@EmployeeId INT, @ProjectID INT)
AS
BEGIN
    BEGIN TRANSACTION
    DECLARE @EmployeeProjects INT
    SET @EmployeeProjects = (SELECT COUNT(ep.ProjectID)
                               FROM EmployeesProjects ep
                              WHERE ep.EmployeeID = @EmployeeId)
    IF (@EmployeeProjects >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
        RETURN
    END

    INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
         VALUES (@EmployeeId, @ProjectID)
    COMMIT
END

-- 22 --
CREATE TABLE Deleted_Employees (
    EmployeeId INT NOT NULL IDENTITY(1, 1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    MiddleName NVARCHAR(50),
    JobTitle NVARCHAR(50),
    DepartmentId INT,
    Salary DECIMAL(18, 2),

    CONSTRAINT PK_Deleted_Employees PRIMARY KEY (EmployeeId)
)

CREATE TRIGGER tr_DeleteEmployees 
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
         SELECT d.FirstName,
                d.LastName,
                d.MiddleName,
                d.JobTitle,
                d.DepartmentID,
                d.Salary
           FROM DELETED d
END