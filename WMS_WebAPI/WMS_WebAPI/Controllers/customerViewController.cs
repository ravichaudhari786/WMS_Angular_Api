using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [RoutePrefix("api/Customer")]
    public class customerViewController : ApiController
    {
        private WMS_Entities _context;

        customerViewController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("CustomerView_GetData")]
        public IHttpActionResult CustomerView_GetData(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.CustomerView_GetData(obj.CustomerID,obj.WarehouseID,obj.LotNo).ToList();
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
