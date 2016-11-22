USE [tiempoygestion]
GO

/****** Object:  Table [dbo].[informemorosidad]    Script Date: 22/11/2016 11:47:19 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[informepartidadefuncion](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[Nombre] [varchar](201) NULL,
	[Apellido] [varchar](201) NULL,
	[IdTipoDoc] [smallint] NULL,
	[NroDoc] [varchar](50) NULL,
	[Cuit] [varchar](46) NULL,
	[Observaciones] [text] NULL,
 CONSTRAINT [PK_informepartidadefuncion1] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[informepartidadefuncion]  WITH CHECK ADD  CONSTRAINT [FK_informepartidadefuncion_bandejaentrada1] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO

ALTER TABLE [dbo].[informepartidadefuncion] CHECK CONSTRAINT [FK_informepartidadefuncion_bandejaentrada1]
GO


