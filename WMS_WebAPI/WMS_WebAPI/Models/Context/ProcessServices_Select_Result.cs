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
    
    public partial class ProcessServices_Select_Result
    {
        public int SrNo { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public Nullable<bool> Selected { get; set; }
        public Nullable<bool> IsOptional { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ProcessName { get; set; }
        public Nullable<int> ProcessID { get; set; }
    }
}
