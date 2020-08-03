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
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE auction (
	auction_id int IDENTITY(1, 1) NOT NULL,
	org_name varchar(50) NOT NULL,
	start_time datetime NOT NULL,
	end_time datetime NOT NULL
	CONSTRAINT PK_auction_id PRIMARY KEY (auction_id)
)

CREATE TABLE item (
	item_id int IDENTITY(1, 1) NOT NULL,
	auction_id int NOT NULL,
	title varchar(50) NOT NULL,
	subtitle varchar(240) NOT NULL,
	starting_bid decimal NOT NULL,
	category_id varchar(50) NOT NULL,
	is_sold bit
	CONSTRAINT PK_item PRIMARY KEY (item_id),
	CONSTRAINT FK_item_auction FOREIGN KEY (auction_id) REFERENCES auction(auction_id)
)

CREATE TABLE category (
	category_id int IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	name varchar(100) NOT NULL,
)

CREATE TABLE item_category (
	item_id int NOT NULL,
	category_id int NOT NULL,
	CONSTRAINT pk_item_category PRIMARY KEY (item_id, category_id),
	CONSTRAINT fk_item_category_item FOREIGN KEY (item_id) REFERENCES item(item_id),
	CONSTRAINT fk_item_category_category FOREIGN KEY (category_id) REFERENCES category(category_id)
)

--CREATE TABLE auction_item (
--	auction_id int NOT NULL,
--	item_id int NOT NULL
--	CONSTRAINT PK_auction_item PRIMARY KEY (auction_id, item_id),
--	CONSTRAINT FK_auction_item_auction FOREIGN KEY (auction_id) REFERENCES auction(auction_id),
--	CONSTRAINT FK_auction_item_item FOREIGN KEY (item_id) REFERENCES item(item_id)

--)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO