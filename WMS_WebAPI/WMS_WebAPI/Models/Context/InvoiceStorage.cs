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
    
    public partial class InvoiceStorage
    {
        public int InvoiceStorageID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<int> InwardDID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public string LotNo { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<System.DateTime> InwardDate { get; set; }
        public Nullable<decimal> InQuantity { get; set; }
        public Nullable<decimal> OpeningQuantity { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public Nullable<decimal> BillQuantity { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> BillingCycleQuantity { get; set; }
        public Nullable<decimal> StorageCharges { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public string HSNCode { get; set; }
        public Nullable<int> FinancialYearID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CustomerRateListID { get; set; }
        public string Description { get; set; }
    }
}
