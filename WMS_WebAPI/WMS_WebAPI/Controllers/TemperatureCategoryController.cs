using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class TemperatureCategoryController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/TemperatureCategory/TemperatureCategories_Insert")]
        public IHttpActionResult TemperatureCategories_Insert(cls_TemperatureCategories obj)
        {
            try
            {
                var data = _context.TemperatureCategories_Insert(obj.TempCategoryID,obj.TempCategory,obj.MinTemp,obj.MaxTemp,obj.CreatedBy).ToList();
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
        [Route("api/TemperatureCategory/TemperatureCategories_Select")]
        public IHttpActionResult TemperatureCategories_Select()
        {
            try
            {
                var data = _context.TemperatureCategories_Select().ToList();
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