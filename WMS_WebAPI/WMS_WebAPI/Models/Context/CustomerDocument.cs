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
    
    public partial class CustomerDocument
    {
        public int CustomerDocID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> DocumentID { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsValidated { get; set; }
    }
}
