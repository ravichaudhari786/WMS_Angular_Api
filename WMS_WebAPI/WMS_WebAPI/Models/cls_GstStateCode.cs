using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_GstStateCode
    {
        public Nullable<int> stateID { get; set; }
        public Nullable<int> serviceID { get; set; }
        public Nullable<int> customerID { get; set; }
        public Nullable<int> productID { get; set; }

    }
}