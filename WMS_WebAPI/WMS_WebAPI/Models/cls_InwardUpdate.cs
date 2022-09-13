using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_InwardUpdate
    {
        public Nullable<int> inwardDID{get;set;}
        public Nullable<int> brandId{get;set;}
        public string itemsInPacket{get;set;}
        public Nullable<decimal> inQuantity{get;set;}
        public  string lotno{get;set;}
        public string docID{get;set;}
        public string unLoadingBy{get;set;}
        public string remarks{get;set;}
        public string truckNo{get;set;}
        public string containerNo{get;set;}
        public Nullable<int> inwardID{get;set;}
        public Nullable<int> storageAreaID { get; set; }
    }
}