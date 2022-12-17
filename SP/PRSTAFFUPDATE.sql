CREATE PROCEDURE PRSTAFFUPDATE
(	
	  @STAFFID			INT
	 ,@NAME				VARCHAR(100)
	 ,@USERNAME			VARCHAR(100)
	 ,@PASSWORD			VARCHAR(10)
	 ,@CONTACTNO		VARCHAR(10)
	 ,@EMAILID			VARCHAR(50)
	 ,@GENDER			VARCHAR(10)
	 ,@DOJ				DATE
	 ,@ROLE				VARCHAR(50)
	 ,@USERCODE			INT
)
AS
BEGIN
	UPDATE TBLSTAFF
	SET 
		 FLDNAME			= @NAME
		,FLDUSERNAME		= @USERNAME
		,FLDPASSWORD		= @PASSWORD
		,FLDCONTACTNO		= @CONTACTNO
		,FLDEMAILID			= @EMAILID
		,FLDGENDER			= @GENDER
		,FLDDOJ				= @DOJ
		,FLDROLE			= @ROLE
		,FLDMODIFIEDDATE	= GETUTCDATE()
		,FLDMODIFIEDBY		= @USERCODE
	WHERE FLDSTAFFID = @STAFFID
END