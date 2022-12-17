CREATE PROCEDURE PRSTAFFBRANCHINSERT  
(		
	  @STAFFID			INT
	 ,@BRANCHID			INT
	 ,@USERCODE			INT
)
AS
BEGIN
	DECLARE @STAFFBRANCHID INT

	SELECT @STAFFBRANCHID = MAX(FLDSTAFFBRANCHID)
	FROM TBLSTAFFBRANCH

	INSERT INTO TBLSTAFFBRANCH
	(
		 FLDSTAFFBRANCHID
		,FLDSTAFFID
		,FLDBRANCHID
		,FLDCREATEDDATE
		,FLDCREATEDBY
		,FLDMODIFIEDDATE
		,FLDMODIFIEDBY
	)
	SELECT ISNULL(@STAFFBRANCHID,0) + 1
		,@STAFFID
		,@BRANCHID
		,GETUTCDATE()
		,@USERCODE
		,GETUTCDATE()
		,@USERCODE
END