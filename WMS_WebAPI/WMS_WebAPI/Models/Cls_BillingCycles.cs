using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_BillingCycles
    {
        public Nullable<int> BillingCycleID { get; set; }
        public string BillingCycleCode { get; set; }
        public string BillingCycleName { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    }
}