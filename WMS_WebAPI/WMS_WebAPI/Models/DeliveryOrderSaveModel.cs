using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Models
{
    public class DeliveryOrderSaveModel
    {
        public Nullable<int> DeliveryOrderID { get; set; }
        public Nullable<DateTime> DeliveryOrderDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string DeliverTo { get; set; }
        public Nullable<int> CustomerPartyID { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderGivenBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ByCustomer { get; set; }
        public Nullable<Boolean> IsDoDispatch { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }

        public List<DeliveryOrderDetail> DeliveryOrderDetailModel { get; set; }
    }
}