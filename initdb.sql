USE [DI1P2-2027-TP_Bibliotheque];
CREATE TABLE [status]
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	name VARCHAR(255) NOT NULL,
	maxbook INT NOT NULL,
);

CREATE TABLE [user]
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(255) NOT NULL,
	firstname VARCHAR(255) NOT NULL,
	[password] VARCHAR(1024) NOT NULL,
	[status] INT FOREIGN KEY REFERENCES [status](id),
);

CREATE TABLE [author]
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(255) NOT NULL,
	firstname VARCHAR(255) NOT NULL,
	[description] TEXT NOT NULL,
);

CREATE TABLE [book]
(
	isbn INT PRIMARY KEY NOT NULL,
	title VARCHAR(255) NOT NULL,
	publishdate VARCHAR(255) NOT NULL,
	author INT FOREIGN KEY REFERENCES [author](id),
);

CREATE TABLE [borrow]
(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[user] INT FOREIGN KEY REFERENCES [user](id),
	book INT FOREIGN KEY REFERENCES book(isbn),
	[date] DATETIME NOT NULL,
);