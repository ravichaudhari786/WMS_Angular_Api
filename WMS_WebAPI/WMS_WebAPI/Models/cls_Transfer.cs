using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Transfer
    {
        public Nullable<int> transferID{get;set;}
        public Nullable<int> wareHouseID{get;set;}
        public Nullable<int> companyID{get;set;}
        public Nullable<int> fromCustomerID{get;set;}
        public Nullable<int> toCustomerID{get;set;}
        public Nullable<System.DateTime> transferDate{get;set;}
      public  string orderGivenBy{get;set;}
        public string remarks{get;set;}
        public Nullable<int> createdBy{get;set;}
        public Nullable<int> financialYearID{get;set;}
        public Nullable<int> storageAreaMasterID { get; set; }
    }
}