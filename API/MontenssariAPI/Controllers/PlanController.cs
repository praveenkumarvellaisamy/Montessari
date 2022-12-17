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
    public class PlanController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public List<ModelPlan> GetPlan(ModelPlan objModelPlan)
        {
            List<ModelPlan> lstModelPlan = new List<ModelPlan>();
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.PlanID));
                DataTable dt = DataAccess.ExecSPReturnDataTable("PRPLANLIST", ParameterList);

                foreach (DataRow items in dt.Rows)
                {
                    objModelPlan.PlanID = Convert.ToInt16(items["FLDPLANID"].ToString());
                    objModelPlan.PlanName = items["FLDPLANNAME"].ToString();
                    objModelPlan.TimeChangeYN = Convert.ToInt32(items["FLDTIMECHANGEYN"].ToString());
                    objModelPlan.DayWeekChangeYN = Convert.ToInt32(items["FLDDAYWEEKCHANGEYN"].ToString());
                    objModelPlan.DurationFlexibilityYN = Convert.ToInt32(items["FLDDURATIONFLEXIBILITYYN"].ToString());
                    objModelPlan.CancellationYN = Convert.ToInt32(items["FLDCANCELLATIONYN"].ToString());
                    objModelPlan.WaitListYN = Convert.ToInt32(items["FLDWAITLISTYN"].ToString());
                    objModelPlan.GuestsYN = Convert.ToInt32(items["FLDGUESTSYN"].ToString());
                    objModelPlan.FoodYN = Convert.ToInt32(items["FLDFOODYN"].ToString());
                    objModelPlan.LateFeeYN = Convert.ToInt32(items["FLDLATEFEEYN"].ToString());
                    objModelPlan.LateFeeBillCycle = Convert.ToInt32(items["FLDLATEFEEBILLCYCLE"].ToString());
                    objModelPlan.EntryOutYN = Convert.ToInt32(items["FLDENTRYOUTYN"].ToString());
                    objModelPlan.ReferalBenefitYN = Convert.ToInt32(items["FLDREFERALBENEFITYN"].ToString());
                    objModelPlan.ScheduleCommunicationYN = Convert.ToInt32(items["FLDSCHEDULECOMMUNICATIONYN"].ToString());
                    objModelPlan.GalleryYN = Convert.ToInt32(items["FLDGALLERYYN"].ToString());
                    objModelPlan.NotificationsYN = Convert.ToInt32(items["FLDNOTIFICATIONSYN"].ToString());
                    objModelPlan.CircularYN = Convert.ToInt32(items["FLDCIRCULARYN"].ToString());
                    objModelPlan.SiblingYN = Convert.ToInt32(items["FLDSIBLINGYN"].ToString());
                    objModelPlan.PaymentYN = Convert.ToInt32(items["FLDPAYMENTYN"].ToString());
                    objModelPlan.TotalHours = Convert.ToInt32(items["FLDTOTALHOURS"].ToString());
                    objModelPlan.MaxHoursinADay = Convert.ToInt32(items["FLDMAXHOURSINADAY"].ToString());
                    objModelPlan.MaxDaysfromRegistration = Convert.ToInt32(items["FLDMAXDAYSFROMREGISTRATION"].ToString());
                    lstModelPlan.Add(objModelPlan);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstModelPlan;
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void PlanInsert(ModelPlan objModelPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@PLANNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelPlan.PlanName));
                ParameterList.Add(DataAccess.GetDBParameter("@TIMECHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.TimeChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DAYWEEKCHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.DayWeekChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DURATIONFLEXIBILITYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.DurationFlexibilityYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CANCELLATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.CancellationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@WAITLISTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.WaitListYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GUESTSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.GuestsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@FOODYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.FoodYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.LateFeeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEBILLCYCLE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.LateFeeBillCycle));
                ParameterList.Add(DataAccess.GetDBParameter("@ENTRYOUTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.EntryOutYN));
                ParameterList.Add(DataAccess.GetDBParameter("@REFERALBENEFITYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.ReferalBenefitYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SCHEDULECOMMUNICATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.ScheduleCommunicationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GALLERYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.GalleryYN));
                ParameterList.Add(DataAccess.GetDBParameter("@NOTIFICATIONSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.NotificationsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CIRCULARYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.CircularYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SIBLINGYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.SiblingYN));
                ParameterList.Add(DataAccess.GetDBParameter("@PAYMENTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.PaymentYN));
                ParameterList.Add(DataAccess.GetDBParameter("@TOTALHOURS", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.TotalHours));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXHOURSINADAY", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.MaxHoursinADay));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXDAYSFROMREGISTRATION", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.MaxDaysfromRegistration));
                DataAccess.ExecSPReturnInt("PRPLANINSERT", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void PlanUpdate(ModelPlan objModelPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.PlanID));
                ParameterList.Add(DataAccess.GetDBParameter("@USERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.UserCode));
                ParameterList.Add(DataAccess.GetDBParameter("@PLANNAME", SqlDbType.VarChar, DbConstant.VARCHAR_100, ParameterDirection.Input, objModelPlan.PlanName));
                ParameterList.Add(DataAccess.GetDBParameter("@TIMECHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.TimeChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DAYWEEKCHANGEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.DayWeekChangeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@DURATIONFLEXIBILITYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.DurationFlexibilityYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CANCELLATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.CancellationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@WAITLISTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.WaitListYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GUESTSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.GuestsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@FOODYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.FoodYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.LateFeeYN));
                ParameterList.Add(DataAccess.GetDBParameter("@LATEFEEBILLCYCLE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.LateFeeBillCycle));
                ParameterList.Add(DataAccess.GetDBParameter("@ENTRYOUTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.EntryOutYN));
                ParameterList.Add(DataAccess.GetDBParameter("@REFERALBENEFITYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.ReferalBenefitYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SCHEDULECOMMUNICATIONYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.ScheduleCommunicationYN));
                ParameterList.Add(DataAccess.GetDBParameter("@GALLERYYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.GalleryYN));
                ParameterList.Add(DataAccess.GetDBParameter("@NOTIFICATIONSYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.NotificationsYN));
                ParameterList.Add(DataAccess.GetDBParameter("@CIRCULARYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.CircularYN));
                ParameterList.Add(DataAccess.GetDBParameter("@SIBLINGYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.SiblingYN));
                ParameterList.Add(DataAccess.GetDBParameter("@PAYMENTYN", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.PaymentYN));
                ParameterList.Add(DataAccess.GetDBParameter("@TOTALHOURS", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.TotalHours));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXHOURSINADAY", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.MaxHoursinADay));
                ParameterList.Add(DataAccess.GetDBParameter("@MAXDAYSFROMREGISTRATION", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.MaxDaysfromRegistration));
                DataAccess.ExecSPReturnInt("PRPLANUPDATE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public void PlanDelete(ModelPlan objModelPlan)
        {
            try
            {
                List<SqlParameter> ParameterList = new List<SqlParameter>();
                ParameterList.Add(DataAccess.GetDBParameter("@PLANID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, objModelPlan.PlanID));
                DataAccess.ExecSPReturnInt("PRPLANDELETE", ParameterList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}