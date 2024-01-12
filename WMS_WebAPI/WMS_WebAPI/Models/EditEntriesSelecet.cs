using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class EditEntriesSelecet
    {
        public Nullable<int> CustomerID { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string Process { get; set; }
        public string lotno { get; set; }
        
    }
}