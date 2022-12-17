using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelPlan
    {
        public int UserCode { get; set; }
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int TimeChangeYN { get; set; }
        public int DayWeekChangeYN { get; set; }
        public int DurationFlexibilityYN { get; set; }
        public int CancellationYN { get; set; }
        public int WaitListYN { get; set; }
        public int GuestsYN { get; set; }
        public int FoodYN { get; set; }
        public int LateFeeYN { get; set; }
        public int LateFeeBillCycle { get; set; }
        public int EntryOutYN { get; set; }
        public int ReferalBenefitYN { get; set; }
        public int ScheduleCommunicationYN { get; set; }
        public int GalleryYN { get; set; }
        public int NotificationsYN { get; set; }
        public int CircularYN { get; set; }
        public int SiblingYN { get; set; }
        public int PaymentYN { get; set; }
        public int TotalHours { get; set; }
        public int MaxHoursinADay { get; set; }
        public int MaxDaysfromRegistration { get; set; }
    }
}