using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparklesAPI.Models
{
    public class SlotBookingSummary
    {
        public int SlotBookingSummaryID { get; set; }
        public int UserCode { get; set; }
        public int BranchID { get; set; }
        public DateTime Date { get; set; }
        public int SlotID { get; set; }
        public int BookingCount { get; set; }
        public int AvailableCount { get; set; }
    }
}