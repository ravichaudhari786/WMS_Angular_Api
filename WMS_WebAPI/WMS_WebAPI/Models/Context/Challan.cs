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
    
    public partial class Challan
    {
        public int ChallanID { get; set; }
        public string ChallanNumber { get; set; }
        public Nullable<System.DateTime> ChallanDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string PersonName { get; set; }
        public string TransporterName { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public Nullable<int> DocID { get; set; }
        public Nullable<int> UnLoadingBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsCancelled { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
