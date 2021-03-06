USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[informesCambioEstado]    Script Date: 01/13/2011 17:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[informesCambioEstado](
	[idTipoGrupo] [int] NOT NULL,
	[idInforme] [numeric](18, 0) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_informesCambioEstado_1] PRIMARY KEY CLUSTERED 
(
	[idTipoGrupo] ASC,
	[idInforme] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[informesGrupoCambioEstado]    Script Date: 01/13/2011 17:34:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[informesGrupoCambioEstado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[fecha] [datetime] NOT NULL CONSTRAINT [DF_informesGrupoCambioEstado_fecha]  DEFAULT (getdate()),
 CONSTRAINT [PK_informesGrupoEstado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[informesCambioEstado]  WITH CHECK ADD  CONSTRAINT [FK_informesCambioEstado_informesGrupoCambioEstado] FOREIGN KEY([idTipoGrupo])
REFERENCES [dbo].[informesGrupoCambioEstado] ([id])
GO
ALTER TABLE [dbo].[informesCambioEstado] CHECK CONSTRAINT [FK_informesCambioEstado_informesGrupoCambioEstado]