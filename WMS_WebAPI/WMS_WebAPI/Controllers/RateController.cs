using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class RateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/Rate/RateList_Select")]
        public IHttpActionResult RateList_Select()
        {
            try
            {
                var data = _context.RateList_Select().ToList();
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
        [Route("api/Rate/Ratelist_Insert")]
        public IHttpActionResult Ratelist_Insert(cls_Rate obj)
        {

            DataTable dtLTD_Customer = new DataTable();
            dtLTD_Customer = ConvertDataTable.ConvertToDataTable(obj.LTD_Customer);


            DataTable dtLTD_Rate = new DataTable();
            dtLTD_Rate = ConvertDataTable.ConvertToDataTable(obj.LTD_Rate);


            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Ratelist_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[8];
                        param[0] = new SqlParameter("@RateListID", Convert.ToInt32(obj.RateListID));
                        param[1] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
                        param[2] = new SqlParameter("@ProductID", Convert.ToInt32(obj.ProductID));
                        param[3] = new SqlParameter("@WarehouseID", Convert.ToInt32(obj.WarehouseID));

                        param[4] = new SqlParameter("@Rate", dtLTD_Rate);
                        param[5] = new SqlParameter("@TaxID", Convert.ToInt32(obj.TaxID));
                        param[6] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        
                        param[7] = new SqlParameter("@TD_Customer", dtLTD_Customer);

                        param[4].SqlDbType = SqlDbType.Structured;

                        param[7].SqlDbType = SqlDbType.Structured;

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
        [Route("api/Rate/Rate_Services")]
        public IHttpActionResult Rate_Services(cls_SpecialRates obj)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rate_Services", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@ProductID", Convert.ToInt32(obj.ProductID));
                        param[1] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
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
