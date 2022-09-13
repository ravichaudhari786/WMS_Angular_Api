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
    public class ProductController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();

        [HttpGet]
        [Route("api/ProductTypes")]
        public IHttpActionResult GetProductType()
        {
            var data = _context.ProductTypes.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/ProductGroups")]
        public IHttpActionResult GetProductGroups()
        {
            var data = _context.ProductGroups.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/uomlist")]
        public IHttpActionResult GetUOMs()
        {
            var data = _context.UOMs.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/GetBillingCycles")]
        public IHttpActionResult GetBillingCycles()
        {
            var data = _context.BillingCycle_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/GetPackingTypes")]
        public IHttpActionResult GetPackingTypes()
        {
            var data = _context.PackingTypes.ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/TemperatureCategories")]
        public IHttpActionResult GetTemperatureCategories()
        {
            var data = _context.TemperatureCategories_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("api/ProductList")]
        public IHttpActionResult GetProductList()
        {
            var data = _context.Product_Select().ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        //OnItem Selection Change----------
        [HttpGet]
        [Route("api/itemwisetempCategory")]
        public IHttpActionResult Get_TemperatureCategory(int itemid)
        {
            var data = _context.Get_TemperatureCategory(itemid).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("api/SaveProduct")]
        public IHttpActionResult SaveProduct(ProductMaster p)
        {
            var data = _context.ProductMaster_Insert_Update(p.ProductID, p.ProductCode, p.ProductName, p.ItemID, p.ProductGroupID, p.PackingTypeID, p.UOMID,
                Convert.ToDecimal(p.ItemUnit), p.ItemCount, p.ProductTypeID, p.ProductTaxCategoryID, p.TemperatureCategoryID, p.WeightinKG, p.Width, p.Length, p.Height, p.CubicArea,
                p.SelfLife, p.IsActive, p.CreatedBy, p.ApproxValue, p.BillingcycleID).ToList();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }

}
