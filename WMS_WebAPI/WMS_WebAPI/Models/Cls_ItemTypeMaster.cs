using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_ItemTypeMaster
    {
        public Nullable<int> ItemTypeID { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemType { get; set; }
    }
}