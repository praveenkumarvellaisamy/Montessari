CREATE PROCEDURE PRUSERDELETE
(	
	@USERID					INT	
	,@USERCODE				INT	=	NULL
)
AS
BEGIN
	DELETE FROM TBLUSER
	WHERE FLDUSERID = @USERID
END