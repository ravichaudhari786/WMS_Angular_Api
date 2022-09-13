using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_customerRateList
    {
        public Nullable<int> CustomerRateListID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<DateTime> wefDate { get; set; }

        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<int> RateID { get; set; }
        public Nullable<int> BillingCycleID { get; set; }

        public List<TD_CustomerRateList> LTD_CustomerRateList { get; set; }
        public List<TD_CustomerStorageArea1> LTD_CustomerStorageArea1 { get; set; }
        public List<TD_CustomerAddOnServices1> LTD_CustomerAddOnServices1 { get; set; }
        public List<TD_WareHouses> LTD_WareHouses { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> CompanyID { get; set; }
    }
    public class TD_CustomerRateList
    {
        public Nullable<int> CustomerRateListID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> ChargedRate { get; set; }
        public Nullable<decimal> LabourRate { get; set; }
       


    }
    public class TD_CustomerStorageArea1
    {
        public Nullable<int> StorageAreaID { get; set; }
        public Nullable<int> SpaceAllocationPercentage { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
      
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public Nullable<int> IsUpdate { get; set; }

    }
    public class TD_CustomerAddOnServices1
    {
        public Nullable<int> ServiceID { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> BillingCycleID { get; set; }
        public Nullable<int> IsUpdate { get; set; }


    }
    public class TD_WareHouses
    {
        public Nullable<int> WarehouseID { get; set; }

    }

    public class cls_RateList
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> RateID { get; set; }

        public Nullable<int> SrNo { get; set; }

    }


}