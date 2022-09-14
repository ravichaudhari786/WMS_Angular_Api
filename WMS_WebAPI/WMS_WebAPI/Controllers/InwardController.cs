using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    public class InwardController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/InwardList")]
        public IHttpActionResult getInwardList(cls_Inward obj)
        {
            try
            {

               //Ravi
                var data = _context.GetInwardList(obj.CompanyId, obj.WarehouseId, obj.FinantialYearId).ToList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Inward/GetCustomerProducts")]
        public IHttpActionResult BindProduct(cls_Inward obj)
        {
            try
            {
                var data = _context.GetProductByID(obj.CustomerID, obj.WarehouseId).ToList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/Inward/BindSericeType")]
        public IHttpActionResult BindSericeType()
        {
            try
            {
                var data = _context.GetInwardStorageArea().ToList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Inward/GetInwardService")]
        public IHttpActionResult GetInwardService(cls_Inward obj)
        {
            try
            {
                //var data = _context.GetInwardServices(customerid, productid).ToList();
                //if (data == null)
                //{
                //    return NotFound();
                //}
                //return Ok(data);
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetInwardServices", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@CustomerID", obj.CustomerID);
                        param[1] = new SqlParameter("@ProductID", obj.ProductID);

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
        }

        [HttpPost]
        [Route("api/Inward/GetInwardChallanData")]
        public IHttpActionResult GetInwardChallanData(cls_Inward obj)
        {
            try
            {
                //var data = _context.GetInwardChallenData(customerid, warehouseid, challan).ToList();               
                //if (data == null)
                //{
                //    return NotFound();
                //}
                //return Ok(data);
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetInwardChallenData", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@CustomerID", obj.CustomerID);
                        param[1] = new SqlParameter("@WarehouseID", obj.WarehouseId);
                        param[2] = new SqlParameter("@ChallanNo", obj.challan);
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
        }


        [HttpPost]
        [Route("api/Inward/GetCustomerContact")]
        public IHttpActionResult GetCustomerContact(cls_Inward obj)
        {
            try
            {
                var data = _context.GetCustomerContacts(obj.CustomerID).ToList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Inward/GetLotNo")]
        public IHttpActionResult GetLotNo(cls_Inward obj)
        {
            try
            {
                var data = _context.GetLotNo(obj.WarehouseId, obj.StorageAreaMasterID, obj.FinancialYear, obj.FinantialYearId).ToList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }















        [HttpPost]
        [Route("api/Inward/GetAvailableStorageArea")]

        public IHttpActionResult GetAvailableStorageArea(AvailbaleStorageArea a)
        {
            try
            {
                cls_Inward obj = new cls_Inward();
                DataSet ds = new DataSet();
                DataTable dtchallanproduct = obj.ToDataTable(a.Cproduct);
                DataTable dtchallanlocation = obj.ToDataTable(a.Clocation);

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetAvailableStorageArea", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@WarehouseID", a.WarehouseID);
                        param[1] = new SqlParameter("@CustomerID", a.CustomerID);
                        param[2] = new SqlParameter("@Mode", a.Mode);
                        param[3] = new SqlParameter("@InwardID", Convert.ToInt32(0));
                        param[4] = new SqlParameter("@TDChallanProductList", dtchallanproduct);
                        param[5] = new SqlParameter("@TD_ChallanLocation", dtchallanlocation);
                        param[6] = new SqlParameter("@ChallanID", Convert.ToInt32(0));

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
        }

        [Route("api/Inward/GetServiceId")]
        [HttpGet]
        public IHttpActionResult GetServiceId(cls_Inward obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetStorageAreaTypeID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@ServiceID", obj.serviceID);
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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inward/GetInwardProductRate")]
        [HttpGet]
        public IHttpActionResult GetInwardProductRate(cls_Inward obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetInwardProduct_ServiceTypeRate", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@CustomerID", obj.CustomerID);
                        param[1] = new SqlParameter("@ProductID", obj.ProductID);
                        param[2] = new SqlParameter("@ServiceID", obj.serviceID);
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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inward/GetCustomerContacts")]
        [HttpGet]
        public IHttpActionResult GetCustomerContacts(cls_Inward obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetCustomerContacts", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@CustomerID", obj.CustomerID);
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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inward/SaveInward")]
        [HttpPost]
        public IHttpActionResult SaveInward([FromBody] InwardSaveModel ism)
        {
            try
            {
                DataTable dtInwardDetail = CommanListToDataTableConverter.ConvertToDataTable(ism.InwardDetailModel);
                DataTable dtInwardLocation = CommanListToDataTableConverter.ConvertToDataTable(ism.InwardLocationModel);
                DataTable dtInwardcharges = CommanListToDataTableConverter.ConvertToDataTable(ism.InwardChargesModel);
                DataTable dtInwardTransper = CommanListToDataTableConverter.ConvertToDataTable(ism.InwardTransperModel);
                //foreach (DataRow IDrow in dtInwardDetail.Rows)
                //{
                //    IDrow["MFDDate"] = "";
                //    IDrow["ExpDate"] = "";
                //}
                string Mode = "";
                if (ism.InwardID == 0)
                {
                    Mode = "New";
                }
                else
                {
                    Mode = "Update";
                }

                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Inward_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[19];
                        param[0] = new SqlParameter("@InwardID", Convert.ToInt32(ism.InwardID));
                        param[1] = new SqlParameter("@CustomerID", Convert.ToInt32(ism.CustomerID));
                        param[2] = new SqlParameter("@CompanyID", Convert.ToInt32(ism.CompanyID));
                        param[3] = new SqlParameter("@WareHouseID", Convert.ToInt32(ism.WarehouseID));
                        param[4] = new SqlParameter("@InwardDate", Convert.ToDateTime(ism.InwardDate));
                        param[5] = new SqlParameter("@BillingStartDate", Convert.ToDateTime(ism.InwardDate));
                        param[6] = new SqlParameter("@PersonName", "123");
                        param[7] = new SqlParameter("@Remarks", ism.Remarks);
                        param[8] = new SqlParameter("@FinancialYearID", Convert.ToInt32(ism.FinancialYearID));
                        param[9] = new SqlParameter("@CreatedBy", Convert.ToInt32(ism.UserID));
                        param[10] = new SqlParameter("@ReceiptNo", ism.ReceiptNo);
                        param[11] = new SqlParameter("@Mode", Mode);
                        param[12] = new SqlParameter("@TD_InwardDetail", dtInwardDetail);
                        param[13] = new SqlParameter("@TD_InwardLocation", dtInwardLocation);
                        param[14] = new SqlParameter("@TD_InwardCharges", dtInwardcharges);
                        param[15] = new SqlParameter("@TD_InwardTransport", dtInwardTransper);
                        param[16] = new SqlParameter("@DocID", Convert.ToInt32(ism.dockID));
                        param[17] = new SqlParameter("@UnLoadingBy", Convert.ToInt32(ism.UnLoadingBy));
                        param[18] = new SqlParameter("@StorageAreaMasterID", ism.StorageAreaMasterID);
                        param[12].SqlDbType = SqlDbType.Structured;
                        param[13].SqlDbType = SqlDbType.Structured;
                        param[14].SqlDbType = SqlDbType.Structured;
                        param[15].SqlDbType = SqlDbType.Structured;
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
        [Route("api/Inward/GetInwardDetailsByID")]
        public IHttpActionResult GetInwardDetailsByID(cls_Inward obj)
        {
            try
            {
                //var data = _context.GetInwardDetailsByID(InwardID).ToList();

                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetInwardDetailsByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@InwardID", obj.InwardID);
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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Inward/GetAppliedStoargeArea")]
        public IHttpActionResult GetAppliedStoargeArea([FromBody] InwardGetAvailableStorageArea iga)
        {
            try
            {
                //var data = _context.GetInwardDetailsByID(InwardID).ToList();

                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetAvailableStorageArea", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@WarehouseID", iga.WarehouseID);
                        param[1] = new SqlParameter("@CustomerID", iga.CustomerID);
                        param[2] = new SqlParameter("@Mode", iga.Mode);
                        param[3] = new SqlParameter("@InwardID", iga.InwardID);
                        param[4] = new SqlParameter("@TDChallanProductList", iga.InwardDetailModel);
                        param[5] = new SqlParameter("@TD_ChallanLocation", iga.InwardLocationModel);
                        param[6] = new SqlParameter("@ChallanID", iga.ChallanID);

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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/Inward/DeleteInward")]
        public IHttpActionResult DeleteInward(cls_Inward obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Inward_Cancelled", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@InwardID", obj.InwardID);
                        param[1] = new SqlParameter("@CustomerID", obj.CustomerID);
                        param[2] = new SqlParameter("@Remarks", obj.Remarks);
                        param[3] = new SqlParameter("@CreatedBy", obj.CreatedBy);
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
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
