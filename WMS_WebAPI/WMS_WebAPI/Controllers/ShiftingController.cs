using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ShiftingController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Shifting/Shifting_insert")]
        public IHttpActionResult Shifting_insert(cls_Shifting obj)
        {
            try
            {
                var data = _context.Shifting_insert(obj.shiftingID,obj.warehouseID,obj.customerID,obj.createdBy,obj.shiftingDate,obj.loadingBy);
               
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/Shifting/Shifting_List")]
        public IHttpActionResult Shifting_List(cls_Shifting obj)
        {
            try
            {
                var data = _context.Shifting_List(obj.warehouseID).ToList();
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
        [Route("api/Shifting/Shifting_Cancelled")]
        public IHttpActionResult Shifting_Cancelled(cls_Shifting obj)
        {
            try
            {
                var data = _context.Shifting_Cancelled(obj.shiftingID,obj.shiftingDID,obj.remarks,obj.createdBy,obj.warehouseID).ToList();
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
        [Route("api/Shifting/Rep_Shifting")]
        public IHttpActionResult Rep_Shifting(cls_Shifting obj)
        {
            try
            {
                var data = _context.Rep_Shifting(obj.shiftingID).ToList();
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
        [Route("api/Shifting/ShiftingEdit_List")]
        public IHttpActionResult ShiftingEdit_List(cls_Shifting obj)
        {
            try
            {
                var data = _context.ShiftingEdit_List(obj.shiftingID,obj.shiftingDID,obj.warehouseID).ToList();
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
        [Route("api/Shifting/GetInwardDetails")]
        public IHttpActionResult GetInwardDetails(cls_Shifting obj)
        {
            try
            {
                var data = _context.GetInwardDetails(obj.customerID,obj.LotNo).ToList();
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
        [Route("api/Shifting/Shifting_services")]
        public IHttpActionResult Shifting_services()
        {
            try
            {
                var data = _context.Shifting_services().ToList();
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