using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CustomerAddOnService
    {
        public Nullable<int> AddOnServiceID { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<DateTime> StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public Nullable<decimal> Rate { get; set; }

        public Nullable<int> BillingCycleID { get; set; }

        public Nullable<int> createdBy { get; set; }
    }
}