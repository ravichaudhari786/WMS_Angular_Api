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
    
    public partial class Repacking_List_Result
    {
        public int RepackingID { get; set; }
        public string RepackingNo { get; set; }
        public string LotNo { get; set; }
        public string CustomerName { get; set; }
        public string OrderGivenBy { get; set; }
        public string ProductName { get; set; }
        public string StorageArea { get; set; }
        public Nullable<System.DateTime> RepackingDate { get; set; }
        public string Remarks { get; set; }
        public string WareHouseName { get; set; }
    }
}
