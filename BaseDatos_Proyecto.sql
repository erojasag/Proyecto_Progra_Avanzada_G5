CREATE DATABASE Proyecto_Progra_Avanzada_G5;


USE Proyecto_Progra_Avanzada_G5;
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ROLES TABLE----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Roles(
	Id int IDENTITY(1,1),
	Rol_Name varchar(max),
CONSTRAINT PK_Role_ID PRIMARY KEY(Id)
);

INSERT INTO Roles(Rol_Name) VALUES('Administrator');

INSERT INTO Roles(Rol_Name) VALUES('Cashier');

INSERT INTO Roles(Rol_Name) VALUES('Customer');

SELECT * FROM ROLES;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ROLES TABLE----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------USER TABLE-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Users(
	Id int IDENTITY(1,1),
	Username varchar(50) NOT NULL UNIQUE,
	Password varchar(50) NOT NULL,
	User_Role int NOT NULL,
	Photo varchar(max),
CONSTRAINT PK_User_ID PRIMARY KEY(Id),
CONSTRAINT FK_Role_ID FOREIGN KEY (User_Role) REFERENCES Roles(Id)
);

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('erojasag', 'Cliente123', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('ximrojas', 'Corah2022*', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('ironTony', 'mundo123', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('ikerCasillas', 'realmadrid', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('comeGalletas', 'justoOrozco', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('blacky', 'tintin888', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('JesusCaja', 'cajero123', 2,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('MariaJCaja', 'mariacajera', 2,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('BezosJeff', 'Amazon23', 3,'no photo');

INSERT INTO Users(Username, Password, User_Role, Photo) VALUES('EmaAdmin', 'SuperAdmin2022', 1,'no photo');

SELECT * FROM Users u 


UPDATE Users SET Photo=('https://upload.wikimedia.org/wikipedia/commons/5/5f/Alberto_conversi_profile_pic.jpg') WHERE Users.Id = 10;
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------USER TABLE-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PERSON TABLE---------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Person(
    Id INT IDENTITY(1,1) NOT NULL,
    Name varchar(50) NOT NULL,
    First_last_name varchar(50) NOT NULL,
    Second_last_name varchar(50) NOT NULL,
    Identification varchar(9) NOT NULL UNIQUE,
    Phone varchar(max) NOT NULL,
    Email varchar(50) NOT NULL UNIQUE,
    Registration_date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Modification_date DATETIME2 NULL,
    Birth_date DATE NOT NULL,
    Address varchar(50) NOT NULL,
    Email_Verification bit,
    Activation_Code uniqueidentifier,
    User_Id int,
CONSTRAINT PK_Person_Id  PRIMARY KEY (Id),
CONSTRAINT FK_User_Id FOREIGN KEY (User_Id) REFERENCES Users(Id)
);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Emanuel', 'Rojas', 'Cliente', '117250521', '88667456', 'eroaguero01@gmail.com', '01-11-1998', 'Alajuela',1);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Ximena', 'Rojas', 'Aguero', '117250522', '88667457', 'ximenara@gmail.com', '01-11-1998', 'San Jose',2);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Anthony', 'Arce', 'Rodriguez', '117250523', '88667458', 'ironTony@protonmail.com', '01-11-1998', 'Limon',3);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Iker', 'Casillas', 'Morales', '117250524', '88667459', 'ikerCasillas@hotmail.com', '01-11-1998', 'Alajuela',4);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Justo', 'Orozco', 'Orozco', '117250525', '88667460', 'justoOrozcoPresidente@gmail.com', '01-11-1998', 'Heredia',5);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Joel', 'Martin', 'Segura', '117250526', '88667461', 'JoelMartin@gmail.com', '01-11-1998', 'Alajuela',6);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Jesus', 'Morales', 'Segura', '117250527', '88667462', 'jesusMorales@shoeCorp.com', '01-11-1998', 'Alajuela',7);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Maria Jesus', 'Castillo', 'Torres', '117250528', '88667463', 'mariaJesus@shoeCorp.com', '01-11-1998', 'Heredia',8);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Jeff', 'Bezos', 'Bezos', '117250529', '88667464', 'jeffBezos@amazon.com', '01-11-1998', 'Guanacaste',9);

INSERT INTO Person(Name, First_last_name, Second_last_name, Identification, Phone, Email, Birth_date, Address, User_Id)
VALUES('Emanuel', 'Rojas', 'Aguero', '117250530', '88667465', 'emanuelRojas@shoeCorp.com', '01-11-1998', 'Alajuela', 10);

CREATE OR ALTER PROCEDURE view_users
AS 
BEGIN 
	SELECT * FROM Person p, Users u
	WHERE u.Id = p.User_Id;
END

EXEC view_users

SELECT * FROM Person p
where p.User_Id = 4

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PERSON TABLE---------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------BRAND TABLE----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Brand(
	Id INT IDENTITY(1,1),
	Name varchar(50) NOT NULL,
	Photo varchar(max),
CONSTRAINT PK_Brand_Id PRIMARY KEY (Id)
);

INSERT INTO Brand(Name, Photo)
VALUES('Nike', 'https://w7.pngwing.com/pngs/224/696/png-transparent-nike-logo-movement-brands-black.png');

INSERT INTO Brand(Name, Photo)
VALUES('Adidas', 'https://w7.pngwing.com/pngs/488/478/png-transparent-adidas-originals-t-shirt-logo-brand-adidas-angle-text-retail.png');

INSERT INTO Brand(Name, Photo)
VALUES('New Balance', 'https://e7.pngegg.com/pngimages/590/244/png-clipart-new-balance-logo-shoe-sneakers-newbalance-cdr-text.png');

INSERT INTO Brand(Name, Photo)
VALUES('Project Rock', 'https://mpng.subpng.com/20190509/wgz/kisspng-under-armour-project-rock-collection-t-shirt-under-cryptobulls-cryptocurrency-blockchain-educatio-5cd4a8247e4f62.5253223915574405485174.jpg');

INSERT INTO Brand(Name, Photo)
VALUES('Puma', 'https://e7.pngegg.com/pngimages/586/636/png-clipart-puma-adidas-logo-clothing-brand-adidas-mammal-cat-like-mammal-thumbnail.png');

INSERT INTO Brand(Name, Photo)
VALUES('Sperry', 'https://img1.pnghut.com/16/9/12/jBri0YMXdw/text-logo-saucony-decal-shoe.jpg');

INSERT INTO Brand(Name, Photo)
VALUES('Yeezy', 'https://w0.peakpx.com/wallpaper/311/742/HD-wallpaper-yeezy-adidas-logo-originals.jpg');


SELECT * FROM Brand;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------BRAND TABLE----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Product(
    Id INT NOT NULL,
    Brand_Id INT,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Model varchar(50) not null,
    Color Varchar(50) not null,
    shoeSize varchar(2) not null,
    Photo varchar(max),
    Registration_date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Modification_date DATETIME2 NULL,
    CONSTRAINT PK_Product_Id PRIMARY KEY (id),
    CONSTRAINT FK_Brand_Id FOREIGN KEY (Brand_Id) REFERENCES Brand(Id),
); 

SELECT * FROM Product 
----------------------------------INSERT NIKE------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0001,1,119000,3,'Dunk Low','Red',40, 'https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/f2da5e21-59d9-41e9-bb39-76e2e57b25db/calzado-dunk-low-disrupt-2-zz6jpt.png');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0002,1,119000,4,'Dunk Low','PRM2',38, 'https://productos.cimocr.xyz/dd8338-001_2.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0003,1,119000,2,'Dunk Low','Lime',42, 'https://limitedresell.com/3672-full_default/nike-dunk-low-lime-ice.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0004,1,119000,1,'Dunk Low','Sunrise',39, 'https://sneakerbardetroit.com/wp-content/uploads/2022/06/Nike-Dunk-Low-Disrupt-2-DX2676-100-Release-Date-4-1068x762.jpeg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0005,1,119000,6,'Dunk Low','EMB',37, 'https://sneakernews.com/wp-content/uploads/2021/07/nike-dunk-low-nba-75th-anniversary-knicks-DD3363-002-5.jpg');

----------------------------------INSERT Adidas------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0006,2,89000,8,'Forum Mid','Blue',40, 'https://productos.cimocr.xyz/fy4976_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0007,2,89000,2,'Stan Smith','white',36, 'https://productos.cimocr.xyz/gw0487_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0008,2,89000,4,'Stan Smith','white',39, 'https://productos.cimocr.xyz/gw0487_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0009,2,89000,3,'Forum Mid','Blue',42, 'https://productos.cimocr.xyz/fy4976_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0010,2,89000,1,'Forum Mid','Blue',41, 'https://productos.cimocr.xyz/fy4976_1.jpg');

----------------------------------INSERT New Balance-------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0011,3,89000,10,'574','Cream',38, 'https://productos.cimocr.xyz/ml574wn2-d_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0012,3,89000,7,'574','Red',42, 'https://productos.cimocr.xyz/ml574evm-d_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0013,3,89000,9,'574','Blue',39, 'https://productos.cimocr.xyz/ml574evn-d_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0014,3,89000,4,'574','White',36, 'https://productos.cimocr.xyz/ml574evw-d_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0015,3,89000,3,'574','Black',41, 'https://productos.cimocr.xyz/ml574dgo-d_1.jpg');

----------------------------------INSERT Project Rock-------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0016,4,165000,6,'Velociti Wind','Blue',41, '');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0017,4,165000,3,'Phantom 2 IntelliKnit','Black',39, '');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0018,4,165000,5,'UA Charged Pursuit 3','Black',43, '');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0019,4,165000,9,'Curry Flow 9','Blue',38, '');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0020,4,165000,16,'UA HOVR™ Machina 3','Beige',36, '');

