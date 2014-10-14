USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[CtaCteMovimientosRemitos]    Script Date: 09/11/2012 11:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtaCteMovimientosPartesEntrega](
	[nroMovimiento] [numeric](18, 0) NOT NULL,
	[nroParte] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_CtaCteMovimientosPartesEntrega] PRIMARY KEY CLUSTERED 
(
	[nroMovimiento] ASC,
	[nroParte] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CtaCteMovimientosPartesEntrega]  WITH CHECK ADD  CONSTRAINT [FK_ctaCteMovimientosPartesEntrega_CtaCtePartesEntrega] FOREIGN KEY([nroMovimiento])
REFERENCES [dbo].[CtaCtePartesEntrega] ([nroMovimiento])
GO
ALTER TABLE [dbo].[CtaCteMovimientosPartesEntrega] CHECK CONSTRAINT [FK_ctaCteMovimientosPartesEntrega_CtaCtePartesEntrega]
GO
ALTER TABLE [dbo].[CtaCteMovimientosPartesEntrega]  WITH CHECK ADD  CONSTRAINT [FK_ctaCteMovimientosPartesEntrega_partesEntrega] FOREIGN KEY([nroParte])
REFERENCES [dbo].[partesEntrega] ([nroParte])
GO
ALTER TABLE [dbo].[CtaCteMovimientosPartesEntrega] CHECK CONSTRAINT [FK_ctaCteMovimientosRemitos_partesEntrega]