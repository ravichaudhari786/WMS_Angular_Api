using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CityController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        #region City  Part
        [HttpPost]
        [Route("api/City/Cities_Insert")]
        public IHttpActionResult Cities_Insert(cls_City obj)
        {
            try
            {
                var data = _context.Cities_Insert(obj.CityID,obj.City,obj.StateID,obj.CreatedBy).ToList();
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
        [Route("api/City/Cities_Select")]
        public IHttpActionResult Cities_Select()
        {
            try
            {
                var data = _context.Cities_Select().ToList();
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

        #endregion End City Part

        #region State Part

        [HttpPost]
        [Route("api/City/States_insert")]
        public IHttpActionResult States_insert(States obj)
        {
            try
            {
                var data = _context.States_insert(obj.StateID,obj.State,obj.StateCode,obj.CreatedBy,obj.GstCode).ToList();
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
        [Route("api/City/States_Select")]
        public IHttpActionResult States_Select()
        {
            try
            {
                var data = _context.States_Select().ToList();
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

        #endregion End State Part


    }
}