USE [tiempoygestion]
GO

/****** Object:  Table [dbo].[archivos]    Script Date: 14/11/2016 8:21:23 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[archivos](
	[IdArchivo] [int] NOT NULL,
	[Descripcion] [varchar](256) NULL,
	[path] [varchar](41) NOT NULL,
	[extension] [varchar](4) NOT NULL,
	[idInforme] [numeric](10, 0) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


