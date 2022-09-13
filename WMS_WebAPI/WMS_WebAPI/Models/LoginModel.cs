using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Nullable<int> FinitialYearID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<Boolean> RememberMe { get; set; }

    }
}