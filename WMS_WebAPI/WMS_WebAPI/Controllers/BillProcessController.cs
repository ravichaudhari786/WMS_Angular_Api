using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class BillProcessController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/BillProcess/Invoice_Process_storage")]
        public IHttpActionResult Invoice_Process_storage(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.Invoice_Process_storage(obj.BillDate,obj.BillStartDate,obj.BillEndDate,obj.WarehouseID,obj.CreatedBy,obj.InCompanyName);
                
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("api/BillProcess/Invoice_Process_Labour")]
        public IHttpActionResult Invoice_Process_Labour(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.Invoice_Process_Labour(obj.BillDate, obj.BillStartDate, obj.BillEndDate, obj.WarehouseID, obj.CreatedBy, obj.InCompanyName);

                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }



        [HttpPost]
        [Route("api/BillProcess/Invoice_Re_Process_storage")]
        public IHttpActionResult Invoice_Re_Process_storage(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.Invoice_Re_Process_storage(obj.BillDate, obj.BillStartDate, obj.BillEndDate, obj.WarehouseID, obj.CreatedBy, 
                    obj.InCompanyName,obj.customers);

                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }



        [HttpPost]
        [Route("api/BillProcess/Invoice_Process_Validation")]
        public IHttpActionResult Invoice_Process_Validation(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.Invoice_Process_Validation(obj.BillDate, obj.BillStartDate, obj.BillEndDate, obj.WarehouseID, obj.CreatedBy, obj.invoiceType).ToList();
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
        [Route("api/BillProcess/BillProcess_List")]
        public IHttpActionResult BillProcess_List(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.BillProcess_List(obj.WarehouseID).ToList();
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
        [Route("api/BillProcess/BillReprocess_List")]
        public IHttpActionResult BillReprocess_List(Cls_BillProcess obj)
        {
            try
            {
                var data = _context.BillReprocess_List(obj.WarehouseID).ToList();
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