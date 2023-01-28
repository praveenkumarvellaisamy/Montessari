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
    public class PickupPersonController : ApiController
    {
        [HttpPost]
        [Route("api/GetPickupPerson")]
        [AllowAnonymous]
        public List<PickupPerson> GetPickupPerson(PickupPerson objPickupPerson)
        {
            List<PickupPerson> lstPickupPerson = new List<PickupPerson>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PickupPersonID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.ChildPickupPersonID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRPickupPersonLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objPickupPerson.ChildPickupPersonID = Convert.ToInt16(items["FLDPickupPersonID"].ToString());
                    objPickupPerson.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objPickupPerson.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objPickupPerson.ChildID = Convert.ToInt16(items["FLDCHILDID"].ToString());
                    objPickupPerson.PersonName = items["FLDPERSONNAME"].ToString();
                    objPickupPerson.Phone = items["FLDPHONE"].ToString();
                    objPickupPerson.PhotoPath = items["FLDPHOTOPATH"].ToString();
                    objPickupPerson.SameasPersonYN = Convert.ToInt32(items["FLDSAMEASPARENTYN"].ToString());
                    lstPickupPerson.Add(objPickupPerson);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPickupPerson;
        }
        [HttpPost]
        [Route("api/PickupPersonInsert")]
        [AllowAnonymous]
        public void PickupPersonInsert(PickupPerson objPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@PERSONNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objPickupPerson.PersonName));
                ParameterList.Add(DataAccess.GetDBParameter("@PHONE", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objPickupPerson.Phone));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objPickupPerson.PhotoPath));
                ParameterList.Add(DataAccess.GetDBParameter("@SAMEASPERSONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.SameasPersonYN));
                DataAccess.ExecSPReturnInt("PRPickupPersonINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/PickupPersonUpdate")]
        [AllowAnonymous]
        public void PickupPersonUpdate(PickupPerson objPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@PickupPersonID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.ChildPickupPersonID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@PERSONNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objPickupPerson.PersonName));
                ParameterList.Add(DataAccess.GetDBParameter("@PHONE", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objPickupPerson.Phone));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objPickupPerson.PhotoPath));
                ParameterList.Add(DataAccess.GetDBParameter("@SAMEASPERSONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.SameasPersonYN));
                DataAccess.ExecSPReturnInt("PRPickupPersonUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/PickupPersonDelete")]
        [AllowAnonymous]
        public void PickupPersonDelete(PickupPerson objPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PickupPersonID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPickupPerson.ChildPickupPersonID));
                DataAccess.ExecSPReturnInt("PRPickupPersonDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}