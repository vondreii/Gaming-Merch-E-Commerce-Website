USE Merchkraft1_DB;

DROP TABLE CartItem; 
DROP TABLE PurchasedItem;
DROP TABLE CustomerAccount;
DROP TABLE MailingAddress;
DROP TABLE Customer;
DROP TABLE Product;
DROP TABLE ShoppingCart;
DROP TABLE DiscountType;
DROP TABLE PayPal;
DROP TABLE BankCard;
DROP TABLE PaymentMethod;
DROP TABLE Category;
DROP TABLE Admin; 
DROP TABLE AdminAccount;
DROP TABLE Login;


-- /----------------------The Customer Table----------------------/


CREATE TABLE Customer (
customerID		int			NOT NULL IDENTITY(1000,1),
firstName		VARCHAR(30) NOT NULL,
lastName		VARCHAR(50) NOT NULL,
dateOfBirth		date		NOT NULL,
emailAddress	VARCHAR(200)NOT NULL,
PRIMARY KEY (customerID)
);


INSERT INTO Customer VALUES('Sharlene','Von Drehnen','1996-02-02', 'SVD@outlook.com'); 
INSERT INTO Customer VALUES('Sora','Khan','1994-11-19', 'SK@outlook.com');
INSERT INTO Customer VALUES('Lettie','Von Drehnen','1980-04-30', 'LVD@outlook.com');

Select * from Customer;

-- /----------------------The MailingAddress Table----------------------/

CREATE TABLE MailingAddress (
addressID	int			NOT NULL IDENTITY(1000,1),
unit		VARCHAR(3)	NOT NULL,
street		VARCHAR(50) NOT NULL,
suburb		VARCHAR(50) NOT NULL,
city		VARCHAR(50) NOT NULL,
state		VARCHAR(3)	NOT NULL,
country		VARCHAR(50) NOT NULL,
postcode	CHAR(4)		NOT NULL,
PRIMARY KEY (addressID)
);

INSERT INTO MailingAddress VALUES('123','Henry Avenue','Birmingham Gardens', 'Newcastle', 'NSW', 'Australia', '2297');
INSERT INTO MailingAddress VALUES('123','Sasha Road','Woy Woy', 'Central Coast', 'NSW', 'Australia', '2256');
INSERT INTO MailingAddress VALUES('123','Roberts Street','Strathfield', 'Sydney', 'NSW', 'Australia', '2135');

Select * from MailingAddress;


-- /----------------------The Login Table----------------------/
CREATE TABLE Login (
loginID		int			NOT NULL IDENTITY(1000,1),
username	CHAR(8)		NOT NULL UNIQUE,
password	VARCHAR(50) NOT NULL,
PRIMARY KEY (loginID)
);

-- Customer Logins
INSERT INTO Login VALUES('user1111','password1');
INSERT INTO Login VALUES('user2222','password2');
INSERT INTO Login VALUES('user3333','password3');

-- Admin Logins
INSERT INTO Login VALUES('admin111','password1');
INSERT INTO Login VALUES('admin222','password2');

SELECT * FROM Login;

-- /----------------------The DiscountType Table----------------------/

CREATE TABLE DiscountType (
discountID		int				NOT NULL IDENTITY(1,1), 
discountCode	VARCHAR(20)		NOT NULL, 
discountAmount	decimal(5,2)	NOT NULL,
conditions		VARCHAR(500),
PRIMARY KEY (discountID)
);

INSERT INTO DiscountType VALUES('FIFTY_OFF', 50, 'Customer gets 50% off when purchasing over $40');
INSERT INTO DiscountType VALUES('FIFTY_OFFSHIPP', 50, 'Customer gets 50% off mid year');

SELECT * FROM DiscountType;


-- /----------------------The PaymentMethod Table----------------------/

CREATE TABLE PaymentMethod (
paymentID	int			NOT NULL IDENTITY(1,1), --
paymentTransaction VARCHAR(15)	NOT NULL ,
PRIMARY KEY (paymentID)
);

INSERT INTO PaymentMethod VALUES('Paypal_TRS467');
INSERT INTO PaymentMethod VALUES('Paypal_TRS334');
INSERT INTO PaymentMethod VALUES('Card_TRS245');


SELECT * FROM PaymentMethod;

-- /----------------------The PaymentMethodPaypal Table----------------------/

