CREATE Table Account
(
	account_id int PRIMARY KEY IDENTITY(1,1),
	account_number VARCHAR(50),
	account_type VARCHAR(50),
	user_name VARCHAR(50) UNIQUE,
	email VARCHAR(50) UNIQUE,
	mobile VARCHAR(15),
	address VARCHAR(MAX),
	passport VARCHAR(10),
	has_job int,
	joint_account int,
	joint_account_username_1 VARCHAR(50),
	joint_account_username_2 VARCHAR(50),
	joint_account_username_3 VARCHAR(50),
	question_id int FOREIGN KEY REFERENCES security_question(question_id),
	user_value VARCHAR(50),
	user_balance int,
	user_password VARCHAR(50),
	user_type VARCHAR(10),
	gender VARCHAR(10),
	timestamp DATETIME default CURRENT_TIMESTAMP
);