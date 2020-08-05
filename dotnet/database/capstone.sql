--Begin tran
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
	--org_name varchar(50) NOT NULL,
	start_time datetime NOT NULL,
	end_time datetime NOT NULL
	CONSTRAINT PK_auction_id PRIMARY KEY (auction_id)
)

CREATE TABLE item (
	item_id int IDENTITY(1, 1) NOT NULL,
	auction_id int NOT NULL,
	title varchar(50) NOT NULL,
	subtitle varchar(240) NOT NULL,
	pic varchar(200) NOT NULL,
	starting_bid decimal NOT NULL,
	--is_sold bit
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
Create Table bid (
	bid_id int IDENTITY Not NULL,
	item_id int NOT NULL,
	user_id int NOT NULL,
	amount decimal NOT NUll,
	time_placed datetime NOT NULL,
	CONSTRAINT pk_bid PRIMARY KEY (bid_id),
	CONSTRAINT fk_bid_item FOREIGN KEY (item_id) References item(item_id),
	CONSTRAINT fk_bid_user FOREIGN KEY (user_id) References users(user_id)
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

--Dummy Data--

INSERT INTO auction (start_time, end_time) VALUES ('2020-08-15T09:00:00', '2020-08-16T09:00:00');
INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Josh''s Waterbottle', 'This waterbottle was drunk from by the one and only Josh Tucholski.', 
	'https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80', 
	'150');
INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Max''s Waterbottle', 'This waterbottle was drunk from by the one and only Max Michael.', 
	'https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80', 
	'150');
INSERT INTO category (name) VALUES ('Celebrity');
INSERT INTO category (name) VALUES ('Sports Memorabilia');
INSERT INTO category (name) VALUES ('Musical Instrument');
INSERT INTO category (name) VALUES ('Clothes');
INSERT INTO category (name) VALUES ('Horcrux');
INSERT INTO category (name) VALUES ('Celebrity');
INSERT INTO item_category (item_id, category_id) VALUES (1, 1);
INSERT INTO item_category (item_id, category_id) VALUES (1, 2);
INSERT INTO item_category (item_id, category_id) VALUES (1, 5);
INSERT INTO item_category (item_id, category_id) VALUES (2, 1);
INSERT INTO item_category (item_id, category_id) VALUES (2, 2);
INSERT INTO item_category (item_id, category_id) VALUES (2, 5);

INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 1, 5.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 2, 10.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 1, 15.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (2, 2, 100.00, '2020-08-15T09:00:00' )

--Commit Tran
Select * From item 
	Join auction on item.auction_id = auction.auction_id
	Join item_category as ic on ic.item_id = item.item_id
	Join category on category.category_id = ic.category_id

	Select * from category

	Select * from bid join item on item.item_id = bid.item_id where item.item_id = 1
	select * from bid


INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Josh''s Waterbottle', 'This waterbottle was drunk from by the one and only Josh Tucholski.', 
	'https://images.unsplash.com/photo-1523362628745-0c100150b504?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1493&q=80', 
	150);


INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Clyde''s Special Catnip', 'A secret blend of herbs, spices, and proteins that every cat will love.', 
	'https://i.insider.com/5b2d07195e48eca9028b458d?width=750&format=jpeg&auto=webp', 
	10);


INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Hotel Stay at the beach for 2', 'One night with a lovely ocean view', 
	'https://www.simplemost.com/wp-content/uploads/2016/08/beach-vacation-e1470663653924.jpeg',
	150);


INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Baseball signed by Omar Vizquel', 'Signed by the world''s greatest shortstop', 
	'https://i1.wp.com/www.cooperstowncred.com/wp-content/uploads/2018/12/OMAR-VIZQUEL-CHUCK-CROW.png?fit=922%2C644&ssl=1',
	250);


INSERT INTO item (auction_id, title, subtitle, pic, starting_bid) 
	VALUES (1, 'Fruit Basket', 'You may not eat it all, but it looks nice', 
	'https://www.bachatagifts.com/124-thickbox_default/fruit-basket-big-delivered-in-dominican-republic.jpg',
	10);


INSERT INTO item_category (item_id, category_id) VALUES (1, 1);
INSERT INTO item_category (item_id, category_id) VALUES (3, 9);
INSERT INTO item_category (item_id, category_id) VALUES (3, 1);

INSERT INTO item_category (item_id, category_id) VALUES (4, 7);
INSERT INTO item_category (item_id, category_id) VALUES (4, 10);

INSERT INTO item_category (item_id, category_id) VALUES (5, 1);

INSERT INTO item_category (item_id, category_id) VALUES (5, 2);
INSERT INTO item_category (item_id, category_id) VALUES (6, 8);

INSERT INTO item_category (item_id, category_id) VALUES (@item5, @category7);
INSERT INTO item_category (item_id, category_id) VALUES (@item5, @category4);

delete from item_category where item_id = 1
select * from users

select * from bid

INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 1, 150.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 2, 155.00, '2020-08-15T09:01:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 1, 160.00, '2020-08-15T09:02:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (1, 2, 170.00, '2020-08-15T09:03:00' )


INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (3, 1, 10.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (3, 2, 11.00, '2020-08-15T09:01:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (3, 1, 15.00, '2020-08-15T09:02:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (3, 2, 20.00, '2020-08-15T09:03:00' )


INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (4, 1, 150.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (4, 2, 160.00, '2020-08-15T09:01:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (4, 1, 161.00, '2020-08-15T09:02:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (4, 2, 171.00, '2020-08-15T09:03:00' )


INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (5, 1, 250.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (5, 2, 255.00, '2020-08-15T09:01:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (5, 1, 265.00, '2020-08-15T09:02:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (5, 2, 270.00, '2020-08-15T09:03:00' )


INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (6, 1, 10.00, '2020-08-15T09:00:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (6, 2, 11.00, '2020-08-15T09:01:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (6, 1, 21.00, '2020-08-15T09:02:00' )
INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (6, 2, 26.00, '2020-08-15T09:03:00' )

	
	
	
	
	
