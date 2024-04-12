using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ReportPrintInfoController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/ReportPrintInfo/PageSizes")]
        public IHttpActionResult PageSizes()
        {
            try
            {
                var data = _context.PageSizes.ToList();
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
        [Route("api/ReportPrintInfo/ReportPrint_InfoUpdate")]
        public IHttpActionResult ReportPrint_InfoUpdate(REportPrintInfoclass obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("ReportPrint_InfoUpdate", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[8];
                        param[0] = new SqlParameter("@ReportID", obj.ReportID);
                        param[1] = new SqlParameter("@PrinterName", obj.PrinterName);
                        param[2] = new SqlParameter("@PageSize", obj.PageSize);
                        param[3] = new SqlParameter("@Oriantation", obj.Oriantation);
                        param[4] = new SqlParameter("@TopMargin", obj.TopMargin);
                        param[5] = new SqlParameter("@LeftMargin", obj.LeftMargin);
                        param[6] = new SqlParameter("@BottomMargin", obj.BottomMargin);
                        param[7] = new SqlParameter("@RightMargin", obj.RightMargin);
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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ReportPrintInfo/ReportPrintInfo_Select")]
        public IHttpActionResult ReportPrintInfo_Select()
        {
            try
            {
                var data = _context.ReportPrintInfo_Select().ToList();
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
