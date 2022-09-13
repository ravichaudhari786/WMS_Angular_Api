using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CustomerUsers
    {
        public Nullable<int> CustomerLoginID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}