using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_BillEstimate
    {
        public Nullable <System.DateTime> billStartDate{get;set;}
        public Nullable <System.DateTime> billEndDate{get;set;}
        public Nullable <int> warehouseID { get; set; }
        public List<CustomerModel> CustomerModel { get; set; }
    }
}