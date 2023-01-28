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
    public class SlotBookingController : ApiController
    {
        [HttpPost]
        [Route("api/GetSlotBooking")]
        [AllowAnonymous]
        public List<SlotBooking> GetSlotBooking(SlotBooking objSlotBooking)
        {
            List<SlotBooking> lstSlotBooking = new List<SlotBooking>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.SlotBookingID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBOOKINGLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objSlotBooking.SlotBookingID = Convert.ToInt16(items["FLDSLOTBOOKINGID"].ToString());
                    objSlotBooking.BookingID = Convert.ToInt32(items["FLDBOOKINGID"].ToString());
                    objSlotBooking.UserID = Convert.ToInt32(items["FLDUSERID"].ToString());
                    objSlotBooking.UserProfileID = Convert.ToInt32(items["FLDUSERPROFILEID"].ToString());
                    objSlotBooking.ChildID = Convert.ToInt32(items["FLDCHILDID"].ToString());
                    objSlotBooking.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objSlotBooking.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objSlotBooking.Date = Convert.ToDateTime(items["FLDDATE"].ToString());
                    objSlotBooking.BookingNumber = items["FLDBOOKINGNUMBER"].ToString();
                    objSlotBooking.Status = items["FLDSTATUS"].ToString();
                    lstSlotBooking.Add(objSlotBooking);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSlotBooking;
        }
        [HttpPost]
        [Route("api/SlotBookingInsert")]
        [AllowAnonymous]
        public void SlotBookingInsert(SlotBooking objSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.BookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlotBooking.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@STATUS", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objSlotBooking.Status));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objSlotBooking.BookingNumber));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBookingUpdate")]
        [AllowAnonymous]
        public void SlotBookingUpdate(SlotBooking objSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.SlotBookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.BookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objSlotBooking.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@STATUS", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objSlotBooking.Status));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objSlotBooking.BookingNumber));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/SlotBookingDelete")]
        [AllowAnonymous]
        public void SlotBookingDelete(SlotBooking objSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objSlotBooking.SlotBookingID));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}