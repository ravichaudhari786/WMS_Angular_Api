using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class BillEstimateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_storage_summary")]
        public IHttpActionResult Rep_Invoice_Estimate_storage_summary(cls_BillEstimate obj)
        {
            try
            {
                var data = _context.Rep_Invoice_Estimate_storage_summary(obj.billStartDate, obj.billEndDate, obj.warehouseID);
                
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_storage")]
        public IHttpActionResult Rep_Invoice_Estimate_storage(cls_BillEstimate obj)
        {
            try
            {
                var data = _context.Rep_Invoice_Estimate_storage(obj.billStartDate, obj.billEndDate, obj.warehouseID);
                
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_Labour")]
        public IHttpActionResult Rep_Invoice_Estimate_Labour(cls_BillEstimate obj)
        {
            try
            {
                var data = _context.Rep_Invoice_Estimate_Labour(obj.billStartDate, obj.billEndDate, obj.warehouseID);
               
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
    }
}