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
    
    public partial class CustomerRateList_Service_Result
    {
        public int AddOnServiceID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public string BillingCyclesName { get; set; }
    }
}
