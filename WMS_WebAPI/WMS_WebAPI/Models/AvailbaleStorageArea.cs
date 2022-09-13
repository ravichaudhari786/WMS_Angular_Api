using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class AvailbaleStorageArea
    {
        public int WarehouseID { get; set; }
        public int CustomerID { get; set; }
        public string Mode { get; set; }
        public int InwardID { get; set; }
        public int ChallanID { get; set; }
        public List<ChallanProduct> Cproduct { get; set; }
        public List<ChallanLocations> Clocation { get; set; }
    }
}