using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    ////[Authorize]
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        private WMS_Entities _context;

        BrandController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBrand()
        {
            var data = _context.Brand_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
