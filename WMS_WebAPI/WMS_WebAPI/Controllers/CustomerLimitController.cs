using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CustomerLimitController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/CustomerLimit/customerlimit_insert")]
        public IHttpActionResult customerlimit_insert(cls_CustomerLimit obj)
        {
            try
            {
                var data = _context.customerlimit_insert(obj.CustomerLimitID,obj.CustomerID,obj.WarehouseID,obj.LimitAmount,obj.CreatedBy).ToList();
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
        [Route("api/CustomerLimit/customerlimit_Select")]
        public IHttpActionResult customerlimit_Select()
        {
            try
            {
                var data = _context.customerlimit_Select().ToList();
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