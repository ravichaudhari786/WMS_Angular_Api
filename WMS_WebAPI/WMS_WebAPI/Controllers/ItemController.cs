using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{

    [Authorize]
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        private WMS_Entities _context;

        ItemController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("itemlist")]
        public IHttpActionResult GetItems()
        {
            var data = _context.Items_Select().ToList();
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("itemType")]
        public IHttpActionResult GetItemType()
        {
            var data = _context.ItemTypeMaster_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult PostItems(Item i)
        {
            var data = _context.Items_Insert_Update(i.ItemID,i.ItemCode,i.ItemName,i.CreatedBy,i.ItemTypeID,i.TemperatureCategoryID,i.IsActive).ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        #region add  by dharmendra bhadoria

        [HttpGet]
        [Route("Items_Select")]
        public IHttpActionResult Items_Select()
        {
            try
            {
                var data = _context.Items_Select().ToList();
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
        [Route("Items_Insert_Update")]
        public IHttpActionResult Items_Insert_Update(Item i)
        {
            try
            {
                var data = _context.Items_Insert_Update(i.ItemID, i.ItemCode, i.ItemName, i.CreatedBy, i.ItemTypeID, i.TemperatureCategoryID, i.IsActive).ToList();
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
