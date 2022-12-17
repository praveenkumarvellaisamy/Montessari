using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelUserProfile
    {
        public int UserProfileID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CountryCode { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Occupation { get; set; }
        public string AnnualinCode { get; set; }
        public int DefaultPaymentCard { get; set; }
        public string Photopath { get; set; }
        public int UserCode{ get; set; }
    }
}