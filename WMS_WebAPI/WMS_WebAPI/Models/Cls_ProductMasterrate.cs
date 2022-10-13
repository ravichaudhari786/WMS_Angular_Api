using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_ProductMasterrate
    {
        public string servicename { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<int> rateID { get; set; }
        public Nullable<int> serviceId { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> typeID { get; set; }
    }
}