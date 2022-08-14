USE [MFM_Simple]
GO

/****** Object:  Table [SimpleSchema].[EquityPricesMixSector]    Script Date: 11/4/2019 12:02:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SimpleSchema].[EquityPricesMixSector](
	[PrimaryID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NULL,
	[XOM] [float] NULL,
	[PEP] [float] NULL,
	[CAT] [float] NULL,
	[HON] [float] NULL,
	[GOOG] [float] NULL
) ON [PRIMARY]
GO


