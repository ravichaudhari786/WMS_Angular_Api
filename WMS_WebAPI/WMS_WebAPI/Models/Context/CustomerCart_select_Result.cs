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
    
    public partial class CustomerCart_select_Result
    {
        public int CustomerCartID { get; set; }
        public int DeliveryOrderID { get; set; }
        public int InwardDID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> InwardLocationID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string LotNo { get; set; }
        public Nullable<decimal> CartQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public int StorageAreaID { get; set; }
        public string StorageArea { get; set; }
        public string Status { get; set; }
    }
}
