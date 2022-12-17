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
    public class SlotBookingController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelSlotBooking> GetSlotBooking(ModelSlotBooking objModelSlotBooking)
        {
            List<ModelSlotBooking> lstModelSlotBooking = new List<ModelSlotBooking>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.SlotBookingID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRSLOTBOOKINGLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelSlotBooking.SlotBookingID = Convert.ToInt16(items["FLDSLOTBOOKINGID"].ToString());
                    objModelSlotBooking.BookingID = Convert.ToInt32(items["FLDBOOKINGID"].ToString());
                    objModelSlotBooking.UserID = Convert.ToInt32(items["FLDUSERID"].ToString());
                    objModelSlotBooking.UserProfileID = Convert.ToInt32(items["FLDUSERPROFILEID"].ToString());
                    objModelSlotBooking.ChildID = Convert.ToInt32(items["FLDCHILDID"].ToString());
                    objModelSlotBooking.BranchID = Convert.ToInt32(items["FLDBRANCHID"].ToString());
                    objModelSlotBooking.SlotID = Convert.ToInt32(items["FLDSLOTID"].ToString());
                    objModelSlotBooking.Date = Convert.ToDateTime(items["FLDDATE"].ToString());
                    objModelSlotBooking.BookingNumber = items["FLDBOOKINGNUMBER"].ToString();
                    objModelSlotBooking.Status = items["FLDSTATUS"].ToString();
                    lstModelSlotBooking.Add(objModelSlotBooking);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelSlotBooking;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingInsert(ModelSlotBooking objModelSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.BookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlotBooking.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@STATUS", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelSlotBooking.Status));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelSlotBooking.BookingNumber));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingUpdate(ModelSlotBooking objModelSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.SlotBookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.BookingID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERPROFILEID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.UserProfileID));
                ParameterList.Add(DataAccess.GetDBParameter("@CHILDID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.ChildID));
                ParameterList.Add(DataAccess.GetDBParameter("@BRANCHID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.BranchID));
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.SlotID));
                ParameterList.Add(DataAccess.GetDBParameter("@DATE", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, objModelSlotBooking.Date));
                ParameterList.Add(DataAccess.GetDBParameter("@STATUS", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelSlotBooking.Status));
                ParameterList.Add(DataAccess.GetDBParameter("@BOOKINGNUMBER", SqlDbType.VarChar, DbConstant.VARCHAR_10, ParameterDirection.Input, objModelSlotBooking.BookingNumber));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void SlotBookingDelete(ModelSlotBooking objModelSlotBooking)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@SLOTBOOKINGID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelSlotBooking.SlotBookingID));
                DataAccess.ExecSPReturnInt("PRSLOTBOOKINGDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}