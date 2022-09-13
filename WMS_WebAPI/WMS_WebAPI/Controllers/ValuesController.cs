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
    public class ValuesController : ApiController
    {

        private WMS_Entities _context;

        ValuesController()
        {
            _context = new WMS_Entities();
        }
        // GET api/values
        [HttpGet]
        [Route("api/dock")]
        public IHttpActionResult GetDock()
        {
            var data = _context.Dock_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/UnloadingBy")]
        public IHttpActionResult UnloadingBy()
        {
            var data = _context.Users_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/Remarks")]
        public IHttpActionResult GetRemarks()
        {
            var data = _context.Remarks_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/CountInPacket")]
        public IHttpActionResult GetCountInPacket()
        {
            var data = _context.CountMasters.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/TemperatureCategory")]
        public IHttpActionResult GetTempCategory()
        {
            var data = _context.TemperatureCategories_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
