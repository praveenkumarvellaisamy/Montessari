CREATE PROCEDURE PRSTAFFDELETE
(	
	 @STAFFID			INT	
	,@USERCODE			INT	=	NULL
)
AS
BEGIN
	DELETE FROM TBLSTAFF
	WHERE FLDSTAFFID = @STAFFID
END