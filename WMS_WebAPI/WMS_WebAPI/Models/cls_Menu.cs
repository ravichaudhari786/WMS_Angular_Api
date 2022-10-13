using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Menu
    {
        public Nullable<int> userid { get; set; }
    }
    
    public class Cls_menu
    {
        public Menu[] menu { get; set; }
    }

    public class Menu
    {
        public string route { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public Badge badge { get; set; }
        public Child[] children { get; set; }
        public Permissions permissions { get; set; }
        public Label label { get; set; }
    }

    public class Badge
    {
        public string color { get; set; }
        public string value { get; set; }
    }

    public class Permissions
    {
        public string only { get; set; }
        public string except { get; set; }
    }

    public class Label
    {
        public string color { get; set; }
        public string value { get; set; }
    }

    public class Child
    {
        public string route { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }



}