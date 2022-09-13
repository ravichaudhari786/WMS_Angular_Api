using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_CountMaster
    {
        public Nullable<int> CountID { get; set; }
        public string Counts { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

        public Nullable<int> CreatedBy { get; set; }
    }
}