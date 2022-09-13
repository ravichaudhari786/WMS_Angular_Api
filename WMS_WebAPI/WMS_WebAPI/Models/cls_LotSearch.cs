using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_LotSearch
    {
       public string lotNo { get; set; }
        public Nullable<int> wareHouseID { get; set; }
    }
}