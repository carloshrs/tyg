USE [tiempoygestion]
GO
/****** Object:  Table [dbo].[informepropiedadtransferido]    Script Date: 04/18/2011 11:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[informepropiedadtransferido](
	[idEncabezadoPadre] [numeric](18, 0) NOT NULL,
	[idEncabezado] [numeric](18, 0) NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_informepropiedadtransferido] PRIMARY KEY CLUSTERED 
(
	[idEncabezadoPadre] ASC,
	[idEncabezado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[informepropiedadtransferido]  WITH CHECK ADD  CONSTRAINT [FK_informepropiedadtransferido_bandejaentrada] FOREIGN KEY([idEncabezadoPadre])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[informepropiedadtransferido] CHECK CONSTRAINT [FK_informepropiedadtransferido_bandejaentrada]
GO
ALTER TABLE [dbo].[informepropiedadtransferido]  WITH CHECK ADD  CONSTRAINT [FK_informepropiedadtransferido_bandejaentrada1] FOREIGN KEY([idEncabezado])
REFERENCES [dbo].[bandejaentrada] ([idEncabezado])
GO
ALTER TABLE [dbo].[informepropiedadtransferido] CHECK CONSTRAINT [FK_informepropiedadtransferido_bandejaentrada1]