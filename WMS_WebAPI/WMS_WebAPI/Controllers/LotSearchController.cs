using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class LotSearchController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/LotSearch/LotSearch_List")]
        public IHttpActionResult LotSearch_List(cls_LotSearch obj)
        {
            try
            {
                //var data = _context.LotSearch_List(obj.lotNo,obj.wareHouseID).ToList();
                //if (data == null)
                //{
                //    return NotFound();
                //}
                //return Ok(data);
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("LotSearch_List", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@LotNo", obj.lotNo);
                        param[1] = new SqlParameter("@WareHouseID", obj.wareHouseID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);

                        }

                        connection.Close();
                    }
                }
                var data = ds;
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
    }
}