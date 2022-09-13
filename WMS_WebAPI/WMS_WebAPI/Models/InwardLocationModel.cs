using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardLocationModel
    {
        public Nullable<int> InwardDID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<decimal> StorageQuantity { get; set; }
        public string LotNo { get; set; }
        public Nullable<Boolean> IsCustomerAreaSelected { get; set; }
    }
}