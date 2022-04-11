USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	last_search datetime2(0) NULL,
	is_subscribed bit NOT NULL DEFAULT 0,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

CREATE TABLE author (
	author_id int IDENTITY(1,1) NOT NULL,
	first_name varchar (32) NOT NULL,
	last_name varchar (32) NOT NULL,
	CONSTRAINT PK_author_id PRIMARY KEY (author_id)
	)

CREATE TABLE genre (
	genre_id tinyint IDENTITY (1,1),
	genre_name varchar (50),
	CONSTRAINT PK_genre_id PRIMARY KEY (genre_id)
	)

CREATE TABLE books (
	book_id int IDENTITY(1,1) NOT NULL,
	title varchar(100) NOT NULL,
	author_id int NOT NULL,
	isbn bigint NOT NULL,
	genre_id tinyint NOT NULL,
	added datetime2(0) NOT NULL,
	CONSTRAINT PK_book_id PRIMARY KEY (book_id),
	CONSTRAINT FK_author_id FOREIGN KEY (author_id) REFERENCES [author] (author_id),
	CONSTRAINT FK_genre_id FOREIGN KEY (genre_id) REFERENCES [genre] (genre_id),
)

CREATE TABLE user_book (
	user_id int,
	book_id int,
	CONSTRAINT PK_user_book PRIMARY KEY (user_id, book_id),
	CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES [users] (user_id),
	CONSTRAINT FK_book_id FOREIGN KEY (book_id) REFERENCES [books] (book_id)
	)

GO