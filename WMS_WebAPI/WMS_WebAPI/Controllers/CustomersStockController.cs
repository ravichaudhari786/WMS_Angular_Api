using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;


namespace WMS_WebAPI.Controllers
{
    public class CustomersStockController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/CustomersStock/CustomerView_GetData")]
        public IHttpActionResult CustomerView_GetData(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.CustomerView_GetData(obj.CustomerID,obj.WarehouseID,obj.LotNo).ToList();
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