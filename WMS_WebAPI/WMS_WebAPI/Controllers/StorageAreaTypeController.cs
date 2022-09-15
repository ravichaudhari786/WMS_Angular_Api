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
  
    public class StorageAreaTypeController : ApiController
    {
        private WMS_Entities _context;

        StorageAreaTypeController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("api/StorageAreaType/ServieceStorageAreaType")]
        public IHttpActionResult ServieceStorageAreaType()
        {
            var data = _context.GetInwardStorageArea().ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpPost]
        [Route("api/StorageAreaType/StorageAreaType_Insert_Update")]
        public IHttpActionResult StorageAreaType_Insert_Update(cls_StorageAreaType obj)
        {
            try
            {
                var data = _context.StorageAreaType_Insert_Update(obj.StorageAreaTypeID,obj.StorageAreaType,obj.TemperatureCategoryID,
                    obj.IsActive,obj.CreatedBy).ToList();
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
        [Route("api/StorageAreaType/StorageAreaType_Select")]
        public IHttpActionResult StorageAreaType_Select()
        {
            try
            {
                var data = _context.StorageAreaType_Select().ToList();
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
