using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CustomerLimit
    {
        public Nullable<int> CustomerLimitID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<decimal> LimitAmount { get; set; }

        public Nullable<int> CreatedBy { get; set; }
    }
}