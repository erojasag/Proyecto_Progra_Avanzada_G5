CREATE DATABASE Proyecto_Progra_Avanzada_G5;
USE Proyecto_Progra_Avanzada_G5;


CREATE TABLE Customer(
    customer_user_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    customer_name varchar(50) NOT NULL,
    customer_first_last_name varchar(50) NOT NULL,
    customer_last_name varchar(50) NOT NULL,
    customer_id varchar(50) NOT NULL,
    customer_phone varchar(50) NOT NULL,
    customer_email varchar(50) NOT NULL,
    customer_registration_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    customer_birthDate DATE NOT NULL,
    customer_photo varchar(50),
    customer_address varchar(50) NOT NULL
);



CREATE TABLE Product(
    product_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    product_name varchar(50) NOT NULL,
    product_description varchar(50) NOT NULL,
    product_price DECIMAL(10,2) NOT NULL,
    product_stock INT NOT NULL,
    product_image varchar(50),
    product_brand varchar(50) NOT NULL,
    product_model varchar(50) NOT NULL,
    product_registration_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ShoppingCart(
    shoppingCart_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    shoppingCart_customer_id INT NOT NULL,
    shoppingCart_product_id INT NOT NULL,
    shoppipingCart_product_name varchar(50) NOT NULL,
    shoppingCart_image varchar(50) NOT NULL,
    shoppingCart_description varchar(50) NOT NULL,
    shoppingCart_quantity INT NOT NULL,
    shoppingCart_product_price DECIMAL(10,2) NOT NULL,
    shoppingCart_state char(2) NOT NULL
    CONSTRAINT fk_shoppingCart_customer_id FOREIGN KEY (shoppingCart_customer_id) REFERENCES Customer(customer_user_id),
    CONSTRAINT fk_shoppingCart_product_id FOREIGN KEY (shoppingCart_product_id) REFERENCES Product(product_id)
);


CREATE TABLE Employee(
    employee_user_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    employee_name varchar(50) NOT NULL,
    employee_first_last_name varchar(50) NOT NULL,
    employee_second_last_name varchar(50) NOT NULL,
    employee_id varchar(50) NOT NULL,
    employee_phone varchar(50) NOT NULL,
    employee_email varchar(50) NOT NULL,
    employee_hire_date TIMESTAMP NOT NULL,
    employee_birthDate DATE NOT NULL,
);

CREATE TABLE Total_Users(
    total_users INT NOT NULL,
    customer_user_id INT,
    employee_user_id INT
    CONSTRAINT fk_total_users_customer_id FOREIGN KEY (customer_user_id) REFERENCES Customer(customer_user_id),
    CONSTRAINT fk_total_users_employee_id FOREIGN KEY (employee_user_id) REFERENCES Employee(employee_user_id)
);

CREATE TABLE Orders(
    order_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    order_customer_id INT NOT NULL,
    order_date TIMESTAMP NOT NULL,
    order_total DECIMAL(10,2) NOT NULL,
    CONSTRAINT fk_order_customer_id FOREIGN KEY (order_customer_id) REFERENCES Customer(customer_user_id)
);

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
--------------------------------------CUSTOMER CRUD PROCEDURES---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------INSERT CUSTOMER------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE OR ALTER PROCEDURE insert_customer
@name as varchar(50),
@first_last_name as varchar(50),
@last_name as varchar(50),
@id as varchar(50),
@phone as varchar(50),
@email as varchar(50),
@birtDate as DATE,
@address as varchar(50)
AS
BEGIN 
	INSERT INTO Customer(
    customer_name,
    customer_first_last_name,
    customer_last_name,
    customer_id,
    customer_phone,
    customer_email,
    customer_birthDate,
    customer_address
	) VALUES(
    @name,
    @first_last_name,
    @last_name,
    @id,
    @phone,
    @email,
    @birtDate,
    @address
	)
END;

EXEC insert_customer 'Emanuel', 'Rojas', 'Aguero', '117250521', '88667456', 'eroaguero01@gmail.com', '1998-11-01', 'Alajuela';  --linea para volcado de datos
EXEC insert_customer 'Ximena', 'Rojas', 'Aguero', '000000001', '86099433', 'ximenara@gmail.com', '2001-03-07', 'Alajuela';


-----------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------visualizar el total de clientes en la tabla Customer---------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_Customer
AS
BEGIN 
	SELECT * FROM Customer c
END;

EXEC view_Customer;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------Visualizar un cliente por Id en la tabla Customer--------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_customer_by_id
@Id as INT
AS
BEGIN 
	SELECT * FROM Customer c where c.customer_user_id = @Id
for json auto
END;

EXEC view_customer_by_id 2;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------Actualizar un cliente segund su id en la tabla Customer--------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE update_customer_by_id
@Id as INT,
@phone as varchar(50),
@email as varchar(50),
@address as varchar(50)
AS
BEGIN 
	UPDATE Customer 
	SET Customer.customer_phone = @phone, Customer.customer_email = @email, Customer.customer_address = @address
	WHERE Customer.customer_user_id = @Id
END;

EXEC update_customer_by_id 2, 24389113, 'ximena1d@hotmail.com','Belen';

-----------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------Borrar un cliente segun su codigo-----------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE delete_customer_by_id
@Id as INT
AS
BEGIN 
	DELETE FROM Customer where Customer.customer_user_id=@id
END;

exec delete_customer 2;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------CUSTOMER CRUD PROCEDURES---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------Product CRUD PROCEDURES---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------INSERT PRODUCT-------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE insert_product
@product_name as varchar(50),
@product_description as varchar(50),
@product_price as decimal(10,2),
@product_stock as INT,
@product_brand as varchar(50),
@product_model as varchar(50)
AS
BEGIN 
	INSERT INTO Product(
    product_name,
    product_description,
    product_price,
    product_stock,
    product_brand,
    product_model
	) VALUES(
    @product_name,
    @product_description,
    @product_price,
    @product_stock,
    @product_brand,
    @product_model
	)
END;

EXEC insert_product 'Jordan 1 Retro 1 CHOC', 'Nike jordan 1 chocolate', 130000,00, 'Nike', 'Jordan Retro 1';  --linea para volcado de datos


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------VIEW ALL Product----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_Product
AS 
BEGIN 
	SELECT * FROM Product
END;

EXEC view_Product;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------VIEW Product BY CODE------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_product_by_id
@product_Id as INT
AS 
BEGIN
	SELECT * FROM Product p 
	WHERE p.product_id = @product_id
END;

EXEC view_product_by_id 1;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------UPDATE Product BY CODE----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE update_Product_by_id
@product_Id as INT,
@product_price as VARCHAR,
@product_stock as INT
AS 
BEGIN 
	UPDATE Product 
	SET product_price = @product_price, product_stock = @product_stock
	WHERE product_id = @product_Id
END;

EXEC update_Product_by_id 1;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------DELETE Product BY CODE----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE delete_Product_by_id
@product_Id as INT
AS 
BEGIN 
	DELETE FROM Product 
	WHERE product_id = @product_Id
END;

EXEC delete_Product_by_id;

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------Product CRUD PROCEDURES---------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------



-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------Employee CRUD PROCEDURES--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------INSERT Employee-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE insert_Employee
    @name varchar(50),
    @first_last_name varchar(50),
    @second_last_name varchar(50),
    @id varchar(50),
    @phone varchar(50),
    @email varchar(50),
    @birthDate DATE
AS 
BEGIN 
	INSERT INTO Employee(
    employee_name,
    employee_first_last_name,
    employee_second_last_name,
    employee_id,
    employee_phone,
    employee_email,
    employee_birthDate
    )
	VALUES(
	@name,
    @first_last_name ,
    @second_last_name,
    @id,
    @phonE,
    @email,
    @birthDate
	)
END;


EXEC insert_Employee 'Trabajador', 'Apellido1', 'Apellido2', '000000002', '89502955', 'trabajo@trabajo2.com', '1996-05-02';

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------VIEW Employee-------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_Employee
AS 
BEGIN 
	SELECT * FROM Employee e;
END;

EXEC view_Employee;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------VIEW EMPLOYEE BY ID--------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE view_Employee_by_id
@employee_Id as INT
AS 
BEGIN 
	SELECT * FROM Employee
	where employee_user_id = @employee_Id
END;


EXEC view_Employee_by_id 1;


-----------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------DELETE EMPLOYEE BY ID------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE delete_Employee_by_id
@employee_Id as INT
AS 
BEGIN 
	DELETE FROM Employee
	WHERE employee_user_id = @employee_Id
END;

EXEC delete_Employee_by_id 1;
