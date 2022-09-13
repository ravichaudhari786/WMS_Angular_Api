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
    [RoutePrefix("api/CustomerParty")]
    public class CustomerPartyController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetItems()
        {
            var data = _context.CustomerParties.ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("CustomerPartysave")]
        public IHttpActionResult PostItems(CustomerParty cp)
        {
            var data = _context.CustomerParties_Insert(cp.CustomerPartyID,cp.CustomerID,cp.PartyName,cp.ShippingAddress,cp.ShippingAddress1,cp.PinCode,cp.CreatedBy).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
