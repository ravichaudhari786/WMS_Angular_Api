//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS_WebAPI.Models.Context
{
    using System;
    
    public partial class DeliveryOrder_List_Result
    {
        public int DeliveryOrderID { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public Nullable<int> CustomerPartyID { get; set; }
        public string DeliveryOrderNo { get; set; }
        public Nullable<System.DateTime> DeliveryOrderDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderGivenBy { get; set; }
        public string DeliverTo { get; set; }
        public string Remarks { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string Process { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
    }
}
