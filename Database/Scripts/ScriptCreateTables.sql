CREATE DATABASE STGenetics;

USE STGenetics

CREATE TABLE Animals (
   AnimalId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   [Name] NVARCHAR(50),
   Breed NVARCHAR(200),
   BirthDate Date,
   Sex NVARCHAR(50),
   Price float,
   [Status] NVARCHAR(50),
   CreateDate Date,
   DeleteDate Date
);

CREATE TABLE Orders (
   OrderId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   CreateDate Date,
   DeleteDate Date,
   TotalPrice float,
   TotalAnimals Int,
   Error nvarchar(max)
);

CREATE TABLE OrdersAnimals (
   OrderAnimalId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   OrderId UNIQUEIDENTIFIER NOT NULL,
   AnimalId UNIQUEIDENTIFIER NOT NULL,
   PricePerUnit float,
   AnimalsAmount int,
   TotalPerItem float,   
   CreateDate Date,
   DeleteDate Date,

);