CREATE DATABASE InfoedukaDb;
GO

USE InfoedukaDb;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(500) NULL
);

CREATE TABLE CourseLecturers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    LecturerId INT NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    FOREIGN KEY (LecturerId) REFERENCES Users(Id)
);

CREATE TABLE Notifications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    CreatorId INT NOT NULL,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(1000) NOT NULL,
    PublishDate DATE NOT NULL,
    ExpiryDate DATE NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    FOREIGN KEY (CreatorId) REFERENCES Users(Id)
);


INSERT INTO Users (FirstName, LastName, Email, PasswordHash, Role)
VALUES
('Admin', 'Admin', 'admin@infoeduka.hr', 'admin123', 'Administrator'),
('Iva', 'Ivić', 'iva.ivic@infoeduka.hr', 'predavac123', 'Predavac');

INSERT INTO Courses (Name, Description)
VALUES
('Projektni razvoj aplikacija', 'Kolegij za razvoj aplikativnog rješenja.'),
('Baze podataka', 'Kolegij vezan uz SQL i relacijske baze.');

INSERT INTO CourseLecturers (CourseId, LecturerId)
VALUES
(1, 2);