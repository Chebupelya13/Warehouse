CREATE DATABASE WarehouseDB;
GO
USE WarehouseDB;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Login NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'User'
);
GO

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    BasePrice DECIMAL(18, 2) NOT NULL CHECK (BasePrice >= 0)
);
GO

CREATE TABLE Suppliers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(150),
    Address NVARCHAR(255)
);
GO

CREATE TABLE StorageCells (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Capacity INT NULL
);
GO

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId INT NULL FOREIGN KEY REFERENCES Suppliers(Id),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT 'В обработке'
);
GO

CREATE TABLE Movements (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
    CellId INT NOT NULL FOREIGN KEY REFERENCES StorageCells(Id),
    OrderId INT NULL FOREIGN KEY REFERENCES Orders(Id),
    MovementType NVARCHAR(20) NOT NULL CHECK (MovementType IN ('Поступление', 'Отгрузка')),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    TotalCost DECIMAL(18, 2) NOT NULL CHECK (TotalCost >= 0),
    MovementDate DATETIME DEFAULT GETDATE()
);
GO

CREATE NONCLUSTERED INDEX IX_Movements_ProductId ON Movements(ProductId);
GO
CREATE NONCLUSTERED INDEX IX_Movements_CellId ON Movements(CellId);
GO
CREATE NONCLUSTERED INDEX IX_Movements_MovementDate ON Movements(MovementDate);
GO

INSERT INTO Users (Login, PasswordHash, Role) VALUES
('admin', '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 'Администратор'),
('store', 'D5367AEA1C17343B6C380F774B81A8D7D5E33C43DC445FDC8A6F884723694F3D', 'Кладовщик');

INSERT INTO StorageCells (Name, Capacity) VALUES
('Стеллаж А-1', 100), ('Стеллаж А-2', 150), ('Стеллаж Б-1', 200), ('Зона приемки', 500);

INSERT INTO Products (Name, Category, BasePrice) VALUES
('Серверное шасси Supermicro 2U', 'Серверное оборудование', 150000.00),
('Коммутатор Cisco Catalyst 24-port', 'Сетевое оборудование', 85000.00),
('Патч-корд медный UTP 3м', 'Расходные материалы', 350.00),
('Источник бесперебойного питания APC 1500VA', 'Электроника', 22000.00),
('Жесткий диск Seagate 16TB Enterprise', 'Комплектующие ПК', 45000.00),
('Модуль оперативной памяти DDR4 64GB ECC', 'Комплектующие ПК', 18000.00);

INSERT INTO Suppliers (Name, ContactInfo, Address) VALUES 
('ООО ТехноОпт', '+79991112233', 'г. Москва');

INSERT INTO Orders (SupplierId, Status) VALUES 
(1, 'Завершен'), (1, 'Завершен'), (1, 'Завершен'), (1, 'Завершен'), (1, 'Завершен');

INSERT INTO Movements (ProductId, CellId, OrderId, MovementType, Quantity, TotalCost, MovementDate) VALUES
(1, 1, 1, 'Поступление', 5, 750000.00, '2023-11-01 10:15:00'),
(2, 2, 1, 'Поступление', 10, 850000.00, '2023-11-01 11:30:00'),
(1, 1, 2, 'Отгрузка', 2, 300000.00, '2023-11-05 14:00:00'),
(3, 3, 3, 'Поступление', 100, 35000.00, '2023-11-10 09:00:00'),
(4, 4, 4, 'Поступление', 20, 440000.00, '2023-11-12 16:45:00'),
(1, 1, 5, 'Отгрузка', 1, 150000.00, '2023-11-15 10:20:00');