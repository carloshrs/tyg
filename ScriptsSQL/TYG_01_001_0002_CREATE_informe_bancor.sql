USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[ambientalbancor]    Script Date: 10/01/2010 11:27:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ambientalbancor](
	[IdInforme] [numeric](18, 0) NOT NULL,
	[IdTipoPersona] [int] NULL,
	[Nombre] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[Apellido] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[idEstadoCivil] [smallint] NULL,
	[IdTipoDoc] [smallint] NULL,
	[NroDoc] [float] NULL,
	[Calle] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[CalleNro] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Piso] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Depto] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Lote] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Manzana] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[CP] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Telefono] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Complejo] [varchar](150) COLLATE Modern_Spanish_CI_AS NULL,
	[Torre] [varchar](150) COLLATE Modern_Spanish_CI_AS NULL,
	[Email] [varchar](100) COLLATE Modern_Spanish_CI_AS NULL,
	[Barrio] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[idLocalidad] [int] NULL,
	[idProvincia] [int] NULL,
	[FechaVerificacion] [datetime] NULL,
	[HabitaLugar] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Antiguedad] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[TelefonoAlt] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[RelacionTitular] [varchar](150) COLLATE Modern_Spanish_CI_AS NULL,
	[idTipoVivienda] [smallint] NULL,
	[idDestino] [smallint] NULL,
	[idTipoConstruccion] [smallint] NULL,
	[idEstado] [smallint] NULL,
	[idTipoZona] [smallint] NULL,
	[idInteresado] [smallint] NULL,
	[AccesoDomicilio] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[Informo] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[Relacion] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[VecinalNombre] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[VecinalDomicilio] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[VecinalConoce] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[Observaciones] [text] COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoA] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoB] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoC] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoD] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoVecinoA] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoVecinoB] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoVecinoC] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[PlanoVecinoD] [varchar](201) COLLATE Modern_Spanish_CI_AS NULL,
	[idFoto] [smallint] NULL,
	[idResultado] [smallint] NULL,
 CONSTRAINT [PK_ambientalbancor] PRIMARY KEY CLUSTERED 
(
	[IdInforme] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ambientalbancor]  WITH CHECK ADD  CONSTRAINT [FK_ambientalbancor_bandejaentrada] FOREIGN KEY([IdInforme])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[ambientalbancor] CHECK CONSTRAINT [FK_ambientalbancor_bandejaentrada]