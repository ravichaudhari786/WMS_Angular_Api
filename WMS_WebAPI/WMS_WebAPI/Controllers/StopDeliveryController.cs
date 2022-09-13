using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class StopDeliveryController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/StopDelivery/StopDeliveryOrder_insert")]
        public IHttpActionResult StopDeliveryOrder_insert(cls_StopDelivery obj)
        {
            try
            {
                var data = _context.StopDeliveryOrder_insert(obj.stopDeliveryID,obj.waherhouseID,obj.customerID,obj.release,obj.remarks,obj.createdBy).ToList();
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
        [Route("api/StopDelivery/ReleaseDeliveryOrder_List")]
        public IHttpActionResult ReleaseDeliveryOrder_List(cls_StopDelivery obj)
        {
            try
            {
                var data = _context.ReleaseDeliveryOrder_List(obj.waherhouseID).ToList();
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
        [Route("api/StopDelivery/StopDeliveryOrder_List")]
        public IHttpActionResult StopDeliveryOrder_List(cls_StopDelivery obj)
        {
            try
            {
                var data = _context.StopDeliveryOrder_List(obj.waherhouseID).ToList();
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