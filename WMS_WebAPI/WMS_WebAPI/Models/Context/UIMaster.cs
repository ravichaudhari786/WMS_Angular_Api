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
    
    public partial class UIMaster
    {
        public int UIMasterID { get; set; }
        public Nullable<int> UIGroupID { get; set; }
        public string UIName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<int> SequanceNo { get; set; }
        public string Path { get; set; }
        public string IconName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string AngularChildName { get; set; }
        public string AngularChildRoute { get; set; }
    }
}
