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
    
    public partial class Rep_RepackingReport_Result
    {
        public string CustomerName { get; set; }
        public int ReceiptNo { get; set; }
        public string RepackingNo { get; set; }
        public Nullable<System.DateTime> RepackingDate { get; set; }
        public string OrderGivenBy { get; set; }
        public string LotNo { get; set; }
        public string OldProduct { get; set; }
        public string NewProduct { get; set; }
        public Nullable<decimal> oldQty { get; set; }
        public Nullable<decimal> NewQty { get; set; }
        public string WareHouseName { get; set; }
        public string WAddress { get; set; }
        public string EmailID { get; set; }
        public string Fax { get; set; }
        public string TelNumber { get; set; }
        public byte[] Logo { get; set; }
    }
}
