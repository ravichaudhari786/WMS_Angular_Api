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
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
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
        public IHttpActionResult Email_Report_insert(EmailScheduleSave obj)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtCustomers = CommanListToDataTableConverter.ConvertToDataTable(obj.CustomerModel);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Email_Report_insert", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[16];
                        param[0] = new SqlParameter("@ReportID", obj.ReportID);
                        param[1] = new SqlParameter("@CustomerID", dtCustomers);
                        param[2] = new SqlParameter("@Today", Convert.ToBoolean(obj.Today));
                        param[3] = new SqlParameter("@Daily", Convert.ToBoolean(obj.Daily));
                        param[4] = new SqlParameter("@Weekly", Convert.ToBoolean(obj.Weekly));
                        param[5] = new SqlParameter("@weekly_Day", Convert.ToString(obj.weekly_Day));
                        param[6] = new SqlParameter("@Monthly", Convert.ToBoolean(obj.Monthly));
                        param[7] = new SqlParameter("@Monthaly_day", obj.Monthaly_day);
                        param[8] = new SqlParameter("@EmailTime", Convert.ToDateTime(obj.EmailTime));
                        param[9] = new SqlParameter("@EmailReportID", Convert.ToInt32(obj.EmailReportID));
                        param[10] = new SqlParameter("@EmailSubject", obj.EmailSubject);
                        param[11] = new SqlParameter("@EmailText", obj.EmailText);
                        param[12] = new SqlParameter("@EmailReportName", obj.EmailReportName);
                        param[13] = new SqlParameter("@WareHouseID", obj.WareHouseID);
                        param[14] = new SqlParameter("@CreatedBy", obj.CreatedBy);
                        param[15] = new SqlParameter("@EmailReportDID", Convert.ToInt32(obj.EmailReportDID));

                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        connection.Close();
                    }
                }

                return Ok(ds.Tables[0]);
            }
            catch (System.Exception ex)
            {
                string dds = ex.Message.ToString();
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

        [HttpPost]
        [Route("api/EmailSchedule/Email_CustomerContractList")]
        public IHttpActionResult Email_CustomerContractList(int cid)
        {
            try
            {
                var data = _context.Email_CustomerContractList(cid).ToList();
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
        [Route("api/EmailSchedule/Email_ReportList")]
        public IHttpActionResult Email_ReportList(int Rid)
        {
            try
            {
                var data = _context.Email_ReportList(Rid).ToList();
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