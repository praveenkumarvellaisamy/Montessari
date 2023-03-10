CREATE PROCEDURE PRPLANSLIST
(	
	@PLANID	INT	=	NULL
)
AS
BEGIN
	SELECT 
		 FLDPLANID
		,FLDPLANNAME
		,FLDTIMECHANGEYN
		,FLDDAYWEEKCHANGEYN
		,FLDDURATIONFLEXIBILITYYN
		,FLDCANCELLATIONYN
		,FLDWAITLISTYN
		,FLDGUESTSYN
		,FLDFOODYN
		,FLDLATEFEEYN
		,FLDLATEFEEBILLCYCLE
		,FLDENTRYOUTYN
		,FLDREFERALBENEFITYN
		,FLDSCHEDULECOMMUNICATIONYN
		,FLDGALLERYYN
		,FLDNOTIFICATIONSYN
		,FLDCIRCULARYN
		,FLDSIBLINGYN
		,FLDPAYMENTYN
		,FLDTOTALHOURS
		,FLDMAXHOURSINADAY
		,FLDMAXDAYSFROMREGISTRATION
	FROM TBLPLANS
	WHERE (@PLANID IS NULL OR FLDPLANID = @PLANID)
END