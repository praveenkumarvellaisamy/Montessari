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
    public class ChildController : ApiController
    {
        [HttpPost]
        [Route("api/GetChild")]
        [AllowAnonymous]
        public List<Child> GetChild(Child objChild)
        {
            List<Child> lstChild = new List<Child>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.ChildID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHILDLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objChild.ChildID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objChild.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objChild.FirstName = items["FLDFIRSTNAME"].ToString();
                    objChild.LastName = items["FLDLASTNAME"].ToString();
                    objChild.MiddleName = items["FLDMIDDLENAME"].ToString();
                    objChild.DOB = Convert.ToDateTime(items["FLDDOB"].ToString());
                    objChild.Gender = items["FLDGENDER"].ToString();
                    objChild.PhotoPath = items["FLDPHOTOPATH"].ToString();
                    lstChild.Add(objChild);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstChild;
        }
        [HttpPost]
        [Route("api/ChildInsert")]
        [AllowAnonymous]
        public void ChildInsert(Child objChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objChild.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objChild.PhotoPath));
                DataAccess.ExecSPReturnInt("PRCHILDINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/ChildUpdate")]
        [AllowAnonymous]
        public void ChildUpdate(Child objChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@FIRSTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.FirstName));
                ParameterList.Add(DataAccess.GetDBParameter("@LASTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.LastName));
                ParameterList.Add(DataAccess.GetDBParameter("@MIDDLENAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.MiddleName));
                ParameterList.Add(DataAccess.GetDBParameter("@DOB", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objChild.DOB));
                ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objChild.Gender));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objChild.PhotoPath));
                DataAccess.ExecSPReturnInt("PRCHILDUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/ChildDelete")]
        [AllowAnonymous]
        public void ChildDelete(Child objChild)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objChild.ChildID));
                DataAccess.ExecSPReturnInt("PRCHILDDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}