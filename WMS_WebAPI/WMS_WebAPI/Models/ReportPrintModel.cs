using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class ReportPrintModel
    {
        public Nullable<int> ReportID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<DateTime> AsonDate { get; set; }
        public string LotNo { get; set; }
        public List<cls_CustomerMST> TD_CustomerReport { get; set; }
        public List<cls_LabourContracterMST> TD_LabourContractor { get; set; }
        public List<Cls_ProductMasterMST> TD_ProductReport { get; set; }
        public List<cls_StorageMST> TD_StorageAreaReport { get; set; }
        public List<Cls_BrandsMST> TD_BrandReport { get; set; }
        public List<cls_CustomerGroupMST> TD_CustomerGroup { get; set; }
        public List<cls_UsersMST> TD_UserName { get; set; }
        public Nullable<int> InvoiceTypeID { get; set; }
        public string SPName { get; set; }
        public string ReportType { get; set; }
        public string ReportName { get; set; }
    }
    

}
public class cls_CustomerMST
{
    public Nullable<int> CustomerID { get; set; }
}
public class cls_LabourContracterMST
{
    public Nullable<int> LabourContractorID { get; set; }
}
public class Cls_ProductMasterMST
{
    public Nullable<int> productID { get; set; }
}
public class cls_StorageMST
{
    public Nullable<int> StorageAreaID { get; set; }
}
public class Cls_BrandsMST
{
    public Nullable<int> BrandID { get; set; }
}
public class cls_CustomerGroupMST
{
    public string GroupName { get; set; }
}
public class cls_UsersMST
{
    public Nullable<int> UserID { get; set; }
}