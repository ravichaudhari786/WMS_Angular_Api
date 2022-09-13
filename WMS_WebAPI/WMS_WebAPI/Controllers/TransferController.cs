using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class TransferController : ApiController
    {

        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Transfer/Transfer_Insert")]
        public IHttpActionResult Transfer_Insert(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_Insert(obj.transferID,obj.wareHouseID,obj.companyID,obj.fromCustomerID,obj.toCustomerID,
                    obj.transferDate,obj.orderGivenBy,obj.remarks,obj.createdBy,obj.financialYearID,obj.storageAreaMasterID);
               
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        [Route("api/Transfer/Transfer_List")]
        public IHttpActionResult Transfer_List(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_List( obj.wareHouseID).ToList();
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
        [Route("api/Transfer/Transfer_Cancelled")]
        public IHttpActionResult Transfer_Cancelled(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_Cancelled(obj.transferID,obj.toCustomerID,obj.remarks,obj.createdBy,obj.wareHouseID).ToList();
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
        [Route("api/Transfer/Rep_TransferReport")]
        public IHttpActionResult Rep_TransferReport(cls_Transfer obj)
        {
            try
            {
                var data = _context.Rep_TransferReport(obj.transferID).ToList();
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