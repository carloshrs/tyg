ALTER TABLE [dbo].[automotorestitulares]
ADD

	[Calle] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[CalleNro] [varchar](21) COLLATE Modern_Spanish_CI_AS NULL,
	[Piso] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[Depto] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[CP] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[Barrio] [varchar](251) COLLATE Modern_Spanish_CI_AS NULL,
	[idLocalidad] [int] NULL,
	[idProvincia] [int] NULL,
	[CPEmpresa] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[BarrioEmpresa] [varchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[PisoEmpresa] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[DptoEmpresa] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[NroEmpresa] [varchar](11) COLLATE Modern_Spanish_CI_AS NULL,
	[CalleEmpresa] [varchar](256) COLLATE Modern_Spanish_CI_AS NULL,
	[TelefonoEmpresa] [varchar](46) COLLATE Modern_Spanish_CI_AS NULL,
	[ProvinciaEmpresa] [int] NULL,
	[LocalidadEmpresa] [int] NULL

