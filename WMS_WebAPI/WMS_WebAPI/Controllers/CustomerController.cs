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
    [Authorize]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        private WMS_Entities _context;

        CustomerController()
        {
            _context = new WMS_Entities();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCustomer()
        {
            try
            {
                var data = _context.GetCustomers().ToList();
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
        #region old 
        //[Route("customerbyWarehouse/{warehousID}")]
        //public IHttpActionResult GetCustomer(int warehouseid)
        //{
        //    var data = _context.GetCustomerName(warehouseid).ToList();
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(data);
        //}
        #endregion
        #region Chnage by dharmendra  on 06-09-2022
        [HttpGet]
        [Route("GetCustomerbyid")]
        public IHttpActionResult GetCustomerbyid(cls_Warehouse obj)
        {
            try
            {
                var data = _context.GetCustomerName(obj.WarehouseID).ToList();
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
        [Route("Customer_Select")]
        public IHttpActionResult Customer_Select()
        {
            try
            {
                var data = _context.Customer_Select().ToList();
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
        [Route("CustomerContact_Select")]
        public IHttpActionResult CustomerContact_Select(cls_CustomerUsers obj)
        {
            try
            {
                var data = _context.CustomerContact_Select(obj.CustomerID).ToList();
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
        [Route("CustomerDocument_Select")]
        public IHttpActionResult CustomerDocument_Select(cls_CustomerUsers obj)
        {
            try
            {
                var data = _context.CustomerDocument_Select(obj.CustomerID).ToList();
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
        [Route("Get_GststateCode")]
        public IHttpActionResult Get_GststateCode(cls_GstStateCode obj)
        {
            try
            {
                var data = _context.Get_GststateCode(obj.stateID).ToList();
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
        [Route("Customers_Insert")]
        public IHttpActionResult Customers_Insert(cls_Customer obj)
        {

            DataTable dtcustomerContacts = new DataTable();
            dtcustomerContacts = ConvertDataTable.ConvertToDataTable(obj.customerContacts);
            DataTable TD_CustomerDocuments = new DataTable();
            TD_CustomerDocuments = ConvertDataTable.ConvertToDataTable(obj.TD_CustomerDocuments);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Customers_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[24];
                        param[0] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
                        param[1] = new SqlParameter("@WarehouseID", Convert.ToInt32(obj.WarehouseID));
                        param[2] = new SqlParameter("@Initials", Convert.ToString(obj.Initials));
                        param[3] = new SqlParameter("@CustomerName", Convert.ToString(obj.CustomerName));
                        param[4] = new SqlParameter("@CustomerCode", Convert.ToString(obj.CustomerCode));
                        param[5] = new SqlParameter("@CustomerTypeID", Convert.ToInt32(obj.CustomerTypeID));
                        param[6] = new SqlParameter("@Address1", Convert.ToString(obj.Address1));
                        param[7] = new SqlParameter("@Address2", Convert.ToString(obj.Address2));
                        param[8] = new SqlParameter("@GroupName", Convert.ToString(obj.GroupName));
                        param[9] = new SqlParameter("@CityId", Convert.ToInt32(obj.CityId));
                        param[10] = new SqlParameter("@Email", Convert.ToString(obj.Email));
                        param[11] = new SqlParameter("@Gstno", Convert.ToString(obj.Gstno));
                        param[12] = new SqlParameter("@Panno", Convert.ToString(obj.Panno));
                        param[13] = new SqlParameter("@customerContacts", dtcustomerContacts);
                        param[14] = new SqlParameter("@TD_CustomerDocuments", TD_CustomerDocuments);
                        param[15] = new SqlParameter("@createdby", Convert.ToInt32(obj.createdby));
                        param[16] = new SqlParameter("@State", Convert.ToInt32(obj.State));
                        param[17] = new SqlParameter("@FICINo", Convert.ToString(obj.FICINo));
                        param[18] = new SqlParameter("@StorageDiscount", Convert.ToDecimal(obj.StorageDiscount));
                        param[19] = new SqlParameter("@LabourDiscount", Convert.ToDecimal(obj.LabourDiscount));
                        param[20] = new SqlParameter("@ReferredBy", Convert.ToString(obj.ReferredBy));
                        param[21] = new SqlParameter("@PinCode", Convert.ToString(obj.PinCode));
                        param[22] = new SqlParameter("@GSTStateCode", Convert.ToString(obj.GSTStateCode));
                        param[23] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));

                        param[13].SqlDbType = SqlDbType.Structured;
                        param[14].SqlDbType = SqlDbType.Structured;

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


        #endregion
    }

}
