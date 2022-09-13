using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class OutwardController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Outward/GetOutwardList")]
        public IHttpActionResult GetOutwardList(cls_Outward obj)
        {
            try
            {
                var data = _context.GetOutwardList(obj.warehouseID).ToList();
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
        [Route("api/Outward/OutWard_Cancelled")]
        public IHttpActionResult OutWard_Cancelled(cls_Outward obj )
        {
            try
            {
                var data = _context.OutWard_Cancelled(obj.outwardID,obj.warehouseID,obj.remarks,obj.createdBy).ToList();
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
        [Route("api/Outward/Rep_GatePass")]
        public IHttpActionResult Rep_GatePass(cls_Outward obj)
        {
            try
            {
                var data = _context.Rep_GatePass(obj.outwardID,obj.warehouseID).ToList();
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
        [Route("api/Outward/Outward_Insert")]
        public IHttpActionResult Outward_Insert(cls_Outward obj)
        {
            try
            {
                var data = _context.Outward_Insert(obj.outwardID,obj.warehouseID,obj.outWardDate,obj.billStartDate,obj.deliveryOrderID,
                    obj.customerPartyID,obj.truckNo,obj.containerNo,obj.transporterName,obj.remarks,
                    obj.createdBy,obj.customerID,obj.driverName,obj.driverNo,obj.docID,obj.loadingBy,obj.transferID,obj.dispatchID);
                
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
    }
}