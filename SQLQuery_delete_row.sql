CREATE TABLE ValidateAccount
(
	id INT PRIMARY KEY IDENTITY(1,1),
	accId INT FOREIGN KEY REFERENCES Account(account_id),
	verify_account TINYINT default 0,
	delete_account TINYINT default 0
);

CREATE TABLE Deleted_Users
(
	id  INT PRIMARY KEY IDENTITY(1,1),
	accId  INT FOREIGN KEY REFERENCES Account(account_id),
	startDate datetime,
	endDate datetime  DEFAULT CURRENT_TIMESTAMP
);