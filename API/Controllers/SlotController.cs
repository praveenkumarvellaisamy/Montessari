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
    public class SlotController : ApiController
    {
        [HttpPost]
        [Route("api/GetSlot")]
        [AllowAnonymous]
        public List<Slot> GetSlot(Slot objSlot)
        {
            List<Slot> lstSlot = new List<Slot>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlot.SlotID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objSlot.SlotID = Convert.ToInt16(items["FLDSLOTID"].ToString());
                    objSlot.SlotName = items["FLDSLOTNAME"].ToString();
                    objSlot.StartTime = Convert.ToDateTime(items["FLDSTARTTIME"].ToString());
                    objSlot.EndTime = Convert.ToDateTime(items["FLDENDTIME"].ToString());
                    lstSlot.Add(objSlot);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSlot;
        }
        [HttpPost]
        [Route("api/SlotInsert")]
        [AllowAnonymous]
        public void SlotInsert(Slot objSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlot.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objSlot.SlotName));
                ParameterList.Add(DataAccess.GetDBParameter("@STARTTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlot.StartTime));
                ParameterList.Add(DataAccess.GetDBParameter("@ENDTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlot.EndTime));
                DataAccess.ExecSPReturnInt("PRSLOTINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotUpdate")]
        [AllowAnonymous]
        public void SlotUpdate(Slot objSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlot.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlot.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objSlot.SlotName));
                ParameterList.Add(DataAccess.GetDBParameter("@STARTTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlot.StartTime));
                ParameterList.Add(DataAccess.GetDBParameter("@ENDTIME", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlot.EndTime));
                DataAccess.ExecSPReturnInt("PRSLOTUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotDelete")]
        [AllowAnonymous]
        public void SlotDelete(Slot objSlot)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlot.SlotID));
                DataAccess.ExecSPReturnInt("PRSLOTDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}