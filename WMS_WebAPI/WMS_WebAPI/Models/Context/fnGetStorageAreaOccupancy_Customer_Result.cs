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
    
    public partial class fnGetStorageAreaOccupancy_Customer_Result
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> sdate { get; set; }
        public string storagearea { get; set; }
        public Nullable<int> stockqty { get; set; }
        public Nullable<int> AreaOccupied { get; set; }
        public Nullable<int> storageareaID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
    }
}
