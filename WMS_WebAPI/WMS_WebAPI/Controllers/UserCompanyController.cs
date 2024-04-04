using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Rest.Api.V2010;

namespace WMS_WebAPI.Controllers
{
    public class UserCompanyController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/UserCompany/UserCompany_Insert")]
        public IHttpActionResult UserCompany_Insert(cls_UserCompany obj)
        {
            DataTable dtLTD_UserCompany = new DataTable();
            dtLTD_UserCompany = ConvertDataTable.ConvertToDataTable(obj.LTD_UserCompany);
          
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("UserCompany_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@UserCompanyID", Convert.ToInt32(obj.UserCompanyID));

                        param[1] = new SqlParameter("@UserCompany", dtLTD_UserCompany);
                        param[2] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                       
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
        [HttpGet]
        [Route("api/UserCompany/UserCompanyList_select")]
        public IHttpActionResult UserCompanyList_select()
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("UserCompanyList_select", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds1);
                        }
                        connection.Close();
                    }
                    return Ok(ds1.Tables[0]);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/UserCompany/UserCompanyWareHouseList_select")]
        public IHttpActionResult UserCompanyWareHouseList_select(cls_UserCompanyWareHouseList obj)
        {
            try
            {
                var data = _context.UserCompanyWareHouseList_select(obj.UserID,obj.CompanyID).ToList();
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
