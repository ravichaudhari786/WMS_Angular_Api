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
    
    public partial class GetDispatchDetails_Result
    {
        public string DeliveryOrderNo { get; set; }
        public int DeliveryOrderDID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string LotNo { get; set; }
        public string StorageArea { get; set; }
        public int InwardDID { get; set; }
        public Nullable<int> InwardLocationID { get; set; }
        public Nullable<decimal> DOQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public int DispatchQuantity { get; set; }
        public string BrandName { get; set; }
        public string ItemsInPacket { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public string OrderGivenBy { get; set; }
    }
}
