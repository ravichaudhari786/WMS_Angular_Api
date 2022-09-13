using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Storage
    {
        public Nullable<int> warehouseID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public List<cls_TD_StorageAreaS> LTD_StorageAreaS { get; set; }
        public Nullable<int> createdBy { get; set; }

        public Nullable<int> BlockID { get; set; }
    }
    public class cls_TD_StorageAreaS
    {
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public string StorageAreaCode { get; set; }
        public  string StorageArea { get; set; }
        public Nullable<int> StorageAreaMasterID { get; set; }
        public string StorageName { get; set; }
        public Nullable<int> StorageAreaTypeID { get; set; }
        public string StorageAreaType { get; set; }
        public Nullable<int> ParentStorageAreaID { get; set; }
        public Nullable<Boolean> IsStorable { get; set; }
        public Nullable<Boolean> IsTemparatureControlled { get; set; }
        public Nullable<int> Preference { get; set; }
        public Nullable<decimal> MinTempareture { get; set; }
        public Nullable<decimal> MaxTempareture { get; set; }
        public Nullable<int> TemperatureCategoryID { get; set; }

        public Nullable<decimal> AreaLength { get; set; }
        public Nullable<decimal> AreaHeight { get; set; }
        public Nullable<decimal> AreaBreadth { get; set; }

        public Nullable<decimal> StorageCapacity { get; set; }
    }
}