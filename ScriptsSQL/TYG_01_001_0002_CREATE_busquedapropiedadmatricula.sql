USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[busquedapropiedadmatricula]    Script Date: 10/15/2010 15:51:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[busquedapropiedadmatricula](
	[IdMatricula] [int] IDENTITY(1,1) NOT NULL,
	[idInforme] [int] NULL,
	[PROPMatricula] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[PROPTipo] [smallint] NOT NULL,
	[PROPFolio] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[PROPTomo] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[PROPAno] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF