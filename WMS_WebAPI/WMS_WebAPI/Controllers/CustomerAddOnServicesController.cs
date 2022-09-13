using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CustomerAddOnServicesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/CustomerAddOnServices/CustomerAddOnService_insert")]
        public IHttpActionResult CustomerAddOnService_insert(cls_CustomerAddOnService obj)
        {
            try
            {
                var data = _context.CustomerAddOnService_insert(obj.AddOnServiceID,obj.CustomerID,obj.WarehouseID,obj.ServiceID,obj.StartDate,
                    obj.EndDate,obj.Rate,obj.BillingCycleID,obj.createdBy).ToList();
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
        [Route("api/CustomerAddOnServices/CustomerAddOnServices_List")]
        public IHttpActionResult CustomerAddOnServices_List(cls_CustomerAddOnService obj)
        {
            try
            {
                var data = _context.CustomerAddOnServices_List(obj.CustomerID).ToList();
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