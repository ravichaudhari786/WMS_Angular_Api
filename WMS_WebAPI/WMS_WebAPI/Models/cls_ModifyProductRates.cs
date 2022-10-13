using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_ModifyProductRates
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> RateID { get; set; }
        public Nullable<int> serviceId { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> CustomerID { get; set; }
    }


    public class Cls_ProductRates
    {
        public Nullable<int> RateID { get; set; }
        public List<TD_CustomerReport> TD_CustomerReport { get; set; }
        public List<TD_ProductReport> TD_ProductReport { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string LotNo { get; set; }
    }
    public class TD_CustomerReport
    {
        public Nullable<int> CustomerID { get; set; }
    }
    public class TD_ProductReport
    {
        public Nullable<int> ProductID { get; set; }

    }
}