using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_RateMaster
    {
        public Nullable<int> RateID { get; set; }
        public string RateCode { get; set; }
        public string RateDescription { get; set; }
        public string  StartDate { get; set; }
        public string EndDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public List<cls_TD_RateList> LTD_RateList { get; set; }
    }
    public class cls_TD_RateList
    {
        public Nullable<int> RateID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> L_Rate { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
    }
}