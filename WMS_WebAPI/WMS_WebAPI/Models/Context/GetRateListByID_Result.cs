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
    
    public partial class GetRateListByID_Result
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> ChargedRate { get; set; }
        public Nullable<decimal> LabourRate { get; set; }
        public Nullable<int> SrNo { get; set; }
    }
}
