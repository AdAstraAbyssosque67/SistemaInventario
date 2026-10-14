/* ============================================================
   schema.sql - Sistema de Inventario (SQL Server / LocalDB)
   Re-ejecutable: borra y recrea las tablas.
   Si usas sqlcmd, ejecútalo con -I (QUOTED_IDENTIFIER ON).
   ============================================================ */
SET QUOTED_IDENTIFIER ON;
GO

IF DB_ID('SistemaInventario') IS NULL
    CREATE DATABASE SistemaInventario;
GO

USE SistemaInventario;
GO

-- 1. Eliminar tablas (orden inverso a las dependencias)
DROP TABLE IF EXISTS dbo.Productos;
DROP TABLE IF EXISTS dbo.FotosCategoria;
DROP TABLE IF EXISTS dbo.Suplidores;
DROP TABLE IF EXISTS dbo.Categorias;
GO

-- 2. Categorias
CREATE TABLE dbo.Categorias (
    Id                INT IDENTITY(1,1) NOT NULL,
    Nombre            NVARCHAR(100)     NOT NULL,
    Descripcion       NVARCHAR(500)     NOT NULL,
    Activo            BIT               NOT NULL CONSTRAINT DF_Categorias_Activo DEFAULT 1,
    FechaCreacion     DATETIME2         NOT NULL CONSTRAINT DF_Categorias_FechaCreacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2         NULL,
    CONSTRAINT PK_Categorias PRIMARY KEY (Id),
    CONSTRAINT CK_Categorias_Nombre CHECK (LEN(Nombre) >= 3)
);
GO

-- Nombre único solo entre registros activos (permite recrear uno que está en la papelera)
CREATE UNIQUE INDEX UX_Categorias_Nombre
    ON dbo.Categorias (Nombre) WHERE Activo = 1;
GO

-- 3. Suplidores
CREATE TABLE dbo.Suplidores (
    Id                INT IDENTITY(1,1) NOT NULL,
    NombreEmpresa     NVARCHAR(150)     NOT NULL,
    NombreContacto    NVARCHAR(100)     NOT NULL,
    Telefono          NVARCHAR(12)      NOT NULL,
    Email             NVARCHAR(150)     NOT NULL,
    SitioWeb          NVARCHAR(300)     NULL,
    Activo            BIT               NOT NULL CONSTRAINT DF_Suplidores_Activo DEFAULT 1,
    FechaCreacion     DATETIME2         NOT NULL CONSTRAINT DF_Suplidores_FechaCreacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2         NULL,
    CONSTRAINT PK_Suplidores PRIMARY KEY (Id),
    CONSTRAINT CK_Suplidores_NombreEmpresa CHECK (LEN(NombreEmpresa) >= 1),
    -- Red de seguridad; la validación real está en la capa de Lógica de Negocio
    CONSTRAINT CK_Suplidores_Telefono CHECK (
        Telefono LIKE '809-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]' OR
        Telefono LIKE '829-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]' OR
        Telefono LIKE '849-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')
);
GO

CREATE UNIQUE INDEX UX_Suplidores_NombreEmpresa
    ON dbo.Suplidores (NombreEmpresa) WHERE Activo = 1;
GO

-- 4. FotosCategoria (0 a 5 por categoría; el máximo se valida en C#)
CREATE TABLE dbo.FotosCategoria (
    Id             INT IDENTITY(1,1) NOT NULL,
    CategoriaId    INT               NOT NULL,
    NombreArchivo  NVARCHAR(260)     NOT NULL,
    Imagen         VARBINARY(MAX)    NOT NULL,
    FechaCreacion  DATETIME2         NOT NULL CONSTRAINT DF_FotosCategoria_FechaCreacion DEFAULT SYSDATETIME(),
    CONSTRAINT PK_FotosCategoria PRIMARY KEY (Id),
    CONSTRAINT FK_FotosCategoria_Categorias FOREIGN KEY (CategoriaId)
        REFERENCES dbo.Categorias (Id) ON DELETE CASCADE
);
GO

CREATE INDEX IX_FotosCategoria_CategoriaId ON dbo.FotosCategoria (CategoriaId);
GO

-- 5. Productos
CREATE TABLE dbo.Productos (
    Id                INT IDENTITY(1,1) NOT NULL,
    Nombre            NVARCHAR(150)     NOT NULL,
    Precio            DECIMAL(18,2)     NOT NULL,
    CategoriaId       INT               NOT NULL,
    SuplidorId        INT               NOT NULL,
    Activo            BIT               NOT NULL CONSTRAINT DF_Productos_Activo DEFAULT 1,
    FechaCreacion     DATETIME2         NOT NULL CONSTRAINT DF_Productos_FechaCreacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2         NULL,
    CONSTRAINT PK_Productos PRIMARY KEY (Id),
    CONSTRAINT CK_Productos_Nombre CHECK (LEN(Nombre) >= 1),
    CONSTRAINT CK_Productos_Precio CHECK (Precio > 0),
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (CategoriaId) REFERENCES dbo.Categorias (Id),
    CONSTRAINT FK_Productos_Suplidores FOREIGN KEY (SuplidorId)  REFERENCES dbo.Suplidores (Id)
);
GO

CREATE INDEX IX_Productos_CategoriaId ON dbo.Productos (CategoriaId);
CREATE INDEX IX_Productos_SuplidorId  ON dbo.Productos (SuplidorId);
GO
