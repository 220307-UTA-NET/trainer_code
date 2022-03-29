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



