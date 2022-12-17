using MontenssariAPI.Models;
using MontenssariAPI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MontenssariAPI.Controllers
{
    public class UserProfileController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelUserProfile> GetUserProfile(ModelUserProfile objModelUserProfile)
        {
            List<ModelUserProfile> lstModelUserProfile = new List<ModelUserProfile>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserProfileID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERPROFILELIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelUserProfile.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objModelUserProfile.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objModelUserProfile.FirstName = items["FLDFIRSTNAME"].ToString();
                    objModelUserProfile.LastName = items["FLDLASTNAME"].ToString();
                    objModelUserProfile.MiddleName = items["FLDMIDDLENAME"].ToString();
                    objModelUserProfile.DOB = Convert.ToDateTime(items["FLDDOB"].ToString());
                    objModelUserProfile.RegistrationDate = Convert.ToDateTime(items["FLDREGISTRATIONDATE"].ToString());
                    objModelUserProfile.CountryCode = Convert.ToInt16(items["FLDCOUNTRYCODE"].ToString());
                    objModelUserProfile.Gender = items["FLDGENDER"].ToString();
                    objModelUserProfile.Qualification = items["FLDQUALIFICATION"].ToString();
                    objModelUserProfile.Occupation = items["FLDOCCUPATION"].ToString();
                    objModelUserProfile.AnnualinCode = items["FLDANNUALINCODE"].ToString();
                    objModelUserProfile.DefaultPaymentCard = Convert.ToInt16(items["FLDDEFAULTPAYMENTCARD"].ToString());
                    objModelUserProfile.Photopath = items["FLDPHOTOPATH"].ToString();
                    lstModelUserProfile.Add(objModelUserProfile);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelUserProfile;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserProfileInsert(ModelUserProfile objModelUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserProfile.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@REGISTRATIONDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserProfile.RegistrationDate));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRYCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.CountryCode));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@QUALIFICATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Qualification));
                ParameterList.Add(DataAccess.GetDBParameter("@OCCUPATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Occupation));
                ParameterList.Add(DataAccess.GetDBParameter("@ANNUALINCODE", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.AnnualinCode));
                ParameterList.Add(DataAccess.GetDBParameter("@DEFAULTPAYMENTCARD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.DefaultPaymentCard));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelUserProfile.Photopath));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserProfileUpdate(ModelUserProfile objModelUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserProfile.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@REGISTRATIONDATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelUserProfile.RegistrationDate));
                ParameterList.Add(DataAccess.GetDBParameter("@COUNTRYCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.CountryCode));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@QUALIFICATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Qualification));
                ParameterList.Add(DataAccess.GetDBParameter("@OCCUPATION", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.Occupation));
                ParameterList.Add(DataAccess.GetDBParameter("@ANNUALINCODE", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUserProfile.AnnualinCode));
                ParameterList.Add(DataAccess.GetDBParameter("@DEFAULTPAYMENTCARD", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.DefaultPaymentCard));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelUserProfile.Photopath));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserProfileDelete(ModelUserProfile objModelUserProfile)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUserProfile.UserProfileID));
                DataAccess.ExecSPReturnInt("PRUSERPROFILEDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}