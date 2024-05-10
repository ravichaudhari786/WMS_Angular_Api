using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class TransferSaveModel
	{
		public Nullable<int> TransferID { get; set; }
		public Nullable<int> WareHouseID { get; set; }
		public Nullable<int> CompanyID { get; set; }
		public Nullable<int> FromCustomerID { get; set; }
		public Nullable<int> ToCustomerID { get; set; }
		public Nullable<DateTime> TransferDate { get; set; }
		public string OrderGivenBy { get; set; }
		public string Remarks { get; set; }
		public Nullable<int> CreatedBy { get; set; }
		public List<TransferDetailModule> TD_TransferDetail { get; set; }
		public List<TransferChargesModule> TD_TransferCharges { get; set; }
		public Nullable<int> FinancialYearID { get; set; }
		public Nullable<int> StorageAreaMasterID { get; set; }
	}
	public class TransferDetailModule
	{
		public Nullable<int> TransferDID { get; set; }
		public Nullable<int> InwardDID { get; set; }
		public Nullable<int> ProductID { get; set; }
		public string LotNo { get; set; }
		public Nullable<int> InwardLocationID { get; set; }
		public Nullable<int> StorageAreaID { get; set; }
		public Nullable<decimal> TransferQuantity { get; set; }
		public Nullable<int> ToStorageAreaID { get; set; }
		public Nullable<int> LabourContractorID { get; set; }
		public string Remarks { get; set; }
		public Nullable<int> StorageAreaTypeID { get; set; }
		public string NewLotNo { get; set; }
	}
	public class TransferChargesModule
	{
		public Nullable<int> TransferDID { get; set; }
		public Nullable<int> ServiceID { get; set; }
		public string ServiceName { get; set; }
		public Nullable<decimal> Rate { get; set; }
		public Nullable<decimal> Rate_L { get; set; }
	}
}