CREATE TABLE Paypal (
paymentID		int				NOT NULL,
paypalEmail		VARCHAR(200)	NOT NULL,
paypalPassword	VARCHAR(50)		NOT NULL,
PRIMARY KEY (paymentID),
FOREIGN KEY (paymentID) REFERENCES PaymentMethod(paymentID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO Paypal VALUES(1, 'Sharlene@outlook.com', 'paypalPassword1');
INSERT INTO Paypal VALUES(2, 'Sora@gmail.com', 'paypalPassword2');

select * FROM Paypal;

-- /----------------------The PaymentMethodBankCard Table----------------------/

CREATE TABLE BankCard (
paymentID	int			NOT NULL,
cardNumber	CHAR(16)	NOT NULL ,
CVV			VARCHAR(4)	NOT NULL, 
expiryDate	date		NOT NULL,
PRIMARY KEY (paymentID),
FOREIGN KEY (paymentID) REFERENCES PaymentMethod(paymentID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO BankCard VALUES(3, '4567345232190098', '223', '2020-02-02');

SELECT * FROM BankCard;

-- /----------------------The ShoppingCart Table----------------------/

CREATE TABLE ShoppingCart (
shoppingCartID	INT				NOT NULL IDENTITY(1000,1), --
numberOfItems	INT				NOT NULL ,
shippingCost	DECIMAL(5,2)	NOT NULL ,
totalPrice		DECIMAL(6,2)	NOT NULL , --
discountID		INT ,
paymentID		INT ,

PRIMARY KEY (shoppingCartID),
FOREIGN KEY (discountID) REFERENCES DiscountType(discountID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (paymentID) REFERENCES PaymentMethod(paymentID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO ShoppingCart VALUES(1,30,10,NULL,1); -- paying with PayPal
INSERT INTO ShoppingCart VALUES(1,30,5,NULL,2); -- paying with PayPal
INSERT INTO ShoppingCart VALUES(2,40.50,90,1,3); -- 50 off with card over $40

SELECT * FROM ShoppingCart;

-- /----------------------The CustomerAccount Table----------------------/

CREATE TABLE CustomerAccount (
customerAccountID	int		NOT NULL IDENTITY(1000,1),
joinDate			date	NOT NULL,
numOfPurchases		int		NOT NULL DEFAULT 0,
addressID			int		NOT NULL,
customerID			int		NOT NULL,
shoppingCartID		int		NOT NULL,
loginID				int		NOT NULL,
PRIMARY KEY (customerAccountID),
FOREIGN KEY (addressID) REFERENCES MailingAddress(addressID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (customerID) REFERENCES Customer(customerID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (shoppingCartID) REFERENCES ShoppingCart(shoppingCartID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (loginID) REFERENCES Login(loginID)
ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO CustomerAccount VALUES('2018-04-05', 4, 1000, 1000, 1000, 1000);
INSERT INTO CustomerAccount VALUES('2017-07-12', 1, 1001, 1001, 1001, 1001);
INSERT INTO CustomerAccount VALUES('2016-02-11', 1, 1002, 1002, 1002, 1002);

SELECT * FROM CustomerAccount;


-- /----------------------The Category Table----------------------/

CREATE TABLE Category (
categoryID			INT			NOT NULL IDENTITY(1,1), --
name				VARCHAR(50) NOT NULL ,
categoryDescription VARCHAR(200)NOT NULL ,
PRIMARY KEY (categoryID)
);

INSERT INTO Category VALUES('Clothing','Gaming Tees and clothes you cannot find elsewhere!');
INSERT INTO Category VALUES('Accessories','Necklaces that are awesome!');
INSERT INTO Category VALUES('Home Decor','Premium cups and pillow cases!');
INSERT INTO Category VALUES('Technology','Phone, IPad and Laptop cases with game designs!');

SELECT * FROM Category; 

-- /----------------------The Product Table----------------------/

CREATE TABLE Product (
productID			INT				NOT NULL IDENTITY(1,1),
productDescription	VARCHAR(300)	NOT NULL,
productImageName	VARCHAR(300)	NOT NULL,
price				DECIMAL(6,2)	NOT NULL,
audience			VARCHAR(20)		NOT NULL,
colour				VARCHAR(50)		NOT NULL,
printType			VARCHAR(200)	NOT NULL,
size				VARCHAR(15)		NOT NULL,
categoryID			INT				NOT NULL,
PRIMARY KEY (productID),
FOREIGN KEY (categoryID) REFERENCES Category(categoryID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

-- Products that are not yet in a shopping cart:


-- Clothing 
INSERT INTO Product VALUES('Witcher: Sword Hoodie', 'Images/witcher.png', 10, 'men', 'white', 'Sword print', 'XL', 1);
INSERT INTO Product VALUES('Skyrim Shoe', 'Images/SkyrimShoe.png', 30, 'kids', 'grey', 'Skyrim Shoe print', 'M', 1);
INSERT INTO Product VALUES('Fallout 3 Hoodie', 'Images/falloutHoodie.png', 25, 'women', 'grey', 'parachute print', 'XL', 1);
INSERT INTO Product VALUES('Horizon Zero Dawn: Aloy', 'Images/horizon.png', 20, 'women', 'black', 'Aloy portrait print', 'M', 1);
INSERT INTO Product VALUES('Fallout 3: Guns', 'Images/falloutGuns.png', 19, 'men', 'blue', 'guns print', 'L', 1);
INSERT INTO Product VALUES('Fallout 3 Nuke', 'Images/falloutOrange.jpg', 12, 'women', 'orange', 'Nuclear Bomb print', 'S', 1);
INSERT INTO Product VALUES('Pikachu Hoodie', 'Images/pikachuHoodie.png', 22, 'women', 'grey', 'Pikachu print', 'M', 1);
INSERT INTO Product VALUES('Morrowind: Gloves','Images/morrowindGloves.png', 15, 'men', 'red', 'Dragon print', 'XXXL', 1);
INSERT INTO Product VALUES('Skyrim: TShirt','Images/skyrimTee.png', 15, 'women', 'black', 'Blue Paarthurnax print', 'S', 1);
INSERT INTO Product VALUES('GTA Shirt','Images/gtaShirt.png', 30, 'men', 'black', 'GTA print', 'M', 1);

-- Accessories
INSERT INTO Product VALUES('Nathan Drake Collectable', 'Images/uncharted1.jpg', 10, 'unisex', 'multi', 'Nathan Drake figurine', 'L', 2);
INSERT INTO Product VALUES('GTA Bling', 'Images/gtaBling.png', 15, 'men', 'yellow', 'GTA Bling pendant', 'M', 2);
INSERT INTO Product VALUES('Galaxy Backpack', 'Images/galaxyBackpack.png', 19, 'unisex', 'blue', 'Galaxy print', 'M', 2);
INSERT INTO Product VALUES('Metal Gear mountaineer', 'Images/metalGearMountainClimbing.png', 20, 'men', 'brown', 'Camo print', 'L', 2);
INSERT INTO Product VALUES('Sims green diamond', 'Images/simsGreen.png', 20, 'women', 'green', 'diamond pendant', 'M', 2);
INSERT INTO Product VALUES('Sims 3 Diamond Necklace','Images/SimsDiamond.jpg', 15, 'women', 'green', 'sims diamond pendant', 'M', 2);

-- Home Decor
INSERT INTO Product VALUES('Pokemon Cup','Images/pokemonCup.png', 5, 'unisex', 'purple', 'picture of pokemon', 'M', 3);
INSERT INTO Product VALUES('Spiderman Cup','Images/spidermanCup.png', 10, 'unisex', 'red', 'spiderman print', 'M', 3);
INSERT INTO Product VALUES('Kewpie Cup','Images/KewpieCup.png', 15, 'unisex', 'white', 'Kewpie print', 'M', 3);
INSERT INTO Product VALUES('My Little Pony Game Cup','Images/MyLittlePony.jpg', 15, 'unisex', 'pink', 'My Little Pony print', 'M', 3);
INSERT INTO Product VALUES('Harry Potter Game stationary','Images/HarryPotterGame.png', 15, 'unisex', 'grey and black', 'Harry Potte print', 'M', 3);
INSERT INTO Product VALUES('Pikachu Pillow','Images/pikachu.png', 15, 'unisex', 'yellow', 'picture of Pikachi', 'M', 3);
INSERT INTO Product VALUES('Pokeball Pillow','Images/pokeball.png', 15, 'unisex', 'white and red', 'picture of Pokeball', 'M', 3);
INSERT INTO Product VALUES('Minecraft Pillow','Images/minecraftPillow.png', 15, 'unisex', 'grey', 'pixel print', 'M', 3);
INSERT INTO Product VALUES('Skyrim Dawnguard Mirror', 'Images/skyrimMirror.png', 10, 'women', 'black', 'flower and coffin print', 'M', 3);

-- Technology
INSERT INTO Product VALUES('GTA Character IPhone Case','Images/iPhoneCases.png', 10, 'unisex', 'grey', 'GTA Gun print', 'M', 4);
INSERT INTO Product VALUES('GTA Footballer Iphone Case','Images/gtaPhoneCase.png', 15, 'unisex', 'blue', 'GTA footballer print', 'M', 4);
INSERT INTO Product VALUES('Portal Design IPhone Case','Images/portalDesign.png', 18, 'unisex', 'blue', 'tech portal print', 'M', 4);
INSERT INTO Product VALUES('Metal Gear IPhone Case','Images/metalGearCase.png', 15, 'unisex', 'blue', 'Camo print', 'M', 4);
INSERT INTO Product VALUES('Minecraft IPhone Case','Images/minecraftIPhoneCase.jpg', 15, 'unisex', 'brown', 'Minecraft print', 'M', 4);


SELECT * FROM Product; 

-- /----------------------The AdminAccount Table----------------------/

CREATE TABLE AdminAccount (
adminAccountID	INT			NOT NULL IDENTITY(1000,1),--
joinDate		DATE		NOT NULL ,
companyRole		VARCHAR(50) NOT NULL ,
lastAccessed	DATETIME	NOT NULL ,
changeLog		DATETIME,
loginID			int			NOT NULL ,
PRIMARY KEY (adminAccountID),
FOREIGN KEY (loginID) REFERENCES Login(loginID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO AdminAccount VALUES('2018-04-10', 'Admin', '2018-04-11 12:00:00', '2018-04-11 12:00:00', 1003);
INSERT INTO AdminAccount VALUES('2018-04-10', 'IT Technician', '2018-04-11 12:00:00', '2018-04-11 12:00:00', 1004);

SELECT * FROM AdminAccount; 

-- /----------------------The Admin Table----------------------/

CREATE TABLE Admin (
adminID			INT			NOT NULL IDENTITY(1000,1),
adminAccountID  INT			NOT NULL ,
firstName		VARCHAR(30) NOT NULL ,
lastName		VARCHAR(50) NOT NULL ,
dateOfBirth		DATE		NOT NULL ,
emailAddress	VARCHAR(200)NOT NULL 
PRIMARY KEY (adminID),
FOREIGN KEY (adminAccountID) REFERENCES AdminAccount(adminAccountID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);

INSERT INTO Admin VALUES(1000, 'Nathan', 'Drake', '1972-05-05', 'nathan@drakesFortune.com');
INSERT INTO Admin VALUES(1001, 'Lara', 'Croft', '1988-11-12', 'laraCroft@tombRaider.com');

SELECT * FROM Admin; 


-- cartItem (items that are in the shopping cart **************

CREATE TABLE CartItem (
cartItemID			INT		NOT NULL IDENTITY(1,1),
productID			INT		NOT NULL,
shoppingCartID		INT		NOT NULL,	
quantity			INT		NOT NULL,
PRIMARY KEY (cartItemID),
FOREIGN KEY (productID) REFERENCES Product(productID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (shoppingCartID) REFERENCES ShoppingCart(shoppingCartID)
	ON UPDATE NO ACTION ON DELETE NO ACTION
);

-- Items in account 1000's shopping cart (Sharlene) 
INSERT INTO CartItem VALUES (1, 1000, 3);
INSERT INTO CartItem VALUES (2, 1000, 1);
INSERT INTO CartItem VALUES (7, 1000, 1);

-- Items in account 1000's shopping cart (Sora) 
INSERT INTO CartItem VALUES (10, 1001, 2);
INSERT INTO CartItem VALUES (11, 1001, 1);

-- Items in account 1000's shopping cart (Lettie) 
INSERT INTO CartItem VALUES (2, 1002, 1);
INSERT INTO CartItem VALUES (20, 1002, 1);
INSERT INTO CartItem VALUES (17, 1002, 2);
INSERT INTO CartItem VALUES (10, 1002, 2);

SELECT * FROM CartItem;

-- /----------------------The PurchasedItem Table----------------------/
CREATE TABLE PurchasedItem (
purchasedItemID		int		NOT NULL IDENTITY(1000,1),
datePurchased		date	NOT NULL,
receiptNumber		CHAR(8) NOT NULL,
customerAccountID	int		NOT NULL,
productID			int		NOT NULL,
PRIMARY KEY (purchasedItemID),
FOREIGN KEY (customerAccountID) REFERENCES CustomerAccount(customerAccountID)
	ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY (productID) REFERENCES Product(productID)
	ON UPDATE CASCADE ON DELETE NO ACTION
);
	
INSERT INTO PurchasedItem VALUES('2018-04-25', 'HRYF72H4', 1000, 1);
INSERT INTO PurchasedItem VALUES('2018-04-25', 'HRYF72H4', 1000, 2);
INSERT INTO PurchasedItem VALUES('2018-04-25', 'HRYF72H4', 1001, 5);
INSERT INTO PurchasedItem VALUES('2018-04-25', 'HRYF72H4', 1001, 6);
INSERT INTO PurchasedItem VALUES('2018-05-27', 'AD35K89T', 1001, 2);
INSERT INTO PurchasedItem VALUES('2018-04-25', 'HRYF72H4', 1002, 17);
INSERT INTO PurchasedItem VALUES('2018-05-27', 'AD35K89T', 1002, 15);

SELECT * FROM PurchasedItem;
