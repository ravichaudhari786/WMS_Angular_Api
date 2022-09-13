using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class ChallanProduct
    {
        public bool AddArea { get; set; }
        public bool Auto { get; set; }
        public int ChallanDID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string LotNo { get; set; }
        //public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int ItemsInPacket { get; set; }
        public int InQuantity { get; set; }
        public int StorageAreaTypeID { get; set; }
        public string StorageAreaType { get; set; }
        public bool Applied { get; set; }
    }
}