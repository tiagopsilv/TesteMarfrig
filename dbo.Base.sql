USE [SistemaComprasGado]
GO

IF OBJECT_ID('dbo.CompraGadoItem', 'U') IS NOT NULL 
  DROP TABLE dbo.CompraGadoItem; 

GO

IF OBJECT_ID('dbo.CompraGado', 'U') IS NOT NULL 
  DROP TABLE dbo.CompraGado; 

GO

IF OBJECT_ID('dbo.Pecuarista', 'U') IS NOT NULL 
  DROP TABLE dbo.Pecuarista; 

GO

IF OBJECT_ID('dbo.Animal', 'U') IS NOT NULL 
  DROP TABLE dbo.Animal; 

GO

/****** Object: Table [dbo].[Animal] Script Date: 02/05/2020 17:54:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Animal] (
    [ID]        INT NOT NULL PRIMARY KEY IDENTITY,
    [Descricao] VARCHAR (255) NULL,
    [Preco]     VARCHAR (255) NULL
);

GO

INSERT INTO [dbo].[Animal](Descricao, Preco) Values('Nelore', '1.600,00');
INSERT INTO [dbo].[Animal](Descricao, Preco) Values('Angus', '1.800,00');
INSERT INTO [dbo].[Animal](Descricao, Preco) Values('Hereford', '1.800,00');
INSERT INTO [dbo].[Animal](Descricao, Preco) Values('Wagyu', '1.900,00');

GO

/****** Object: Table [dbo].[Pecuarista] Script Date: 02/05/2020 17:54:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pecuarista] (
    [ID]   INT NOT NULL PRIMARY KEY IDENTITY,
    [Nome] VARCHAR (255) NULL
);

GO

INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 1');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 2');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 3');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 4');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 5');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 6');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 7');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 8');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 9');
INSERT INTO [dbo].[Pecuarista](Nome) Values('Pecuarista 10');

GO

/****** Object: Table [dbo].[CompraGado] Script Date: 02/05/2020 17:54:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompraGado] (
    [ID]        INT NOT NULL PRIMARY KEY,
    [DataEntrega] DATETIME NOT NULL,
    [PecuaristaId] INT FOREIGN KEY REFERENCES Pecuarista(ID)
);

GO

/****** Object: Table [dbo].[CompraGadoItem] Script Date: 02/05/2020 17:54:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompraGadoItem] (
    [ID]        INT NOT NULL PRIMARY KEY IDENTITY,
    [Quantidade] VARCHAR(500) NOT NULL,
    [CompraGadoId] INT FOREIGN KEY REFERENCES CompraGado(ID),
	[AnimalId] INT FOREIGN KEY REFERENCES Animal(ID),
);

GO

