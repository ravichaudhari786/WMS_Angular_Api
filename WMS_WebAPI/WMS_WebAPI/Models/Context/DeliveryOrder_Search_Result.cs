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
    
    public partial class DeliveryOrder_Search_Result
    {
        public int DeliveryOrderID { get; set; }
        public int InwardDID { get; set; }
        public int InwardLocationID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string LotNo { get; set; }
        public string FirstLotNo { get; set; }
        public string StorageAreaName { get; set; }
        public Nullable<decimal> InQuantity { get; set; }
        public Nullable<decimal> PendingDO { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public int DOQuantity { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public string ItemsInPacket { get; set; }
    }
}
