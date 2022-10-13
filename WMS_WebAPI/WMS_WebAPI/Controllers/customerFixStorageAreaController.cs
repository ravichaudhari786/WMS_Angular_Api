using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class customerFixStorageAreaController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpGet]
        [Route("api/customerFixStorageArea/GetStorageArea")]
        public IHttpActionResult GetStorageArea(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.GetStorageArea(obj.WarehouseID,obj.CustomerID).ToList();
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
        [Route("api/customerFixStorageArea/CustomerStorageArea_List")]
        public IHttpActionResult CustomerStorageArea_List(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.CustomerStorageArea_List(obj.WarehouseID).ToList();
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
        [Route("api/customerFixStorageArea/CustomerStorageArea_insert")]
        public IHttpActionResult CustomerStorageArea_insert(cls_CustomerStorageArea obj)
        {
            try
            {
                var data = _context.CustomerStorageArea_insert(obj.CustomerStorageAreaID,obj.CustomerID,obj.WarehouseID,obj.StorageAreaID,
                    obj.SpaceAllocationPercentage,obj.StartDate,obj.EndDate,obj.Rate,obj.BillingCycleID,obj.createdBy).ToList();
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
