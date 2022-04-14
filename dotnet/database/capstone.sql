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
INSERT INTO author (first_name, last_name) VALUES ('Jane','Austen');
INSERT INTO author (first_name, last_name) VALUES ('Yaa', 'Gyasi');
INSERT INTO author (first_name, last_name) VALUES ('J.K', 'Rowling');
INSERT INTO author (first_name, last_name) VALUES ('F.Scott','Fitzgerald');
INSERT INTO author (first_name, last_name) VALUES ('Kristin' ,'Cashore');
INSERT INTO author (first_name, last_name) VALUES ('Madaline', 'Miller');

CREATE TABLE genre (
	genre_id tinyint IDENTITY (1,1),
	genre_name varchar (50),
	CONSTRAINT PK_genre_id PRIMARY KEY (genre_id)
	)
INSERT INTO genre (genre_name) VALUES ('Fantasy');
INSERT INTO genre (genre_name) VALUES ('Comedy');
INSERT INTO genre (genre_name) VALUES ('Historical Fiction');
INSERT INTO genre (genre_name) VALUES ('Romance');
INSERT INTO genre (genre_name) VALUES ('Thriller');
INSERT INTO genre (genre_name) VALUES ('Non-Fiction');
INSERT INTO genre (genre_name) VALUES ('Mystery');
INSERT INTO genre (genre_name) VALUES ('Horror');
INSERT INTO genre (genre_name) VALUES ('Action');
INSERT INTO genre (genre_name) VALUES ('Adventure');

CREATE TABLE books (
	book_id int IDENTITY(1,1) NOT NULL,
	title varchar(100) NOT NULL,
	author_id int NOT NULL,
	isbn nvarchar(15) NOT NULL,
	genre_id tinyint NULL,
	added datetime NOT NULL,
	keyword nvarchar(MAX) NOT NULL,
	[character] nvarchar(MAX) NULL,
	[location] nvarchar(MAX) NULL,
	CONSTRAINT PK_book_id PRIMARY KEY (book_id),
	CONSTRAINT FK_author_id FOREIGN KEY (author_id) REFERENCES [author] (author_id),
	CONSTRAINT FK_genre_id FOREIGN KEY (genre_id) REFERENCES [genre] (genre_id),
)

INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Pride and Prejudice', '1', '0143105426', '3', '2022-04-11 12:40:50','','','');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Transcendent Kingdom', '2', '0525658181', '3','2022-04-11 12:40:59','','','');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('The Song of Achilles','6','0062060627','4','2022-04-11 12:41:10','','','');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Graceling','5','0547258305','1','2022-04-11 12:41:20','','','');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location])VALUES ('Bitterblue','5','0142426016','1','2022-04-11 12:41:30', 'Power, Identity', 'Queen Bitterblue, Thiel, Sapphire, Teddy, Tilda, Bren, Madlen, Rood', 'Graceling Realm, Monsea');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Fire','5','0803734611','1','2022-04-11 12:41:30', 'Power, Identity', 'Lady Fire, Prince Brigan, Archer, Brocker, Cansrel, Nash, Hanna, Clara, Garan, Nax, Queen Roen, Leck', 'Graceling Realm, King City');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Chamber of Secrets','3','0439064872','1','2022-04-11 12:41:12','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Prisoner of Azkaban','3','0747542155','1','2022-04-11 12:41:20','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Sorcerers Stone','3','0590353403','1','2022-04-11 12:41:20','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Deathly Hallows','3','0545010225','1','2022-04-11 12:41:20','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Goblet of Fire','3','0439139600','1','2022-04-11 12:41:29','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Half-Blood Prince','3','0747581088','1','2022-04-11 12:41:31','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('Harry Potter and the Order of the Phoenix','3','0747551006','1','2022-04-11 12:41:32','Magic, Wizards, Witches', 'Harry Potter, Hermione Granger, Ron Weasley, Severus Snape, Albus Dumbledore, Rubeus Hagrid, Drako Malfoy, Tom Riddle, Voldemort', 'Hogwarts');
INSERT INTO books (title, author_id, isbn, genre_id, added, keyword, [character], [location]) VALUES ('The Great Gatsby','4','1982146702','3','2022-04-11 12:41:40', 'Wealth, Class, Love, Romance, Idealism', 'Nick Carraway, Jay Gatsby, Daisy Buchanan, Thomas Buchanan, Jordan Baker, George B. Wilson, Myrtle Wilson', 'New York City');

CREATE TABLE user_book (
	user_id int,
	book_id int,
	CONSTRAINT PK_user_book PRIMARY KEY (user_id, book_id),
	CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES [users] (user_id),
	CONSTRAINT FK_book_id FOREIGN KEY (book_id) REFERENCES [books] (book_id)
	)

GO