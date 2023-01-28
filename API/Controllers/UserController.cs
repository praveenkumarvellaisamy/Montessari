using SparklesAPI.FrameWork;
using SparklesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SparklesAPI.Controllers
{
    [Route("api")]
    [Authorize]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/CheckUser")]
        [AllowAnonymous]
        public List<User> CheckUser([FromBody] User objModelUser)
        {

            List<User> lstModelUser = new List<User>();
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, objModelUser.UserName));
            ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_400, ParameterDirection.Input, objModelUser.Password));
            DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHECKUSER", ParameterList);
            foreach (DataRow items in dt.Rows)
            {
                objModelUser.UserID = Convert.ToInt16(items["FLDUSERID"].ToString() == "" ? null : items["FLDUSERID"].ToString());
                objModelUser.UserName = items["FLDUSERNAME"].ToString();
                objModelUser.IsValidUser = Convert.ToInt16(items["FLDVALIDUSER"].ToString() == "" ? null : items["FLDVALIDUSER"].ToString());
                objModelUser.Password = "";
                lstModelUser.Add(objModelUser);
            }
            return lstModelUser;

        }
        [HttpPost]
        [Route("api/GetUser")]
        [AllowAnonymous]
        public List<User> GetUser(User objModelUser)
        {
            List<User> lstModelUser = new List<User>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelUser.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objModelUser.UserName = items["FLDUSERNAME"].ToString();
                    objModelUser.EMail = items["FLDEMAIL"].ToString();
                    objModelUser.Password = items["FLDPASSWORD"].ToString();
                    objModelUser.EMailVerifiedYN = Convert.ToInt16(items["FLDEMAILVERIFIEDYN"].ToString());
                    objModelUser.MobileNo = items["FLDMOBILENO"].ToString();
                    objModelUser.MobileVerifiedYN = Convert.ToInt16(items["FLDMOBILENOVERIFIEDYN"].ToString());
                    //objModelUser.UserCode = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    lstModelUser.Add(objModelUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelUser;
        }
        [ResponseType(typeof(string))]
        [HttpPost]
        [Route("api/UserInsert")]
        [AllowAnonymous]
        public HttpResponseMessage UserInsert(User objModelUser)
        {
            try
            {
                List<User> lstModelUser = new List<User>();
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUser.UserName));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAIL", SqlDbType.NVarChar, DbConstant.NVARCHAR_100, ParameterDirection.Input, objModelUser.EMail));
                ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_200, ParameterDirection.Input, objModelUser.Password));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAILVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.EMailVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENO", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelUser.MobileNo));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENOVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.MobileVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserCode));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRUSERINSERT", ParameterList);
                foreach (DataRow items in dt.Rows)
                {
                    objModelUser.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    lstModelUser.Add(objModelUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, objModelUser);

        }
        [HttpPost]
        [Route("api/UserUpdate")]
        [AllowAnonymous]
        public void UserUpdate(User objModelUser)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUser.UserName));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAIL", SqlDbType.NVarChar, DbConstant.NVARCHAR_100, ParameterDirection.Input, objModelUser.EMail));
                ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_200, ParameterDirection.Input, objModelUser.Password));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAILVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.EMailVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENO", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelUser.MobileNo));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENOVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.MobileVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserCode));
                DataAccess.ExecSPReturnInt("pruserupdate", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/UserDelete")]
        [AllowAnonymous]
        public void UserDelete(User objModelUser)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserID));
                DataAccess.ExecSPReturnInt("PRUSERDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
