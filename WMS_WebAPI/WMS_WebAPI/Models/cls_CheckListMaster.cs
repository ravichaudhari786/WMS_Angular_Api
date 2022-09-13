using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_CheckListMaster
    {
        public Nullable<int> CheckListID { get; set; }
        public string CheckListName { get; set; }
        public string  Description { get; set; }

        public Nullable<int> PeriodTypeID { get; set; }
        public Nullable<int> Frequancy { get; set; }
        public Nullable<Boolean> IsOptional { get; set; }
        public Nullable<Boolean> OptionYesNo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
       
    }
}