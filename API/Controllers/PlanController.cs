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
    public class PlanController : ApiController
    {
        [HttpPost]
        [Route("api/GetPlan")]
        [AllowAnonymous]
        public List<Plan> GetPlan(Plan objPlan)
        {
            List<Plan> lstPlan = new List<Plan>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.PlanID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRPLANLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objPlan.PlanID = Convert.ToInt16(items["FLDPLANID"].ToString());
                    objPlan.PlanName = items["FLDPLANNAME"].ToString();
                    objPlan.TimeChangeYN = Convert.ToInt32(items["FLDTIMECHANGEYN"].ToString());
                    objPlan.DayWeekChangeYN = Convert.ToInt32(items["FLDDAYWEEKCHANGEYN"].ToString());
                    objPlan.DurationFlexibilityYN = Convert.ToInt32(items["FLDDURATIONFLEXIBILITYYN"].ToString());
                    objPlan.CancellationYN = Convert.ToInt32(items["FLDCANCELLATIONYN"].ToString());
                    objPlan.WaitListYN = Convert.ToInt32(items["FLDWAITLISTYN"].ToString());
                    objPlan.GuestsYN = Convert.ToInt32(items["FLDGUESTSYN"].ToString());
                    objPlan.FoodYN = Convert.ToInt32(items["FLDFOODYN"].ToString());
                    objPlan.LateFeeYN = Convert.ToInt32(items["FLDLATEFEEYN"].ToString());
                    objPlan.LateFeeBillCycle = Convert.ToInt32(items["FLDLATEFEEBILLCYCLE"].ToString());
                    objPlan.EntryOutYN = Convert.ToInt32(items["FLDENTRYOUTYN"].ToString());
                    objPlan.ReferalBenefitYN = Convert.ToInt32(items["FLDREFERALBENEFITYN"].ToString());
                    objPlan.ScheduleCommunicationYN = Convert.ToInt32(items["FLDSCHEDULECOMMUNICATIONYN"].ToString());
                    objPlan.GalleryYN = Convert.ToInt32(items["FLDGALLERYYN"].ToString());
                    objPlan.NotificationsYN = Convert.ToInt32(items["FLDNOTIFICATIONSYN"].ToString());
                    objPlan.CircularYN = Convert.ToInt32(items["FLDCIRCULARYN"].ToString());
                    objPlan.SiblingYN = Convert.ToInt32(items["FLDSIBLINGYN"].ToString());
                    objPlan.PaymentYN = Convert.ToInt32(items["FLDPAYMENTYN"].ToString());
                    objPlan.TotalHours = Convert.ToInt32(items["FLDTOTALHOURS"].ToString());
                    objPlan.MaxHoursinADay = Convert.ToInt32(items["FLDMAXHOURSINADAY"].ToString());
                    objPlan.MaxDaysfromRegistration = Convert.ToInt32(items["FLDMAXDAYSFROMREGISTRATION"].ToString());
                    lstPlan.Add(objPlan);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPlan;
        }
        [HttpPost]
        [Route("api/PlanInsert")]
        [AllowAnonymous]
        public void PlanInsert(Plan objPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@PLANNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objPlan.PlanName));
                ParameterList.Add(DataAccess.GetDBParameter("@TIMECHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.TimeChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DAYWEEKCHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.DayWeekChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DURATIONFLEXIBILITYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.DurationFlexibilityYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CANCELLATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.CancellationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@WAITLISTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.WaitListYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GUESTSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.GuestsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@FOODYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.FoodYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.LateFeeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEBILLCYCLE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.LateFeeBillCycle));
                ParameterList.Add(DataAccess.GetDBParameter("@ENTRYOUTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.EntryOutYN));
                ParameterList.Add(DataAccess.GetDBParameter("@REFERALBENEFITYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.ReferalBenefitYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SCHEDULECOMMUNICATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.ScheduleCommunicationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GALLERYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.GalleryYN));
                ParameterList.Add(DataAccess.GetDBParameter("@NOTIFICATIONSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.NotificationsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CIRCULARYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.CircularYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SIBLINGYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.SiblingYN));
                ParameterList.Add(DataAccess.GetDBParameter("@PAYMENTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.PaymentYN));
                ParameterList.Add(DataAccess.GetDBParameter("@TOTALHOURS", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.TotalHours));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXHOURSINADAY", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.MaxHoursinADay));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXDAYSFROMREGISTRATION", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.MaxDaysfromRegistration));
                DataAccess.ExecSPReturnInt("PRPLANINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/PlanUpdate")]
        [AllowAnonymous]
        public void PlanUpdate(Plan objPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.PlanID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@PLANNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objPlan.PlanName));
                ParameterList.Add(DataAccess.GetDBParameter("@TIMECHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.TimeChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DAYWEEKCHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.DayWeekChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DURATIONFLEXIBILITYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.DurationFlexibilityYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CANCELLATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.CancellationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@WAITLISTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.WaitListYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GUESTSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.GuestsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@FOODYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.FoodYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.LateFeeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEBILLCYCLE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.LateFeeBillCycle));
                ParameterList.Add(DataAccess.GetDBParameter("@ENTRYOUTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.EntryOutYN));
                ParameterList.Add(DataAccess.GetDBParameter("@REFERALBENEFITYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.ReferalBenefitYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SCHEDULECOMMUNICATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.ScheduleCommunicationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GALLERYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.GalleryYN));
                ParameterList.Add(DataAccess.GetDBParameter("@NOTIFICATIONSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.NotificationsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CIRCULARYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.CircularYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SIBLINGYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.SiblingYN));
                ParameterList.Add(DataAccess.GetDBParameter("@PAYMENTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.PaymentYN));
                ParameterList.Add(DataAccess.GetDBParameter("@TOTALHOURS", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.TotalHours));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXHOURSINADAY", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.MaxHoursinADay));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXDAYSFROMREGISTRATION", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.MaxDaysfromRegistration));
                DataAccess.ExecSPReturnInt("PRPLANUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("api/PlanDelete")]
        [AllowAnonymous]
        public void PlanDelete(Plan objPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objPlan.PlanID));
                DataAccess.ExecSPReturnInt("PRPLANDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}