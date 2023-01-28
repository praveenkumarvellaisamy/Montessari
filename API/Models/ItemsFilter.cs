using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparklesAPI.Models
{
    public class ItemsFilter
    {
        public string ShipIMO { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}