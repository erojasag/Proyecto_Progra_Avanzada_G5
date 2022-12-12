CREATE DATABASE SHOECORP_BD;


USE SHOECORP_BD;

--------------------------------------ERRORES-----------------------------------------------------------------
CREATE TABLE ERRORES(
	ID_ERROR INT IDENTITY(1,1) NOT NULL,
	ERROR_NUMBER INT NOT NULL,
	ERROR_STATE INT NOT NULL,
	ERROR_SEVERITY INT NOT NULL,
	ERROR_LINE INT NOT NULL,
	ERROR_PROCEDURE varchar(max) NOT NULL,
	ERROR_MESSAGE varchar (max) NOT NULL,
	ERROR_DATETIME datetime NOT NULL)

--------------------------------------END OF ERRORES------------------------------------------------------------


--------------------------------------ROLES TABLE----------------------------------------------------------------------------------------------------------

CREATE TABLE Roles(
	Id int IDENTITY(1,1),
	Rol_Name varchar(max),
CONSTRAINT PK_Role_ID PRIMARY KEY(Id)
);

--INSERT
INSERT INTO Roles(Rol_Name) VALUES('Administrator');
INSERT INTO Roles(Rol_Name) VALUES('Cashier');
INSERT INTO Roles(Rol_Name) VALUES('Customer');

--------------------------------------END OF ROLES TABLE----------------------------------------------------------------------------------------------------------


--------------------------------------USER TABLE-----------------------------------------------------------------------------------------------------------

CREATE TABLE Users(
	Id uniqueidentifier,
	Identification varchar(9) NOT NULL UNIQUE,
	Name varchar(50) NOT NULL,
    First_last_name varchar(50) NOT NULL,
    Second_last_name varchar(50) NOT NULL,
	User_Role int NOT NULL,
	Username varchar(50) NOT NULL UNIQUE,
	Password varbinary(max) NOT NULL,
    Birth_date DATE NOT NULL,
    Phone varchar(20) NOT NULL,
    Email varchar(50) NOT NULL UNIQUE,
    Registration_date DATETIME NOT NULL DEFAULT GETDATE(),
	Photo VARBINARY(max) NULL,
    Modification_date DATETIME NULL,
    Address varchar(100) NOT NULL,
    Email_Verification bit DEFAULT 0,
    Activation_Code uniqueidentifier,
	CONSTRAINT PK_User_ID PRIMARY KEY(Id),
	CONSTRAINT FK_Role_ID FOREIGN KEY (User_Role) REFERENCES Roles(Id)
);

Alter table Users
Alter column Photo varchar(max) null

--------------------------------------END OF USER TABLE-----------------------------------------------------------------------------------------------------------


--------------------------------------BRAND TABLE----------------------------------------------------------------------------------------------------------

CREATE TABLE Brand(
	Id INT IDENTITY(1,1),
	Name varchar(50) NOT NULL,
	Photo varchar(max),
CONSTRAINT PK_Brand_Id PRIMARY KEY (Id)
);

--INSERT
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


--------------------------------------END OF BRAND TABLE----------------------------------------------------------------------------------------------------------

--------------------------------------PRODUCT TABLE--------------------------------------------------------------------------------------------------------


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


ALTER table PRODUCT
Alter column Modification_date DATETIME2 null
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
VALUES(0020,4,165000,16,'UA HOVR� Machina 3','Beige',36, '');

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
VALUES(0028,6,45000,8,'Authentic Original Boat','Blue',38, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0029,6,45000,15,'Authentic Original Boat','Grey',43, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0030,6,45000,2,'Authentic Original Boat','Red',41, 'https://m.media-amazon.com/images/I/810nvVwNztL._AC_UX395_.jpg');

