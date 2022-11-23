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
    [RoutePrefix("api/service")]
    public class ServiceController : ApiController
    {
        private WMS_Entities _context;

        ServiceController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetService()
        {
            var data = _context.Service_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("serviceType")]
        public IHttpActionResult GetServiceType()
        {
            var data = _context.ServiceTypeMaster_View.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("InwardService")]
        public IHttpActionResult GetProductWiseService(int productID,int customerID)
        {
            var data = _context.GetInwardServices(customerID,productID).ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("Service_List")]
        public IHttpActionResult GetService_List()
        {
            try
            {
                var data = _context.Services.ToList();
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
