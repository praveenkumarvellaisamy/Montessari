CREATE PROCEDURE PRSLOBBOOKINGSUMMARYLIST
(	
	@SLOBBOOKINGSUMMARYID	INT	=	NULL
)
AS
BEGIN
	SELECT 
		 FLDSLOBBOOKINGSUMMARYID
		,FLDBRANCHID
		,FLDDATE
		,FLDSLOTID
		,FLDBOOKINGCOUNT
		,FLDAVAILABLECOUNT
	FROM TBLSLOBBOOKINGSUMMARY
	WHERE (@SLOBBOOKINGSUMMARYID IS NULL OR FLDSLOBBOOKINGSUMMARYID = @SLOBBOOKINGSUMMARYID)
END