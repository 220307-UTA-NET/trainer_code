-- this is SQL
-- for comments

-- when nothing is highlighted, and we run/execute everything in the current query is run
-- you can select only a specific command, and only run that one

SELECT * FROM Customer;
-- when you make a query to a DB, any result will take the form of a table

SELECT 'Hello World';
-- single quotes mark a string literal

SELECT 2 + 2;

SELECT SYSUTCDATETIME();

-- USUALLY nothing in SQL is case sensitive
select 2 + 2;

-- semicolons are not a required end-line character. they are an end of operation/end of thought. and are not generally required.
SELECT 2 + 2


SELECT Address FROM Customer;
-- SELECT (Columns) FROM (Table)
--          ^ select-list


-- Column Alias 
-- great for concatenating multiple columns together.
SELECT FirstName + ' ' + LastName, Address FROM Customer;
SELECT FirstName + ' ' + LastName AS FullName, Address FROM Customer;
SELECT FirstName + ' ' + LastName AS 'FullName', Address FROM Customer;
SELECT FirstName + ' ' + LastName AS [FullName], Address FROM Customer;


-- filtering with WHERE

SELECT * -- get this column
FROM Customer -- from this table
WHERE LEN(FirstName) > 5; -- for entries that meet this condition

SELECT *
FROM Customer
WHERE Country = 'Brazil';

SELECT *
FROM Customer
WHERE Country = 'Brazil' AND City = 'São Paulo';

SELECT *
FROM Customer
WHERE CustomerId = 10;


-- Aggregate Functions

SELECT COUNT(*)
FROM Customer;

SELECT SUM(Total)
FROM Invoice;

-- other agg functions include min, max, avg

SELECT CustomerId, SUM(Total)
FROM Invoice
GROUP BY CustomerId; -- Group By gives us a way to group the results of an agg. function by entries


SELECT CustomerId, SUM(Total) AS Sum_Total
FROM Invoice
WHERE BillingCountry != 'USA'
GROUP BY CustomerId
HAVING SUM(Total) > 40
ORDER BY Sum_Total DESC, CustomerId; 

-- Logical order of operations is:
-- FROM
-- WHERE
-- GROUP BY
-- HAVING
-- SELECT
-- ORDER BY



-- JOINS
-- accessing more than one table to return the desired data

SELECT * 
FROM Employee AS e1 CROSS JOIN Employee AS e2
WHERE e1.EmployeeID != e2.EmployeeID;


-- Cross Join
-- Inner Join
-- Left/Right Join
-- Outter Join


-- every album by artist
SELECT Album.Title AS [Album Title], Artist.Name AS [Aritist Name]
FROM Album INNER JOIN  Artist ON Album.ArtistID = Artist.ArtistID;


SELECT al.Title, ar.Name
FROM Album AS al INNER JOIN Artist AS ar 
    ON al.ArtistID = ar.ArtistID;





-- all rock songs, showing the name in the the format "Artist-Name - Song-Name"


-- genre has genre name and genre ID
-- track has track name, genre id, and album id
-- Album has album id and artist id
-- artist has artist name and artist id

SELECT Artist.Name + ' - ' + Track.Name AS [Artist - Song]
FROM Track 
    INNER JOIN Genre ON Genre.GenreID = Track.GenreID
    JOIN Album ON Track.AlbumID = Album.AlbumID
    JOIN Artist ON Album.ArtistID = Artist.ArtistID
WHERE Genre.Name = 'Rock'






-- Set operations
-- Set operations let us run multiple queries as a single query

-- all first names of employees and customers
SELECT FirstName FROM Employee
UNION ALL
SELECT FirstName FROM Customer;
-- UNION returns all entries that are found on either query, without duplicates.
-- UNION ALL '', with duplicates (a little faster, but could have more results)

-- names that are both a customer and an employee
SELECT FirstName FROM Employee
INTERSECT
SELECT FirstName FROM Customer;
-- INTERSECT returns all entries that are in both queries (without duplicates)

-- names that are employees but not customers
SELECT FirstName FROM Customer
EXCEPT
SELECT FirstName FROM Employee;
-- EXCEPT returns entries that match the first query, and are not matched in the second query.
-- ORDER MATTERS!

-- To use a set operation, the queries must return the same type and number of columns.





-- Sub-Query
-- it's sometimes easier to express a complex idea as two queries that work sequentially

-- the artist who made the album with the longest title.
SELECT * FROM Artist
WHERE ArtistID = (
        SELECT ArtistID FROM Album
        WHERE LEN(Title) >= ALL(SELECT LEN(Title) FROM Album)
);

-- returns all tracks that were never purchased
SELECT * FROM Track WHERE TrackID NOT IN( SELECT TrackID FROM InvoiceLine );
-- Queries operate from the most-nested to the least-nested query
-- Operators for Subqueries:
-- IN, NOT IN, EXISTS, ANY, ALL



