using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class Cls_BankAccountDetail
    {
    public Nullable<int> BankAccountID  {get;set;}
    public Nullable<int> WarehouseID { get; set; }
    public Nullable<int> LabourContractorID { get; set; }
    public string BankName { get; set; }
    public string Branch { get; set; }
    public string AccountNo { get; set; }
    public string IFSCCode { get; set; }
    public Nullable<int> CreatedBy { get; set; }
}
}