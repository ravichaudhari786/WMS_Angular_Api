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
    
    public partial class api_StockSummary_Result
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Count { get; set; }
        public Nullable<decimal> StockQty { get; set; }
        public string LotNo { get; set; }
    }
}
