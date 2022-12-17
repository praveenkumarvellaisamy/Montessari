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
    public class ChildController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelChild> GetChild(ModelChild objModelChild)
        {
            List<ModelChild> lstModelChild = new List<ModelChild>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.ChildID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHILDLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelChild.ChildID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objModelChild.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objModelChild.FirstName = items["FLDFIRSTNAME"].ToString();
                    objModelChild.LastName = items["FLDLASTNAME"].ToString();
                    objModelChild.MiddleName = items["FLDMIDDLENAME"].ToString();
                    objModelChild.DOB = Convert.ToDateTime(items["FLDDOB"].ToString());
                    objModelChild.Gender = items["FLDGENDER"].ToString();
                    objModelChild.PhotoPath = items["FLDPHOTOPATH"].ToString();
                    lstModelChild.Add(objModelChild);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelChild;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildInsert(ModelChild objModelChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelChild.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelChild.PhotoPath));
                DataAccess.ExecSPReturnInt("PRCHILDINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildUpdate(ModelChild objModelChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelChild.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChild.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelChild.PhotoPath));
                DataAccess.ExecSPReturnInt("PRCHILDUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildDelete(ModelChild objModelChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChild.ChildID));
                DataAccess.ExecSPReturnInt("PRCHILDDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}