using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_ProcessServices
    {
        public Nullable<int> ProcessIDID { get; set; }

        public List<TD_ProcessServices> LTD_ProcessServices { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        public Nullable<int> ProcessID { get; set; }
       
    }
    public class TD_ProcessServices
    {
        public Nullable<int> ProcessID { get; set; }

        public Nullable<int> ServiceID { get; set; }

        public Nullable<Boolean> Selected { get; set; }

        public Nullable<Boolean> IsOptional { get; set; }

        public Nullable<Boolean> IsDefault { get; set; }

    }
}