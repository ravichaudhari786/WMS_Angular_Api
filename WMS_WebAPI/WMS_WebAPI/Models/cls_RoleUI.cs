using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_RoleUI
    {
        public List<cls_TD_RolesUI> LTD_RolesUI { get; set; }
        public Nullable<int> RoleID { get; set; }
        public List<cls_TD_RoleReport> LTD_RoleReport { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
    public class cls_TD_RolesUI
    {
        public Nullable<int> RoleUIID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> UIMasterID { get; set; }
        public Nullable<Boolean> New_flg { get; set; }
        public Nullable<Boolean> List_flg { get; set; }
        public Nullable<Boolean> Edit_flg { get; set; }
        public Nullable<Boolean> Delete_flg { get; set; }
        public Nullable<Boolean> Print_flg { get; set; }
        public Nullable<Boolean> Export_flg { get; set; }
       

    }
    public class cls_TD_RoleReport
    {
        public Nullable<int> ReportID { get; set; }
        public Nullable<Boolean> isAssigned { get; set; }
    }
}