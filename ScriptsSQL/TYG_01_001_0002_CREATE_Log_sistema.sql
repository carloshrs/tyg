USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[log]    Script Date: 04/10/2012 18:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[log](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idTipo] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[evento] [varchar](255) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[descripcion] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[fecha] [datetime] NOT NULL CONSTRAINT [DF_Log_fecha]  DEFAULT (getdate()),
	[ip] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[logTipos]    Script Date: 04/10/2012 18:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[logTipos](
	[id] [int] NOT NULL,
	[descripcion] [varchar](250) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[activo] [tinyint] NOT NULL,
 CONSTRAINT [PK_LogTipos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LogTipos] FOREIGN KEY([idTipo])
REFERENCES [dbo].[logTipos] ([id])
GO
ALTER TABLE [dbo].[log] CHECK CONSTRAINT [FK_Log_LogTipos]