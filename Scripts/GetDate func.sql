CREATE FUNCTION GetCurrentDate
()
RETURNS DATETIME
AS
BEGIN
	DECLARE @Result datetime
	DECLARE @systemTime datetime
	DECLARE @globalDate datetime
	SELECT TOP 1 @globalDate = CAST(Date AS date) FROM GlobalDate
	SELECT @systemTime = CAST(GETDATE() as time)
	SET @Result = @globalDate + @systemTime
	RETURN @Result
END
GO

