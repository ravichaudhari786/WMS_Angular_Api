using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    public class DeliveryOrderController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpGet]
        [Route("api/DeliveryOrder/GetCustomerProducts")]
        public IHttpActionResult BindProduct(int customerid, int warehouseid)
        {
            try
            {
                var data = _context.GetProductByID(customerid, warehouseid).ToList();
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
        [Route("api/DeliveryOrder/DOSearch")]
        public IHttpActionResult DOSearch(int CustomerID,int WarehouseID)
        {
            try
            {
                var data = _context.DeliveryOrder_Search(CustomerID, WarehouseID).ToList();
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
        [HttpGet]
        [Route("api/DeliveryOrder/DOList")]
        public IHttpActionResult GetDOList(int FinancialYearID, int WareHouseID, int UserID)
        {
            try
            {
                var data = _context.DeliveryOrder_List(FinancialYearID, WareHouseID, UserID).ToList();
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
        [Route("api/DeliveryOrder/AddParty")]
        public IHttpActionResult AddParty([FromBody]CustomerParty cp)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("CustomerParties_Insert", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@CustomerPartyID", Convert.ToInt32(0));
                        param[1] = new SqlParameter("@CustomerID", cp.CustomerID);
                        param[2] = new SqlParameter("@PartyName", cp.PartyName);
                        param[3] = new SqlParameter("@ShippingAddress", cp.ShippingAddress);
                        param[4] = new SqlParameter("@ShippingAddress1", cp.ShippingAddress1);
                        param[5] = new SqlParameter("@PinCode", cp.PinCode);
                        param[6] = new SqlParameter("@CreatedBy", cp.CreatedBy);
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
        [HttpGet]
        [Route("api/DeliveryOrder/DOValidation")]
        public IHttpActionResult DOValidation(int CustomerID,int WaherhouseID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("StopDeliveryOrder_Validation", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@CustomerID", Convert.ToInt32(CustomerID));
                        param[1] = new SqlParameter("@WaherhouseID", WaherhouseID);
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
        [Route("api/DeliveryOrder/SaveDO")]
        public IHttpActionResult SaveDO([FromBody]DeliveryOrderSaveModel dod)
        {
            DataTable dtDODetail = CommanListToDataTableConverter.ConvertToDataTable(dod.DeliveryOrderDetailModel);
            DataView dv = new DataView(dtDODetail);
            DataTable dtn = dv.ToTable(false, "DeliveryOrderID", "ProductID", "InwardDID", "LotNO", "DOQuantity", "InwardLocationID", "StorageAreaID");
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("DeliveryOrder_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[16];
                    param[0] = new SqlParameter("@DeliveryOrderID", dod.DeliveryOrderID);
                    param[1] = new SqlParameter("@DeliveryOrderDate", Convert.ToDateTime(dod.DeliveryOrderDate));
                    param[2] = new SqlParameter("@CustomerID", Convert.ToInt32(dod.CustomerID));
                    param[3] = new SqlParameter("@WareHouseID", dod.WareHouseID);
                    param[4] = new SqlParameter("@CompanyID", dod.CompanyID);
                    param[5] = new SqlParameter("@DeliverTo", dod.DeliverTo);
                    param[6] = new SqlParameter("@CustomerPartyID", Convert.ToInt32(dod.CustomerPartyID));
                    param[7] = new SqlParameter("@ShippingAddress", dod.ShippingAddress);
                    param[8] = new SqlParameter("@OrderGivenBy", dod.OrderGivenBy);
                    param[9] = new SqlParameter("@Remarks", dod.Remarks);
                    param[10] = new SqlParameter("@CreatedBy", dod.CreatedBy);
                    param[11] = new SqlParameter("@ByCustomer", Convert.ToInt32(0));
                    param[12] = new SqlParameter("@TD_DeliveryOrderDetail", dtn);
                    param[13] = new SqlParameter("@IsDoDispatch", Convert.ToBoolean(dod.IsDoDispatch));
                    param[14] = new SqlParameter("@TruckNo", dod.TruckNo);
                    param[15] = new SqlParameter("@ContainerNo",dod.ContainerNo);
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
        [HttpGet]
        [Route("api/DeliveryOrder/GetEditDelivryOrder")]
        public IHttpActionResult GetEditDelivryOrder(int DeliveryOrderID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("DeliveryOrder_Select", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@DeliveryOrderID", Convert.ToInt32(DeliveryOrderID));
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
        [Route("api/DeliveryOrder/CancelledDO")]
        public IHttpActionResult CancelledDO(int DeliveryOrderID, int CustomerId,string Remarks, int CreatedBy)
        {
            try
            {
                var data = _context.DeliveryOrder_Cancelled(DeliveryOrderID, CustomerId, Remarks, CreatedBy).ToList();
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
        [Route("api/DeliveryOrder/PartiallyCancelled")]
        public IHttpActionResult PartiallyCancelled(int DeliveryOrderID, int CustomerId, string Remarks, int CreatedBy)
        {
            try
            {
                var data = _context.DeliveryOrder_PartiallyCancelled(DeliveryOrderID, CustomerId, Remarks, CreatedBy).ToList();
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
        [HttpGet]
        [Route("api/DeliveryOrder/DeliveryOrderReceipt")]
        public IHttpActionResult DeliveryOrderReceipt(int DeliveryOrderID)
        {
            try
            {
                DataTable dtReports = new DataTable();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_DeliveryOrder", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@DeliveryOrderID", DeliveryOrderID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            DevExpress.XtraReports.UI.XtraReport report = GetSelectedReport("Delivery Order Report");
                            if (report != null)
                            {
                                report.DataSource = ds.Tables[0];
                                report.DataMember = ds.Tables[0].TableName;

                                MemoryStream ms = new MemoryStream();
                                report.ExportToPdf(ms);
                                byte[] bytes;
                                bytes = ms.ToArray();
                                string base64 = Convert.ToBase64String(bytes);

                                dtReports.Columns.AddRange(new DataColumn[1]{
                                        new DataColumn("Base64Str",typeof(string))
                                    });
                                dtReports.Rows.Add(base64);
                            }
                        }
                        connection.Close();
                    }
                }
                return Ok(dtReports);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        XtraReport GetSelectedReport(string ReportName1)
        {
            if (string.IsNullOrEmpty(ReportName1))
                return null;
            SqlConnection con1 = new SqlConnection(connectionstring);
            string com1 = "Select ReportBuffer from ReportDesigner where ReportName=" + "'" + ReportName1 + "'";
            SqlDataAdapter adpt1 = new SqlDataAdapter(com1, con1);
            DataTable dt1 = new DataTable();
            adpt1.Fill(dt1);
            byte[] buffer1 = (byte[])dt1.Rows[0][0];
            using (MemoryStream stream1 = new MemoryStream(buffer1))
            {
                return XtraReport.FromStream(stream1, true);
            }
        }



    }
}
