USE master;
CREATE DATABASE TechShopInventory;
GO

USE TechShopInventory;

CREATE TABLE Warehouses(
    IdWarehouse INT IDENTITY,
	Code NVARCHAR(20),
	Name NVARCHAR(100) NOT NULL,
	Location NVARCHAR(200) NOT NULL,

	CONSTRAINT PK_Warehouses PRIMARY KEY (IdWarehouse),
	CONSTRAINT UQ_Warehoses_Code UNIQUE(Code)
);

CREATE TABLE StockItems(
	IdStockItem INT IDENTITY,
	IdWarehouse INT NOT NULL,
	Sku NVARCHAR(50) NOT NULL,
	QuantityAvailable INT NOT NULL,
	QuantityReserved INT NOT NULL,
	LastUpdated DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

	CONSTRAINT PK_StockItems PRIMARY KEY (IdStockItem),
	CONSTRAINT UQ_StockItems_IdWarehouse_Sku UNIQUE(IdWarehouse, Sku),
	CONSTRAINT FK_StockItems_Warehouses_IdWarehouse FOREIGN KEY (IdWarehouse) REFERENCES Warehouses(IdWarehouse)
);

CREATE TABLE InventoryMovements(
	IdInventoryMovement INT IDENTITY,
	IdStockItem INT NOT NULL,
	MovementType NVARCHAR(20) NOT NULL, 				-- entrada, salida, reserva, liberacion, ajuste
	Quantity INT NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	Reason NVARCHAR(200), 								-- Compra, Devolucion, consiliacion, etc
	ReferenceId NVARCHAR(50), 							-- Codigo de orden, codigo de autorizacion
	CONSTRAINT PK_InventoryMovements PRIMARY KEY (IdInventoryMovement),
	CONSTRAINT FK_InventoryMovements_StockItems_IdStockItem FOREIGN KEY (IdStockItem) REFERENCES StockItems(IdStockItem)
);
