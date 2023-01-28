using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparklesAPI.Models
{
    public class AgeGroup
    {
        public int AgeGroupID { get; set; }
        public int UserCode { get; set; }
        public string Name { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
    }
}