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
    
    public partial class BillProcess_List_Result
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceType { get; set; }
        public string WareHouseName { get; set; }
        public decimal InvoiceAmount { get; set; }
    }
}
