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
    
    public partial class BarCode
    {
        public int BarCodeID { get; set; }
        public Nullable<System.DateTime> BarCodeDate { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string LotNo { get; set; }
        public Nullable<int> SrNo { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> ChallanDID { get; set; }
        public Nullable<int> InwardDID { get; set; }
        public string BarCode1 { get; set; }
        public Nullable<bool> IsPrinted { get; set; }
        public Nullable<System.DateTime> PrintedDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
