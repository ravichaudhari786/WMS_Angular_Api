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

    [RoutePrefix("api/Customer")]
    public class customerViewController : ApiController
    {
        private WMS_Entities _context;
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        customerViewController()
        {
            _context = new WMS_Entities();
        }

        [HttpPost]
        [Route("CustomerView_GetData")]
        public IHttpActionResult CustomerView_GetData(cls_CustomersStock obj)
        {
            try
            {
                
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("CustomerView_GetData", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@CustomerID", obj.CustomerID);
                        param[1] = new SqlParameter("@LotNo", obj.LotNo);
                        param[2] = new SqlParameter("@WarehouseID", obj.WarehouseID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        connection.Close();
                    }
                }
                return Ok(ds);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //try
            //{
            //    var data = _context.CustomerView_GetData(obj.CustomerID,obj.WarehouseID,obj.LotNo).ToList();
            //    if (data == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(data);
            //}
            //catch (System.Exception e)
            //{

            //    return BadRequest();
            //}

        }

    }
}
