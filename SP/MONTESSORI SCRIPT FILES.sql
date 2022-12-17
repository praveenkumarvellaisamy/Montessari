CREATE TABLE TBLUSER
(
	FLDUSERID				INT				NOT NULL PRIMARY KEY
	,FLDUSERNAME			VARCHAR(100)
	,FLDEMAIL				VARCHAR(100)
	,FLDPASSWORD			VARBINARY(200)
	,FLDEMAILVERIFIEDYN		TINYINT
	,FLDMOBILENO			VARCHAR(20)
	,FLDMOBILENOVERIFIEDYN	TINYINT
	,FLDCREATEDDATE			DATETIME
	,FLDCREATEDBY			INT
	,FLDMODIFIEDDATE		DATETIME
	,FLDMODIFIEDBY			INT
	,FLDISACTIVE			INT	NOT NULL CONSTRAINT DF_TBLUSER_ISACTIVE DEFAULT(1)
)
GO
CREATE TABLE TBLUSERPROFILE
(
	FLDUSERPROFILEID		INT				NOT NULL PRIMARY KEY
	,FLDUSERID				INT				FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDFIRSTNAME			VARCHAR(100)
	,FLDLASTNAME			VARCHAR(100)
	,FLDMIDDLENAME			VARCHAR(100)
	,FLDDOB					DATE
	,FLDREGISTRATIONDATE	DATE
	,FLDCOUNTRYCODE			INT
	,FLDGENDER				VARCHAR(100)
	,FLDQUALIFICATION		VARCHAR(100)
	,FLDOCCUPATION			VARCHAR(100)
	,FLDANNUALINCODE		VARCHAR(100)
	,FLDDEFAULTPAYMENTCARD	INT				--FOREIGN KEY REFERENCES TBLUSERCREDITCARD(FLDCARDID)
	,FLDPHOTOPATH			NVARCHAR(MAX)
	,FLDCREATEDDATE			DATETIME
	,FLDCREATEDBY			INT
	,FLDMODIFIEDDATE		DATETIME
	,FLDMODIFIEDBY			INT
)
GO

