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
    
    public partial class Customer_Login_Result
    {
        public string Message { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int WareHouseID { get; set; }
        public string WareHouseName { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public byte[] Logo { get; set; }
        public Nullable<bool> Result { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> CustomerLoginID { get; set; }
    }
}
