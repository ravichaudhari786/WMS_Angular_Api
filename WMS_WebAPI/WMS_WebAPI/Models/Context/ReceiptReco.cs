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
    
    public partial class ReceiptReco
    {
        public int ReceiptRecoID { get; set; }
        public Nullable<int> ReceiptDID { get; set; }
        public Nullable<int> PaymentStatusID { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ClearBounceDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
