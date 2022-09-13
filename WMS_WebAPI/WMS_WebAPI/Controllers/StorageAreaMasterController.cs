using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/StorageAreaMaster")]
    public class StorageAreaMasterController : ApiController
    {
        private WMS_Entities _context;

        StorageAreaMasterController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetWarehouse(int WarehouseID)
        {
            var data = _context.GetStorageArea_byWarehouse(WarehouseID).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        //--------------
    }
}
