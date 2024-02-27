using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_Receipt
    {
        public Nullable<int> ReceiptID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<DateTime> ReceiptDate { get; set; }
        public Nullable<decimal> Amount { get; set; }

        public Nullable<decimal> TDSAmount { get; set; }

        public Nullable<int> ReceiptTypeID { get; set; }

        public Nullable<int> CreatedBy { get; set; }
        public string remarks { get; set; }
        public Nullable<int> customerID { get; set; }
        public List<TD_ReceiptDetail> LTD_ReceiptDetail { get; set; }
        public List<TD_ReceiptInvoiceDetail> LTD_ReceiptInvoiceDetail { get; set; }
    }
    public class TD_ReceiptDetail
    {
        public Nullable<int> ReceiptDID { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public Nullable<int> PaymentModeID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> TDSAmount { get; set; }
        public string ReferenceNo { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public Nullable<DateTime> ReferenceDate { get; set; }
        public string Remarks { get; set; }

    }

    public class TD_ReceiptInvoiceDetail
    {
        public Nullable<int> ReceiptID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<decimal> ReceiptAmount { get; set; }
        public Nullable<decimal> TDSAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
       
    }
}