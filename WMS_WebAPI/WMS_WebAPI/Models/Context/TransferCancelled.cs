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
    
    public partial class TransferCancelled
    {
        public int TransferCID { get; set; }
        public Nullable<int> TransferID { get; set; }
        public string CanceledRemarks { get; set; }
        public Nullable<int> CancelledBy { get; set; }
        public Nullable<System.DateTime> CancelledDate { get; set; }
    }
}
