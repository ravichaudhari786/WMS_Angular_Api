using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class ShiftingChargesModel
    {
        public Nullable<int> ShiftingDID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Rate_L { get; set; }
    }
}