CREATE DATABASE Supermarket

USE Supermarket

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Price DECIMAL(15,2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL CHECK (LEN(Phone) = 12),
Salary DECIMAL(15, 2) NOT NULL
)

CREATE TABLE Orders (
Id INT PRIMARY KEY IDENTITY,
[DateTime] DATETIME NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems (
OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
Quantity INT NOT NULL CHECK(Quantity >= 1)

PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts(
Id INT IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CheckIn DATETIME NOT NULL,
CheckOut DATETIME NOT NULL

PRIMARY KEY (Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CH_CheckDates CHECK(CheckOut > CheckIn)

-- Insert --
INSERT INTO Employees VALUES
('Stoyan', 'Petrov', '888-785-8573',	500.25),
('Stamat', 'Nikolov', '789-613-1122',	999995.25),
('Evgeni', 'Petkov', '645-369-9517',	1234.51),
('Krasimir', 'Vidolov',	'321-471-9982',	50.25)

INSERT INTO Items VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32,	1),
('Glasses', 10,	8),
('Bottle of water', 1, 1)

-- Update --
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1,2,3)

-- Delete --
DELETE FROM OrderItems
WHERE ItemId = 48

-- 5 --
SELECT Id, FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

-- 6 --
SELECT FirstName + ' ' + LastName AS [Full Name],
Phone AS [Phone Number]
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

-- 7 --
SELECT FirstName, 
LastName, 
COUNT(e.Id) AS [Count]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName
ORDER BY [Count] DESC, FirstName

-- 8 --
SELECT 
e.FirstName,
e.LastName, 
AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work Hours] DESC, e.Id

-- 9 --
SELECT TOP(1) 
o.Id,
SUM(oi.Quantity * i.Price) AS [TotalPrice]
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY TotalPrice DESC

-- 10 --
SELECT TOP(10)
oi.OrderId, 
MAX(i.Price) AS [ExpensivePrice],
MIN(i.Price) AS [CheapPrice]
FROM OrderItems AS oi
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY ExpensivePrice DESC, OrderId

-- 11 --
SELECT DISTINCT 
e.Id, e.FirstName, e.LastName 
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
WHERE o.Id IS NOT NULL
ORDER BY e.Id

-- 12 --
SELECT DISTINCT 
e.Id, 
e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

-- 13 --
SELECT TOP(10)
e.FirstName + ' ' + e.LastName AS [Full Name],
SUM(oi.Quantity * i.Price) AS [Total Price],
SUM(oi.Quantity) AS [Items]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.DateTime < '2018-06-15'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, Items DESC

-- 14 --
SELECT
e.FirstName + ' ' + e.LastName AS [Full Name],
DATENAME(WEEKDAY, s.CheckIn) AS [DayOfWeek]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12 AND o.Id IS NULL
ORDER BY e.Id

-- 15 --
SELECT 
k.[Full Name],
DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
k.TotalSum
FROM (
SELECT 
e.Id AS EmployeeId,
o.Id AS OrderId,
o.DateTime,
e.FirstName + ' ' + e.LastName AS [Full Name],
SUM(oi.Quantity * i.Price) AS TotalSum,
ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price) DESC) AS RowNumber
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY e.Id, e.FirstName, e.LastName, o.Id, o.DateTime) AS k
JOIN Shifts AS s ON s.EmployeeId = k.EmployeeId
WHERE k.RowNumber = 1 AND k.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY k.[Full Name], WorkHours DESC, k.TotalSum DESC

-- 16 --
SELECT
DATEPART(DAY, o.DateTime)  AS [DayOfMonth],
FORMAT(AVG(i.Price * oi.Quantity),  'N2') AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY DayOfMonth ASC

-- 17 --
SELECT
i.Name,
c.Name,
SUM(oi.Quantity)  As [Count],
SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
RIGHT JOIN Items AS i ON i.Id = oi.ItemId
JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.Name, c.Name
ORDER BY TotalPrice DESC, [Count] DESC

-- 18 --
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
	BEGIN
	 RETURN 'One of the items does not exists!'
	END

	IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
	BEGIN
	 RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @NewFirstItemPrice DECIMAL(15,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
	DECLARE @NewSecondItemPrice DECIMAL(15,2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
	DECLARE @NewThirdItemPrice DECIMAL(15,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100)

	DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	RETURN @FirstItemName + ' price: ' + CAST(ROUND(@NewFirstItemPrice,2) as varchar) + ' <-> ' +
		   @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondItemPrice,2) as varchar)+ ' <-> ' +
		   @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
END

-- 19 --
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

	IF (@order IS NULL)
	BEGIN
		;THROW 51000, 'The order does not exist!', 1
	END

	DECLARE @OrderDate DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
	DECLARE @DateDiff INT = (SELECT DATEDIFF(DAY, @OrderDate, @CancelDate))

	IF (@DateDiff > 3)
	BEGIN
		;THROW 51000, 'You cannot cancel the order!', 2
	END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId
END


-- 20 --
CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)

CREATE TRIGGER t_DeleteOrders
    ON OrderItems AFTER DELETE
    AS
    BEGIN
	  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	  SELECT d.OrderId, d.ItemId, d.Quantity
	    FROM deleted AS d
    END
