using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelUserCreditCard
    {

        public int UserCode { get; set; }
        public int CardID { get; set; }
        public int UserID { get; set; }
        public int UserProfileID { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}