USE [MFM_Simple]
GO

/****** Object:  Table [SimpleSchema].[EquityPricesTechSector]    Script Date: 11/4/2019 12:00:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SimpleSchema].[EquityPricesTechSector](
	[PrimaryID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NULL,
	[AAPL] [float] NULL,
	[AMZN] [float] NULL,
	[GOOG] [float] NULL,
	[FB] [float] NULL,
	[MSFT] [float] NOT NULL
) ON [PRIMARY]
GO


