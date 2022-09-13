using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_FinancialYears
    {
        public Nullable<int> FinancialYearID { get; set; }
        public string Year { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> WareHouseID { get; set; }
    }
}