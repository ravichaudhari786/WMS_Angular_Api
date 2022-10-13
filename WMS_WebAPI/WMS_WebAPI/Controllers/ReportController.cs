using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

       

        [HttpGet]
        [Route("api/Report/GetReports")]
        public IHttpActionResult GetReports()
        {
            try
            {
                var data = _context.GetReports().ToList();
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
        [Route("api/Report/GetInvoiceType")]
        public IHttpActionResult GetInvoiceType()
        {
            try
            {
                var data = _context.GetInvoiceType().ToList();
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
        [Route("api/Report/GetCustomerName")]
        public IHttpActionResult GetCustomerName(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.GetCustomerName(obj.WarehouseID).ToList();
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
        [Route("api/Report/GetAllLabourContractor")]
        public IHttpActionResult GetAllLabourContractor()
        {
            try
            {
                var data = _context.GetAllLabourContractor().ToList();
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
        [Route("api/Report/AllCustomerGroup")]
        public IHttpActionResult AllCustomerGroup(cls_CustomersStock obj)
        {
            try
            {
                var data = _context.AllCustomerGroup(obj.WarehouseID).ToList();
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
        [Route("api/Report/GetAllUserName")]
        public IHttpActionResult GetAllUserName()
        {
            try
            {
                var data = _context.GetAllUserName().ToList();
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
        [Route("api/Report/GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var data = _context.GetAllProducts().ToList();
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
        [Route("api/Report/GetAllBrands")]
        public IHttpActionResult GetAllBrands()
        {
            try
            {
                var data = _context.GetAllBrands().ToList();
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
        [Route("api/Report/GetAllStorageArea")]
        public IHttpActionResult GetAllStorageArea()
        {
            try
            {
                var data = _context.GetAllStorageArea().ToList();
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
