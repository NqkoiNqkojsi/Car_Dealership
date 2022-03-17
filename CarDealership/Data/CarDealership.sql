CREATE DATABASE cardealership;
GO
USE cardealership;
GO
CREATE TABLE carbrand 
(
  idcar_brand INT NOT NULL IDENTITY,
  brand VARCHAR(45) NOT NULL,
  model VARCHAR(45) NOT NULL,
  PRIMARY KEY (idcar_brand)
  );

CREATE TABLE car (
  id INT NOT NULL IDENTITY,
  idcar_brand INT NOT NULL,
  FOREIGN KEY (idcar_brand) REFERENCES carbrand(idcar_brand),
  price FLOAT NOT NULL,
  manufactureDate DATETIME NOT NULL,
  horsepower FLOAT NOT NULL,
  kmDriven FLOAT NULL,
  imgDir VARCHAR(45) NULL,
  engineVolume FLOAT NULL,
  additional_info VARCHAR(255) NULL,
  PRIMARY KEY (id)
  );

  CREATE TABLE customer (
  id INT NOT NULL IDENTITY,
  name VARCHAR(45) NOT NULL,
  birthDate DATE NOT NULL,
  password VARCHAR(500) NOT NULL,
  email VARCHAR(45) NOT NULL,
  phoneNum VARCHAR(45) NOT NULL,
  imgDir VARCHAR(150) NOT NULL,
  PRIMARY KEY (id));

  CREATE TABLE relaionSeller
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
    customerId INT NOT NULL,
    FOREIGN KEY (customerId) REFERENCES customer(id),
    carId INT NOT NULL,
    FOREIGN KEY (carId) REFERENCES car(id)
);

CREATE TABLE relaionFavourite
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
    customerId INT NOT NULL,
    FOREIGN KEY (customerId) REFERENCES customer(id),
    carId INT NOT NULL,
    FOREIGN KEY (carId) REFERENCES car(id)
);

CREATE TABLE picture
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
    carId INT NOT NULL,
    FOREIGN KEY (carId) REFERENCES car(id),
    picDir varbinary(MAX)
);