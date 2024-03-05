﻿using DevExpress.XtraReports.UI;
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
    public class DispatchController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpGet]
        [Route("api/Dispatch/DispatchSearch")]
        public IHttpActionResult DispatchSearch(int CustomerID, int WarehouseId,int CompanyID)
        {
            try
            {
                var data = _context.GetDispatchByID(CustomerID, WarehouseId, CompanyID).ToList();
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
        [Route("api/Dispatch/GetDispatchDetails")]
        public IHttpActionResult GetDispatchDetail(int DeliveryOrderID, int DeliveryOrderNo)
        {
            try
            {
                var data = _context.GetDispatchDetails(DeliveryOrderID, DeliveryOrderNo).ToList();
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
        [Route("api/Dispatch/Dispatch_Select")]
        public IHttpActionResult Dispatch_Select()
        {
            try
            {
                var data = _context.Dispatch_Select().ToList();
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
        [Route("api/Dispatch/Dispatch_Cancelled")]
        public IHttpActionResult Dispatch_Cancelled(int DispatchID, string Remark, int CreatedBy)
        {
            try
              {
                var data = _context.Dispatch_Cancelled(DispatchID,Remark,CreatedBy).ToList();
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
        [Route("api/Dispatch/SaveDispatch")]
        public IHttpActionResult SaveDispatch([FromBody]DispatchSaveModel dsm)
        {
            DataTable dtDispatchDetail = CommanListToDataTableConverter.ConvertToDataTable(dsm.DispatchDetailModel);
            DataView dv = new DataView(dtDispatchDetail);
            DataTable dtn = dv.ToTable(false,"DeliveryOrderDID", "ProductID", "InwardDID", "LotNO", "DispatchQuantity", "InwardLocationID", "StorageAreaID");
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("Dispatch_insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[12];
                    param[0] = new SqlParameter("@DispatchID", dsm.DispatchID);
                    param[1] = new SqlParameter("@CustomerID", Convert.ToInt32(dsm.CustomerID));
                    param[2] = new SqlParameter("@CustomerPartyID", Convert.ToInt32(dsm.CustomerPartyID));
                    param[3] = new SqlParameter("@WareHouseID", dsm.WareHouseID);
                    param[4] = new SqlParameter("@ShippingAddress", Convert.ToString(dsm.ShippingAddress));
                    param[5] = new SqlParameter("@OrderGivenBy", dsm.OrderGivenBy);
                    param[6] = new SqlParameter("@Remarks", dsm.Remarks);
                    param[7] = new SqlParameter("@CreatedBy", dsm.CreatedBy);
                    param[8] = new SqlParameter("@TD_DispatchDetail", dtn);
                    param[9] = new SqlParameter("@DeliveryOrderID", dsm.DeliveryOrderID);
                    param[10] = new SqlParameter("@TruckNo", dsm.TruckNo);
                    param[11] = new SqlParameter("@ContainerNo", dsm.ContainerNo);
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
        [Route("api/Dispatch/DispatchReceipt")]
        public IHttpActionResult DispatchReceipt(int DispatchID)
        {
            try
            {
                DataTable dtReports = new DataTable();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_Dispatch", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@DispatchID", DispatchID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            DevExpress.XtraReports.UI.XtraReport report = GetSelectedReport("DispatchReport");
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
