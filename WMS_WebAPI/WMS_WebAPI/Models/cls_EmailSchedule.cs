using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_EmailSchedule
    {
       public Nullable<int> reportID { get; set; }
        public Nullable<bool> today { get; set; }
        public Nullable<bool> daily { get; set; }
        public Nullable<bool> weekly { get; set; }
        public string weekly_Day { get; set; }
        public Nullable<bool> monthly { get; set; }
        public Nullable<int> monthaly_day { get; set; }
        public Nullable<System.TimeSpan> emailTime { get; set; }
        public Nullable<int> emailReportID { get; set; }
        public string emailSubject { get; set; }
        public string emailText { get; set; }
        public Nullable<int> wareHouseID { get; set; }
        public string emailReportName { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> emailReportDID { get; set; }
    }
}