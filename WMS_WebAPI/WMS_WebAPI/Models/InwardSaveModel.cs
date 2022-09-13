using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class InwardSaveModel
    {
        public Nullable<int> InwardID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<DateTime> InwardDate { get; set; }
        public string Remarks{ get; set; }
        public Nullable<int> FinancialYearID  { get; set; }
        public Nullable<int> UserID { get; set; } 
        public string ReceiptNo { get; set; }
        public Nullable<int> dockID { get; set; }
        public Nullable<int> UnLoadingBy { get; set; }
        public Nullable<int> StorageAreaMasterID { get; set; }
        public List<InwardDetailModel> InwardDetailModel { get; set; }
        public List<InwardChargesModel> InwardChargesModel { get; set; }
        public List<InwardLocationModel> InwardLocationModel { get; set; }
        public List<InwardTransperModel> InwardTransperModel { get; set; }
    }
}