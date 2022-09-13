using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_City
    {
        public Nullable<int> CityID { get; set; }
        public string City { get; set; }

        public Nullable<int> StateID { get; set; }

        public Nullable<int> CreatedBy { get; set; }
    }

    public class States
    {
        public Nullable<int> StateID { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string GstCode { get; set; }

    }
}