CREATE TABLE TBLCHILD
(
	FLDCHILDID			INT				NOT NULL PRIMARY KEY
	,FLDUSERID			INT				FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDUSERPROFILEID	INT				FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDFIRSTNAME		VARCHAR(100)
	,FLDMIDDLENAME		VARCHAR(100)
	,FLDLASTNAME		VARCHAR(100)
	,FLDDOB				DATE
	,FLDGENDER			VARCHAR(100)
	,FLDPHOTOPATH		NVARCHAR(MAX)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLUSERCREDITCARD
(
	FLDCARDID			INT				NOT NULL PRIMARY KEY
	,FLDUSERID			INT				FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDUSERPROFILEID	INT				FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDCARDHOLDERNAME	VARCHAR(100)
	,FLDCARDTYPE		VARCHAR(10)
	,FLDCARDNUMBER		VARCHAR(50)
	,FLDEXPIRYDATE		DATE
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLCHILDPICKUPPERSON
(
	FLDCHILDPICKUPPERSONID	INT				NOT NULL PRIMARY KEY
	,FLDCHILDID				INT				FOREIGN KEY REFERENCES TBLCHILD(FLDCHILDID)
	,FLDUSERID				INT				FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDUSERPROFILEID		INT				FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDPERSONNAME			VARCHAR(100)
	,FLDPHONE				VARCHAR(20)
	,FLDPHOTOPATH			NVARCHAR(MAX)
	,FLDSAMEASPARENTYN		TINYINT
	,FLDCREATEDDATE			DATETIME
	,FLDCREATEDBY			INT
	,FLDMODIFIEDDATE		DATETIME
	,FLDMODIFIEDBY			INT
)
GO

CREATE TABLE TBLORGANISATION
(
	FLDORGANISATIONID	INT				NOT NULL PRIMARY KEY
	,FLDORGNAME			VARCHAR(100)
	,FLDORGREGNUMBER	VARCHAR(100)
	,FLDADDRESSLINE1	VARCHAR(100)
	,FLDADDRESSLINE2	VARCHAR(100)
	,FLDADDRESSLINE3	VARCHAR(100)
	,FLDCOUNTRY			VARCHAR(50)
	,FLDSTATE			VARCHAR(50)
	,FLDCITY			VARCHAR(50)
	,FLDOFFICEPH		VARCHAR(20)
	,FLDMOBILEPH		VARCHAR(20)
	,FLDLONGITUDE		VARCHAR(50)
	,FLDLATITUDE		VARCHAR(50)
	,FLDBASECURRENCY	VARCHAR(4)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLBRANCH
(
	FLDBRANCHID			INT				NOT NULL PRIMARY KEY
	,FLDBRANCHNAME		VARCHAR(100)
	,FLDADDRESSLINE1	VARCHAR(100)
	,FLDADDRESSLINE2	VARCHAR(100)
	,FLDADDRESSLINE3	VARCHAR(100)
	,FLDCOUNTRY			VARCHAR(50)
	,FLDSTATE			VARCHAR(50)
	,FLDCITY			VARCHAR(50)
	,FLDBRANCHPH		VARCHAR(20)
	,FLDMOBILEPH		VARCHAR(20)
	,FLDCONTACTPERSON	VARCHAR(100)
	,FLDLONGITUDE		VARCHAR(50)
	,FLDLATITUDE		VARCHAR(50)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLSLOTS
(
	FLDSLOTID			INT			NOT NULL PRIMARY KEY
	,FLDSLOTNAME		VARCHAR(100)
	,FLDSTARTTIME		TIME
	,FLDENDTIME			TIME
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLSLOTBRANCHMAP
(
	FLDSLOTMAPID		INT	NOT NULL PRIMARY KEY
	,FLDBRANCHID		INT	FOREIGN KEY REFERENCES TBLBRANCH(FLDBRANCHID)
	,FLDSLOTID			INT	FOREIGN KEY REFERENCES TBLSLOTS(FLDSLOTID)
	,FLDMAXCHILD		INT
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLPLANS
(
	FLDPLANID						INT NOT NULL PRIMARY KEY
	,FLDPLANNAME					VARCHAR(100)
	,FLDTIMECHANGEYN				TINYINT
	,FLDDAYWEEKCHANGEYN				TINYINT
	,FLDDURATIONFLEXIBILITYYN		TINYINT
	,FLDCANCELLATIONYN				TINYINT
	,FLDWAITLISTYN					TINYINT
	,FLDGUESTSYN					TINYINT
	,FLDFOODYN						TINYINT
	,FLDLATEFEEYN					TINYINT
	,FLDLATEFEEBILLCYCLE			INT
	,FLDENTRYOUTYN					TINYINT
	,FLDREFERALBENEFITYN			TINYINT
	,FLDSCHEDULECOMMUNICATIONYN		TINYINT
	,FLDGALLERYYN					TINYINT
	,FLDNOTIFICATIONSYN				TINYINT
	,FLDCIRCULARYN					TINYINT
	,FLDSIBLINGYN					TINYINT
	,FLDPAYMENTYN					TINYINT
	,FLDTOTALHOURS					INT
	,FLDMAXHOURSINADAY				INT
	,FLDMAXDAYSFROMREGISTRATION		INT
	,FLDCREATEDDATE					DATETIME
	,FLDCREATEDBY					INT
	,FLDMODIFIEDDATE				DATETIME
	,FLDMODIFIEDBY					INT
)
GO

CREATE TABLE TBLAGEGROUP
(
	FLDAGEGROUPID		INT NOT NULL PRIMARY KEY
	,FLDNAME			VARCHAR(100)
	,FLDAGEFROM			INT
	,FLDAGETO			INT
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLSLOTBOOKING
(
	FLDSLOTBOOKINGID	INT NOT NULL PRIMARY KEY
	,FLDBOOKINGID		INT	--FOREIGN KEY REFERENCES TBLBRANCH(FLDBOOKINGID)
	,FLDUSERID			INT FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDUSERPROFILEID	INT	FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDCHILDID			INT	FOREIGN KEY REFERENCES TBLCHILD(FLDCHILDID)
	,FLDBRANCHID		INT	FOREIGN KEY REFERENCES TBLBRANCH(FLDBRANCHID)
	,FLDSLOTID			INT	FOREIGN KEY REFERENCES TBLSLOTS(FLDSLOTID)
	,FLDDATE			DATE
	,FLDSTATUS			VARCHAR(10)
	,FLDBOOKINGNUMBER	VARCHAR(10)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLSLOBBOOKINGSUMMARY
(
	FLDSLOBBOOKINGSUMMARYID		INT NOT NULL PRIMARY KEY
	,FLDBRANCHID				INT	FOREIGN KEY REFERENCES TBLBRANCH(FLDBRANCHID)
	,FLDDATE					DATE
	,FLDSLOTID					INT	FOREIGN KEY REFERENCES TBLSLOTS(FLDSLOTID)
	,FLDBOOKINGCOUNT			INT
	,FLDAVAILABLECOUNT			INT
	,FLDCREATEDDATE				DATETIME
	,FLDCREATEDBY				INT
	,FLDMODIFIEDDATE			DATETIME
	,FLDMODIFIEDBY				INT
)
GO

CREATE TABLE TBLPAYMENT
(
	FLDPAYMENTID			INT NOT NULL PRIMARY KEY
	,FLDBOOKINGID			INT	--FOREIGN KEY REFERENCES TBLSLOTBOOKING(FLDSLOTBOOKINGID)
	,FLDUSERID				INT FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDUSERPROFILEID		INT	FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDTRANSACTIONREFNO	VARCHAR(50)
	,FLDDATE				DATE
	,FLDAMOUNT				DECIMAL(10,2)
	,FLDSTATUS				VARCHAR(10)
	,FLDAPIRESPONSEMESSAGE	NVARCHAR(MAX)
	,FLDCREATEDDATE			DATETIME
	,FLDCREATEDBY			INT
	,FLDMODIFIEDDATE		DATETIME
	,FLDMODIFIEDBY			INT
)
GO

CREATE TABLE TBLSTAFF
(
	FLDSTAFFID			INT NOT NULL PRIMARY KEY
	,FLDNAME			VARCHAR(100)
	,FLDUSERNAME		VARCHAR(100)
	,FLDPASSWORD		VARCHAR(10)
	,FLDCONTACTNO		VARCHAR(20)
	,FLDEMAILID			VARCHAR(50)
	,FLDGENDER			VARCHAR(10)
	,FLDDOJ				DATE
	,FLDROLE			VARCHAR(50)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLSTAFFBRANCH
(
	FLDSTAFFBRANCHID	INT NOT NULL PRIMARY KEY
	,FLDSTAFFID			INT FOREIGN KEY REFERENCES TBLSTAFF(FLDSTAFFID)
	,FLDBRANCHID		INT FOREIGN KEY REFERENCES TBLBRANCH(FLDBRANCHID)
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO

CREATE TABLE TBLATTENDANCE
(
	FLDATTENDANCEID		INT NOT NULL PRIMARY KEY
	,FLDDATE			DATE
	,FLDSLOTID			INT FOREIGN KEY REFERENCES TBLSLOTS(FLDSLOTID)
	,FLDBOOKINGID		INT --FOREIGN KEY REFERENCES TBLSLOTBOOKING(FLDSLOTBOOKINGID)
	,FLDUSERPROFILEID	INT	FOREIGN KEY REFERENCES TBLUSERPROFILE(FLDUSERPROFILEID)
	,FLDCHILDID			INT	FOREIGN KEY REFERENCES TBLCHILD(FLDCHILDID)
	,FLDINTIME			DATETIME
	,FLDOUTTIME			DATETIME
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO
CREATE TABLE TBLUSEROTP
(
	FLDUSEROTPID		INT	NOT NULL PRIMARY KEY
	,FLDUSERID			INT	FOREIGN KEY REFERENCES TBLUSER(FLDUSERID)
	,FLDOTP				BIGINT
	,FLDISACTIVE		INT
	,FLDCREATEDDATE		DATETIME
	,FLDCREATEDBY		INT
	,FLDMODIFIEDDATE	DATETIME
	,FLDMODIFIEDBY		INT
)
GO