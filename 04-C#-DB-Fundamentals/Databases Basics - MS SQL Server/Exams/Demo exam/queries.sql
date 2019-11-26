CREATE DATABASE ColonialJourney
CREATE TABLE Planets (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys (
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards (
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(11) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

INSERT INTO Planets ([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW',	3),
('WakaWaka', 'Wakanda',	4),
('Falcon9',	'SpaceX',	1),
('Bed',	'Vidolov',	6)


UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12


DELETE FROM TravelCards
WHERE JourneyId IN (1,2,3)

DELETE FROM Journeys
WHERE Id IN (1,2,3)

-- 5 --
SELECT CardNumber, JobDuringJourney 
FROM TravelCards
ORDER BY CardNumber

-- 6 --
SELECT 
	Id,
	FirstName + ' ' + LastName AS FullName,
	Ucn
 FROM Colonists
 ORDER BY FirstName, LastName, Id

 -- 7 --
 SELECT Id, 
 FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
 FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
 FROM Journeys
 WHERE Purpose = 'Military'
 ORDER BY JourneyStart

-- 8 --
SELECT c.Id, c.FirstName + ' ' + c.LastName AS full_name
FROM Colonists AS C
JOIN TravelCards AS t ON t.ColonistId = c.Id
WHERE t.JobDuringJourney = 'Pilot'
ORDER BY c.Id

-- 9 --
SELECT COUNT(*) AS count
FROM TravelCards AS tc
JOIN Journeys AS j ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'

-- 10 --
SELECT TOP(1) s.[Name], sp.[Name]
FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
ORDER BY LightSpeedRate DESC

-- 11 --
SELECT s.[Name], s.Manufacturer 
FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot' AND c.BirthDate > '01/01/1989'
ORDER BY s.[Name]

-- 12 --
SELECT p.[Name], s.[Name]
FROM Spaceports AS s
JOIN Planets AS p ON p.Id = s.PlanetId
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC

-- 13 --
SELECT p.[Name], COUNT(j.DestinationSpaceportId) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY COUNT(j.DestinationSpaceportId) DESC, p.[Name]

-- 14 --
SELECT TOP(1) 
		j.Id,
		p.[Name],
		s.[Name],
		j.Purpose
FROM Journeys AS j
JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
JOIN Planets AS p ON p.Id = s.PlanetId
ORDER BY DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd)

-- 15 --
SELECT TOP(1) tc.JourneyId, tc.JobDuringJourney AS JobName
FROM TravelCards AS tc
WHERE tc.JourneyId = (SELECT TOP(1) j.Id FROM Journeys AS j ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd) DESC)
GROUP BY tc.JobDuringJourney, tc.JourneyId
ORDER BY COUNT(tc.JobDuringJourney) ASC

-- 16 --
SELECT k.JobDuringJourney, k.FullName, k.JobRank
FROM (
SELECT JobDuringJourney,
c.FirstName + ' ' + c.LastName AS FullName,
ROW_NUMBER() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) AS JobRank
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON tc.ColonistId = c.Id) AS k
WHERE k.JobRank = 2

-- 17 --
SELECT p.[Name], COUNT(s.Id) AS [Count]
 FROM Spaceports AS s
RIGHT JOIN Planets AS p ON p.Id = s.PlanetId
GROUP BY p.[Name]
ORDER BY COUNT(s.Id) DESC, p.Name

-- 18 --
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN

DECLARE @Result INT = (SELECT COUNT(*) 
FROM TravelCards AS t
JOIN Journeys AS j ON j.Id = t.JourneyId
JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
JOIN Planets AS p ON p.Id = s.PlanetId
WHERE p.[Name] = @PlanetName
)

RETURN @Result

END

-- 19 --
CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS

DECLARE @CheckJourney INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

IF(@CheckJourney IS NULL)
BEGIN
	RAISERROR('The journey does not exist!', 16, 1)
END

DECLARE @CheckPurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @CheckJourney)

IF(@NewPurpose = @CheckPurpose)
BEGIN
	RAISERROR('You cannot change the purpose!', 16, 2)
END

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @CheckJourney

-- 20 --
CREATE TRIGGER tr_DeletedJourneys ON Journeys AFTER DELETE
AS
INSERT INTO DeletedJourneys (Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
SELECT * FROM deleted
