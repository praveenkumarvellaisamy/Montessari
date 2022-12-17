CREATE PROCEDURE PRSLOTSLIST
(	
	@SLOTID		INT	=	NULL
)
AS
BEGIN
	SELECT 
		 FLDSLOTID
		,FLDSLOTNAME
		,FLDSTARTTIME
		,FLDENDTIME
	FROM TBLSLOTS
	WHERE (@SLOTID IS NULL OR FLDSLOTID = @SLOTID)
END