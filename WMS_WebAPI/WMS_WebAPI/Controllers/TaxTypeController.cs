using System;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class TaxTypeController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        [HttpPost]
        [Route("api/TaxType/TaxType_Insert_Update")]
        public IHttpActionResult TaxType_Insert_Update(Cls_TaxType obj)
        {
            try
            {
                var data = _context.TaxType_Insert_Update(obj.TaxTypeID,obj.Code,obj.TaxTypeDescription,obj.isActive).ToList();
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
        [Route("api/TaxType/TaxType_Select")]
        public IHttpActionResult TaxType_Select()
        {
            try
            {
                var data = _context.TaxType_Select().ToList();
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