using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Users
    {
        public Nullable<int> UserID { get; set; }
        public string UserName { get; set; }

        public string UserDetail { get; set; }

        public string Password { get; set; }

        public Nullable<int> RoleID { get; set; }

        public Nullable<int> UserTypeID { get; set; }


        public Nullable<int> CreatedBy { get; set; }
        public List<cls_TD_Users> Lcls_TD_Users { get; set; }
    }
    public class cls_TD_Users
    {
        public Nullable<int> CompanyID { get; set; }


        public Nullable<int> WarehouseID { get; set; }
    }
}