using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
   // [Authorize]
    [RoutePrefix("api/LabourContracter")]
    public class LabourContracterController : ApiController
    {
        private WMS_Entities _context;
       
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        LabourContracterController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetLabourContractor()
        {
            var data = _context.LabourContractors_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }  

            return Ok(data);
        }


        #region Add by dharmendra Bhadoria


        [HttpGet]
        [Route("LabourContractors_Select")]
        public IHttpActionResult LabourContractors_Select()
        {
            try
            {
                var data = _context.LabourContractors_Select().ToList();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("LabourContractor_Insert_Update")]
        public IHttpActionResult LabourContractor_Insert_Update(cls_LabourContracter obj)
        {
            try
            {
                var data = _context.LabourContractor_Insert_Update(obj.LabourContractorID,obj.ContractorName,obj.Address1,obj.Address2,obj.ContactNo,obj.PanCardNo,obj.LicenceNo,obj.DOJ,obj.CreatedBy,obj.BankName,obj.Branch,obj.AccountNo,obj.IFSCCode,obj.EmailID,obj.GSTNo).ToList();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
        #endregion
    }
}
