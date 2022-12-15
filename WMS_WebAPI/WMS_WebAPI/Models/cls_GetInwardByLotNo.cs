using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_GetInwardByLotNo
    {
        public string LotNo { get; set; }
        public Nullable<int> WarehouseID { get; set; }
    }
}