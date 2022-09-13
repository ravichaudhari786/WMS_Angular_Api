using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_TaxType
    {
        public Nullable<int> TaxTypeID { get; set; }
        public string Code { get; set; }
        public string TaxTypeDescription { get; set; }
        public Nullable<Boolean> isActive { get; set; }
}
}