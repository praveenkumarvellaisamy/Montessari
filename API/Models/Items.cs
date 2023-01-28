using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SparklesAPI.Models
{

    public class Items
    {
        public string ShipIMO { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OrderRcvDate { get; set; }
        public string Supplier { get; set; }

        public string Supplier_Email1 { get; set; }
        public string Supplier_Email2 { get; set; }
        public string Supplier_Email3 { get; set; }
        public string Supplier_Phone1 { get; set; }
        public string Supplier_Phone2 { get; set; }
        public string PO_Number { get; set; }
        public string Product { get; set; }
        public string Brand { get; set; }
        public string PartDescription { get; set; }
        public string PartExecution { get; set; }
        public decimal Qty_Ord { get; set; }
        public string Unit { get; set; }
       
    }
}
