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
    
    public partial class ShiftingCharge
    {
        public int ShiftingChargeID { get; set; }
        public Nullable<int> ShiftingDID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Rate_L { get; set; }
    
        public virtual ShiftingDetail ShiftingDetail { get; set; }
    }
}
