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
    
    public partial class GetOutwardByOutwardNo_Result
    {
        public int OutWardID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> DocID { get; set; }
        public string DockName { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string LoadingBy { get; set; }
        public Nullable<int> CustomerPartyID { get; set; }
        public string DeliverTo { get; set; }
        public string Remarks { get; set; }
        public int LabourContractorID { get; set; }
        public string ContractorName { get; set; }
    }
}
