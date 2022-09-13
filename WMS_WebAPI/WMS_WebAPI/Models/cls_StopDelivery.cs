using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_StopDelivery
    {
        public Nullable<int> stopDeliveryID{get;set;}
        public Nullable<int> waherhouseID{get;set;}
        public Nullable<int> customerID{get;set;}
        public Nullable<bool> release{get;set;}
        public  string remarks{get;set;}
        public Nullable<int> createdBy { get; set; }
    }
}