use VacaRenga;

CREATE TABLE usuarios(
	id INT IDENTITY(1,1) PRIMARY KEY,
	tipo VARCHAR(25) NOT NULL,
	usuario VARCHAR(30) NOT NULL UNIQUE,
	contrasena VARCHAR(30) NOT NULL
);

CREATE TABLE Empresas (
	id INT PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL
);

CREATE TABLE ClienteEmpresa (
	id INT PRIMARY KEY,
	cedula VARCHAR(8) NOT NULL UNIQUE,
	nombre VARCHAR(50) NOT NULL,
	apellido VARCHAR(50) NOT NULL,
	direccion VARCHAR(50) NOT NULL,
	telefono VARCHAR(20) NOT NULL,
	idEmpresa INT references Empresas(id),
	descuento INT,
);

CREATE TABLE ClienteParticular (
	id INT PRIMARY KEY,
	cedula VARCHAR(8) NOT NULL UNIQUE,
	nombre VARCHAR(50) NOT NULL,
	apellido VARCHAR(50) NOT NULL,
	direccion VARCHAR(50) NOT NULL,
	telefono VARCHAR(20) NOT NULL,
);

CREATE TABLE Proveedores(
	id INT PRIMARY KEY,
	cedula VARCHAR(8) NOT NULL UNIQUE,
	nombre VARCHAR(50) NOT NULL,
	apellido VARCHAR(50) NOT NULL,
	direccion VARCHAR(50) NOT NULL,
	telefono VARCHAR(20) NOT NULL,
	tipoproducto VARCHAR(40) NOT NULL,
	procedencia VARCHAR(40) NOT NULL,
	impuestos INT DEFAULT(0)
);

CREATE TABLE Insumos(
id INT PRIMARY KEY,
nombre VARCHAR(50) NOT NULL,
comentario VARCHAR(100) DEFAULT('Sin Comentarios'),
id_proveedor INT REFERENCES Proveedores(id),
stock INT CHECK(stock >= 0) NOT NULL,
precio DECIMAL NOT NULL
);

CREATE TABLE Ventas(
id INT PRIMARY KEY,
fecha DATE NOT NULL,
hora DATETIME NOT NULL,
insumo INT REFERENCES Insumos(id),
unidades INT NOT NULL,
id_cliente INT NOT NULL,
precio VARCHAR(25) NOT NULL,
tipoCliente VARCHAR(10) NOT NULL
);

select * from ventas;

/*Ingreso de datos de prueba/*
INSERT INTO Empresa VALUES (1, 'Pepsi');
INSERT INTO ClienteEmpresa VALUES (1, 53601413, 'Miguel', 'Mediza', 'Calle 20', 0952599304, 1, 10);
INSERT INTO ClienteParticular VALUES (1, 53601413, 'Miguel', 'Mediza', 'Calle 20', 0952599304);
INSERT INTO Proveedores VALUES (1, 53601413, 'Miguel', 'Mediza', 'Calle 20', 094234324, 'Semillas', 'Nacional', 0);
INSERT INTO Insumos VALUES(1, 'Semilla Trigo', 'Es de mayor calidad', 1, 1000, 125.5);
INSERT INTO Ventas(id, fecha, hora, insumo, unidades, id_cliente, precio, tipoCliente) values(3,'3/12/2023 0:00:00','3/12/2023 15:32:00',1,2,1,'250,2','EMP');