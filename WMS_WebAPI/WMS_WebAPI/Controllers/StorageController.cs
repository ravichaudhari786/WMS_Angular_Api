using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class StorageController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Storage/StorageAreas_Insert")]
        public IHttpActionResult StorageAreas_Insert(cls_Storage obj)
        {

            DataTable dtLTD_StorageAreaS = new DataTable();
            dtLTD_StorageAreaS = ConvertDataTable.ConvertToDataTable(obj.LTD_StorageAreaS);
            
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("StorageAreas_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@StorageAreaID", Convert.ToInt32(obj.StorageAreaID));

                        param[1] = new SqlParameter("@Storage", dtLTD_StorageAreaS);


                        param[2] = new SqlParameter("@createdBy", Convert.ToInt32(obj.createdBy));
                        param[3] = new SqlParameter("@BlockID", Convert.ToInt32(obj.BlockID));
                        

                        param[1].SqlDbType = SqlDbType.Structured;
                        

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
        [Route("api/Storage/StorageArea_Select")]
        public IHttpActionResult StorageArea_Select(cls_Storage obj)
        {
            try
            {
                var data = _context.StorageArea_Select(obj.warehouseID).ToList();
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