using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Models
{
    public class DispatchSaveModel
    {
        public Nullable<int> DispatchID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CustomerPartyID { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderGivenBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> DeliveryOrderID { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }

        public List<DispatchDetail> DispatchDetailModel { get; set; }
    }


    public class cls_Dispatch
    {
        public Nullable<int> DeliveryOrderID { get; set; }
        public Nullable<int> DeliveryOrderNo { get; set; }
        public string Remark { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> DispatchID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CompanyID { get; set; }
       
        public Nullable<int> WarehouseId { get; set; }
      
      
    }
}