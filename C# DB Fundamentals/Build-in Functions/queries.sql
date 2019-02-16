-- 1 --
SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'SA%'

-- 2 --
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%' 

-- 3 --
SELECT FirstName 
FROM Employees
WHERE DepartmentID IN (3, 10)
	AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

-- 4 --
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 5 --
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

-- 6 --
SELECT * 
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- 7 ---
SELECT * 
FROM Towns
WHERE [Name] LIKE '[^RDB]%'
ORDER BY [Name]

-- 8 --
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

-- 9 --
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10 --
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE SALARY BETWEEN 10000 AND 50000
ORDER BY Salary DESC 

-- 11 --
   SELECT *
   FROM (
       SELECT EmployeeID,
              FirstName,
              LastName,
              Salary,
              DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	   FROM Employees AS R  
   ) Employees  
   WHERE Rank = 2 AND Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC

-- 12 -- 
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- 13 --
SELECT p.PeakName, r.RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName) - 1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r
ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- 14 --'
SELECT TOP (50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

-- 15 --
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

-- 16 --
SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 17 --
SELECT Name AS Game,
	[Part of the Day] = 
		CASE 
			WHEN DATEPART(HOUR, Start) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
			ELSE 'Evening'
		END,
	Duration =
		CASE
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration <= 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			ELSE 'Extra Long'
		END
FROM Games
ORDER BY Game, Duration, [Part of the Day]

-- 18 --
SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) 
AS [Pay Due], DATEADD(MONTH, 1, OrderDate) 
AS [Deliver Due] 
FROM Orders

-- 19 --
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People VALUES
('Viktor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT Name,
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People