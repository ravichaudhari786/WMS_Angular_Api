using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class EmailScheduleSave
    {
        public Nullable<int> ReportID { get; set; }  
        public List<CustomerModel> CustomerModel { get; set; } 
        public Nullable<Boolean> Today { get; set; }
        public Nullable<Boolean> Daily { get; set; }
        public Nullable<Boolean> Weekly { get; set; }
        public string weekly_Day { get; set; } 
        public Nullable<Boolean> Monthly { get; set; }
        public string Monthaly_day { get; set; }
        public Nullable<DateTime> EmailTime { get; set; }
        public Nullable<int> EmailReportID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public string EmailReportName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> EmailReportDID { get; set; }
    }
}