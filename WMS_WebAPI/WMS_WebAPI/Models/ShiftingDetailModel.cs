using System;


namespace WMS_WebAPI.Models
{
    public class ShiftingDetailModel
    {
        public Nullable<int> ShiftingDID { get; set; }
        public Nullable<int> InwardLocationID { get; set; }
        public string LotNo { get; set; }
        public Nullable<int> InwardDID { get; set; }
        public Nullable<int> FromLocationID { get; set; }
        public Nullable<int> ToLocationID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> LabourContractorID { get; set; }

    }
}