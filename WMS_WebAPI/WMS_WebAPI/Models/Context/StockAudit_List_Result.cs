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
    
    public partial class StockAudit_List_Result
    {
        public Nullable<System.DateTime> StockDate { get; set; }
        public int WareHouseID { get; set; }
        public string WareHouseName { get; set; }
        public string UserName { get; set; }
        public Nullable<System.TimeSpan> Stock_Generated_Time { get; set; }
    }
}
