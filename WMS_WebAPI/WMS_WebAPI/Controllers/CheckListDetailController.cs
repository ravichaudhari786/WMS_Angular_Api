using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class CheckListDetailController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/CheckListDetail/CheckListDetail_Insert")]
        public IHttpActionResult CheckListDetail_Insert(cls_CheckListDetail obj)
        {

            DataTable dtLTD_CheckListDetail = new DataTable();
            dtLTD_CheckListDetail = ConvertDataTable.ConvertToDataTable(obj.LTD_CheckListDetail);
           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("CheckListDetail_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@CheckListDetailID", Convert.ToInt32(obj.CheckListDetailID));
                        param[1] = new SqlParameter("@TD_CheckListDetails", dtLTD_CheckListDetail);
                       
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
        [Route("api/CheckListDetail/CheckListDetail_List")]
        public IHttpActionResult CheckListDetail_List(cls_CheckListDetail obj)
        {
            try
            {
                var data = _context.CheckListDetail_List(obj.periodType).ToList();
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