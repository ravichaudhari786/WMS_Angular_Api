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
    
    public partial class BillSummary_Result
    {
        public int InvoiceID { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
