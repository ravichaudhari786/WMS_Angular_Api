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
    [Authorize]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private WMS_Entities _context;

        CustomerController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCustomer()
        {
            var data = _context.GetCustomers().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        #region old 
        //[Route("customerbyWarehouse/{warehousID}")]
        //public IHttpActionResult GetCustomer(int warehouseid)
        //{
        //    var data = _context.GetCustomerName(warehouseid).ToList();
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(data);
        //}
        #endregion
        #region Chnage by dharmendra  on 06-09-2022
        [Route("GetCustomerbyid")]
        public IHttpActionResult GetCustomerbyid(cls_Warehouse obj)
        {
            var data = _context.GetCustomerName(obj.WarehouseID).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        #endregion
    }

}
