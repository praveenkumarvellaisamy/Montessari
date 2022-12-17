CREATE PROCEDURE PRAGEGROUPINSERT  
(		
	 @NAME				VARCHAR(100)
	,@AGEFROM			INT
	,@AGETO				INT
	,@USERCODE			INT
)
AS
BEGIN
	DECLARE @AGEGROUPID INT

	SELECT @AGEGROUPID = MAX(FLDAGEGROUPID)
	FROM TBLAGEGROUP

	INSERT INTO TBLAGEGROUP
	(
		 FLDAGEGROUPID
		,FLDNAME
		,FLDAGEFROM
		,FLDAGETO
		,FLDCREATEDDATE
		,FLDCREATEDBY
		,FLDMODIFIEDDATE
		,FLDMODIFIEDBY
	)
	SELECT ISNULL(@AGEGROUPID,0) + 1
		,@NAME
		,@AGEFROM
		,@AGETO
		,GETUTCDATE()
		,@USERCODE
		,GETUTCDATE()
		,@USERCODE
END