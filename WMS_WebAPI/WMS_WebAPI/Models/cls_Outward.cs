using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Outward
    {
       public Nullable<int> outwardID { get; set; }
        public Nullable<int> warehouseID { get; set; }
        public Nullable<System.DateTime> outWardDate { get; set; }
        public Nullable<System.DateTime> billStartDate { get; set; }
        public Nullable<int> deliveryOrderID { get; set; }
        public Nullable<int> customerPartyID { get; set; }
        public string truckNo { get; set; }
        public string containerNo { get; set; }
        public string transporterName { get; set; }
        public string remarks { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> customerID { get; set; }
        public string driverName { get; set; }
        public string driverNo { get; set; }
        public Nullable<int> docID { get; set; }
        public Nullable<int> loadingBy { get; set; }
        public Nullable<int> transferID { get; set; }
        public Nullable<int> dispatchID { get; set; }
        public Nullable<int> StatusID { get; set; }
    }
}