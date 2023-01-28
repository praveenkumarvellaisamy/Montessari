using SparklesAPI.FrameWork;
using SparklesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SparklesAPI.Controllers
{
    [Route("api")]
    [Authorize]
    public class UserProfileController : ApiController
    {
        [HttpPost]
        [Route("api/GetUserProfile")]
        [AllowAnonymous]
        public List<UserProfile> GetUserProfile(UserProfile objUserProfile)
        {
            List<UserProfile> lstUserProfile = new List<UserProfile>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserProfileID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERPROFILELIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objUserProfile.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objUserProfile.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objUserProfile.FirstName = items["FLDFIRSTNAME"].ToString();
                    objUserProfile.LastName = items["FLDLASTNAME"].ToString();
                    objUserProfile.MiddleName = items["FLDMIDDLENAME"].ToString();
                    objUserProfile.DOB = Convert.ToDateTime(items["FLDDOB"].ToString());
                    objUserProfile.RegistrationDate = Convert.ToDateTime(items["FLDREGISTRATIONDATE"].ToString());
                    objUserProfile.CountryCode = Convert.ToInt16(items["FLDCOUNTRYCODE"].ToString());
                    objUserProfile.Gender = items["FLDGENDER"].ToString();
                    objUserProfile.Qualification = items["FLDQUALIFICATION"].ToString();
                    objUserProfile.Occupation = items["FLDOCCUPATION"].ToString();
                    objUserProfile.AnnualinCode = items["FLDANNUALINCODE"].ToString();
                    objUserProfile.DefaultPaymentCard = Convert.ToInt16(items["FLDDEFAULTPAYMENTCARD"].ToString());
                    objUserProfile.Photopath = items["FLDPHOTOPATH"].ToString();
                    lstUserProfile.Add(objUserProfile);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstUserProfile;
        }
        [HttpPost]
        [Route("api/UserProfileInsert")]
        [AllowAnonymous]
        public void UserProfileInsert(UserProfile objUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserProfile.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@REGISTRATIONDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserProfile.RegistrationDate));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRYCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.CountryCode));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@QUALIFICATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Qualification));
                ParameterList.Add(DataAccess.GetDBParameter("@OCCUPATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Occupation));
                ParameterList.Add(DataAccess.GetDBParameter("@ANNUALINCODE", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.AnnualinCode));
                ParameterList.Add(DataAccess.GetDBParameter("@DEFAULTPAYMENTCARD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.DefaultPaymentCard));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objUserProfile.Photopath));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/UserProfileUpdate")]
        [AllowAnonymous]
        public void UserProfileUpdate(UserProfile objUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserProfile.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@REGISTRATIONDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objUserProfile.RegistrationDate));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRYCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.CountryCode));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@QUALIFICATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Qualification));
                ParameterList.Add(DataAccess.GetDBParameter("@OCCUPATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.Occupation));
                ParameterList.Add(DataAccess.GetDBParameter("@ANNUALINCODE", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objUserProfile.AnnualinCode));
                ParameterList.Add(DataAccess.GetDBParameter("@DEFAULTPAYMENTCARD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.DefaultPaymentCard));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objUserProfile.Photopath));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/UserProfileDelete")]
        [AllowAnonymous]
        public void UserProfileDelete(UserProfile objUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objUserProfile.UserProfileID));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
