using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardChargesModel
    {
        public Nullable<int> InwardDID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> C_Rate { get; set; }
        public Nullable<decimal> L_Rate { get; set; }
        
    }
}