using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelSlot
    {
        public int SlotID { get; set; }
        public int UserCode { get; set; }
        public string SlotName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}