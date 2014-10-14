USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[remitoadicionales]    Script Date: 09/04/2012 18:40:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partesEntrega](
	[nroParte] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idUsuarioIntra] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[estado] [int] NOT NULL CONSTRAINT [DF_partesEntrega_estado]  DEFAULT ((1)),
	[periodoCobranza] [int] NOT NULL CONSTRAINT [DF_partesEntrega_tipoCobranza]  DEFAULT ((1)),
 CONSTRAINT [PK_partesEntrega] PRIMARY KEY CLUSTERED 
(
	[nroParte] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parteEntregaAdicionales](
	[nroParte] [numeric](18, 0) NOT NULL,
	[idAdicional] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[facturado] [tinyint] NOT NULL CONSTRAINT [DF_parteEntregaAdicionales_facturado]  DEFAULT ((0)),
 CONSTRAINT [PK_parteEntregaAdicionales] PRIMARY KEY CLUSTERED 
(
	[nroParte] ASC,
	[idAdicional] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[remitoinforme]    Script Date: 09/04/2012 18:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].parteEntregaInforme](
	[nroParte] [numeric](18, 0) NOT NULL,
	[idEncabezado] [numeric](18, 0) NOT NULL,
	[idTipoInforme] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[facturado] [tinyint] NOT NULL CONSTRAINT [DF_parteEntregaInforme_facturado]  DEFAULT ((0)),
 CONSTRAINT [PK_parteEntregaInforme] PRIMARY KEY CLUSTERED 
(
	[nroParte] ASC,
	[idEncabezado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[remitos]    Script Date: 09/04/2012 18:40:21 ******/
SET ANSI_NULLS ON
GO

ALTER TABLE [dbo].[parteEntregaAdicionales]  WITH CHECK ADD  CONSTRAINT [FK_parteEntregaAdicionales_partesEntrega] FOREIGN KEY([nroParte])
REFERENCES [dbo].[partesEntrega] ([nroParte])
GO
ALTER TABLE [dbo].[parteEntregaAdicionales] CHECK CONSTRAINT [FK_parteEntregaAdicionales_partesEntrega]
GO
ALTER TABLE [dbo].[parteEntregaAdicionales]  WITH CHECK ADD  CONSTRAINT [FK_parteEntregaAdicionales_serviciosAdicionales] FOREIGN KEY([idAdicional])
REFERENCES [dbo].[serviciosAdicionales] ([id])
GO
ALTER TABLE [dbo].[parteEntregaAdicionales] CHECK CONSTRAINT [FK_parteEntregaAdicionales_serviciosAdicionales]
GO
ALTER TABLE [dbo].[parteEntregaInforme]  WITH CHECK ADD  CONSTRAINT [FK_parteEntregaInforme_bandejaentrada] FOREIGN KEY([idEncabezado])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[parteEntregaInforme] CHECK CONSTRAINT [FK_parteEntregaInforme_bandejaentrada]
GO
ALTER TABLE [dbo].[parteEntregaInforme]  WITH CHECK ADD  CONSTRAINT [FK_parteEntregaInforme_partesEntrega] FOREIGN KEY([nroParte])
REFERENCES [dbo].[partesEntrega] ([nroParte])
GO
ALTER TABLE [dbo].[parteEntregaInforme] CHECK CONSTRAINT [FK_parteEntregaInforme_partesEntrega]
GO
ALTER TABLE [dbo].[parteEntregaInforme]  WITH CHECK ADD  CONSTRAINT [FK_remitoinforme_tiposinformes] FOREIGN KEY([idTipoInforme])
REFERENCES [dbo].[tiposinformes] ([idTipoInforme])
GO
ALTER TABLE [dbo].[parteEntregaInforme] CHECK CONSTRAINT [FK_parteEntregaInforme_tiposinformes]