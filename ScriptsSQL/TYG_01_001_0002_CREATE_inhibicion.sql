USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[inhibiciones]    Script Date: 02/25/2011 17:54:25 ******/
DROP TABLE inhibiciones
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inhibiciones](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[idTipoPersona] [int] NULL,
	[Nombre] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[Apellido] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[IdTipoDoc] [smallint] NULL,
	[NroDoc] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Cuit] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[RazonSocial] [varchar](256) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Observaciones] [text] COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_inhibiciones] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[inhibicionesResultados]    Script Date: 02/25/2011 17:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inhibicionesResultados](
	[idResultado] [int] IDENTITY(1,1) NOT NULL,
	[IdInforme] [numeric](18, 0) NULL,
	[Medida] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Diario] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Ano] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Fecha] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[TipoMedida] [varchar](200) COLLATE Modern_Spanish_CI_AS NULL,
	[OrdenadoPor] [varchar](200) COLLATE Modern_Spanish_CI_AS NULL,
	[Secretaria] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[EnAutos] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[TipoBusqueda] [varchar](200) COLLATE Modern_Spanish_CI_AS NULL,
	[InmueblesGravados] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[AnotacionesDefinitivas] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_inhibicionesResultados] PRIMARY KEY CLUSTERED 
(
	[idResultado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[inhibiciones]  WITH CHECK ADD  CONSTRAINT [FK_inhibiciones_bandejaentrada] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[inhibiciones] CHECK CONSTRAINT [FK_inhibiciones_bandejaentrada]