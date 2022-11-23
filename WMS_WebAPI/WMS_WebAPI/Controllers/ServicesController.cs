using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ServicesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/Services/Service_Select")]
        public IHttpActionResult Service_Select()
        {
            try
            {
                var data = _context.Service_Select().ToList();
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
        [Route("api/Services/Services_Insert")]
        public IHttpActionResult Services_Insert(cls_Services obj)
        {
            try
            {
                var data = _context.Services_Insert(obj.ServiceID,obj.ServiceCode,obj.ServiceName,obj.ServiceTypeID,obj.HCNCode,
                    obj.BillingCycleID,obj.StorageAreaTypeID,obj.IsActive,obj.TaxID).ToList();
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