CREATE PROCEDURE PRUSERPROFILEDELETE
(
	 @USERPROFILEID			INT		
)
AS
BEGIN
	DELETE FROM TBLUSERPROFILE
	WHERE FLDUSERPROFILEID	= @USERPROFILEID
END