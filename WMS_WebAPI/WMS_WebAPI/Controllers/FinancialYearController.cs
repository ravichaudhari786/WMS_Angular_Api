using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class FinancialYearController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/FinancialYear/FinancialYears_Insert")]
        public IHttpActionResult FinancialYears_Insert(cls_FinancialYears obj)
        {
            try
            {
                var data = _context.FinancialYears_Insert(obj.FinancialYearID,obj.Year,obj.StartDate,obj.EndDate,obj.IsActive,obj.WareHouseID).ToList();
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