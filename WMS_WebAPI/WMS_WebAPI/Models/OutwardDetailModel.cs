using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class OutwardDetailModel
    {
        public int OutwardDID { get; set; }
        public Nullable<int> DispatchDID { get; set; }
        public Nullable<int> DeliveryOrderDID { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<int> LabourContractorID { get; set; }
    }
}