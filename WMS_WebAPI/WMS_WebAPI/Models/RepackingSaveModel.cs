using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class RepackingSaveModel
    {
        public Nullable<int> RepackingID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<DateTime> RepackingDate { get; set; }
        public string OrderGivenBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public List<TD_RepackingDetailsModel> RepackingDetailsModel { get; set; }
        public List<TD_RepackingChargesModel> RepackingChargesModel { get; set; }
        public List<TD_RepackingInwardDetailsModel> RepackingInwardDetailsModel { get; set; }
        public Nullable<int> FinancialYearID { get; set; }
        public Nullable<int> StorageAreaMasterID { get; set; }
        public Nullable<int> CompanyID { get; set; }
    }

    public class TD_RepackingDetailsModel
    {
        public Nullable<int> RepackingDID { get; set; }
        public Nullable<int> InwardDID { get; set; }
        public string LotNo { get; set; }
        public string NewLotNo { get; set; }
        public Nullable<int> InwardLocationID { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> NewProductID { get; set; }
        public Nullable<decimal> NewQuantity { get; set; }
        public Nullable<int> NewBrandID { get; set; }
        public string NewCountinPacket { get; set; }
        public Nullable<int> NewStorageAreaID { get; set; }
        public Nullable<int> LabourContractorID { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public string ClassName { get; set; }
        public Nullable<decimal> ProductTotalWeight { get; set; }
        public Nullable<decimal> ProductWeight { get; set; }
    }

    public class TD_RepackingChargesModel
    {
        public Nullable<int> RepackingDID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Rate_L { get; set; }
    }
    public class TD_RepackingInwardDetailsModel
    {
        public Nullable<int> RepackingDID { get; set; }
        public Nullable<int> NewInwardDID { get; set; }
        public string NewLotNo { get; set; }
        public Nullable<int> NewInwardLocationID { get; set; }
        public Nullable<int> NewStorageAreaID { get; set; }
        public Nullable<int> NewProductID { get; set; }
        public Nullable<decimal> NewQuantity { get; set; }
        public Nullable<int> NewBrandID { get; set; }
        public string NewCountinPacket { get; set; }
        public Nullable<int> NewLabourContracterID { get; set; }
        public string NewRemarks { get; set; }
        public Nullable<int> NewStorageTypeID { get; set; }
        public Nullable<int> NewServiceID { get; set; }
        public string OldLotNo { get; set; }
        public string ClassName { get; set; }
    }
}