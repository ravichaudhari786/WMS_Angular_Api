using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_PackingType
    {
        public Nullable<int> PackingTypeID { get; set; }
        public string PackingType { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
    }
}