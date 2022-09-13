using System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class ProcessServicesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/ProcessServices/ProcessServices_Insert")]
        public IHttpActionResult ProcessServices_Insert(Cls_ProcessServices obj)
        {
            DataTable dtLTD_ProcessServices = new DataTable();
            dtLTD_ProcessServices = ConvertDataTable.ConvertToDataTable(obj.LTD_ProcessServices);
           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("ProcessServices_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@ProcessIDID", Convert.ToInt32(obj.ProcessIDID));
                        param[1] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        param[2] = new SqlParameter("@ProcessID", Convert.ToInt32(obj.ProcessID));
                        
                        param[3] = new SqlParameter("@TD_ProcessServices", dtLTD_ProcessServices);
                       

                        param[3].SqlDbType = SqlDbType.Structured;
                       

                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        connection.Close();
                    }
                    return Ok(ds);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/Department/ProcessServices_Select")]
        public IHttpActionResult ProcessServices_Select(Cls_ProcessServices obj)
        {
            try
            {
                var data = _context.ProcessServices_Select(obj.ProcessID).ToList();
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