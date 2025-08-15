CREATE DATABASE ZapatosDB;
GO
 
USE ZapatosDB;
GO
 
-- Tabla de Categor�as (solo lo b�sico)
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);
 go

-- Tabla de Zapatos (campos esenciales + imagen)
CREATE TABLE Zapatos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoriaId INT FOREIGN KEY REFERENCES Categorias(Id) ON DELETE CASCADE,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    ImagenURL NVARCHAR(255), -- Ruta de la imagen/foto del zapato
    FechaCreacion DATETIME DEFAULT GETDATE()
);
 go

-- Tabla de Tallas (inventario b�sico)
CREATE TABLE Tallas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ZapatoId INT FOREIGN KEY REFERENCES Zapatos(Id) ON DELETE CASCADE,
    Talla NVARCHAR(10) NOT NULL, -- Ej: '38', '39', '40', 'M', 'L'
    Cantidad INT DEFAULT 0,
    CONSTRAINT UQ_ZapatoTalla UNIQUE (ZapatoId, Talla)
);
 go

 select id, nombre from Categorias
 
-- Insertar categor�as
INSERT INTO Categorias (Nombre)
VALUES 
('Deportivos'),
('Formales');
GO
 
-- Insertar zapatos
INSERT INTO Zapatos (CategoriaId, Nombre, Precio, ImagenURL)
VALUES 
(1, 'Zapato Running Pro', 89.99, '/imagenes/running-pro.jpg'),  -- Deportivos
(2, 'Zapato Oxford Cl�sico', 120.50, '/imagenes/oxford-clasico.jpg');  -- Formales
GO
 
-- Insertar tallas para el primer zapato (Running Pro)
INSERT INTO Tallas (ZapatoId, Talla, Cantidad)
VALUES 
(1, '38', 5),
(1, '39', 8);
GO
 
-- Insertar tallas para el segundo zapato (Oxford Cl�sico)
INSERT INTO Tallas (ZapatoId, Talla, Cantidad)
VALUES 
(2, '40', 3),
(2, '41', 6);
GO
 
select * from Zapatos;
 
----------------------->Vista
CREATE VIEW vistaCategoria AS
SELECT Z.Id AS [N� de Registro], Z.Nombre, Z.Precio, Z.ImagenURL, C.Nombre AS Categoria FROM Zapatos Z
            INNER JOIN Categorias C ON Z.CategoriaId = C.Id

            select *from vistaCategoria;

            delete from Zapatos where Id = 4
 
