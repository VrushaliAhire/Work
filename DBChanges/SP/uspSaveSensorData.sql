IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspSaveSensorData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspSaveSensorData]
GO

------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE uspSaveSensorData
	@tvpSensorData tvpSensorData readonly
AS
BEGIN

DECLARE @sensorData as TABLE(
	ZoneName NVARCHAR(5) NULL,
	SensorString NVARCHAR(20) NULL,
	IsFound BIT Default 0
)

--insert input data in temp table
INSERT INTO @sensorData
(ZoneName, SensorString)
SELECT ZoneName, SensorString
FROM @tvpSensorData


--check for new data
UPDATE X
SET X.IsFound = 1
FROM @sensorData X
INNER JOIN tblSensorsData S
ON X.ZoneName = S.ZoneName



--INSERT new values

INSERT INTO tblSensorsData
(ZoneName, SensorString, ModifiedON)
SELECT ZoneName, SensorString, GETUTCDATE()
FROM @sensorData
WHERE IsFound = 0


---update already existing values

UPDATE X
SET X.SensorString = S.SensorString,
X.ModifiedOn = GETUTCDATE()
FROM tblSensorsData X
INNER JOIN @sensorData S
ON X.ZoneName = S.ZoneName
WHERE S.IsFound = 1
	
END
GO
