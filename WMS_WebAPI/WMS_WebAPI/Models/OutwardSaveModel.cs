using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Models
{
    public class OutwardSaveModel
    {
        public Nullable<int> OutwardID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<DateTime> OutWardDate { get; set; }
        public Nullable<DateTime> BillStartDate { get; set; }
        public Nullable<int> DeliveryOrderID { get; set; }
        public Nullable<int> CustomerPartyID { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public string TransporterName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string DriverName { get; set; }
        public string DriverNo { get; set; }
        public Nullable<int> DocID { get; set; }
        public Nullable<int> LoadingBy { get; set; }
        public Nullable<int> TransferID { get; set; }
        public Nullable<int> DispatchID { get; set; }
        public List<OutwardDetailModel> OutwardDetailModel { get; set; }
        public List<OutwardChargesModel> OutwardChargeModel { get; set; }
    }
}