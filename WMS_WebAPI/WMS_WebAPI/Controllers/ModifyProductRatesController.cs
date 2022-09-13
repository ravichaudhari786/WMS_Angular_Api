using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ModifyProductRatesController : ApiController
    {

        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/ModifyProductRates/ModifyProductRate_Insert")]
        public IHttpActionResult ModifyProductRate_Insert(cls_ModifyProductRates obj)
        {
            try
            {
                var data = _context.ModifyProductRate_Insert(obj.ProductID,obj.RateID,obj.serviceId,obj.Rate,obj.CreatedBy,obj.CustomerID).ToList();
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