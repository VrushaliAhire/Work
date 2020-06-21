
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspSaveSensorData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspSaveSensorData]
GO

DROP TYPE tvpSensorData


-- ================================
-- Create User-defined Table Type
-- ================================


-- Create the data type
CREATE TYPE tvpSensorData AS TABLE 
(
	ZoneName NVARCHAR(5) NULL,
	SensorString NVARCHAR(50) NULL

)
GO
