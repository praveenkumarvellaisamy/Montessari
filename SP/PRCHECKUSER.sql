CREATE PROCEDURE PRCHECKUSER
(
	@USERNAME		VARCHAR(100)
	,@PASSWORD	NVARCHAR(200)
)
AS
BEGIN
	DECLARE @VALIDUSER INT
	
	SELECT @VALIDUSER = 1
	FROM TBLUSER
	WHERE FLDUSERNAME = @USERNAME
	AND FLDPASSWORD = HASHBYTES('MD5', @PASSWORD)
	SELECT ISNULL(@VALIDUSER,0) AS FLDVALIDUSER
END