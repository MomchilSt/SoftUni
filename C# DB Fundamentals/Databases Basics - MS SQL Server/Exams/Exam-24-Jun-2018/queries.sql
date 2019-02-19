CREATE TABLE Cities (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL (15, 2)
)

CREATE TABLE Rooms (
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL (15, 2) NOT NULL,
[Type] VARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips (
Id INT PRIMARY KEY IDENTITY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATE NOT NULL,
ArrivalDate DATE NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE
)

CREATE TABLE Accounts (
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
MiddleName VARCHAR(20),
LastName VARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id),
BirthDate DATE NOT NULL,
Email VARCHAR(100) UNIQUE NOT NUlL
)

CREATE TABLE AccountsTrips (
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
TripId INT FOREIGN KEY REFERENCES Trips(Id),
Luggage INT NOT NULL CHECK(Luggage >= 0)

PRIMARY KEY(AccountId, TripId)
)

ALTER TABLE Trips
ADD CONSTRAINT CHK_BookDate CHECK (BookDate < ArrivalDate );

ALTER TABLE Trips
ADD CONSTRAINT CHK_ArrivalDate CHECK (ArrivalDate < ReturnDate);

-- Insert --
INSERT INTO Accounts VALUES 
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59,	'1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2,'1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101, '2015-04-12',	'2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07',	'2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17',	'2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07',	'2017-08-28', '2017-08-29', NULL)

-- Update --
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

-- Delete --
DELETE FROM AccountsTrips
WHERE AccountId = 47

-- 5 --
SELECT Id, [Name]
FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]

-- 6 --
SELECT 
CONCAT(FirstName, ' ' + MiddleName, ' ', LastName) AS [Full Name],
YEAR(BirthDate) AS [BirthYear]
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY YEAR(BirthDate) DESC, FirstName

-- 7 --
SELECT 
a.FirstName,
a.LastName,
FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
c.[Name],
a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE a.Email LIKE 'e%'
ORDER BY c.[Name] DESC

-- 8 --
SELECT c.[Name], COUNT(h.Id) AS Hotels
FROM Cities AS c
LEFT JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]

-- 9 --
SELECT
r.Id,
r.Price,
h.[Name],
c.[Name]
FROM Rooms AS r
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE r.[Type] = 'First Class'
ORDER BY r.Price DESC, r.Id

-- 10 --
SELECT 
a.Id,
a.FirstName + ' ' + a.LastName AS FullName,
MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS aa ON aa.AccountId = a.Id
JOIN Trips AS t ON t.Id = aa.TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, a.Id

-- 11 --
SELECT TOP(5)
c.Id,
c.[Name],
c.CountryCode,
COUNT(a.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC

-- 12 --
SELECT
a.Id,
a.Email,
c.[Name],
COUNT(t.Id) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS ats ON ats.AccountId = a.Id
JOIN Trips AS t ON t.Id = ats.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id

-- 13 --
SELECT TOP(10)
c.Id,
c.[Name],
SUM(h.BaseRate + r.Price) AS [Total Revenue],
COUNT(t.Id) AS Trips
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
JOIN Rooms AS r ON r.HotelId = h.Id
JOIN Trips AS t ON t.RoomId = r.Id
WHERE YEAR(t.BookDate) = 2016
GROUP BY c.Id, c.[Name]
ORDER BY [Total Revenue] DESC, Trips

-- 14 --
SELECT
t.Id,
h.[Name],
r.[Type],
CASE 
	WHEN t.CancelDate IS NULL THEN SUM(h.BaseRate + r.Price)
	ELSE 0
END AS Revenue
FROM Trips As t
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN AccountsTrips AS ats ON ats.TripId = t.Id
GROUP BY t.Id, h.[Name], r.[Type], t.CancelDate
ORDER BY r.[Type], t.Id

-- 15 -- 
SELECT k.Id, k.Email, k.CountryCode, k.Trips FROM (
SELECT
a.Id,
a.Email,
c.CountryCode,
COUNT(t.Id) AS Trips,
ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC) AS TripsRank
FROM Accounts AS a
JOIN AccountsTrips AS ats ON ats.AccountId = a.Id
JOIN Trips AS t ON t.Id = ats.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
GROUP BY a.Id, a.Email, c.CountryCode) AS k
WHERE k.TripsRank = 1
ORDER BY k.Trips DESC, k.Id

-- 16 --
SELECT
TripId,
SUM(Luggage) AS Luggage,
CASE
	WHEN SUM(Luggage) > 5 THEN CONCAT('$', SUM(Luggage) * 5)
	ELSE '$0'
END AS Fee
FROM AccountsTrips
GROUP BY TripId
HAVING SUM(Luggage) > 0
ORDER BY Luggage DESC

-- 17 -- 
SELECT 
t.Id,
CONCAT(a.FirstName, ' ' + a.MiddleName, ' ' + a.LastName) AS [Full Name],
ca.[Name] AS [From],
c.[Name] AS [To],
CASE
	WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
	ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS ats ON ats.TripId = t.Id
JOIN Accounts AS a ON a.Id = ats.AccountId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
JOIN Cities AS ca ON ca.Id = a.CityId
ORDER BY [Full Name], t.Id

-- 18 --
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @AvailableRoom VARCHAR(MAX) = (SELECT TOP(1)
	CONCAT('Room ', r.Id, ': ', r.[Type], ' (', r.Beds, ' beds) - $', (h.BaseRate + r.Price) * @People) 
	FROM Hotels AS h
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE h.Id = @HotelId
	AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
	AND t.CancelDate IS NULL
	AND r.Beds > @People)

	IF @AvailableRoom IS NULL
	BEGIN
	RETURN 'No rooms available'
	END

	RETURN @AvailableRoom
END


-- 19 --
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @HotelTrip INT = (SELECT TOP (1) r.HotelId 
	FROM Trips AS t
	JOIN Rooms AS r ON r.Id = t.RoomId
	WHERE t.Id = @TripId)

	DECLARE @TargetRoomHotelId INT = (SELECT r.HotelId 
	FROM Rooms AS r WHERE r.Id = @TargetRoomId)

	IF (@HotelTrip != @TargetRoomHotelId)
	BEGIN
	RAISERROR ('Target room is in another hotel!', 16, 1)
	RETURN
	END

	DECLARE @TripsAccountBeds INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)

	IF (@TripsAccountBeds > (SELECT r.Beds FROM Rooms AS r WHERE r.Id = @TargetRoomId))
	BEGIN
	RAISERROR ('Not enough beds in target room!', 16, 2)
	RETURN
	END


UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId
END

-- 20 --
CREATE TRIGGER tr_CancelTrip
ON Trips
INSTEAD OF DELETE
AS
UPDATE Trips
SET CancelDate = GETDATE()
WHERE Id IN (SELECT Id FROM deleted WHERE CancelDate IS NULL)