use master;
go

drop database [Library];
go

create database [Library];
go

use [Library];
go

create table Book(
	BookID		int identity(1,1) primary key,
	Title		varchar(50),
	Author		varchar(50),
	Quantity	tinyint,
);

create table [User](
	UserID		int identity(1,1) primary key,
	FullName	nvarchar(50),
	Email		varchar(50) unique,
	Password	varchar(26),
	isAdmin		bit,
);

create table BorrowRecords(
	UserID		int,
	BookID		int,
	BorrowDate	date,
	DueDate		date,

	primary key (UserID, BookID),
	foreign key (UserID) references [User](UserID),
	foreign key (BookID) references Book(BookID)
);

create table ReservationRecords(
	UserID			int,
	BookID			int,
	ReservationDate date,

	primary key (UserID, BookID),
	foreign key (UserID) references [User](UserID),
	foreign key (BookID) references Book(BookID)
);

create table Comments(
	UserID			int,
	BookID			int,
	Comments		varchar(100),
	Rating			tinyint check (Rating >= 0 and Rating <= 5),

	primary key (UserID, BookID),
	foreign key (UserID) references [User](UserID),
	foreign key (BookID) references Book(BookID)
);

INSERT INTO Book (Title, Author, Quantity) VALUES
('The House on Mango Street', 'Sandra Cisneros', 10),
('The Picture of Dorian Gray', 'Oscar Wilde', 8),
('Never Let Me Go', 'Kazuo Ishiguro', 12),
('The Road', 'Cormac McCarthy', 7),
('March: Book One', 'John Lewis and Andrew Aydin', 5),
('The Hobbit', 'J.R.R. Tolkien', 15),
('Pride and Prejudice', 'Jane Austen', 20),
('A Tale of Two Cities', 'Charles Dickens', 10),
('Crime and Punishment', 'Fyodor Dostoyevsky', 6),
('We Should All Be Feminists', 'Chimamanda Ngozi Adichie', 9),
('Persepolis', 'Marjane Satrapi', 4),
('The Grapes of Wrath', 'John Steinbeck', 11),
('Hamlet', 'William Shakespeare', 14),
('Rebecca', 'Daphne du Maurier', 8),
('1984', 'George Orwell', 13),
('On the Road', 'Jack Kerouac', 7),
('Beloved', 'Toni Morrison', 5),
('The Secret Life of Bees', 'Sue Monk Kidd', 9),
('This Side of Paradise', 'F. Scott Fitzgerald', 6),
('Station Eleven', 'Emily St. John Mandel', 10);

INSERT INTO [User](FullName, Email, Password, isAdmin) VALUES
('John Doe', 'jdoe@example.com', 'password123', 0),
('Alice Smith', 'asmith@example.com', 'alice2024', 0),
('Bao Nguyen', 'bnguyen@example.com', 'bao_secure', 0),
('Maria Johnson', 'mjohnson@example.com', 'maria_pass', 0),
('Kevin Lee', 'klee@example.com', 'kevin_lee1', 0),
('Sophia Rodriguez', 'srodriguez@example.com', 'sophia_789', 0),
('John Doe', 'abc', '123', 0),
('lmao', 'admin@email.com', 'a', 1);

 