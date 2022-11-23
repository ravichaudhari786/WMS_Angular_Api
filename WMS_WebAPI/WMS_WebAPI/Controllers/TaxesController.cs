using System;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class TaxesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        [HttpPost]
        [Route("api/Taxes/Taxes_Insert")]
        public IHttpActionResult Taxes_Insert(cls_Taxes obj)
        {
            DataTable dtLTD_Taxes = new DataTable();
            dtLTD_Taxes = ConvertDataTable.ConvertToDataTable(obj.LTD_Taxes);
           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Taxes_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[5];
                        param[0] = new SqlParameter("@TaxID", Convert.ToInt32(obj.TaxID));
                        param[1] = new SqlParameter("@TaxCode", Convert.ToString(obj.TaxCode));
                        param[2] = new SqlParameter("@TaxDescription", Convert.ToString(obj.TaxDescription));
                        param[3] = new SqlParameter("@IsActive", Convert.ToBoolean(obj.IsActive));
                        param[4] = new SqlParameter("@Taxes", dtLTD_Taxes);
                       
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


        [HttpGet]
        [Route("api/Taxes/TaxDetail_Select")]
        public IHttpActionResult TaxDetail_Select()
        {
            try
            {
                var data = _context.TaxDetail_Select().ToList();
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
        [Route("api/Taxes/TaxList")]
        public IHttpActionResult TaxList()
        {
            try
            {
                var data = _context.TaxMasters.ToList();
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