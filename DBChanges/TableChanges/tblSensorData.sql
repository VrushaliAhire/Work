USE [CarParking]
GO

/****** Object:  Table [dbo].[tblSensorsData]    Script Date: 6/26/2020 11:51:27 PM ******/
DROP TABLE [dbo].[tblSensorsData]
GO

/****** Object:  Table [dbo].[tblSensorsData]    Script Date: 6/26/2020 11:51:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSensorsData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SensorString] [nchar](50) NOT NULL,
	[ZoneName] [nchar](10) NOT NULL,
	[ModifiedOn] DATETIME NULL
 CONSTRAINT [PK_tblSensorsData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


