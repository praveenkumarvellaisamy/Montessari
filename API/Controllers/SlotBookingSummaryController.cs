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
    public class SlotBookingSummaryController : ApiController
    {
        [HttpPost]
        [Route("api/GetSlotBookingSummary")]
        [AllowAnonymous]
        public List<SlotBookingSummary> GetSlotBookingSummary(SlotBookingSummary objSlotBookingSummary)
        {
            List<SlotBookingSummary> lstSlotBookingSummary = new List<SlotBookingSummary>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.SlotBookingSummaryID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBOOKINGSUMMARYLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objSlotBookingSummary.SlotBookingSummaryID = Convert.ToInt16(items["FLDSlotBookingSummaryID"].ToString());

                    objSlotBookingSummary.BookingCount = Convert.ToInt32(items["FLDBOOKINGCOUNT"].ToString());
                    objSlotBookingSummary.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objSlotBookingSummary.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objSlotBookingSummary.Date = Convert.ToDateTime(items["FLDDATE"].ToString());
                    objSlotBookingSummary.AvailableCount = Convert.ToInt32(items["FLDAVAILABLECOUNT"].ToString());
                    lstSlotBookingSummary.Add(objSlotBookingSummary);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSlotBookingSummary;
        }
        [HttpPost]
        [Route("api/SlotBookingSummaryInsert")]
        [AllowAnonymous]
        public void SlotBookingSummaryInsert(SlotBookingSummary objSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlotBookingSummary.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGCOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.BookingCount));
                ParameterList.Add(DataAccess.GetDBParameter("@AVAILABLECOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.AvailableCount));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBookingSummaryUpdate")]
        [AllowAnonymous]
        public void SlotBookingSummaryUpdate(SlotBookingSummary objSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.SlotBookingSummaryID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlotBookingSummary.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGCOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.BookingCount));
                ParameterList.Add(DataAccess.GetDBParameter("@AVAILABLECOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.AvailableCount));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBookingSummaryDelete")]
        [AllowAnonymous]
        public void SlotBookingSummaryDelete(SlotBookingSummary objSlotBookingSummary)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGSUMMARYID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBookingSummary.SlotBookingSummaryID));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGSUMMARYDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}