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
    
    public partial class CustomerStorageArea
    {
        public int CustomerStorageAreaID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> SpaceAllocationPercentage { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
