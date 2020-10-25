CREATE DATABASE MySkincare_DB
GO

USE MySkincare_DB

CREATE TABLE Users (
	UID INT IDENTITY (1000, 1) PRIMARY KEY,
	FName VARCHAR (50),
	LName VARCHAR (50),
	PhoneNum VARCHAR (15),
	StreetAddress VARCHAR (200),
	City CHAR (20),
	State CHAR (2),
	ZIP VARCHAR (12)
);
CREATE TABLE Logins (
	Email VARCHAR (200),
	Password VARCHAR (100),
	UID INT NOT NULL REFERENCES Users(UID)
);


