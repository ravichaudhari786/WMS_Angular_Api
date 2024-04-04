using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/Users/Users_Select")]
        public IHttpActionResult Users_Select()
        {
            try
            {
                //var data = _context.Users_Select().ToList();
                //if (data == null)
                //{
                //    return NotFound();
                //}
                //return Ok(data);
                DataSet ds = new DataSet();
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionstring))
                    {
                        using (SqlCommand command = new SqlCommand("Users_Select", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            connection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(command))
                            {
                                da.Fill(ds);
                            }
                            connection.Close();
                        }
                        return Ok(ds.Tables[0]);
                    }
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/Users/Users_Insert")]
        public IHttpActionResult Users_Insert(cls_Users obj)
        {

            DataTable dtLcls_TD_Users = new DataTable();
            dtLcls_TD_Users = ConvertDataTable.ConvertToDataTable(obj.Lcls_TD_Users);
           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Users_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[8];
                        param[0] = new SqlParameter("@UserID", Convert.ToInt32(obj.UserID));
                        param[1] = new SqlParameter("@UserName", Convert.ToString(obj.UserName));
                        param[2] = new SqlParameter("@UserDetail", Convert.ToString(obj.UserDetail));
                        param[3] = new SqlParameter("@Password", Convert.ToString(obj.Password));
                        param[4] = new SqlParameter("@RoleID", Convert.ToInt32(obj.RoleID));
                        param[5] = new SqlParameter("@UserTypeID", Convert.ToInt32(obj.UserTypeID));
                        param[6] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));                      
                        param[7] = new SqlParameter("@UserCompany", dtLcls_TD_Users);
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
        [HttpGet]
        [Route("api/Users/UserType_List")]
        public IHttpActionResult UserType_List()
        {
            try
            {
                var data = _context.UserTypes.ToList();
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
        [Route("api/Users/Role_List")]
        public IHttpActionResult Role_List()
        {
            try
            {
                var data = _context.Roles.ToList();
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
        [Route("api/Users/Warehouse_List")]
        public IHttpActionResult Warehouse_List()
        {
            try
            {
                var data = _context.WareHouses.ToList();
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
        [Route("api/Users/CompanyMaster_List")]
        public IHttpActionResult CompanyMaster_List()
        {
            try
            {
                var data = _context.CompanyMasters.ToList();
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
        [Route("api/Users/Get_UserDetail")]
        public IHttpActionResult Get_UserDetail(int UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Get_UserDetail", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@UserID", Convert.ToInt32(UserID));
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        connection.Close();
                    }
                    return Ok(ds.Tables[0]);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
