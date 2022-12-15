using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class OutWard_UpdateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/OutWard_Update/OutwardUpdate_insert")]
        public IHttpActionResult OutwardUpdate_insert(cls_OutWard_Update obj)
        {
            try
            {
                var data = _context.OutwardUpdate_insert(obj.outWardID,obj.docID,obj.truckNo,obj.containerNo,
                    obj.loadingBy,obj.customerPartyID,obj.remarks,obj.labourContractorID,obj.customerID,obj.createdBy).ToList();
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
        [Route("api/OutWard_Update/OutwardUpdate_Search")]
        public IHttpActionResult GetOutwardByOutwardNo(OutWardUpdateSearch obj)
        {
            try
            {
                var data = _context.GetOutwardByOutwardNo(obj.CustomerID,obj.OutWardNo).ToList();
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