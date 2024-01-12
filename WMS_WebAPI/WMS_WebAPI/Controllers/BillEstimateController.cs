using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class BillEstimateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_storage_summary")]
        public IHttpActionResult Rep_Invoice_Estimate_storage_summary(cls_BillEstimate obj)
        {
            try
            {
                //var data = _context.Rep_Invoice_Estimate_storage_summary(obj.billStartDate, obj.billEndDate, obj.warehouseID);                
                //return Ok(data);
                DataSet ds = new DataSet();
                DataTable dtCustomers = CommanListToDataTableConverter.ConvertToDataTable(obj.CustomerModel);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_Invoice_Estimate_storage_summary", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@BillStartDate", obj.billStartDate);
                        param[1] = new SqlParameter("@BillEndDate", obj.billEndDate);
                        param[2] = new SqlParameter("@WarehouseID", obj.warehouseID);
                        param[3] = new SqlParameter("@TD_CustomerID", dtCustomers);
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
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_storage")]
        public IHttpActionResult Rep_Invoice_Estimate_storage(cls_BillEstimate obj)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtCustomers = CommanListToDataTableConverter.ConvertToDataTable(obj.CustomerModel);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_Invoice_Estimate_storage", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@BillStartDate", obj.billStartDate);
                        param[1] = new SqlParameter("@BillEndDate", obj.billEndDate);
                        param[2] = new SqlParameter("@WarehouseID", obj.warehouseID);
                        param[3] = new SqlParameter("@TD_CustomerID", dtCustomers);
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
            catch (System.Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("api/BillEstimate/Rep_Invoice_Estimate_Labour")]
        public IHttpActionResult Rep_Invoice_Estimate_Labour(cls_BillEstimate obj)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtCustomers = CommanListToDataTableConverter.ConvertToDataTable(obj.CustomerModel);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_Invoice_Estimate_Labour", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@BillStartDate", obj.billStartDate);
                        param[1] = new SqlParameter("@BillEndDate", obj.billEndDate);
                        param[2] = new SqlParameter("@WarehouseID", obj.warehouseID);
                        param[3] = new SqlParameter("@TD_CustomerID", dtCustomers);
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
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/BillEstimate/GetCustomers")]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                var data = _context.GetCustomers().ToList();
                return Ok(data);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }
    }
}