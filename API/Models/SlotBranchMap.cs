using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparklesAPI.Models
{
    public class SlotBranchMap
    {
        public int UserCode { get; set; }
        public int SlotMapID { get; set; }
        public int BranchID { get; set; }
        public int SlotID { get; set; }
        public int MaxChild { get; set; }
    }
}