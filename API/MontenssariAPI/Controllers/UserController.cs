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
    public class UserController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public bool CheckUser(ModelUser objModelUser)
        {
            int i = 0;
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, objModelUser.UserName));
            ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_400, ParameterDirection.Input, objModelUser.Password));
            DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHECKUSER", ParameterList);
            if(dt.Rows.Count>0)
            {
                i = Convert.ToInt16(dt.Rows[0]["FLDVALIDUSER"].ToString());
            }
            return Convert.ToBoolean(i);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelUser> GetUser(ModelUser objModelUser)
        {
            List<ModelUser> lstModelUser = new List<ModelUser>();
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

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void UserInsert(ModelUser objModelUser)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelUser.UserName));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAIL", SqlDbType.NVarChar, DbConstant.NVARCHAR_100, ParameterDirection.Input, objModelUser.EMail));
                ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_200, ParameterDirection.Input, objModelUser.Password));
                ParameterList.Add(DataAccess.GetDBParameter("@EMAILVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.EMailVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENO", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelUser.MobileNo));
                ParameterList.Add(DataAccess.GetDBParameter("@MOBILENOVERIFIEDYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.MobileVerifiedYN));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelUser.UserCode));
                DataAccess.ExecSPReturnInt("PRUSERINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void userupdate(ModelUser objModelUser)
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
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void userdelete(ModelUser objModelUser)
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