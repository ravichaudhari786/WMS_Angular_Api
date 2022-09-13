using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_AdditionalService
    {
        public Nullable<int> AdditionalServiceID { get; set; }
        public Nullable<int>  WarehouseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string BillNumber { get; set; }
        public Nullable<Boolean> AddonMonthlyBill { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string Mode { get; set; }
        public List<TD_AdditionalServiceCharges> LTD_AdditionalServiceCharges { get; set; }
        public List<TD_AdditionalServiceDetailS> LTD_AdditionalServiceDetailS { get; set; }
    }
    public class TD_AdditionalServiceCharges
    {
        public Nullable<int> AdditionalServiceChargeID { get; set; }
        public Nullable<int> AdditionalServiceDID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProcuctName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Rate_L { get; set; }
        public string Remarks { get; set; }
    }
    public class TD_AdditionalServiceDetailS
    {
        public Nullable<int> AdditionalServiceDID { get; set; }
        public Nullable<int> AdditionalServiceID { get; set; }

        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public string TruckNo { get; set; }
        public string ContainerNo { get; set; }
        public Nullable<decimal> PerUnitCharges { get; set; }
        public Nullable<decimal> Charges { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> LabourContractorID { get; set; }
        public string LabourContractor { get; set; }
    }
}