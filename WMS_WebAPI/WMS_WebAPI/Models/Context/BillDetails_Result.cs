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
    
    public partial class BillDetails_Result
    {
        public int InvoiceStorageID { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InwardDate { get; set; }
        public string LotNo { get; set; }
        public string StorageArea { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> BillQuantity { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BillingCycles { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> StorageCharges { get; set; }
    }
}
