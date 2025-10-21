USE master;
CREATE DATABASE TechShopDB;
GO

USE TechShopDB;

CREATE TABLE Categorias(
    IdCategoria INT IDENTITY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL,

    CONSTRAINT PK_Categorias PRIMARY KEY(IdCategoria),
    CONSTRAINT UQ_Categorias_Nombre UNIQUE(Nombre)
);

CREATE TABLE Proveedores(
    IdProveedor INT IDENTITY,
    Nombre NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(200),
    Correo NVARCHAR(300),
    Telefono NVARCHAR(20),
    SitioWeb NVARCHAR(400),

    CONSTRAINT PK_Proveedores PRIMARY KEY(IdProveedor)
);

CREATE TABLE Productos(
    IdProducto INT IDENTITY,
    IdProveedor INT NOT NULL,
    IdCategoria INT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,

    CONSTRAINT PK_Productos PRIMARY KEY(IdProducto),
    CONSTRAINT FK_Productos_Proveedores_IdProveedor FOREIGN KEY(IdProveedor) REFERENCES Proveedores(IdProveedor),
    CONSTRAINT FK_Productos_Categorias_IdCategoria FOREIGN KEY(IdCategoria) REFERENCES Categorias(IdCategoria),
    CONSTRAINT CK_Productos_Precio CHECK (Precio > 0),
    CONSTRAINT CK_Productos_Stock CHECK (Stock >= 0)
);
