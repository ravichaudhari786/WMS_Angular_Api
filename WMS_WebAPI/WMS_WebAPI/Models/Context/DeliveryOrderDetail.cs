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
    using System.Collections.Generic;
    
    public partial class DeliveryOrderDetail
    {
        public int DeliveryOrderDID { get; set; }
        public Nullable<int> DeliveryOrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int InwardDID { get; set; }
        public string LotNo { get; set; }
        public Nullable<decimal> DOQuantity { get; set; }
        public Nullable<decimal> DispatchedQuantity { get; set; }
        public Nullable<int> InwardLocationID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<decimal> CancelledQuantity { get; set; }
    }
}
