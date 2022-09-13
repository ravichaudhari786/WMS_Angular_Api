using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_Brands
    {
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}