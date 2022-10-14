using System;

namespace WMS_WebAPI.Models
{
    public class ShiftingSaveModel
    {
        public Nullable<int> ShiftingID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.Collections.Generic.List<ShiftingDetailModel> TD_ShiftingDetails { get; set; }
        
        public System.Collections.Generic.List<ShiftingChargesModel> TD_ShiftingCharges { get; set; }
        public Nullable<DateTime> ShiftingDate { get; set; }
        public Nullable<int> LoadingBy { get; set; }

        //public System.Collections.Generic.List<ShiftingDetailModel> ShiftingDetailModel { get; set; }

    }
}