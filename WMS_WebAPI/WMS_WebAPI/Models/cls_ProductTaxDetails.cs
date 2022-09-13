using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_ProductTaxDetails
    {
        public Nullable<int> ProductTaxID { get; set; }
        public Nullable<int> TaxID { get; set; }
        public Nullable<DateTime> WefDate { get; set; }
        public List<cls_TD_ProductTaxDetailProductID> LTD_ProductTaxDetailProductID { get; set; }
        public List<cls_TD_ProductTaxDetailServiesIDs> LTD_ProductTaxDetailServiesIDs { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string HSNCode { get; set; }
    }
    public class cls_TD_ProductTaxDetailProductID
    {
        public Nullable<int> ProductID { get; set; }
    }
    public class cls_TD_ProductTaxDetailServiesIDs
    {
        public Nullable<int> ServiesID { get; set; }
        public Nullable<int> StorageAreaTypeID { get; set; }
    }
}