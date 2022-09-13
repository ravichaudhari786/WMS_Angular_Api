using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_DockMaster
    {

       public Nullable<int> dockID { get; set; }
        public string dockName { get; set; }
        public Nullable<int> dockNo { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<int> wareHouseID { get; set; }
    }
}