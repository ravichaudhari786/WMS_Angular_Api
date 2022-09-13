//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS_WebAPI.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class StorageArea
    {
        public int StorageAreaID { get; set; }
        public Nullable<int> WareHouseID { get; set; }
        public string StorageAreaCode { get; set; }
        public string StorageArea1 { get; set; }
        public Nullable<int> StorageAreaMasterID { get; set; }
        public Nullable<int> StorageAreaTypeID { get; set; }
        public Nullable<int> ParentStorageAreaID { get; set; }
        public Nullable<bool> IsStorable { get; set; }
        public Nullable<int> Preference { get; set; }
        public Nullable<bool> IsTemparatureControlled { get; set; }
        public Nullable<decimal> MinTempareture { get; set; }
        public Nullable<decimal> MaxTempareture { get; set; }
        public Nullable<int> TemperatureCategoryID { get; set; }
        public Nullable<decimal> AreaLength { get; set; }
        public Nullable<decimal> AreaHeight { get; set; }
        public Nullable<decimal> AreaBreadth { get; set; }
        public Nullable<decimal> StorageCapacity { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> BlockID { get; set; }
    
        public virtual StorageAreaMaster StorageAreaMaster { get; set; }
        public virtual StorageAreaType StorageAreaType { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
