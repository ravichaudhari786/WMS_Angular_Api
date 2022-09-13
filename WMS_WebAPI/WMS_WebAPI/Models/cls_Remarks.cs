using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Remarks
    {
        public Nullable<int> RemarksID { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> ProcessID { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}