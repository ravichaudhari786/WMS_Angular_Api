using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CheckListDetail
    {
        public Nullable<int> CheckListDetailID { get; set; }

        public Nullable<int> periodType { get; set; }
        public List<TD_CheckListDetail> LTD_CheckListDetail { get; set; }
    }
    public class TD_CheckListDetail
    {
        public Nullable<int> CheckListDetailID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<int> StorageAreaID { get; set; }
        public string StorageArea { get; set; }
        public Nullable<int> CheckListID { get; set; }
        public Nullable<DateTime> CheckedDate { get; set; }
        public Nullable<int> CheckedBy { get; set; }
        public string  OptionValue { get; set; }
        public string  Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}