----------------------------------INSERT Puma------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0021,5,45000,2,'SUEDE CLASSIC XXI','Beige',38, 'https://productos.cimocr.xyz/374915-07_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0022,5,45000,8,'SUEDE CLASSIC XXI','Beige',42, 'https://productos.cimocr.xyz/374915-07_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0023,5,45000,6,'SUEDE CLASSIC XXI','Orange',39, 'https://productos.cimocr.xyz/374915%2002_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0024,5,45000,7,'SUEDE CLASSIC XXI','Blue',41, 'https://productos.cimocr.xyz/374915%2004_1.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0025,5,45000,11,'SUEDE CLASSIC XXI','Black',39, 'https://productos.cimocr.xyz/374915%2001_1.jpg');

----------------------------------INSERT Sperry------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0026,6,45000,5,'Authentic Original Boat','Brown',39, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0027,6,45000,2,'Authentic Original Boat','White',42, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0027,6,45000,8,'Authentic Original Boat','Blue',38, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0028,6,45000,15,'Authentic Original Boat','Grey',43, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0029,6,45000,2,'Authentic Original Boat','Red',41, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');

----------------------------------INSERT Yeezy------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0030,7,119000,14,'Boost 350 V2','Black',37, 'https://3app.kicksonfire.com/kofapp/upload/events_master_images/iphone_adidas-yeezy-boost-350-v2-red.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0031,7,119000,3,'Boost 350 V2','White',39, 'https://cdn.shopify.com/s/files/1/0496/4325/8009/products/baskets-yeezy-boost-350-v2-sand-taupe-adidas-kikikickz-868725_800x.progressive.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0032,7,119000,1,'Boost 350 V2','Beige',42, 'https://www.cdiscount.com/pdt2/9/7/8/1/300x300/mp57405978/rw/baskets-decontractees-pour-hommes-et-femmes.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0033,7,119000,12,'Boost 350 V2','Black',43, 'https://2app.kicksonfire.com/kofapp/upload/events_master_images/ipad_adidas-yeezy-boost-350-v2-black-white.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0034,7,119000,8,'Boost 350 V2','Grey',38, 'https://cdn-images.farfetch-contents.com/15/79/86/13/15798613_28931498_600.jpg');


