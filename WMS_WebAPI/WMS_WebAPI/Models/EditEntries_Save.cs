using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class EditEntries_Save
    {
        public Nullable<int> EditEntriesID { get; set; }
        public Nullable<int> createdby { get; set; }
        public string process { get; set; }
        public List<EditEntriesData> TD_EditEntries { get; set; }
    }
}