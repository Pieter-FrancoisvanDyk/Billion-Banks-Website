/* 
Filename: BankingDeatails.sql
Programmer: Pieter-Francois van Dyk
Date: 2023/05/02
Description: We will be creating the database and inserting tables into it aswell.
*/
USE Master --We'll be using the master database to create our database.
GO

--If this database already exists, it will be dropped.
DROP DATABASE IF EXISTS BankingDetails
GO

--Here we are creating our database.
CREATE DATABASE BankingDetails --Name of the database.
ON PRIMARY --Here we are creating our primary file, and specifying it's name, location, size, and the rate it's allowed to grow.
(
	NAME = 'BankingDetails_data',
	FILENAME = 'C:\Databases - C# Advanced\BankingDetails.mdf',
	SIZE = 5MB,
	FILEGROWTH = 10%
)
LOG ON --Here we are creating our log file, and specifying it's name, location, size, and the rate it's allowed to grow.
(
	NAME = 'BankingDetails_log',
	FILENAME = 'C:\Databases - C# Advanced\BankingDetails.ldf',
	SIZE = 5MB,
	FILEGROWTH = 10%
)
GO 

--We need to specify to which database the tables need to be inserted.
USE BankingDetails
GO

--Here we will be creating our tables for this database. As well as specifying the attributes for our tables, with their nullity and key type. 
CREATE TABLE Customer --This table will hold all of the customer's details.
(
	cusIDNumber VARCHAR(13) NOT NULL PRIMARY KEY, --This will serve as the ID number of the customer.
	cusName VARCHAR(40) NOT NULL, --This will serve as the name of the customer.
	cusEmail VARCHAR(30) NOT NULL, --This will serve as the email of the customer.
	cusPassword VARCHAR(10) NOT NULL, --This will serve as the password of the customer.
	cusQuestion VARCHAR(50) NOT NULL, --This will serve as the question asked of the customer when he forgets his password.
	cusAnswer VARCHAR(50) NOT NULL --This will serve as the answer to the above question.
)

CREATE TABLE Account --This table will hold all of the account's details.
(
	accNumber VARCHAR(13) NOT NULL PRIMARY KEY, --This will serve as the ID number of the account.
	accDateOC DATE NOT NULL, --This will serve as the date of creation of the account.
	accBalance INT NOT NULL, --This will serve as the balance of the account.
	cusIDNumber VARCHAR(13) NOT NULL, --This serves as the foreign key of the table.
	CONSTRAINT Fk_Link FOREIGN KEY (cusIDNumber) REFERENCES Customer(cusIDNumber)
	ON DELETE CASCADE
)

CREATE TABLE TransactionInfo --This table will hold all of the recent transactions between accounts.
(
	transID INT IDENTITY (1,1) NOT NULL PRIMARY KEY, --This will serve as the ID number of the transaction.
	sourceAcc VARCHAR(13) NOT NULL, --This shows the accounts that is sending money.
	destinationAcc VARCHAR(13) NOT NULL, --This shows the accounts that is receiving money.
	transferAmount INT NOT NULL, --This show the amount of cash that is being transfered.
	accNumber VARCHAR(13) NOT NULL, --This serves as the foreign key of the table.
	CONSTRAINT Fk_Link2 FOREIGN KEY (accNumber) REFERENCES Account(accNumber)
	ON DELETE CASCADE
)

USE BankingDetails
GO
INSERT INTO Customer --This serves as sample data.
VALUES	('6709262345678', 'Benjamin Armstrong', 'ben2gmail.com', 'Password', 'What is your favourite food?', 'Pie'),
		('7604165234678', 'John Kane', 'kane@gmail.com', 'Kane?', 'What is your favourite colour?', 'Purple'),
		('8902207863514', 'Carlos White', 'whiteStone@gmail.com', '123456', 'How much do you make a year?', 'R150000')
GO

USE BankingDetails
GO
INSERT INTO Account --This serves as sample data.
VALUES	(2234232125050, '02-24-2020', 23000, '6709262345678'),
		(2123334556567, '03-10-2002', 400000, '6709262345678'),
		(1990983736485, '04-16-2010', 14065, '7604165234678'),
		(1968685757546, '06-24-2017', 50000, '7604165234678'),
		(6535363677888, '09-30-2007', 890000, '8902207863514'),
		(6882728947433, '10-25-2001', 6700, '8902207863514')
GO

