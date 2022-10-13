using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ModifyProductRatesController : ApiController
    {

        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/ModifyProductRates/ModifyProductRate_Insert")]
        public IHttpActionResult ModifyProductRate_Insert(cls_ModifyProductRates obj)
        {
            try
            {
                var data = _context.ModifyProductRate_Insert(obj.ProductID,obj.RateID,obj.serviceId,obj.Rate,obj.CreatedBy,obj.CustomerID).ToList();
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
        [Route("api/ModifyProductRates/GetProductRate")]
        public IHttpActionResult GetProductRate(Cls_ProductRates obj)
        {

            DataTable TD_CustomerReport = new DataTable();
            TD_CustomerReport = ConvertDataTable.ConvertToDataTable(obj.TD_CustomerReport);
            DataTable TD_ProductReport = new DataTable();
            TD_ProductReport = ConvertDataTable.ConvertToDataTable(obj.TD_ProductReport);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetProductRate", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[6];
                        param[0] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
                        param[1] = new SqlParameter("@TD_CustomerReport", TD_CustomerReport);
                        param[2] = new SqlParameter("@TD_ProductReport", TD_ProductReport);


                        param[3] = new SqlParameter("@FromDate", Convert.ToDateTime(obj.FromDate));
                        param[4] = new SqlParameter("@ToDate", Convert.ToDateTime(obj.ToDate));
                        param[5] = new SqlParameter("@LotNo", Convert.ToString(obj.LotNo));
                        param[1].SqlDbType = SqlDbType.Structured;
                        param[2].SqlDbType = SqlDbType.Structured;

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