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
    
    public partial class Rep_PlugInReceipt_Result
    {
        public int PlugInID { get; set; }
        public string CustomerName { get; set; }
        public string ContractorName { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int TotalHour { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public string WareHouseName { get; set; }
        public string warehouseAddress { get; set; }
    }
}
