-- 1 --
SELECT TOP (5) 
	e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID

-- 2 --
SELECT TOP (50)
	e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID = e.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY FirstName, LastName

-- 3 --
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

-- 4 --
SELECT TOP(5)
	e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5 --
SELECT DISTINCT TOP(3)
	e.EmployeeID, e.FirstName 
FROM Employees AS e
RIGHT OUTER JOIN EmployeesProjects AS ep
ON e.EmployeeID NOT IN(SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID

-- 6 --
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] 
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '01.01.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- 7 --
SELECT TOP(5)
	e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep 
ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID AND p.StartDate > '2002-08-13' AND P.EndDate IS NULL
ORDER BY e.EmployeeID

-- 8 --
SELECT e.EmployeeID, e.FirstName, 
CASE
	WHEN p.StartDate >= '2005-01-01' THEN NULL
	ELSE p.[Name]
END AS  ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
On ep.EmployeeID = e.EmployeeID AND e.EmployeeID = 24
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID

-- 9 --
SELECT e.EmployeeID, e.FirstName, e.ManagerID, e2.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS e2
ON e2.EmployeeID = e.ManagerID AND e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

-- 10 --
SELECT TOP(50)
	e.EmployeeID, 
	CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName,
	CONCAT(e2.FirstName,' ', e2.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS e2
ON e2.EmployeeID = e.ManagerID
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

-- 11 --
SELECT MIN(AverageSalaryByDepartment) AS MinAverageSalary FROM
(SELECT AVG(Salary) AS AverageSalaryByDepartment FROM Employees
GROUP BY DepartmentID) AS AvgSalaries

-- 12 --
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode AND c.CountryCode = 'BG'
JOIN Mountains AS m
ON m.Id = mc.MountainId
JOIN Peaks as p
ON p.MountainId = m.Id AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13 --
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode AND c.CountryCode IN ('BG', 'US', 'RU')
JOIN Mountains AS m
ON m.Id = mc.MountainId
GROUP BY c.CountryCode

-- 14 --
SELECT TOP(5) 
c.CountryName, r.RiverName 
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers As r
ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15 --
SELECT sel.ContinentCode, sel.CurrencyCode AS CurrencyCode, sel.CurrencyUs AS CurrencyUsage
FROM (SELECT c.ContinentCode,
cr.CurrencyCode,
COUNT(cr.Description) AS CurrencyUs,
DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(cr.CurrencyCode) DESC) AS rankk
FROM  Currencies cr
JOIN Countries c ON cr.CurrencyCode = c.CurrencyCode
GROUP BY c.ContinentCode, cr.CurrencyCode
HAVING  COUNT(cr.Description) > 1) AS sel
WHERE sel.rankk= 1 
ORDER BY ContinentCode

-- 16 --
SELECT COUNT(c.CountryCode) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

-- 17 --
SELECT TOP(5) 
c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c

LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode

LEFT JOIN Mountains AS m 
ON m.Id = mc.MountainId

LEFT JOIN Peaks AS p
ON p.MountainId = m.Id

LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode

LEFT JOIN Rivers AS r
On r.Id = cr.RiverId

GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.[Length]) DESC, c.CountryName

-- 18 --
SELECT TOP (5) 
WITH TIES 
	c.CountryName,
	 ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName',
	  ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation',
	   ISNULL(m.MountainRange, '(no mountain)')
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName