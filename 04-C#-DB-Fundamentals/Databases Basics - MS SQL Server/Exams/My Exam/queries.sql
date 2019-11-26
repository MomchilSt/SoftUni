--schoolAgain
CREATE DATABASE School

USE School

CREATE TABLE Students (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
AGE INT Check(Age >= 5 AND Age <= 100),
[Address] NVARCHAR(50),
Phone NVARCHAR(10) Check(LEN(Phone) = 10)
)

CREATE TABLE Subjects (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects (
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL (15, 2) CHECK(Grade >= 2 AND Grade <= 6) NOT NULL
)

CREATE TABLE Exams (
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams (
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL (15, 2) CHECK(Grade >= 2 AND Grade <= 6) NOT NULL

PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone NVARCHAR(10) CHECK(LEN(Phone) = 10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers (
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

PRIMARY KEY (StudentId, TeacherId)
)

-- Insert --
INSERT INTO Teachers VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)


-- Update --
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) AND Grade >= 5.50

-- Delete --
DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

-- 5 --
SELECT
FirstName,
LastName,
Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

-- 6 --
SELECT
CONCAT(FirstName + ' ', MiddleName, ' ' + LastName) AS [Full Name],
[Address]
FROM Students
WHERE Address LIKE '%road%'
ORDER BY FirstName, LastName, [Address]

-- 7 --
SELECT 
FirstName,
[Address],
Phone
FROM Students
WHERE Phone Like '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName

-- 8 --
SELECT 
FirstName,
LastName,
COUNT(st.TeacherId) AS TeeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY FirstName, LastName

-- 9 --
SELECT 
t.FirstName + ' ' + t.LastName AS FullName,
CONCAT(s.[Name], '-', s.Lessons) AS Subjects,
COUNT(st.StudentId) AS Students
FROM Teachers AS t
JOIN Subjects AS s ON s.Id = t.SubjectId
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName, s.[Name], s.Lessons
ORDER BY Students DESC

-- 10 --
SELECT 
CONCAT(FirstName, ' ' + LastName) AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

-- 11 --
SELECT TOP(10)
t.FirstName,
t.LastName,
COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN Subjects AS s ON s.Id = t.SubjectId
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName

-- 12 --
SELECT TOP (10)
s.FirstName,
s.LastName,
FORMAT(AVG(se.Grade), 'N2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, FirstName, LastName

-- 13 --
SELECT k.FirstName, k.LastName, k.Grade
 FROM (
SELECT
s.FirstName,
s.LastName,
ROW_NUMBER() OVER(PARTITION BY s.Id ORDER BY ss.Grade DESC) AS GradeRank,
ss.Grade
FROM Students AS s
JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
) AS k
WHERE k.GradeRank = 2
ORDER BY k.FirstName, k.LastName

-- 14 --
SELECT 
CONCAT(FirstName + ' ', MiddleName + ' ', LastName) AS [Full Name] 
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

-- 15 --
SELECT j.[Teacher Full Name], j.SubjectName ,j.[Student Full Name], FORMAT(j.TopGrade, 'N2') AS Grade
  FROM (
SELECT k.[Teacher Full Name],k.SubjectName, k.[Student Full Name], k.AverageGrade  AS TopGrade,
	   ROW_NUMBER() OVER (PARTITION BY k.[Teacher Full Name] ORDER BY k.AverageGrade DESC) AS RowNumber
  FROM (
  SELECT t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
  	   s.FirstName + ' ' + s.LastName AS [Student Full Name],
  	   AVG(ss.Grade) AS AverageGrade,
  	   su.Name AS SubjectName
    FROM Teachers AS t 
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
    JOIN Students AS s ON s.Id = st.StudentId
    JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
    JOIN Subjects AS su ON su.Id = ss.SubjectId AND su.Id = t.SubjectId
GROUP BY t.FirstName, t.LastName, s.FirstName, s.LastName, su.Name
) AS k
) AS j
   WHERE j.RowNumber = 1 
ORDER BY j.SubjectName,j.[Teacher Full Name], TopGrade DESC

-- 16 --
SELECT 
s.[Name],
AVG(ss.Grade) AS [AverageGrade]
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id

-- 17 --
SELECT
    [Teacher Full Name], [Subject Name], [Student Full Name], CAST(Grade AS NUMERIC(10, 2)) AS Grade
    FROM(
SELECT
    CONCAT(t.FirstName, ' ', t.LastName) AS [Teacher Full Name],
    sb.[Name] AS [Subject Name],
    CONCAT(s.FirstName, ' ', s.LastName) AS [Student Full Name],
    AVG(ss.Grade) AS Grade,
    ROW_NUMBER() OVER (PARTITION BY t.FirstName, t.LastName ORDER BY AVG(ss.Grade) DESC) AS [Rank]
    FROM Students AS s
    JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
    JOIN StudentsTeachers AS st ON st.StudentId = s.Id
    JOIN Teachers AS t ON t.Id = st.TeacherId
    JOIN Subjects AS sb ON sb.Id = t.SubjectId
    WHERE t.SubjectId = ss.SubjectId
    GROUP BY s.Id, s.FirstName, s.LastName, t.FirstName, t.LastName, sb.[Name]
    ) AS t
    WHERE [Rank] = 1
ORDER BY [Subject Name], [Teacher Full Name], Grade DESC


-- 18 --
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL (15,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @CheckStudent INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF (@CheckStudent IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF (@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @Result INT = (SELECT COUNT(Grade) FROM StudentsExams
	WHERE StudentId = @studentId AND Grade BETWEEN @grade AND @grade + 0.50)

	DECLARE @StudentName NVARCHAR(50) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN 'You have to update '+ CAST(@Result AS NVARCHAR(max)) +' grades for the student ' + CAST(@StudentName AS NVARCHAR(max))
END

-- 19 --
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @CheckStudent INT = (SELECT Id FROM Students WHERE Id = @StudentId)

	IF (@CheckStudent IS NULL)
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
	END

DELETE FROM StudentsExams
WHERE StudentId = @CheckStudent

DELETE FROM StudentsSubjects
WHERE StudentId = @CheckStudent

DELETE FROM StudentsTeachers
WHERE StudentId = @CheckStudent

DELETE FROM Students
WHERE Id = @CheckStudent

END

-- 20 --
CREATE TRIGGER tr_ExcludedStudents ON Students AFTER DELETE
AS
BEGIN
INSERT INTO ExcludedStudents(StudentId, StudentName)
SELECT Id, CONCAT(FirstName, ' ' + LastName) FROM deleted
END