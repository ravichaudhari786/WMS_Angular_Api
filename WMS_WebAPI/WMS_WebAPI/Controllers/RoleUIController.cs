using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class RoleUIController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/RoleUI/RoleUI_Insert_Update")]
        public IHttpActionResult RoleUI_Insert_Update(cls_RoleUI obj)
        {

            DataTable dtLTD_RolesUI = new DataTable();
            dtLTD_RolesUI = ConvertDataTable.ConvertToDataTable(obj.LTD_RolesUI);

            DataTable dtLTD_RoleReport = new DataTable();
            dtLTD_RoleReport = ConvertDataTable.ConvertToDataTable(obj.LTD_RoleReport);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("RoleUI_Insert_Update", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@Role", dtLTD_RolesUI);
                        param[1] = new SqlParameter("@RoleID", Convert.ToInt32(obj.RoleID));
                        param[2] = new SqlParameter("@TD_RoleReport", dtLTD_RoleReport);

                        param[3] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));


                        param[0].SqlDbType = SqlDbType.Structured;
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



        [HttpPost]
        [Route("api/RoleUI/RoleUI_Select")]
        public IHttpActionResult RoleUI_Select(cls_TD_RoleList obj)
        {
            try
            {
                //var data = _context.RoleUI_Select(obj.RoleID);                
                //return Ok(data);
                DataSet dsSelect = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("RoleUI_Select", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@RoleID", obj.RoleID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(dsSelect);
                        }
                        connection.Close();
                    }
                    return Ok(dsSelect);
                }
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/RoleUI/RolesList")]
        public IHttpActionResult RolesList()
        {
            try
            {
                var data = _context.Roles.ToList();
                return Ok(data);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
