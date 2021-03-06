USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[informepartidadefuncion]    Script Date: 11/05/2014 14:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[informepartidadefuncion](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[Nombre] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[Apellido] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[NroDoc] [float] NULL,
	[Sexo] [int] NULL,
	[Fallecido] [int] NULL,
	[FechaFallecido] [datetime] NULL,
	[Acta] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Tomo] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Folio] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[LugarFallecimiento] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[observaciones] [text] COLLATE Modern_Spanish_CI_AS NULL,
	[fecha] [datetime] NULL CONSTRAINT [DF_informepartidadefuncion_fecha]  DEFAULT (getdate()),
 CONSTRAINT [PK_informepartidadefuncion] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[informepartidadefuncion]  WITH CHECK ADD  CONSTRAINT [FK_informepartidadefuncion_bandejaentrada] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[informepartidadefuncion] CHECK CONSTRAINT [FK_informepartidadefuncion_bandejaentrada]