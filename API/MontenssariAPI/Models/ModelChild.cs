using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelChild
    {
        public int ChildID { get; set; }
        public int UserCode { get; set; }
        public int UserID { get; set; }
        public int UserProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}