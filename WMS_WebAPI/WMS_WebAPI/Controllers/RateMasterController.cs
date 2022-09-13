using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class RateMasterController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/RateMaster/Rate_Select")]
        public IHttpActionResult Rate_Select()
        {
            try
            {
                var data = _context.Rate_Select().ToList();
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
        [Route("api/RateMaster/Rate_Insert")]
        public IHttpActionResult Rate_Insert(cls_RateMaster obj)
        {

            DataTable dtLTD_RateList = new DataTable();
            dtLTD_RateList = ConvertDataTable.ConvertToDataTable(obj.LTD_RateList);
           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rate_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
                        param[1] = new SqlParameter("@RateCode", Convert.ToString(obj.RateCode));
                        param[2] = new SqlParameter("@RateDescription", Convert.ToString(obj.RateDescription));
                        param[3] = new SqlParameter("@StartDate", Convert.ToDateTime(obj.StartDate));
                        param[4] = new SqlParameter("@EndDate", Convert.ToDateTime(obj.EndDate));
                        param[5] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        param[6] = new SqlParameter("@TD_RateList", dtLTD_RateList);

                        param[6].SqlDbType = SqlDbType.Structured;

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
    }
}