CREATE DATABASE Proyecto_Progra_Avanzada_G5;
USE Proyecto_Progra_Avanzada_G5;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------CUSTOMER TABLE---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Customer(
	User_Id INT IDENTITY(1,1) NOT NULL,
	Login_name_customer VARCHAR(40) NOT NULL,
	Password varchar(50) NOT NULL,
    Name varchar(50) NOT NULL,
    First_last_name varchar(50) NOT NULL,
    Second_last_name varchar(50) NOT NULL,
    Id varchar(9) NOT NULL,
    Phone varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
    Registration_date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Modification_date DATETIME2 NULL,
    Birth_date DATETIME2 NOT NULL,
    Photo varchar(50),
    Address varchar(50) NOT NULL,
CONSTRAINT PK_Customer_Id  PRIMARY KEY (user_Id)
);

INSERT INTO Customer(Login_name_customer, Password, Name,First_last_name,Second_last_name,
Id, Phone, Email, Birth_date, Address) 
VALUES('erojasag', 'holamundo123', 'Emanuel', 'Rojas','Aguero',117250521,'88667456',
'eroaguero01@gmail.com','1998-11-01','Alajuela')

SELECT * FROM Customer;
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------CUSTOMER TABLE---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Product(
    Id INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Photo varchar(50),
    Brand varchar(50) NOT NULL,
    Model varchar(50) NOT NULL,
    Color varchar(50) NOT NULL,
    Registration_date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Modification_date DATETIME2 NULL,
    CONSTRAINT PK_Product_Id PRIMARY KEY (id)
); 

INSERT INTO Product(Id,Price, Stock, Brand, Model, Color) 
VALUES(0001,150000, 15, 'Nike', 'Jordan Retro 1', 'Chocolate');

SELECT * FROM Product;
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------PRODUCT TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE ShoppingCart(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Customer_id int NOT NULL,
    Product_id INT NOT NULL,
    Name varchar(50) NOT NULL,
    Photo varchar(50) NOT NULL,
    Quantity INT NOT NULL,
    Estimate_Total DECIMAL(10,2) NOT NULL,
    Tax DECIMAL(10,2) NOT NULL DEFAULT 13,
    Total DECIMAL(10,2) NOT NULL,
    State char(2) NOT NULL
    CONSTRAINT FK_shoppingCart_customer_id FOREIGN KEY (customer_id) REFERENCES Customer(User_Id),
    CONSTRAINT FK_shoppingCart_product_id FOREIGN KEY (product_id) REFERENCES Product(Id)
);

INSERT INTO ShoppingCart (Customer_id, Product_id, Name, Photo, Quantity, Estimate_Total, Total, State) 
VALUES(1,1,'test','',1,0,0,1)

SELECT * FROM ShoppingCart sc ;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHOPPING_CART TABLE--------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------EMPLOYEE TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Employee(
    User_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    User_name varchar(50) NOT NULL,
    Password varchar(50) NOT NULL,
    Name varchar(50) NOT NULL,
    First_last_name varchar(50) NOT NULL,
    Second_last_name varchar(50) NOT NULL,
    Id varchar(9) NOT NULL,
    Phone varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
    Hire_date DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Birth_date DATETIME2 NOT NULL,
);

INSERT INTO Employee(User_name, Password, Name, First_last_name, Second_last_name, Id, Phone, Email, Birth_date) 
VALUES('ema_rojas','motopapi123', 'Emanuel', 'Rojas', 'Aguero', '117250521', '88667456', 'ema_rojas@shoeCorp.com', '1998-11-01');

SELECT * FROM Employee ;



EXEC Insert_Employee 'xime_rojas', 'mundocosmetico123', 'Ximena', 'Rojas', 'Aguero', 209098765, '86099433', 'ximenara@shoeCorp.com','2001-03-07'; 
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------EMPLOYEE TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------Total_Users TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Total_Users(
    total_users INT NOT NULL,
    customer_user_id INT,
    employee_user_id varchar(50)
    CONSTRAINT fk_total_users_customer_id FOREIGN KEY (customer_user_id) REFERENCES Customer(customer_user_id),
    CONSTRAINT fk_total_users_employee_id FOREIGN KEY (employee_user_id) REFERENCES Employee(employee_user_id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------Total_Users TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ORDERS TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Orders(
    order_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    order_customer_id INT NOT NULL,
    order_date TIMESTAMP NOT NULL,
    order_total DECIMAL(10,2) NOT NULL
    CONSTRAINT fk_order_customer_id FOREIGN KEY (order_customer_id) REFERENCES Customer(customer_user_id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------ORDERS TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHIPMENTS TABLE--------------------------------------------------------------------------------------------
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
    CONSTRAINT fk_shipment_order_id FOREIGN KEY (shipment_order_id) REFERENCES Orders(order_id),
    CONSTRAINT fk_shipment_customer_id FOREIGN KEY (shipment_customer_id) REFERENCES Customer(customer_user_id)
);

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------SHIPMENTS TABLE--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------









