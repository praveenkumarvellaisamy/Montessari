using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelChildPickupPerson
    {
        public int UserCode { get; set; }
        public int ChildPickupPersonID { get; set; }
        public int ChildID { get; set; }
        public int UserID { get; set; }
        public int UserProfileID { get; set; }
        public string PersonName { get; set; }
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
        public int SameasPersonYN { get; set; }
    }
}