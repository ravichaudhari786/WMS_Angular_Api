using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Customer
    {
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string Initials { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<int> CustomerTypeID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> CityId { get; set; }

        public string Email { get; set; }
        public string Gstno { get; set; }
        public string Panno { get; set; }
        public List<TD_CustomerContacts> customerContacts { get; set; }

        public List<TD_CustomerDocuments> TD_CustomerDocuments { get; set; }

        public Nullable<int> createdby { get; set; }
        public Nullable<int> State { get; set; }

        public string FICINo { get; set; }
        public Nullable<decimal> StorageDiscount { get; set; }
        public Nullable<decimal> LabourDiscount { get; set; }
        public string ReferredBy { get; set; }
        public string PinCode { get; set; }
        public string GSTStateCode { get; set; }
        public Nullable<int> RateID { get; set; }
    }

    public class TD_CustomerContacts
    {
        public Nullable<int> CustomerContactID { get; set; }

        public string ContactPersonName { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public Nullable<Boolean> SendSMS { get; set; }
        public Nullable<Boolean> SendEmail { get; set; }


    }
    public class TD_CustomerDocuments
    {
        public Nullable<int> CustomerDocID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> DocumentID { get; set; }
        public string FilePath { get; set; }
    }
}