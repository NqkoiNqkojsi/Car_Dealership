CREATE DATABASE cardealership;

USE cardealership;

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
  engineLitres FLOAT NULL,
  additional_info VARCHAR(255) NULL,
  PRIMARY KEY (id)
  );