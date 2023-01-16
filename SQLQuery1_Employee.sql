CREATE TABLE Employee
(
	emp_id VARCHAR(10) PRIMARY KEY,
	emp_userName VARCHAR(50) UNIQUE,
	emp_firstName VARCHAR(20),
	emp_lastName VARCHAR(20),
	emp_password VARCHAR(20),
	emp_mobile VARCHAR(20),
	emp_gender VARCHAR(20),
	emp_email VARCHAR(20) UNIQUE,
	emp_address VARCHAR(50),
	emp_passport VARCHAR(20) UNIQUE,
	emp_questionId INT,
	emp_value VARCHAR(20),
	emp_retry INT DEFAULT 0,
	emp_isBlocked INT DEFAULT 0,
	emp_isDeleted INT DEFAULT 0,
	timestamp datetime DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ABC_Admin
(
	id VARCHAR(10),
	admin_userName VARCHAR(50) UNIQUE,
	admin_firstName VARCHAR(20),
	admin_lastName VARCHAR(20),
	admin_password VARCHAR(20),
	admin_mobile VARCHAR(20),
	admin_gender VARCHAR(20),
	admin_email VARCHAR(20) UNIQUE,
	admin_address VARCHAR(50),
	admin_passport VARCHAR(20) UNIQUE,
	admin_questionId INT,
	admin_value VARCHAR(20),
	admin_retry INT DEFAULT 0,
	admin_isBlocked INT DEFAULT 0,
	admin_isDeleted INT DEFAULT 0,
	timestamp datetime DEFAULT CURRENT_TIMESTAMP
);