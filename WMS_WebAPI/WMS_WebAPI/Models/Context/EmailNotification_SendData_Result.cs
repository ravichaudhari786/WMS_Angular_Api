//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS_WebAPI.Models.Context
{
    using System;
    
    public partial class EmailNotification_SendData_Result
    {
        public System.DateTime AsOnDate { get; set; }
        public string CustomerName { get; set; }
        public string ReceiptNo { get; set; }
        public Nullable<System.DateTime> InwardDate { get; set; }
        public string LotNo { get; set; }
        public string FirstLotNo { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ItemsInPacket { get; set; }
        public Nullable<decimal> InQuantity { get; set; }
        public Nullable<decimal> PendingDO { get; set; }
        public Nullable<decimal> OutQuantity { get; set; }
        public Nullable<decimal> BalanceQuantity { get; set; }
        public string StorageArea { get; set; }
        public string WareHouseName { get; set; }
        public string WareHouseAddress { get; set; }
        public string EmailID { get; set; }
        public string TelNumber { get; set; }
        public byte[] Logo { get; set; }
    }
}
