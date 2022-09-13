using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Taxes
    {
        public Nullable<int> TaxID { get; set; }
        public string TaxCode { get; set; }
        public string TaxDescription { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public List<TD_Taxes> LTD_Taxes { get; set; }
    }
    public  class TD_Taxes
    {
        public Nullable<int> TaxTypeID { get; set; }
        public string Code { get; set; }
        public Nullable <decimal> TaxRate { get; set; }
        public Nullable<DateTime> WefDate { get; set; }
    }
}