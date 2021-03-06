USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[informecatastral]    Script Date: 10/26/2010 15:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[informecatastral](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[Calle] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[CalleNro] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Piso] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Depto] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[CP] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Barrio] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[idLocalidad] [int] NULL,
	[idProvincia] [int] NULL,
	[PH] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Lote] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Manzana] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Nomenclatura] [varchar](30) COLLATE Modern_Spanish_CI_AS NULL,
	[Ncuenta] [varchar](30) COLLATE Modern_Spanish_CI_AS NULL,
	[IdTipo] [int] NOT NULL,
	[Matricula] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[Folio] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Tomo] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Anio] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Observaciones] [text] COLLATE Modern_Spanish_CI_AS NULL,

 CONSTRAINT [PK_informecatastral] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[informecatastral]  WITH CHECK ADD  CONSTRAINT [FK_informecatastral_bandejaentrada] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[informecatastral] CHECK CONSTRAINT [FK_informecatastral_bandejaentrada]
GO
ALTER TABLE [dbo].[informecatastral]  WITH CHECK ADD  CONSTRAINT [FK_informecatastral_tipopropiedad] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[tipopropiedad] ([IdTipoPropiedad])
GO
ALTER TABLE [dbo].[informecatastral] CHECK CONSTRAINT [FK_informecatastral_tipopropiedad]