SELECT * FROM Product p
INNER JOIN Brand b 
ON p.Brand_Id = b.Id;
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------




-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE ShoppingCart(
    Id INT NOT NULL IDENTITY(1,1),
	Quantity INT NOT NULL,
	User_Id INT NOT NULL,
	Product_Id INT NOT NULL,
	CONSTRAINT PK_ShoppingCart_Id PRIMARY KEY (Id),
    CONSTRAINT FK_shoppingCart_User_id FOREIGN KEY (User_Id) REFERENCES Users(Id),
    CONSTRAINT FK_shoppingCart_Product_id FOREIGN KEY (product_id) REFERENCES Product(Id)
);



SELECT * FROM ShoppingCart sc ;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ORDERS TABLE---------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Orders(
    Id INT NOT NULL IDENTITY(1,1),
    Order_User_Id INT NOT NULL,
    Order_date TIMESTAMP NOT NULL,
    Order_total DECIMAL(10,2) NOT NULL
    CONSTRAINT PK_Order_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Order_User_Id FOREIGN KEY (Order_User_Id) REFERENCES Users(Id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ORDERS TABLE---------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT_BY_ORDER TABLE-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Product_By_Order(
	Id INT NOT NULL IDENTITY(1,1),
	Product_Id INT NOT NULL,
	Order_Id INT NOT NULL
	CONSTRAINT PK_Product_By_Order_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Product_Id FOREIGN KEY (Product_Id) REFERENCES Product(Id),
	CONSTRAINT FK_Order_Id FOREIGN KEY (Order_Id) REFERENCES Orders(Id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT_BY_ORDER TABLE-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHIPMENTS TABLE------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Shipments(
    shipment_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    shipment_order_id INT NOT NULL,
    shipment_date TIMESTAMP NOT NULL,
    shipment_status varchar(50) NOT NULL,
    shipment_address varchar(50) NOT NULL,
    shipment_city varchar(50) NOT NULL,
    shipment_state varchar(50) NOT NULL,
    shipment_zip_code varchar(50) NOT NULL,
    shipment_country varchar(50) NOT NULL,
    shipment_phone varchar(50) NOT NULL,
    shipment_email varchar(50) NOT NULL,
    shipment_customer_id INT NOT NULL,
    CONSTRAINT fk_shipment_order_id FOREIGN KEY (shipment_order_id) REFERENCES Orders(id),
    CONSTRAINT fk_shipment_customer_id FOREIGN KEY (shipment_customer_id) REFERENCES Users(Id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHIPMENTS TABLE------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------