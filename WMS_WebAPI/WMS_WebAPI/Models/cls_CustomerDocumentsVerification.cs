using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CustomerDocumentsVerification
    {
        public Nullable<int> CustomerVerifiedDocumentsID { get; set; }
        public Nullable<int> CustomerDocID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }

}