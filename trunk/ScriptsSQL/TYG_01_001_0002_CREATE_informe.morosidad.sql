USE [tiempoygestion]
GO

/****** Object:  Table [dbo].[ambientalbancor]    Script Date: 14/11/2016 7:41:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[informemorosidad](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[IdTipoPersona] [int] NULL,
	[Nombre] [varchar](201) NULL,
	[Apellido] [varchar](201) NULL,
	[IdTipoDoc] [smallint] NULL,
	[NroDoc] [varchar](50) NULL,
	[Cuit] [varchar](46) NULL,
	[RazonSocial] [varchar](256) NOT NULL,
	[Observaciones] [text] NULL,
	
 CONSTRAINT [PK_informemorosidad] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[informemorosidad]  WITH CHECK ADD  CONSTRAINT [FK_informemorosidad_bandejaentrada] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO

ALTER TABLE [dbo].[informemorosidad] CHECK CONSTRAINT [FK_informemorosidad_bandejaentrada]
GO


