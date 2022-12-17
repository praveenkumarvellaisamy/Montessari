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
    public class ChildPickupPersonController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelChildPickupPerson> GetChildPickupPerson(ModelChildPickupPerson objModelChildPickupPerson)
        {
            List<ModelChildPickupPerson> lstModelChildPickupPerson = new List<ModelChildPickupPerson>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDPICKUPPERSONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.ChildPickupPersonID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRCHILDPICKUPPERSONLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelChildPickupPerson.ChildPickupPersonID = Convert.ToInt16(items["FLDCHILDPICKUPPERSONID"].ToString());
                    objModelChildPickupPerson.UserID = Convert.ToInt16(items["FLDUSERID"].ToString());
                    objModelChildPickupPerson.UserProfileID = Convert.ToInt16(items["FLDUSERPROFILEID"].ToString());
                    objModelChildPickupPerson.ChildID = Convert.ToInt16(items["FLDCHILDID"].ToString());
                    objModelChildPickupPerson.PersonName = items["FLDPERSONNAME"].ToString();
                    objModelChildPickupPerson.Phone = items["FLDPHONE"].ToString();
                    objModelChildPickupPerson.PhotoPath = items["FLDPHOTOPATH"].ToString();
                    objModelChildPickupPerson.SameasPersonYN = Convert.ToInt32(items["FLDSAMEASPARENTYN"].ToString());
                    lstModelChildPickupPerson.Add(objModelChildPickupPerson);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelChildPickupPerson;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildPickupPersonInsert(ModelChildPickupPerson objModelChildPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@PERSONNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChildPickupPerson.PersonName));
                ParameterList.Add(DataAccess.GetDBParameter("@PHONE", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelChildPickupPerson.Phone));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelChildPickupPerson.PhotoPath));
                ParameterList.Add(DataAccess.GetDBParameter("@SAMEASPERSONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.SameasPersonYN));
                DataAccess.ExecSPReturnInt("PRCHILDPICKUPPERSONINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildPickupPersonUpdate(ModelChildPickupPerson objModelChildPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDPICKUPPERSONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.ChildPickupPersonID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@PERSONNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelChildPickupPerson.PersonName));
                ParameterList.Add(DataAccess.GetDBParameter("@PHONE", SqlDbType.VarChar, DbConstant.VARCHAR_20, ParameterDirection.Input, objModelChildPickupPerson.Phone));
                ParameterList.Add(DataAccess.GetDBParameter("@PHOTOPATH", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, objModelChildPickupPerson.PhotoPath));
                ParameterList.Add(DataAccess.GetDBParameter("@SAMEASPERSONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.SameasPersonYN));
                DataAccess.ExecSPReturnInt("PRCHILDPICKUPPERSONUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void ChildPickupPersonDelete(ModelChildPickupPerson objModelChildPickupPerson)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDPICKUPPERSONID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelChildPickupPerson.ChildPickupPersonID));
                DataAccess.ExecSPReturnInt("PRCHILDPICKUPPERSONDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}