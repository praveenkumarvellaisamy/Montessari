CREATE PROCEDURE PRSTAFFLIST
(	
	@STAFFID	INT	=	NULL
)
AS
BEGIN
	SELECT 
		FLDSTAFFID
		,FLDNAME
		,FLDUSERNAME
		,FLDPASSWORD
		,FLDCONTACTNO
		,FLDEMAILID
		,FLDGENDER
		,FLDDOJ
		,FLDROLE
	FROM TBLSTAFF
	WHERE (@STAFFID IS NULL OR FLDSTAFFID = @STAFFID)
END