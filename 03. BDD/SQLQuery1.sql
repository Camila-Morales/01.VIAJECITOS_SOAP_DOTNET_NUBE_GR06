-- Creating the database
CREATE DATABASE ViajecitosDB;

USE ViajecitosDB;

-- Creating Vuelos table
CREATE TABLE Vuelos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CIUDAD_ORIGEN VARCHAR(3) NOT NULL,
    CIUDAD_DESTINO VARCHAR(3) NOT NULL,
    VALOR NUMERIC(7,2) NOT NULL,
    HORA_SALIDA DATETIME NOT NULL
);

-- Inserting sample flight data (6 records)
INSERT INTO Vuelos (CIUDAD_ORIGEN, CIUDAD_DESTINO, VALOR, HORA_SALIDA) VALUES
('GYE', 'UIO', 150.00, '2025-06-01 08:00:00'),
('GYE', 'UIO', 200.00, '2025-06-01 12:00:00'),
('UIO', 'GYE', 180.00, '2025-06-01 09:00:00'),
('UIO', 'CUE', 120.00, '2025-06-01 10:00:00'),
('CUE', 'GYE', 130.00, '2025-06-01 14:00:00'),
('UIO', 'CUE', 250.00, '2025-06-01 16:00:00');

-- Creating Usuarios table
CREATE TABLE Usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    edad INT NOT NULL CHECK (edad >= 0),
    nacionalidad VARCHAR(50) NOT NULL
);

-- Inserting sample user data
INSERT INTO Usuarios (nombre, edad, nacionalidad) VALUES
('Juan Perez', 30, 'Ecuatoriana'),
('Maria Lopez', 25, 'Ecuatoriana'),
('Carlos Gomez', 40, 'Colombiana');

-- Creating Compras table with id_usuario
CREATE TABLE Compras (
    Id INT PRIMARY KEY IDENTITY(1,1),
    VueloId INT NOT NULL,
    id_usuario INT NOT NULL,
    PurchaseDate DATETIME NOT NULL,
    FOREIGN KEY (VueloId) REFERENCES Vuelos(Id),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);

ALTER TABLE Compras
ADD Cantidad INT NOT NULL DEFAULT 1;

CREATE TABLE Facturas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CompraId INT NOT NULL,
    UsuarioId INT NOT NULL,
    VueloId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario NUMERIC(7,2) NOT NULL,
    PrecioTotal NUMERIC(10,2) NOT NULL,
    FechaEmision DATETIME NOT NULL,
    FOREIGN KEY (CompraId) REFERENCES Compras(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (VueloId) REFERENCES Vuelos(Id)
);

ALTER TABLE Facturas
ADD TipoPago NVARCHAR(20);  -- 'EFECTIVO' o 'CREDITO'


CREATE TABLE Amortizaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FacturaId INT FOREIGN KEY REFERENCES Facturas(Id),
    NumeroCuota INT,
    MontoCuota DECIMAL(10,2),
    FechaPago DATE
);

ALTER TABLE Amortizaciones
ADD SaldoRestante DECIMAL(10,2) NOT NULL DEFAULT 0;

CREATE TABLE AsientosReservados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VueloId INT NOT NULL,
    FacturaId INT NOT NULL,
    NumeroAsiento NVARCHAR(10) NOT NULL,
    CONSTRAINT FK_Asiento_Vuelo FOREIGN KEY (VueloId) REFERENCES Vuelos(Id),
    CONSTRAINT FK_Asiento_Factura FOREIGN KEY (FacturaId) REFERENCES Facturas(Id),
    CONSTRAINT UQ_Vuelo_Asiento UNIQUE (VueloId, NumeroAsiento)
);
