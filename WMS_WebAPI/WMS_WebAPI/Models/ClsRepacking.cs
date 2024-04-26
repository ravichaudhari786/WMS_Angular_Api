using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class ClsRepacking
    {
        public Nullable<int> RepackingID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }

    }
}