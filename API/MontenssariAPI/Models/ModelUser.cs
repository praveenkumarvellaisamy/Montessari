﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontenssariAPI.Models
{
    public class ModelUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int EMailVerifiedYN { get; set; }
        public string MobileNo { get; set; }
        public int MobileVerifiedYN { get; set; }
        public int UserCode { get; set; }
    }
}