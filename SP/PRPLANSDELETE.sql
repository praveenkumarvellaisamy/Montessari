CREATE PROCEDURE PRPLANSDELETE
(	
	 @PLANID			INT	
	,@USERCODE			INT	=	NULL
)
AS
BEGIN
	DELETE FROM TBLPLANS
	WHERE FLDPLANID = @PLANID
END