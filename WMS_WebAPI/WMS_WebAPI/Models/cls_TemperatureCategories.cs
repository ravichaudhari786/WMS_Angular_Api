using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_TemperatureCategories
    {
        public Nullable<int> TempCategoryID { get; set; }
        public string TempCategory { get; set; }

        public Nullable<int> MinTemp { get; set; }

        public Nullable<int> MaxTemp { get; set; }


        public Nullable<int> CreatedBy { get; set; }
    }
}