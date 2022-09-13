using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Warehouse")]
    public class WarehouseController : ApiController
    {
        private WMS_Entities _context;

        WarehouseController()
        {
            _context = new WMS_Entities();
        }

        
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetWarehouse()
        {
            var data = _context.Warehouses_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetWarehouseByID(int id)
        {
            var data = _context.Warehouses_Select().Where(w => w.WareHouseID == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("userWarehouse")]
        public IHttpActionResult GetUserWarehouses(int userid,int companyId)
        {
            var data = _context.UserCompanyWareHouseList_select(userid, companyId).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }


        #region add  by dharmendra Bhadoria
        [HttpPost]
        [Route("Warehouse_Insert_Update")]
        public IHttpActionResult Warehouse_Insert_Update(cls_Warehouse obj)
        {
            try
            {
                var data = _context.Warehouse_Insert_Update(obj.WarehouseID, obj.CompanyID, obj.WarehouseName, obj.WarehouseCode,
               obj.Address1, obj.Address2, obj.Address3, obj.TelNumber, obj.Fax, obj.EmailID, obj.CityId, obj.Logo, obj.createdby).ToList();
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
        [Route("Warehouses_Select")]
        public IHttpActionResult Warehouses_Select()
        {
            try
            {
                var data = _context.Warehouses_Select().ToList();
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

        #endregion
    }
}
