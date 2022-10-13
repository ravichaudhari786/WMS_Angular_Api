using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class ProductMasterrateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/ProductMasterrate/GetserviceId_ByserviceName")]
        public IHttpActionResult GetserviceId_ByserviceName(Cls_ProductMasterrate obj)
        {
            try
            {
                var data = _context.GetserviceId_ByserviceName(obj.servicename).ToList();
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
        [Route("api/ProductMasterrate/ProductMasterRate_Insert")]
        public IHttpActionResult ProductMasterRate_Insert(Cls_ProductMasterrate obj)
        {
            try
            {
                var data = _context.ProductMasterRate_Insert(obj.productID,obj.rateID,obj.serviceId,obj.rate,obj.createdBy,obj.typeID).ToList();
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
        [Route("api/ProductMasterrate/GetProductMaster_Rate")]
        public IHttpActionResult GetProductMaster_Rate(Cls_ProductMasterrate obj)
        {
            try
            {
                var data = _context.GetProductMaster_Rate(obj.rateID);
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