----------------------------------INSERT Yeezy------------------------------
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0031,7,119000,14,'Boost 350 V2','Black',37, 'https://3app.kicksonfire.com/kofapp/upload/events_master_images/iphone_adidas-yeezy-boost-350-v2-red.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0032,7,119000,3,'Boost 350 V2','White',39, 'https://cdn.shopify.com/s/files/1/0496/4325/8009/products/baskets-yeezy-boost-350-v2-sand-taupe-adidas-kikikickz-868725_800x.progressive.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0033,7,119000,1,'Boost 350 V2','Beige',42, 'https://www.cdiscount.com/pdt2/9/7/8/1/300x300/mp57405978/rw/baskets-decontractees-pour-hommes-et-femmes.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0034,7,119000,12,'Boost 350 V2','Black',43, 'https://2app.kicksonfire.com/kofapp/upload/events_master_images/ipad_adidas-yeezy-boost-350-v2-black-white.jpg');
INSERT INTO Product(Id,Brand_Id,Price, Stock, Model, Color, shoeSize, Photo)
VALUES(0035,7,119000,8,'Boost 350 V2','Grey',38, 'https://cdn-images.farfetch-contents.com/15/79/86/13/15798613_28931498_600.jpg');


--------------------------------------END OF PRODUCT TABLE--------------------------------------------------------------------------------------------------------

--------------------------------------SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------


CREATE TABLE ShoppingCart(
    Id INT NOT NULL IDENTITY(1,1),
	Quantity INT NOT NULL,
	User_Id uniqueidentifier NOT NULL,
	Product_Id INT NOT NULL,
	CONSTRAINT PK_ShoppingCart_Id PRIMARY KEY (Id),
    CONSTRAINT FK_shoppingCart_User_id FOREIGN KEY (User_Id) REFERENCES Users(Id),
    CONSTRAINT FK_shoppingCart_Product_id FOREIGN KEY (product_id) REFERENCES Product(Id)
);


--------------------------------------END OF SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------

--------------------------------------ORDERS TABLE---------------------------------------------------------------------------------------------------------


CREATE TABLE Orders(
    Id uniqueidentifier,
    Order_User_Id uniqueidentifier NOT NULL,
    NombreCompleto varchar(max),
    Product varchar(max),
    Order_date DATE NOT NULL,
    Order_total DECIMAL(10,2) NOT NULL
    CONSTRAINT PK_Order_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Order_User_Id FOREIGN KEY (Order_User_Id) REFERENCES Users(Id)
);


ALTER table Orders
Add Status bit default 1
--------------------------------------END OF ORDERS TABLE---------------------------------------------------------------------------------------------------------

--------------------------------------PRODUCT_BY_ORDER TABLE-----------------------------------------------------------------------------------------------


CREATE TABLE Product_By_Order(
	Id INT NOT NULL IDENTITY(1,1),
	Product_Id INT NOT NULL,
	Order_Id uniqueidentifier NOT NULL
	CONSTRAINT PK_Product_By_Order_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Product_Id FOREIGN KEY (Product_Id) REFERENCES Product(Id),
	CONSTRAINT FK_Order_Id FOREIGN KEY (Order_Id) REFERENCES Orders(Id)
);

--------------------------------------END OF PRODUCT_BY_ORDER TABLE-----------------------------------------------------------------------------------------------


--------------------------------------SHIPMENTS TABLE------------------------------------------------------------------------------------------------------



CREATE TABLE Shipments(
    shipment_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    shipment_order_id uniqueidentifier NOT NULL,
    shipment_date DATE NOT NULL,
    shipment_status varchar(50) NOT NULL,
    shipment_address varchar(50) NOT NULL,
    shipment_city varchar(50) NOT NULL,
    shipment_state varchar(50) NOT NULL,
    shipment_zip_code varchar(50) NOT NULL,
    shipment_country varchar(50) NOT NULL,
    shipment_phone varchar(50) NOT NULL,
    shipment_email varchar(50) NOT NULL,
    shipment_customer_id uniqueidentifier NOT NULL,
    CONSTRAINT fk_shipment_order_id FOREIGN KEY (shipment_order_id) REFERENCES Orders(id),
    CONSTRAINT fk_shipment_customer_id FOREIGN KEY (shipment_customer_id) REFERENCES Users(Id)
);


