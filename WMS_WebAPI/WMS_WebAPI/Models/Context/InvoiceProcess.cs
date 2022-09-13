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
    
    public partial class InvoiceProcess
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<decimal> ServiceCharges { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public Nullable<decimal> TDSDeductedByCustomer { get; set; }
        public Nullable<decimal> UnclearBalance { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> InvoiceTypeID { get; set; }
        public Nullable<int> LabourContractorID { get; set; }
        public Nullable<bool> InCompanyName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsOK { get; set; }
        public Nullable<int> VerifiedBy { get; set; }
        public Nullable<System.DateTime> VerifiedDate { get; set; }
        public string VerifiedRemarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
