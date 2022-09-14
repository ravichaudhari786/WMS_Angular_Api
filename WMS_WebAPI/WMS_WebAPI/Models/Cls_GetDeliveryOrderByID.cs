using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_GetDeliveryOrderByID
    {
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> CompanyID { get; set; }
    }
}