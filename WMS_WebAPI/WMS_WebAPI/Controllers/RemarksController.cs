using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class RemarksController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/Remarks/Remarks_List")]
        public IHttpActionResult Remarks_List()
        {
            try
            {
                var data = _context.Remarks_List().ToList();
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
        [Route("api/Remarks/Remarks_insert")]
        public IHttpActionResult Remarks_insert(cls_Remarks obj)
        {
            try
            {
                var data = _context.Remarks_insert(obj.RemarksID,obj.Remarks,obj.ProcessID,obj.IsActive,obj.CreatedBy).ToList();
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
        [Route("api/Remarks/ProcessList")]
        public IHttpActionResult ProcessList()
        {
            try
            {
                var data = _context.GetProcess().ToList();
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