-- SQL "Families" of the language

-- DQL - Data Query Language - how we phrase/form a query
-- DDL - Data Definition Language - how we define the database (create a table, define the columns of a table)
-- DML - Data Manipulation Language - how we menipulate the database (add an entry, how we change an entry or table)

-- DDL - CREATE, ALTER, DROP

-- Schemas are a logical 'namespace' in SQL. "dbo" is the default, the one that it assumes if you dont give one.
-- 220307-UTA-NET-MyDatabase.dbo.Invoice
CREATE SCHEMA School;
GO
-- SELECT * FROM dbo.Customer

-- VERB NOUN NAME
CREATE TABLE School.Course ( -- Create a table named Course as part of the School schema
    Course_ID NVARCHAR (31) NOT NULL PRIMARY KEY, -- NOT NULL to enforce that the field must have a value
    Name NVARCHAR (255) NOT NULL,
    TeacherID INT NULL,             -- NULL allows this field to be null when the entry is addd to the table
    StartDate DATE NOT NULL DEFAULT GETDATE(), -- DEFAULT gives us a value if none was specified
    EndDate DATE NOT NULL,
    CHECK (EndDate > StartDate) -- ensures / enforces that the conditon stated must be met before the entry is added to the table
);

-- DROP TABLE School.Course;

ALTER TABLE School.Course
    DROP CONSTRAINT PK__COURSE__37E005fB804D9AE8;
ALTER TABLE School.Course 
    DROP COLUMN Course_ID;

-- Constraints
-- any column CAN contain NULL, we can restrict that with "NOT NULL"
-- Writing "NULL" can make that default explicit

-- PRIMARY KEY
-- automatically implies that a field must not be null, and that it must be unique

-- UNIQUE
-- enforce that every entry must have a different value for this column
-- *GOOD for candidate key
-- *GOOD for representing a 1-1 relationship

-- CHECK
-- CHECK (CONDITION) 
-- whatever condion is inside the () must result in true for the entry to be considered valid
-- if the condition tests false, an entry will be refused

-- DEFAULT 
-- Sets a default value for the column when new data is added.

CREATE TABLE School.Teacher(
    Teacher_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (255) NOT NULL
    CHECK (LEN(Name) > 0)
);

-- IDENTITY
-- creates a unique value that changes with every new entry in the table
-- you CAN specify a seed and an increment

ALTER TABLE School.Course
    ADD CONSTRAINT FK__Course__TeacherID FOREIGN KEY ( TeacherID )
        REFERENCES School.Teacher (Teacher_ID);



-- DML 
-- INSERT, UPDATE, DELETE, TRUNCATE

-- VERB NOUN 
INSERT INTO School.Teacher (Name)  
VALUES
    ('Tryg'),
    ('Brian'),
    ('Francis'),
    ('Cristian');

-- INSERT add data to a table

SELECT * FROM School.Teacher;

DELETE FROM School.Teacher;
-- DELETE to remove entries from a table

UPDATE  School.Teacher 
SET Name = 'Andrew'
WHERE Teacher_ID = 7;
-- Update the values of an entry that are aleady part of a table

DROP TABLE School.Teacher;


CREATE TABLE School.Student(
    Student_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (255) NOT NULL
);

CREATE TABLE School.CourseStudent(
    Course_ID NVARCHAR (31) NOT NULL
        FOREIGN KEY REFERENCES School.Course (Course_ID) ON DELETE CASCADE ON UPDATE CASCADE,
    Student_ID INT NOT NULL
        FOREIGN KEY REFERENCES School.Student (Student_ID) ON DELETE CASCADE ON UPDATE CASCADE
    PRIMARY KEY (Course_ID, Student_ID)
);

-- DROP TABLE School.CourseStudent;

INSERT INTO School.Student (Name) VALUES
('Cam'), ('Kevin'), ('Kelly');

INSERT INTO School.Course (Course_ID, Name, TeacherID, EndDate) VALUES
('CS-101', 'Intro to C#', 8, '2022-06-06');

INSERT INTO School.CourseStudent (Course_ID, Student_ID) VALUES
('CS-101', (SELECT Student_ID FROM School.Student WHERE Name = 'Kelly')),
('CS-101', (SELECT Student_ID FROM School.Student WHERE Name = 'Kevin'));

SELECT * FROM School.CourseStudent;
SELECT * FROM School.Student;
SELECT * FROM School.Course;

DELETE FROM School.Course;
DELETE FROM School.Student WHERE Name = 'Kevin';


-- Cascade
-- a cascade action is a sequence of actions that are triggered by one event, and carry out
-- a series of predetermined commands.