using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_UIMaster
    {
        public  Nullable<int> UIMasterID { get; set; }
        public Nullable<int> UIGroupID { get; set; }
        public string UIName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<int> SequenceNo { get; set; }
        public string Path { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}