--Script to Insert, Delete, Update
INSERT INTO animals (AnimalID, Name, Breed, BirthDate, Sex, Price, Status)
VALUES (NEWID(), 'Buffalo', 'Hallikar', '2018-01-01', 'Female', 600, 'Active')

UPDATE Animals Set Sex = 'Male' where AnimalId = '949AC775-5CF9-4B8D-AAB0-A42A9230CBA3'

Delete Animals where AnimalId = '949AC775-5CF9-4B8D-AAB0-A42A9230CBA3'

------------------------------------
select * from Animals

--Script to list animals older than 2 years and female, sorted by name.
SELECT Name, BirthDate, Sex
FROM Animals
WHERE DATEDIFF(YEAR, BirthDate, GETDATE()) > 1 AND Sex = 'Female'
ORDER BY Name;

--Sript to list the quantity of animals by sex.
SELECT Sex, COUNT(*) AS Quantity
FROM Animals
GROUP BY Sex;