using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_OutWard_Update
    {
        public Nullable <int> outWardID{get;set;}
        public Nullable <int> docID{get;set;}
        public string truckNo{get;set;}
        public string containerNo{get;set;}
        public Nullable <int> loadingBy{get;set;}
        public Nullable <int> customerPartyID{get;set;}
        public string remarks{get;set;}
        public Nullable <int> labourContractorID{get;set;}
        public Nullable <int> customerID{get;set;}
        public Nullable <int> createdBy { get; set;}
    }
}