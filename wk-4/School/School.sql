CREATE SCHEMA School;
GO


-- ////////////// DROP TABLES /////////////
-- DROP TABLE School.Course;
-- DROP TABLE School.Teacher;
-- DROP TABLE School.Student;
-- DROP TABLE School.CourseStudent;


-- ////////////// CREATE TABLES //////////////////

CREATE TABLE School.Course( 
    Course_ID NVARCHAR (31) NOT NULL PRIMARY KEY,
    Name NVARCHAR (255) NOT NULL,
    TeacherID INT NULL,
    StartDate DATE NOT NULL DEFAULT GETDATE(), 
    EndDate DATE NOT NULL,
    CHECK (EndDate > StartDate) 
);

CREATE TABLE School.Teacher(
    Teacher_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (255) NOT NULL
    CHECK (LEN(Name) > 0)
);

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

ALTER TABLE School.Course
    ADD CONSTRAINT FK__Course__TeacherID FOREIGN KEY ( TeacherID )
    REFERENCES School.Teacher (Teacher_ID);


-- //////////////// INSERT DATA ////////////////////////

INSERT INTO School.Teacher (Name)  
    VALUES
    ('Tryg'),
    ('Brian'),
    ('Francis'),
    ('Cristian');

INSERT INTO School.Student (Name)
    VALUES
        ('Cam'),
        ('Kevin'),
        ('Kelly');

INSERT INTO School.Course (Course_ID, Name, TeacherID, EndDate) 
    VALUES
        ('CS-101', 'Intro to C#', 3, '2022-06-06'),
        ('CS-102', 'OOP Fundamentals', 2, '2022-06-06');

INSERT INTO School.CourseStudent (Course_ID, Student_ID)
    VALUES
        ('CS-101', (SELECT Student_ID FROM School.Student WHERE Name = 'Kelly')),
        ('CS-101', (SELECT Student_ID FROM School.Student WHERE Name = 'Kevin')),
        ('CS-102', (SELECT Student_ID FROM School.Student WHERE Name = 'Cam')),
        ('CS-102', (SELECT Student_ID FROM School.Student WHERE Name = 'Kelly'));