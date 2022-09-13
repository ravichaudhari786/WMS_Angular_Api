using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardGetAvailableStorageArea
    {
        public Nullable<int> InwardID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Mode { get; set; }
        public List<InwardDetailModel> InwardDetailModel { get; set; }
        public List<InwardLocationModel> InwardLocationModel { get; set; }
        public Nullable<int> ChallanID { get; set; }
    }
}