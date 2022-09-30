using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Shifting
    {
        public string remarks { get; set; }
        public Nullable<int> shiftingDID { get; set; }
        public Nullable<int> shiftingID{get;set;}
        public Nullable<int> warehouseID{get;set;}
        public Nullable<int> customerID{get;set;}
        public Nullable<int> createdBy{get;set;}
        public Nullable<System.DateTime> shiftingDate{get;set;}
        public Nullable<int> loadingBy { get; set; }        
        public string LotNo { get; set; }
    }
}