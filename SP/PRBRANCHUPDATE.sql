CREATE PROCEDURE PRBRANCHUPDATE
(	
	  @BRANCHID					INT
	 ,@BRANCHNAME				VARCHAR(100)
	 ,@ADDRESSLINE1				VARCHAR(100)
	 ,@ADDRESSLINE2				VARCHAR(100)
	 ,@ADDRESSLINE3				VARCHAR(100)
	 ,@COUNTRY					VARCHAR(50)
	 ,@STATE					VARCHAR(50)
	 ,@CITY						VARCHAR(50)
	 ,@BRANCHPH					VARCHAR(20)
	 ,@MOBILEPH					VARCHAR(20)
	 ,@CONTACTPERSON			VARCHAR(100)
	 ,@LONGITUDE				VARCHAR(50)
	 ,@LATITUDE					VARCHAR(50)
	 ,@USERCODE					INT
)
AS
BEGIN
	UPDATE TBLBRANCH
	SET 
		 FLDBRANCHNAME		= @BRANCHNAME		
		,FLDADDRESSLINE1	= @ADDRESSLINE1	
		,FLDADDRESSLINE2	= @ADDRESSLINE2	
		,FLDADDRESSLINE3	= @ADDRESSLINE3	
		,FLDCOUNTRY			= @COUNTRY			
		,FLDSTATE			= @STATE			
		,FLDCITY			= @CITY			
		,FLDBRANCHPH		= @BRANCHPH		
		,FLDMOBILEPH		= @MOBILEPH		
		,FLDCONTACTPERSON	= @CONTACTPERSON	
		,FLDLONGITUDE		= @LONGITUDE		
		,FLDLATITUDE		= @LATITUDE		
		,FLDMODIFIEDDATE	= GETUTCDATE()
		,FLDMODIFIEDBY		= @USERCODE
	WHERE FLDBRANCHID = @BRANCHID
END