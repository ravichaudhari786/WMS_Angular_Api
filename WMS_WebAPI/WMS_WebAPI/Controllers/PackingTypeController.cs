using System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class PackingTypeController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        [HttpPost]
        [Route("api/PackingType/PackingType_Insert_Update")]
        public IHttpActionResult PackingType_Insert_Update(Cls_PackingType obj)
        {
            try
            {
                var data = _context.PackingType_Insert_Update(obj.PackingTypeID,obj.PackingType,obj.IsActive).ToList();
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
        [Route("api/PackingType/PackingType_Select")]
        public IHttpActionResult PackingType_Select()
        {
            try
            {
                var data = _context.PackingType_Select().ToList();
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