insert into Orders values (NEWID(), 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB', 'Emanuel Rojas','p1','2022-12-5', 3000.00)
insert into Shipments values ('75AAF0D1-A824-457D-8FDB-BA3D0FCA8B99','2022-12-06', 'in progress', 'Av 89', 'Desamparados', 'SJ', '10302', 'CR', '88888888', 'hola@gmail.com', 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB')

--------------------------------------END OF SHIPMENTS TABLE------------------------------------------------------------------------------------------------------


----------------------------------------PROCEDIMIENTOS ALMACENADOS----------------------------------------------
--------------------------------------------USUARIOS--------------------------------------------------------
---INSERTAR USUARIO Y HASHEAR CONTRASE�A

GO
CREATE PROCEDURE REGISTRAR_USUARIO (
	@V_CED VARCHAR(9),
	@V_NAME VARCHAR(50),
	@V_FLASTNAME VARCHAR(50),
	@V_SLASTNAME VARCHAR(50),
	@ID_ROL INT,
	@V_USER VARCHAR(50),
	@PASSWORD VARCHAR(MAX),
	@DOB DATE,
	@TEL VARCHAR(20),
	@V_EMAIL VARCHAR(50),
	@V_PHOTO VARBINARY(MAX),
	@V_ADRESS VARCHAR(100))
	AS
	DECLARE
	@NEWPASSWORD VARBINARY(MAX)
	BEGIN TRY 
		SET @NEWPASSWORD = (ENCRYPTBYPASSPHRASE ('ENCRIPTACION', @PASSWORD));
		INSERT INTO Users(Id, Identification, Name, First_last_name, Second_last_name, User_Role, Username, Password, Birth_date, Phone, Email, Registration_date, Photo, Address, Activation_Code)
		VALUES (NEWID(), @V_CED, @V_NAME, @V_FLASTNAME, @V_SLASTNAME, @ID_ROL, @V_USER, @NEWPASSWORD, @DOB, @TEL, @V_EMAIL, GETDATE(), @V_PHOTO, @V_ADRESS, NEWID());
	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO

USE SHOECORP_BD
--DESENCRIPTAR CONTRASENIA
GO
CREATE PROCEDURE DESENCRIPTAR_CONTRA (
@V_USER VARCHAR(50),
@PASSWORD VARCHAR(MAX))

AS 
	BEGIN TRY
		SELECT * FROM Users WHERE USERNAME = @V_USER AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('ENCRIPTACION', PASSWORD)) = @PASSWORD
	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO

--TEST

EXECUTE REGISTRAR_USUARIO @V_CED = '117250521', @V_NAME = 'Emanuel', @V_FLASTNAME = 'Rojas', @V_SLASTNAME = 'Cliente'
	, @ID_ROL = 3, @V_USER = 'erojasag', @PASSWORD = 'Cliente123', @DOB = '1998-01-11', @TEL = '88667456'
	, @V_EMAIL = 'eroaguero01@gmail.com', @V_PHOTO = null, @V_ADRESS = 'Alajuela';

	
EXECUTE REGISTRAR_USUARIO @V_CED = '117250527', @V_NAME = 'Jesus', @V_FLASTNAME = 'Morales', @V_SLASTNAME = 'Segura'
	, @ID_ROL = 2, @V_USER = 'JesusCaja', @PASSWORD = 'JesusCaja', @DOB = '1998-01-11', @TEL = '88667456'
	, @V_EMAIL = 'jesusMorales@shoeCorp.com', @V_PHOTO = null, @V_ADRESS = 'Alajuela';

	
EXECUTE REGISTRAR_USUARIO @V_CED = '117250530', @V_NAME = 'Emanuel', @V_FLASTNAME = 'Rojas', @V_SLASTNAME = 'Aguero'
	, @ID_ROL = 1, @V_USER = 'EmaAdmin', @PASSWORD = 'SuperAdmin2022', @DOB = '1998-01-11', @TEL = '88667465'
	, @V_EMAIL = 'eroaguero02@gmail.com', @V_PHOTO = null, @V_ADRESS = 'Alajuela';

	
EXECUTE REGISTRAR_USUARIO @V_CED = '117660786', @V_NAME = 'Elisama', @V_FLASTNAME = 'Cubillo', @V_SLASTNAME = 'Vargas'
	, @ID_ROL = 3, @V_USER = 'EliCubillo', @PASSWORD = 'EliShoeCorp', @DOB = '2000-01-15', @TEL = '86755378'
	, @V_EMAIL = 'elicubillo@shoeCorp.com', @V_PHOTO = null, @V_ADRESS = 'San Jose';


EXECUTE DESENCRIPTAR_CONTRA @V_USER = 'EliCubillo', @PASSWORD = 'EliShoeCorp'

-----------------------------------------------------------------------------------------------------
--ACTUALIZAR USUARIO Y QUE LA CONTRA SE ENCRIPTE
GO
CREATE   PROCEDURE ACTUALIZAR_USUARIO

	(@V_ID uniqueidentifier,
	@V_NAME VARCHAR(50),
	@V_FLASTNAME VARCHAR(50),
	@V_SLASTNAME VARCHAR(50),
	@ID_ROL INT,
	@TEL VARCHAR(20),
	@V_EMAIL VARCHAR(50),
	@V_PHOTO VARBINARY(MAX),
	@V_ADRESS VARCHAR(100))

AS
DECLARE
	@NEWPASSWORD VARBINARY(MAX)
	BEGIN TRY
		
		UPDATE Users SET Name = @V_NAME, First_last_name = @V_FLASTNAME, Second_last_name = @V_SLASTNAME,
		User_Role = @ID_ROL, Phone = @TEL, Email = @V_EMAIL, Photo = @V_PHOTO, Address = @V_ADRESS, Modification_date = GETDATE()
		WHERE Id = @V_ID

	END TRY
	BEGIN CATCH
-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORS"
		INSERT INTO ERRORES
				VALUES
				(
				   ERROR_NUMBER(),
				   ERROR_STATE(),
				   ERROR_SEVERITY(),
				   ERROR_LINE(),
				   ERROR_PROCEDURE(),
				   ERROR_MESSAGE(),
				   GETDATE()
				);
    END CATCH
GO


--ACTUALIZAR CONTRASENIA
use SHOECORP_BD
GO
CREATE   PROCEDURE ACTUALIZAR_CONTRASENIA

	(@V_ID uniqueidentifier,
	@PASSWORD VARCHAR(MAX))

AS
DECLARE
	@NEWPASSWORD VARBINARY(MAX)
	BEGIN TRY
		SET @NEWPASSWORD = (ENCRYPTBYPASSPHRASE ('ENCRIPTACION', @PASSWORD));
		UPDATE Users SET Password = @NEWPASSWORD
		WHERE Id = @V_ID

	END TRY
	BEGIN CATCH
-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORS"
		INSERT INTO ERRORES
				VALUES
				(
				   ERROR_NUMBER(),
				   ERROR_STATE(),
				   ERROR_SEVERITY(),
				   ERROR_LINE(),
				   ERROR_PROCEDURE(),
				   ERROR_MESSAGE(),
				   GETDATE()
				);
    END CATCH
GO

execute ACTUALIZAR_CONTRASENIA @V_ID = '0EB540F3-AC21-4465-8C07-05128630DFCD', @PASSWORD = 'Perritos2022'
------------------------------------------------------------------------------------------------------
-------------------------------------------ORDENES----------------------------------------------------
--SP PARA REGISTRAR UNA ORDEN

GO
CREATE PROCEDURE REGISTRAR_ORDEN (
-- INSERTA UNA ORDEN
	@V_ID_USUARIO UNIQUEIDENTIFIER,
	@V_MONTO DECIMAL(10,2),
	@V_Nombre VARCHAR(MAX),
	@V_Product VARCHAR(MAX))
	AS	

	BEGIN TRY 
		INSERT INTO Orders(Id, Order_User_Id, NombreCompleto, Product, Order_date, Order_total)
		VALUES (NEWID(),@V_ID_USUARIO, @V_Nombre, @V_Product, GETDATE(), @V_MONTO);
	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO


--VER ORDENES CON DETALLE DEL CLIENTE
GO
CREATE PROCEDURE MOSTRAR_ORDENES
	AS 
	BEGIN TRY
	--MUESTRA INFORMACION DE LAS ORDENES Y SUS COMPRADORES
		SELECT A.Id,
		A.Order_User_Id,
		CONCAT(B.Name,' ', B.First_last_name,' ', B.Second_last_name) NOMBRE_COMPLETO,
		A.Product,
		A.Order_date,
		A.Order_total
		
		
		FROM Orders A, Users B
		WHERE A.Order_User_Id = B.Id 

	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO

EXECUTE MOSTRAR_ORDENES
--VER ORDENES POR ID CON SU DETALLE DE CLIENTE
GO
CREATE PROCEDURE MOSTRAR_ORDEN_PORID (@V_ID_ORDEN UNIQUEIDENTIFIER)
	AS 
	BEGIN TRY
		SELECT A.Id,
		A.Order_User_Id,
		CONCAT(B.Name,' ', B.First_last_name,' ', B.Second_last_name) NOMBRE_COMPLETO,
		A.Product,
		A.Order_date,
		A.Order_total
		
		FROM Orders A, Users B
		WHERE A.Order_User_Id = B.Id 
		AND A.Id = @V_ID_ORDEN

	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO


----ACTUALIZAR STOCK
USE SHOECORP_BD
GO
CREATE TRIGGER ACTUALIZARSTOCK
ON ShoppingCart 
AFTER INSERT 
AS 
  UPDATE Product
     SET Stock = P.Stock - I.Quantity
	 FROM Product P, inserted I
	 WHERE P.Id = I.Product_Id;
GO



-----------------GENERATE RANDOM PASS
USE SHOECORP_BD
--vista random
GO
CREATE VIEW [dbo].[RANDOM_ID]
AS
SELECT NEWID() AS NEW_ID
GO

--Funcion password random
GO
CREATE OR ALTER  FUNCTION [dbo].[RANDOM_PASS] (@PasswordLength INT )
	RETURNS VARCHAR(20)
	AS
	BEGIN
		DECLARE @Password     VARCHAR(20)
		DECLARE @ValidCharacters   VARCHAR(100)
		DECLARE @PasswordIndex    INT
		DECLARE @CharacterLocation   INT

		SET @ValidCharacters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890'
		SET @PasswordIndex = 1
		SET @Password = ''


		WHILE @PasswordIndex <= @PasswordLength
		BEGIN
		 SELECT @CharacterLocation = ABS(CAST(CAST(NEW_ID AS VARBINARY) AS INT)) % 
		LEN(@ValidCharacters) + 1
		 FROM RANDOM_ID

		 SET @Password = @Password + SUBSTRING(@ValidCharacters, @CharacterLocation, 1)
		 SET @PasswordIndex = @PasswordIndex + 1
		END

		RETURN @Password

END
GO



CREATE   PROCEDURE [dbo].[FORGOT_PASS]
-- SP QUE REESTABLECE UNA CONTRASEÑA NUEVA
	@EMAIL VARCHAR(50)
	AS
	BEGIN TRY
	-- LLAMA A LA FUNCION "RANDOM_PASS" ESA FUNCION SE GUARDA EN LA VARIABLE "@TEMP_PASS"
	--Y LA SETEA EN EL CAMPO "PASSWORD" DONDE EL EMAIL COINCIDA CON EL QUE EL USUARIO DIGITE
	DECLARE 
	@TEMP_PASS VARCHAR(8),
	@NEWPASSWORD VARBINARY(MAX)

	SELECT @TEMP_PASS = [dbo].RANDOM_PASS (8)
	SET @NEWPASSWORD = (ENCRYPTBYPASSPHRASE ('ENCRIPTACION', @TEMP_PASS));
	UPDATE Users SET PASSWORD = @NEWPASSWORD WHERE EMAIL = @EMAIL
	END TRY
	BEGIN CATCH 
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORS"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
	END CATCH

	--PRUEBA, OBTENER NUEVA CONTRA PARA ELI
	EXECUTE FORGOT_PASS @EMAIL = 'memarojas@hotmail.es'

	--VER CONTRA TEMPORAL PARA ENVIARLA POR EMAIL
	GO
	CREATE PROCEDURE SEE_TEMPASSWORD
	@EMAIL VARCHAR(50)
	AS
	BEGIN TRY
	SELECT CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('ENCRIPTACION', PASSWORD) )
	FROM Users WHERE Email = @EMAIL
	END TRY
	BEGIN CATCH 
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORS"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
	END CATCH

