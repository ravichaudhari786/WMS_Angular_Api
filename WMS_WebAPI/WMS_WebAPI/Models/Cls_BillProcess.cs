using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_BillProcess
    {

         public Nullable<DateTime> BillDate { get; set; }
        public Nullable<DateTime> BillStartDate { get; set; }
        public Nullable<DateTime> BillEndDate { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<Boolean> InCompanyName { get; set; }
        public string  customers { get; set; }
        public Nullable<int> invoiceType { get; set; }
    }
}