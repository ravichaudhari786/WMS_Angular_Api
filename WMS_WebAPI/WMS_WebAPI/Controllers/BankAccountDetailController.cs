using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class BankAccountDetailController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        /// <summary>
        /// parameter required
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/BankAccountDetail/BankAccountDetail_insert")]
        public IHttpActionResult BankAccountDetail_insert(Cls_BankAccountDetail obj)
        {
            try
            {
                var data = _context.BankAccountDetail_insert(obj.BankAccountID, obj.WarehouseID, obj.LabourContractorID, obj.BankName, obj.Branch, obj.AccountNo, obj.IFSCCode, obj.CreatedBy).ToList();
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
        [Route("api/BankAccountDetail/BankAccountDetail_Select")]
        public IHttpActionResult BankAccountDetail_Select()
        {
            try
            {
                var data = _context.BankAccountDetail_Select().ToList();
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