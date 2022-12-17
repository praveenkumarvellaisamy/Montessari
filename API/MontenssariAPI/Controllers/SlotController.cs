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
    public class SlotController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelSlot> GetSlot(ModelSlot objModelSlot)
        {
            List<ModelSlot> lstModelSlot = new List<ModelSlot>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlot.SlotID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelSlot.SlotID = Convert.ToInt16(items["FLDSLOTID"].ToString());
                    objModelSlot.SlotName = items["FLDSLOTNAME"].ToString();
                    objModelSlot.StartTime = Convert.ToDateTime(items["FLDSTARTTIME"].ToString());
                    objModelSlot.EndTime = Convert.ToDateTime(items["FLDENDTIME"].ToString());
                    lstModelSlot.Add(objModelSlot);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelSlot;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotInsert(ModelSlot objModelSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlot.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelSlot.SlotName));
                ParameterList.Add(DataAccess.GetDBParameter("@STARTTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlot.StartTime));
                ParameterList.Add(DataAccess.GetDBParameter("@ENDTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlot.EndTime));
                DataAccess.ExecSPReturnInt("PRSLOTINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotUpdate(ModelSlot objModelSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlot.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlot.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelSlot.SlotName));
                ParameterList.Add(DataAccess.GetDBParameter("@STARTTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlot.StartTime));
                ParameterList.Add(DataAccess.GetDBParameter("@ENDTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlot.EndTime));
                DataAccess.ExecSPReturnInt("PRSLOTUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotDelete(ModelSlot objModelSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlot.SlotID));
                DataAccess.ExecSPReturnInt("PRSLOTDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}