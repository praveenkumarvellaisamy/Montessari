CREATE PROCEDURE PRORGANISATIONINSERT  
(		
	  @ORGNAME					VARCHAR(100)
	, @ORGREGNUMBER				VARCHAR(100)
	, @ADDRESSLINE1				VARCHAR(100)
	, @ADDRESSLINE2				VARCHAR(100)
	, @ADDRESSLINE3				VARCHAR(100)
	, @COUNTRY					VARCHAR(50)
	, @STATE					VARCHAR(50)
	, @CITY						VARCHAR(50)
	, @OFFICEPH					VARCHAR(20)
	, @MOBILEPH					VARCHAR(20)
	, @LONGITUDE				VARCHAR(50)
	, @LATITUDE					VARCHAR(50)
	, @BASECURRENCY				VARCHAR(4)
	, @USERCODE					INT
)
AS
BEGIN
	DECLARE @ORGANISATIONID INT

	SELECT @ORGANISATIONID = MAX(FLDORGANISATIONID)
	FROM TBLORGANISATION

	INSERT INTO TBLORGANISATION
	(
		 FLDORGANISATIONID
		,FLDORGNAME
		,FLDORGREGNUMBER
		,FLDADDRESSLINE1
		,FLDADDRESSLINE2
		,FLDADDRESSLINE3
		,FLDCOUNTRY
		,FLDSTATE
		,FLDCITY
		,FLDOFFICEPH
		,FLDMOBILEPH
		,FLDLONGITUDE
		,FLDLATITUDE
		,FLDBASECURRENCY
		,FLDCREATEDDATE
		,FLDCREATEDBY
		,FLDMODIFIEDDATE
		,FLDMODIFIEDBY
	)
	SELECT ISNULL(@ORGANISATIONID,0) + 1
		,@ORGNAME
		,@ORGREGNUMBER
		,@ADDRESSLINE1
		,@ADDRESSLINE2
		,@ADDRESSLINE3
		,@COUNTRY
		,@STATE
		,@CITY
		,@OFFICEPH
		,@MOBILEPH
		,@LONGITUDE
		,@LATITUDE
		,@BASECURRENCY
		,GETUTCDATE()
		,@USERCODE
		,GETUTCDATE()
		,@USERCODE
END