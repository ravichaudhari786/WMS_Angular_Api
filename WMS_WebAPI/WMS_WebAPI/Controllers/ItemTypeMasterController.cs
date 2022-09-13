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
    public class ItemTypeMasterController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/ItemTypeMaster/ItemTypeMaster_Insert_Update")]
        public IHttpActionResult ItemTypeMaster_Insert_Update(Cls_ItemTypeMaster obj)
        {
            try
            {
                var data = _context.ItemTypeMaster_Insert_Update(obj.ItemTypeID,obj.ItemTypeCode,obj.ItemType).ToList();
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
        [Route("api/ItemTypeMaster/ItemTypeMaster_Select")]
        public IHttpActionResult ItemTypeMaster_Select()
        {
            try
            {
                var data = _context.ItemTypeMaster_Select().ToList();
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