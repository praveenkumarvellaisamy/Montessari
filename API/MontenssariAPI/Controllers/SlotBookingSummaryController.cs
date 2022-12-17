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
    public class SlotBookingSummarySummaryController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelSlotBookingSummary> GetSlotBookingSummary(ModelSlotBookingSummary objModelSlotBookingSummary)
        {
            List<ModelSlotBookingSummary> lstModelSlotBookingSummary = new List<ModelSlotBookingSummary>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.SlotBookingSummaryID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBOOKINGSUMMARYLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelSlotBookingSummary.SlotBookingSummaryID = Convert.ToInt16(items["FLDSlotBookingSummaryID"].ToString());
                    
                    objModelSlotBookingSummary.BookingCount = Convert.ToInt32(items["FLDBOOKINGCOUNT"].ToString());
                    objModelSlotBookingSummary.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objModelSlotBookingSummary.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objModelSlotBookingSummary.Date = Convert.ToDateTime(items["FLDDATE"].ToString());
                    objModelSlotBookingSummary.AvailableCount = Convert.ToInt32(items["FLDAVAILABLECOUNT"].ToString());
                    lstModelSlotBookingSummary.Add(objModelSlotBookingSummary);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelSlotBookingSummary;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingSummaryInsert(ModelSlotBookingSummary objModelSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlotBookingSummary.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGCOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.BookingCount));
                ParameterList.Add(DataAccess.GetDBParameter("@AVAILABLECOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.AvailableCount));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingSummaryUpdate(ModelSlotBookingSummary objModelSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.SlotBookingSummaryID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlotBookingSummary.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGCOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.BookingCount));
                ParameterList.Add(DataAccess.GetDBParameter("@AVAILABLECOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.AvailableCount));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingSummaryDelete(ModelSlotBookingSummary objModelSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBookingSummary.SlotBookingSummaryID));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}