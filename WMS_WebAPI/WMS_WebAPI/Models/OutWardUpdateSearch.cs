using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class OutWardUpdateSearch
    {
        public Nullable<int> CustomerID { get; set; }
        public string OutWardNo { get; set; }
    }
}