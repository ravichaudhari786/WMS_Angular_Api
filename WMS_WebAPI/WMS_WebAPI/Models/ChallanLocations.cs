using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class ChallanLocations
    {
        public int InwardDID { get; set; }
        public int StorageAreaID { get; set; }
        public int StorageQuantity { get; set; }
        public int LotNo { get; set; }
        public bool IsCustomerAreaSelected { get; set; }
    }
}