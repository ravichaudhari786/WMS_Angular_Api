using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Warehouse
    {
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string  WarehouseName { get; set; }
        public string  WarehouseCode { get; set; }
        public string  Address1 { get; set; }
        public string  Address2 { get; set; }
        public string  Address3 { get; set; }
        public string  TelNumber { get; set; }
        public string Fax { get; set; }
        public string EmailID { get; set; }

        public Nullable<int> CityId { get; set; }
        public byte[] Logo { get; set; }
        public Nullable<int> createdby { get; set; }
    }
    public class cls_whinfo
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> companyId { get; set; }
    }
}