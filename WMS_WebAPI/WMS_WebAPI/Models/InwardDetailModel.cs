using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardDetailModel
    {
        public Nullable<int> InwardDID { get; set; }
        public Nullable<int> ChallanID { get; set; }
        public Nullable<int> ChallanDID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string LotNo { get; set; }
        public string FirstLotNo { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public string ItemsInPacket { get; set; }
        public Nullable<decimal> InQuantity { get; set; }
        public Nullable<decimal> ChallanQuantity { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<decimal> InprocessQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> TransferDID { get; set; }
        public Nullable<int> LabourContractorID { get; set; }
        public string LabourContractorName { get; set; }
        public Nullable<int> StorageAreaTypeID { get; set; }
        public string StorageAreaType { get; set; }
        public Nullable<int> SelfLife { get; set; }
        public Nullable<Boolean> IsNew { get; set; }
        public string Country { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ClassName { get; set; }
    }
}