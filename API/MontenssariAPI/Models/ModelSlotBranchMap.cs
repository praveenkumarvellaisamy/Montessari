using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelSlotBranchMap
    {
        public int UserCode { get; set; }
        public int SlotMapID { get; set; }
        public int BranchID { get; set; }
        public int SlotID { get; set; }
        public int MaxChild { get; set; }
    }
}