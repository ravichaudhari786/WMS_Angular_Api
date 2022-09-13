using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CustomerDocumentsVerificationController : ApiController
    {

        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/CustomerDocumentsVerification/CustomerVerifiedDocuments_insert")]
        public IHttpActionResult CustomerVerifiedDocuments_insert(cls_CustomerDocumentsVerification obj)
        {
            try
            {
                var data = _context.CustomerVerifiedDocuments_insert(obj.CustomerVerifiedDocumentsID,obj.CustomerDocID,obj.CustomerID,obj.CreatedBy).ToList();
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


        [HttpGet]
        [Route("api/CustomerDocumentsVerification/GetCustomerDocumentVerification_List")]
        public IHttpActionResult GetCustomerDocumentVerification_List()
        {
            try
            {
                var data = _context.GetCustomerDocumentVerification_List().ToList();
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

        [HttpGet]
        [Route("api/CustomerDocumentsVerification/CustomerVerifiedDocuments_List")]
        public IHttpActionResult CustomerVerifiedDocuments_List()
        {
            try
            {
                var data = _context.CustomerVerifiedDocuments_List().ToList();
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
    }
}