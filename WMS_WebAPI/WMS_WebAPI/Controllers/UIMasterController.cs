using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class UIMasterController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/UIMaster/UIMaster_Insert")]
        public IHttpActionResult UIMaster_Insert(cls_UIMaster obj)
        {
            try
            {
                var data = _context.UIMaster_Insert(obj.UIMasterID,obj.UIGroupID,obj.UIName,obj.DisplayName,obj.SequenceNo,obj.Path,obj.IsActive,obj.CreatedBy).ToList();
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
        [Route("api/UIMaster/UIMaster_Grid")]
        public IHttpActionResult UIMaster_Grid()
        {
            try
            {
                var data = _context.UIMaster_Grid().ToList();
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