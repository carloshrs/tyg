USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[CtaCtePartesEntrega]    Script Date: 09/11/2012 11:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtaCtePartesEntrega](
	[nroMovimiento] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idUsuarioIntra] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_CtaCtePartesEntrega] PRIMARY KEY CLUSTERED 
(
	[nroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CtaCtePartesEntrega]  WITH CHECK ADD  CONSTRAINT [FK_CtaCtePartesEntrega_clientes] FOREIGN KEY([idCliente])
REFERENCES [dbo].[clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[CtaCtePartesEntrega] CHECK CONSTRAINT [FK_CtaCtePartesEntrega_clientes]