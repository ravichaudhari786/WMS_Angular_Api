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
}