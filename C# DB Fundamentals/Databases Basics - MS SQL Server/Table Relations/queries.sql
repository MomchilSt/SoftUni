-- 1 --
CREATE TABLE Persons (
	PersonID INT IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL (7, 2),
	PassportID INT
)

CREATE TABLE Passports (
	PassportID INT IDENTITY (101, 1),
	PassportNumber VARCHAR(50) NOT NULL
)

INSERT INTO Persons VALUES 
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

-- 2 --
CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY (101, 1),
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '07-03-1916'),
('Tesla', '01-01-2003'),
('Lada', '01-05-1996')

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

-- 3 --
CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY (101, 1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_Students_Exams PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-- 4 --
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY (101, 1),
	[Name] VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- 5 --
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities (
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
	
)

CREATE TABLE OrderItems (
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
	CONSTRAINT PK_Orders_Items PRIMARY KEY (OrderID, ItemID)
)

-- 6 --
CREATE TABLE Majors (
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(50),
	StudentName VARCHAR(50),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount VARCHAR(50),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
	CONSTRAINT PK_Students_Subjects PRIMARY KEY (StudentID, SubjectID)
)

-- 9 --
USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
JOIN Peaks AS p ON p.MountainID = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC