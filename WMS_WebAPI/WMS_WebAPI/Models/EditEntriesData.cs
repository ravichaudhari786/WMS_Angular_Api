using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class EditEntriesData
    {
        public Nullable<int> customerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> DID { get; set; }
        public Nullable<Boolean> Loading { get; set; }
        public Nullable<Boolean> Unloading { get; set; }
        public Nullable<Boolean> Thappi { get; set; }
        public Nullable<Boolean> Varai { get; set; }
        public Nullable<Boolean> Shifting { get; set; }
        public Nullable<Boolean> Dummping { get; set; }
        public Nullable<Boolean> Weights { get; set; }
    }
}