EXECUTE SEE_TEMPASSWORD @EMAIL = 'eroaguero01@gmail.com'



--ALTERAR EL SIGUIENTE SP PARA AGREGARLE NOMBRE DEL PRODUCTO
GO
ALTER PROCEDURE [dbo].[MOSTRAR_ORDENES]
	AS 
	BEGIN TRY
		SELECT A.Id,
		A.Order_User_Id,
		CONCAT(B.Name,' ', B.First_last_name,' ', B.Second_last_name) NOMBRE_COMPLETO,
		P.Model AS Product,
		A.Order_date,
		A.Order_total
		
		
		FROM Orders A, Users B, Product_By_Order OP, Product P
		WHERE A.Order_User_Id = B.Id 
		AND OP.Product_Id = P.Id

	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO

  INSERT INTO Product_By_Order VALUES (1,1)

--CREACION DE SP QUE MUESTRA LAS ORDENES DE UN CLIENTE EN ESPECIFICO
  GO
CREATE PROCEDURE MOSTRAR_ORDENES_CLIENTE  (@V_ID UNIQUEIDENTIFIER)
	AS 
	BEGIN TRY
	--MUESTRA INFORMACION DE LAS ORDENES Y SU PRODUCTO
		SELECT A.Id,
		A.Order_User_Id,
		CONCAT(B.Name,' ', B.First_last_name,' ', B.Second_last_name) NOMBRE_COMPLETO,
		Product,
		A.Status,
		A.Order_date,
		A.Order_total
		
		
		FROM Orders A, Users B
		WHERE a.Order_User_Id = b.Id 
		

	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO


