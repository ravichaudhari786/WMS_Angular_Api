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
    public class DesignationController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/Designation/Designation_Insert_Update")]
        public IHttpActionResult Designation_Insert_Update(Cls_Designation obj)
        {
            try
            {
                var data = _context.Designation_Insert_Update(obj.DesignationID,obj.DesignationName,obj.DesignationCode,obj.IsActive).ToList();
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
        [Route("api/Designation/Designation_Select")]
        public IHttpActionResult Designation_Select()
        {
            try
            {
                var data = _context.Designation_Select().ToList();
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