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
    public class EditEntriesController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/EditEntries/GetInwardOutward_EditCharge")]
        public IHttpActionResult GetInwardOutward_EditCharge(EditEntriesSelecet es)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("GetInwardOutward_EditCharge", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@fromDate", es.FromDate);
                    param[1] = new SqlParameter("@ToDate", es.ToDate);
                    param[2] = new SqlParameter("@Process", es.Process);
                    param[3] = new SqlParameter("@lotno", es.lotno);
                    param[4] = new SqlParameter("@CustomerID", es.CustomerID);
                    
                    command.Parameters.AddRange(param);
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                    connection.Close();
                }
            }
            
            return Ok(ds.Tables[0]);
        }
        [HttpPost]
        [Route("api/EditEntries/EditEntries_insert")]
        public IHttpActionResult EditEntries_insert([FromBody] EditEntries_Save ees)
        {
            DataSet ds = new DataSet();
            DataTable dtEditEntries = CommanListToDataTableConverter.ConvertToDataTable(ees.TD_EditEntries);
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("EditEntries_insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@EditEntriesID", ees.EditEntriesID);
                    param[1] = new SqlParameter("@createdby", ees.createdby);
                    param[2] = new SqlParameter("@process", ees.process);
                    param[3] = new SqlParameter("@TD_EditEntries", dtEditEntries);

                    command.Parameters.AddRange(param);
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                    connection.Close();
                }
            }

            return Ok(ds.Tables[0]);
        }
    }
}
