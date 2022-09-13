using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Models
{
    public class ApplicationUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        //public List<SP_Login_Result> sploginlist { get; set; }
    }
}