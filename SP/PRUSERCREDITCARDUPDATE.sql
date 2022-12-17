CREATE PROCEDURE PRUSERCREDITCARDUPDATE
(	
	@CARDID				INT
	,@USERID			INT			
	,@USERPROFILEID		INT			
	,@CARDHOLDERNAME	VARCHAR(100)
	,@CARDTYPE			VARCHAR(10)
	,@CARDNUMBER		VARCHAR(50)
	,@EXPIRYDATE		DATE
	,@USERCODE			INT
)
AS
BEGIN
	UPDATE TBLUSERCREDITCARD
	SET FLDUSERID			=  @USERID			
		,FLDUSERPROFILEID	=  @USERPROFILEID	
		,FLDCARDHOLDERNAME	=  @CARDHOLDERNAME	
		,FLDCARDTYPE		=  @CARDTYPE		
		,FLDCARDNUMBER		=  @CARDNUMBER		
		,FLDEXPIRYDATE		=  @EXPIRYDATE				
		,FLDMODIFIEDDATE	= GETUTCDATE()
		,FLDMODIFIEDBY		= @USERCODE
	WHERE FLDCARDID			= @CARDID
END