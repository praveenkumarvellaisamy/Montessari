using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelOrganisation
    {
        public int OrganisationID { get; set; }
        public int UserCode { get; set; }
        public string OrgName { get; set; }
        public string OrgRegNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string OfficePH { get; set; }
        public string MobilePH { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string BaseCurrency { get; set; }
    }
}