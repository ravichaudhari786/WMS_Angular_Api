using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_UserCompany
    {
        public Nullable<int> UserCompanyID { get; set; }
        public List<cls_TD_UserCompany> LTD_UserCompany { get; set; }
        public Nullable<int> CreatedBy { get; set; }

    }
    public class cls_TD_UserCompany
    {
        public Nullable<int> UserID { get; set; }

        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
    }
    public class cls_UserCompanyWareHouseList
    {
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }

    }
}