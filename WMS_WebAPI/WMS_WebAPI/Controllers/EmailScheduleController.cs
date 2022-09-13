using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class EmailScheduleController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/EmailSchedule/EmailSchedule_List")]
        public IHttpActionResult EmailSchedule_List()
        {
            try
            {
                var data = _context.EmailSchedule_List().ToList();
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
        [Route("api/EmailSchedule/Email_Report_insert")]
        public IHttpActionResult Email_Report_insert(cls_EmailSchedule obj)
        {
            try
            {
                var data = _context.Email_Report_insert(obj.reportID,obj.today,obj.daily,obj.weekly,obj.weekly_Day,obj.monthly,obj.monthaly_day,obj.emailTime,
                    obj.emailReportID,obj.emailSubject,obj.emailText,obj.wareHouseID,obj.emailReportName,obj.createdBy,obj.emailReportDID);
                
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        [Route("api/EmailSchedule/EmailReport_Delete")]
        public IHttpActionResult EmailReport_Delete(cls_EmailSchedule obj)
        {
            try
            {
                var data = _context.EmailReport_Delete(obj.emailReportDID,obj.emailReportID).ToList();
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