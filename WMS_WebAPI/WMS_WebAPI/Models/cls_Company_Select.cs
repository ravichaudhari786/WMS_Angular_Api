using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Company_Select
    {
        public Nullable<int> CompanyID { get; set; }
        public string Companyname { get; set; }
        public string CompanyCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Pincode { get; set; }
        public string ContactNo { get; set; }
        public string MobileNo { get; set; }
        public string Gstno { get; set; }
        public string Panno { get; set; }
        public Nullable<int> ParentCompanyId { get; set; }
        public Nullable<int> createdby { get; set; }
    }
}