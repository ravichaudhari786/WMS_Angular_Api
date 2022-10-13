using System;
using System.Collections.Generic;
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
    public class CustomerTypesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpGet]
        [Route("api/CustomerTypes/Get_CustomerTypes")]
        public IHttpActionResult Get_CustomerTypes()
        {
            try
            {
                var data = _context.Get_CustomerTypes().ToList();
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
