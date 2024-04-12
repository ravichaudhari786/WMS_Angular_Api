using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class REportPrintInfoclass
    {

        public int ReportID { get; set; }
        public string PrinterName { get; set; }
        public string PageSize { get; set; }
        public string Oriantation { get; set; }
        public Nullable<decimal> TopMargin { get; set; }
        public Nullable<decimal> LeftMargin { get; set; }
        public Nullable<decimal> BottomMargin { get; set; }
        public Nullable<decimal> RightMargin { get; set; }

    }
}