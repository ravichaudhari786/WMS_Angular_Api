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
    
    public partial class Rate_Product_Result
    {
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public decimal Rate { get; set; }
        public decimal L_Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
    }
}
