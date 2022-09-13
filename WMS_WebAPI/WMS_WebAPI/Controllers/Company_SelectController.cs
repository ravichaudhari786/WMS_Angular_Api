using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class Company_SelectController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/Company_Select/Company_Insert_Update")]
        public IHttpActionResult Company_Insert_Update(cls_Company_Select obj)
        {
            try
            {
                var data = _context.Company_Insert_Update(obj.CompanyID,obj.Companyname,obj.CompanyCode,
                    obj.Address1,obj.Address2,obj.Address3,obj.CityId,obj.Pincode,obj.ContactNo,obj.MobileNo,obj.Gstno,obj.Panno,
                    obj.ParentCompanyId,obj.createdby).ToList();
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
        [Route("api/Company_Select/Company_Select")]
        public IHttpActionResult Company_Select()
        {
            try
            {
                var data = _context.Company_Select().ToList();
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