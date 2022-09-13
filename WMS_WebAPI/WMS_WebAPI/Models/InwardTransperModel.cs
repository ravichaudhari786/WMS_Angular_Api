using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardTransperModel
    {
        public Nullable<int> InwardDID { get; set; }
        public string LotNo { get; set; }
        public string TransporterName { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public Nullable<decimal> Qty { get; set; }

    }
}