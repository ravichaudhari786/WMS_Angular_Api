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
    
    public partial class EmailSchedule_List_Result
    {
        public int EmailReportDID { get; set; }
        public int EmailReportID { get; set; }
        public int CustomerID { get; set; }
        public int ReportID { get; set; }
        public string CustomerName { get; set; }
        public string EmailReportName { get; set; }
        public string ReportName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }
        public Nullable<System.TimeSpan> EmailTime { get; set; }
        public Nullable<bool> today { get; set; }
        public Nullable<bool> Daily { get; set; }
        public Nullable<bool> Weekly { get; set; }
        public string Weekly_day { get; set; }
        public Nullable<bool> Monthly { get; set; }
        public Nullable<int> Monthly_day { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
