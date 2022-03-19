CREATE DATABASE cardealership
GO
USE cardealership
GO
CREATE TABLE [CarBrand]
(
    [id] INT PRIMARY KEY NOT NULL IDENTITY,
    [brand] VARCHAR(45) NOT NULL,
    [model] VARCHAR(45) NOT NULL
);

CREATE TABLE [Car]
(
    [id] INT PRIMARY KEY NOT NULL IDENTITY,
    [carBrandId] INT NOT NULL,
    CONSTRAINT [fk_car_car_brand] FOREIGN KEY ([carBrandId]) REFERENCES [CarBrand]([id]),
    [price] FLOAT NOT NULL,
    [manufDate] VARCHAR(45) NOT NULL,
    [horsePower] FLOAT NOT NULL,
    [kmDriven] FLOAT NOT NULL,
    [engineVolume] FLOAT NOT NULL,
    [info] VARCHAR(1000)
);

CREATE TABLE [Customer]
(
    [id] INT PRIMARY KEY NOT NULL IDENTITY,
    [name] VARCHAR(45) NOT NULL,
    [birthDate] DATETIME NOT NULL,
    [Password] VARCHAR(500) NOT NULL,
    [email] VARCHAR(45) NOT NULL,
    [phoneNum] VARCHAR(45) NOT NULL
);

CREATE TABLE [RelationSeller]
(
    [id] INT PRIMARY KEY NOT NULL IDENTITY,
    [customerId] INT NOT NULL,
    CONSTRAINT [fk_customer_relation] FOREIGN KEY ([customerId]) REFERENCES [Customer]([id]),
    [carId] INT NOT NULL,
    CONSTRAINT [fk_car_relation] FOREIGN KEY ([carId]) REFERENCES [Car]([id])
);

CREATE TABLE [Picture]
(
    [id] INT PRIMARY KEY IDENTITY NOT NULL,
    [carId] INT NOT NULL,
    CONSTRAINT [fk_car_picture] FOREIGN KEY ([carId]) REFERENCES [Car]([Id]),
    [picture] VARBINARY(MAX)
);