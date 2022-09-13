using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_SpecialRates
    {
        public Nullable<int> SpecialRateID { get; set; }

        public Nullable<int> RateID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public List<cls_TD_Rate> L_TD_Rate { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<DateTime> wef { get; set; }
       
    }
    public class cls_TD_Rate
    {
        public Nullable<int> ServiceID { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> L_Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
    }
}