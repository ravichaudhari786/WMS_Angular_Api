using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_StorageAreaType
    {
        public Nullable<int> StorageAreaTypeID { get; set; }
        public string StorageAreaType { get; set; }
        public Nullable<int> TemperatureCategoryID { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}