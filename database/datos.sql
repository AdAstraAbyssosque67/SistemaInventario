/* ============================================================
   datos.sql - Datos de prueba (ejecutar después de schema.sql)
   6 categorías activas + 1 inactiva, 5 suplidores activos + 1 inactivo,
   20 productos activos + 2 inactivos.
   ============================================================ */
USE SistemaInventario;
GO

-- Limpieza para poder re-ejecutar el script (y reiniciar los Id)
DELETE FROM dbo.Productos;
DELETE FROM dbo.FotosCategoria;
DELETE FROM dbo.Suplidores;
DELETE FROM dbo.Categorias;
DBCC CHECKIDENT ('dbo.Productos',       RESEED, 0);
DBCC CHECKIDENT ('dbo.FotosCategoria',  RESEED, 0);
DBCC CHECKIDENT ('dbo.Suplidores',      RESEED, 0);
DBCC CHECKIDENT ('dbo.Categorias',      RESEED, 0);
GO

-- Categorías (Id 1 a 7)
INSERT INTO dbo.Categorias (Nombre, Descripcion, Activo) VALUES
(N'Bebidas',          N'Aguas, jugos, refrescos, café y té.',                         1), -- 1
(N'Lácteos y Huevos', N'Leche, quesos, yogurt, mantequilla y huevos.',                1), -- 2
(N'Limpieza',         N'Productos de limpieza y desinfección para el hogar.',         1), -- 3
(N'Electrónica',      N'Accesorios y dispositivos electrónicos de uso diario.',       1), -- 4
(N'Papelería',        N'Papel, cuadernos y artículos de oficina.',                    1), -- 5
(N'Mascotas',         N'Alimento y accesorios para mascotas (sin productos aún).',    1), -- 6
(N'Juguetes',         N'Juguetes y juegos. Categoría descontinuada (en papelera).',   0); -- 7
GO

-- Suplidores (Id 1 a 6)
INSERT INTO dbo.Suplidores (NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb, Activo) VALUES
(N'Distribuidora Caribe SRL',   N'María Fernández', N'809-555-0101', N'mfernandez@distcaribe.com.do',  N'https://www.distcaribe.com.do',   1), -- 1
(N'Lácteos del Cibao SA',       N'Juan Pérez',      N'829-555-0102', N'jperez@lacteoscibao.com.do',     N'https://www.lacteoscibao.com.do', 1), -- 2
(N'TecnoImport Dominicana',     N'Luis Ramírez',    N'849-555-0103', N'lramirez@tecnoimport.com.do',    N'https://www.tecnoimport.com.do',  1), -- 3
(N'Papelería Moderna',          N'Ana Martínez',    N'809-555-0104', N'amartinez@papmoderna.com.do',    NULL,                               1), -- 4
(N'Limpieza Total',             N'Carlos Gómez',    N'829-555-0105', N'cgomez@limpiezatotal.com.do',    N'https://www.limpiezatotal.com.do',1), -- 5
(N'Importadora Antillana',      N'Rosa Jiménez',    N'849-555-0106', N'rjimenez@antillana.com.do',      NULL,                               0); -- 6 (inactivo)
GO

-- Productos: 20 activos + 2 inactivos
-- (Nombre, Precio, CategoriaId, SuplidorId, Activo)
INSERT INTO dbo.Productos (Nombre, Precio, CategoriaId, SuplidorId, Activo) VALUES
-- Bebidas (8)
(N'Agua purificada 5 galones',  120.00, 1, 1, 1),
(N'Jugo de naranja 1L',          95.50, 1, 1, 1),
(N'Refresco cola 2L',            85.00, 1, 1, 1),
(N'Café molido 1 lb',           310.00, 1, 1, 1),
(N'Té verde caja 20 sobres',    145.75, 1, 1, 1),
(N'Malta 355 ml',                45.00, 1, 1, 1),
(N'Agua mineral 1L',             60.00, 1, 1, 1),
(N'Bebida energizante 473 ml',  110.00, 1, 1, 1),
-- Lácteos y Huevos (5)
(N'Leche entera 1L',             78.00, 2, 2, 1),
(N'Queso blanco 1 lb',          185.00, 2, 2, 1),
(N'Yogurt natural 1L',          120.00, 2, 2, 1),
(N'Mantequilla 250 g',          135.25, 2, 2, 1),
(N'Huevos cartón 30 unidades',  260.00, 2, 2, 1),
-- Limpieza (4)
(N'Detergente en polvo 1 kg',   210.00, 3, 5, 1),
(N'Cloro 1 galón',               95.00, 3, 5, 1),
(N'Desinfectante 900 ml',       130.50, 3, 5, 1),
(N'Esponjas paquete de 3',       55.00, 3, 5, 1),
-- Electrónica (2)
(N'Audífonos inalámbricos',    1850.00, 4, 3, 1),
(N'Cargador USB-C 20W',         695.00, 4, 3, 1),
-- Papelería (1)
(N'Resma de papel carta',       485.00, 5, 4, 1),
-- Productos inactivos (para probar la Papelera)
(N'Cuaderno universitario',      65.00, 5, 4, 0),
(N'Cable HDMI 2 m',             350.00, 4, 3, 0);
GO

-- Verificación rápida
SELECT 'Categorias' AS Tabla, COUNT(*) AS Total, SUM(CAST(Activo AS INT)) AS Activos FROM dbo.Categorias
UNION ALL SELECT 'Suplidores', COUNT(*), SUM(CAST(Activo AS INT)) FROM dbo.Suplidores
UNION ALL SELECT 'Productos',  COUNT(*), SUM(CAST(Activo AS INT)) FROM dbo.Productos;
GO
