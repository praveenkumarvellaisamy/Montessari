CREATE PROCEDURE PRORGANISATIONLIST
(	
	@ORGANISATIONID	INT	=	NULL
)
AS
BEGIN
	SELECT 
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
	FROM TBLORGANISATION
	WHERE (@ORGANISATIONID IS NULL OR FLDORGANISATIONID = @ORGANISATIONID)
END