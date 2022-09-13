using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CheckListMasterController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/CheckListMaster/CheckListMaster_Insert")]
        public IHttpActionResult CheckListMaster_Insert(cls_CheckListMaster obj)
        {
            try
            {
                var data = _context.CheckListMaster_Insert(obj.CheckListID,obj.CheckListName,obj.Description,obj.PeriodTypeID,
                    obj.Frequancy,obj.IsOptional,obj.OptionYesNo,obj.CreatedBy).ToList();
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
        [Route("api/CheckListMaster/CheckListMaster_List")]
        public IHttpActionResult CheckListMaster_List()
        {
            try
            {
                var data = _context.CheckListMaster_List().ToList();
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