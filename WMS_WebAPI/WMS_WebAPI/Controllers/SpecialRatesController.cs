using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class SpecialRatesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/SpecialRates/SpecialRate_List")]
        public IHttpActionResult SpecialRate_List()
        {
            try
            {
                var data = _context.SpecialRate_List().ToList();
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
        [Route("api/SpecialRates/SpecialRatelist_Insert")]
        public IHttpActionResult SpecialRatelist_Insert(cls_SpecialRates obj)
        {

            DataTable dtL_TD_Rate = new DataTable();
            dtL_TD_Rate = ConvertDataTable.ConvertToDataTable(obj.L_TD_Rate);
            
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SpecialRatelist_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[9];
                        param[0] = new SqlParameter("@SpecialRateID", Convert.ToInt32(obj.SpecialRateID));
                        param[1] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
                        param[2] = new SqlParameter("@ProductID", Convert.ToInt32(obj.ProductID));
                        param[3] = new SqlParameter("@WarehouseID", Convert.ToInt32(obj.WarehouseID));

                        param[4] = new SqlParameter("@Rate", dtL_TD_Rate);

                        param[5] = new SqlParameter("@TaxID", Convert.ToInt32(obj.TaxID));
                        param[6] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        param[7] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
                        param[8] = new SqlParameter("@wef", Convert.ToDateTime(obj.wef));

                        param[4].SqlDbType = SqlDbType.Structured;
                       

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
        [Route("api/SpecialRates/SpecialRate_Services")]
        public IHttpActionResult SpecialRate_Services(cls_SpecialRates obj)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SpecialRate_Services", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@ProductID", Convert.ToInt32(obj.ProductID));
                        param[1] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
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
<<<<<<< HEAD

        [HttpPost]
        [Route("api/SpecialRates/SpecialRate_Services")]
        public IHttpActionResult SpecialRate_Services(cls_SpecialRates obj)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("SpecialRate_Services", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@ProductID", Convert.ToInt32(obj.ProductID));
                        param[1] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
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

=======
>>>>>>> ef8bcba584c805c8df8bdd2abcc7106da6d33030

    }
}
