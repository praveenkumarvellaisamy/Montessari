CREATE PROCEDURE PRBRANCHDELETE
(	
	 @BRANCHID			INT	
	,@USERCODE						INT	=	NULL
)
AS
BEGIN
	DELETE FROM TBLBRANCH
	WHERE FLDBRANCHID = @BRANCHID
END