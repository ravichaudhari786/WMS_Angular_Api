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
    
    public partial class Get_PendingDO_Result
    {
        public string CustomerName { get; set; }
        public int DeliveryOrderID { get; set; }
        public string DeliveryOrderNo { get; set; }
        public Nullable<System.DateTime> DeliveryOrderDate { get; set; }
        public string DeliverTo { get; set; }
        public string StatusName { get; set; }
        public Nullable<System.DateTime> HoldDate { get; set; }
        public string HoldBy { get; set; }
    }
}
