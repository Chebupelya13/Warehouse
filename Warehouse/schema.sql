-- Create Tables
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Login NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    BasePrice DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(200),
    Address NVARCHAR(200)
);

CREATE TABLE StorageCells (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) UNIQUE NOT NULL,
    Capacity INT NOT NULL
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SupplierId INT,
    OrderDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
);

CREATE TABLE Movements (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    CellId INT NOT NULL,
    OrderId INT NOT NULL,
    MovementType NVARCHAR(50) NOT NULL, -- 'Поступление' or 'Отгрузка'
    Quantity INT NOT NULL,
    TotalCost DECIMAL(18, 2) NOT NULL,
    MovementDate DATETIME NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CellId) REFERENCES StorageCells(Id),
    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);

-- Insert Users (Password: admin / storekeeper)
INSERT INTO Users (Login, PasswordHash, Role)
VALUES
('admin', '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 'Администратор'),
('store', 'D5367AEA1C17343B6C380F774B81A8D7D5E33C43DC445FDC8A6F884723694F3D', 'Кладовщик');
