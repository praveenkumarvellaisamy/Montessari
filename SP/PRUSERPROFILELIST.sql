CREATE PROCEDURE PRUSERPROFILELIST
(
	 @USERPROFILEID			INT		=	NULL
)
AS
BEGIN
	SELECT FLDUSERPROFILEID
			,FLDUSERID
			,FLDFIRSTNAME
			,FLDLASTNAME
			,FLDMIDDLENAME
			,FLDDOB
			,FLDREGISTRATIONDATE
			,FLDCOUNTRYCODE
			,FLDGENDER
			,FLDQUALIFICATION
			,FLDOCCUPATION
			,FLDANNUALINCODE
			,FLDDEFAULTPAYMENTCARD
			,FLDPHOTOPATH
	FROM TBLUSERPROFILE
	WHERE (@USERPROFILEID IS NULL OR FLDUSERPROFILEID	= @USERPROFILEID)
END