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
    
    public partial class Company_Select_Result
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<int> ParentCompanyID { get; set; }
        public string ParentCompany { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string GSTINNo { get; set; }
        public string PANNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
    }
}
