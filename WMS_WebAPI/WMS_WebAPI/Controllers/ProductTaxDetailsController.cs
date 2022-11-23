using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ProductTaxDetailsController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/ProductTaxDetails/ProductTaxDetail_Select")]
        public IHttpActionResult ProductTaxDetail_Select()
        {
            try
            {
                var data = _context.ProductTaxDetail_Select().ToList();
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
        [Route("api/ProductTaxDetails/ProductTaxDetails_insert")]
        public IHttpActionResult ProductTaxDetails_insert(cls_ProductTaxDetails obj)
        {

            DataTable dtLTD_ProductTaxDetailProductID = new DataTable();
            dtLTD_ProductTaxDetailProductID = ConvertDataTable.ConvertToDataTable(obj.LTD_ProductTaxDetailProductID);

            DataTable dtLTD_ProductTaxDetailServiesIDs = new DataTable();
            dtLTD_ProductTaxDetailServiesIDs = ConvertDataTable.ConvertToDataTable(obj.LTD_ProductTaxDetailServiesIDs);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("ProductTaxDetails_insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@ProductTaxID", Convert.ToInt32(obj.ProductTaxID));
                        param[1] = new SqlParameter("@TaxID", Convert.ToInt32(obj.TaxID));
                        param[2] = new SqlParameter("@WefDate", Convert.ToDateTime(obj.WefDate));
                        param[3] = new SqlParameter("@TD_ProductID", dtLTD_ProductTaxDetailProductID);
                        param[4] = new SqlParameter("@TD_ServiesID", dtLTD_ProductTaxDetailServiesIDs);

                        param[5] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        param[6] = new SqlParameter("@HSNCode", Convert.ToString(obj.HSNCode));

                        param[3].SqlDbType = SqlDbType.Structured;
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
       
    }
}