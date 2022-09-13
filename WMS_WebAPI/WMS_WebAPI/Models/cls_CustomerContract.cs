using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CustomerContract
    {
    }
    public class cls_CustomerContractWarehouse
    {
        public Nullable<int> CustomerRateID { get; set; }
        public string  Mode { get; set; }
        public Nullable<int> WareHouseID { get; set; }

    }

   
}