EXECUTE MOSTRAR_ORDENES_CLIENTE @V_ID = 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB'


SELECT * FROM Orders o WHERE o.Order_User_Id = 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB'

SELECT * FROM Users u WHERE u.Id = 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB'

SELECT * FROM Product_By_Order pbo Where pbo.

 GO
CREATE PROCEDURE MOSTRAR_ORDEN_Y_ENVIO  (@V_ID UNIQUEIDENTIFIER)
	AS 
	BEGIN TRY
	--MUESTRA INFORMACION DE LAS ORDENES Y SU PRODUCTO
		SELECT A.Id,
		A.Order_User_Id,
		S.shipment_status,
		S.shipment_date,
		P.Model AS Product,
		A.Order_date,
		A.Order_total
		
		
		FROM Orders A, Product_By_Order OP, Product P, Shipments S
		WHERE A.Id = S.shipment_order_id
		AND OP.Product_Id = P.Id
		AND A.Id = @V_ID

	END TRY
	BEGIN CATCH
	-- INSERTA EL ERROR PRODUCIDO EN LA TABLA "ERRORES"
		INSERT INTO ERRORES
		VALUES
		(
		   ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE()
		);
END CATCH;
GO



--TEST
EXECUTE MOSTRAR_ORDENES_CLIENTE @V_ID = 'D6F26A93-20D5-4DAB-96F9-1E4EFCBFDAEB'




