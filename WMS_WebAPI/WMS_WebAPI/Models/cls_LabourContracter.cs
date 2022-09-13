using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_LabourContracter
    {
        public Nullable<int> LabourContractorID { get; set; }
        public string ContractorName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactNo { get; set; }
        public string PanCardNo { get; set; }
        public string LicenceNo { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string EmailID { get; set; }
        public string GSTNo { get; set; }
    }
}