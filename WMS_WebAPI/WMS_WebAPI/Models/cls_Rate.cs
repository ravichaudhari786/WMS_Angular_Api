using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Rate
    {
        public Nullable<int> RateListID { get; set; }
        public Nullable<int> RateID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> WarehouseID { get; set; }        
        public List<cls_TD_Rate> LTD_Rate { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        public List<cls_TD_Customer> LTD_Customer { get; set; }
    }
   
   public class cls_TD_Customer
    {
        public Nullable<int> CustomerID { get; set; }
    }
}