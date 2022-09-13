using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Services
    {
        public Nullable<int> ServiceID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<int> ServiceTypeID { get; set; }
        public string HCNCode { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public Nullable<int> StorageAreaTypeID { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> TaxID { get; set; }
    }
    public class cls_service
    {
       public Nullable<int> productID { get; set; }
        public Nullable<int> customerID { get; set; }
    }
}