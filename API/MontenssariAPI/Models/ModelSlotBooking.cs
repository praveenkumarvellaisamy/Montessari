using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelSlotBooking
    {
        public int UserCode { get; set; }
        public int SlotBookingID { get; set; }
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int UserProfileID { get; set; }
        public int ChildID { get; set; }
        public int BranchID { get; set; }
        public int SlotID { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string BookingNumber { get; set; }
    }
}