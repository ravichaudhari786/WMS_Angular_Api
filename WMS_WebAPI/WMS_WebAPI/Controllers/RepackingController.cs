//using DevExpress.XtraReports.UI;
//using DevExpress.XtraPrinting;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
//using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class RepackingController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //ravi
        [HttpGet]
        [Route("api/Repacking/GetRepackingProductList")]
        public IHttpActionResult GetRepackingProductList(int CustomerID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetRepackingProductList", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@CustomerID", CustomerID);
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

        [HttpGet]
        [Route("api/Repacking/ClassMaster_Select")]
        public IHttpActionResult ClassMaster_Select()
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("ClassMaster_Select", connection))
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

        [HttpPost]
        [Route("api/Repacking/GetRepackingServices")]
        public IHttpActionResult GetRepackingServices(cls_service obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetRepackingServices", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@CustomerID", obj.customerID);
                        param[1] = new SqlParameter("@ProductID", obj.productID);

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

        [HttpGet]
        [Route("api/Repacking/GeProductWeight")]
        public IHttpActionResult GeProductWeight(int ProductID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GeProductWeight", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@ProductID", ProductID);
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

        [Route("api/Repacking/SaveRepacking")]
        [HttpPost]
        public IHttpActionResult SaveRepacking([FromBody]RepackingSaveModel ism)
        {
            try
            {
                DataTable dtRepackingDetails = CommanListToDataTableConverter.ConvertToDataTable(ism.RepackingDetailsModel);
                DataTable dtRepackingCharges = CommanListToDataTableConverter.ConvertToDataTable(ism.RepackingChargesModel);
                DataTable dtRepackingInwardDetails = CommanListToDataTableConverter.ConvertToDataTable(ism.RepackingInwardDetailsModel);
                                
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Repacking_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[13];
                        param[0] = new SqlParameter("@RepackingID", Convert.ToInt32(ism.RepackingID));
                        param[1] = new SqlParameter("@WareHouseID", ism.WarehouseID);
                        param[2] = new SqlParameter("@CustomerID", Convert.ToInt32(ism.CustomerID));
                        param[3] = new SqlParameter("@RepackingDate", Convert.ToDateTime(ism.RepackingDate));
                        param[4] = new SqlParameter("@OrderGivenBy", ism.OrderGivenBy);
                        param[5] = new SqlParameter("@Remarks", ism.Remarks);
                        param[6] = new SqlParameter("@CreatedBy", ism.CreatedBy);
                        param[7] = new SqlParameter("@TD_RepackingDetail", dtRepackingDetails);
                        param[8] = new SqlParameter("@TD_RepackingCharges", dtRepackingCharges);
                        param[9] = new SqlParameter("@TD_RepackingInwardDetail", dtRepackingInwardDetails);
                        param[10] = new SqlParameter("@FinancialYearID", ism.FinancialYearID);
                        param[11] = new SqlParameter("@StorageAreaMasterID", ism.StorageAreaMasterID);
                        param[12] = new SqlParameter("@CompanyID", ism.CompanyID);
                        
                        param[7].SqlDbType = SqlDbType.Structured;
                        param[8].SqlDbType = SqlDbType.Structured;
                        param[9].SqlDbType = SqlDbType.Structured;
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
        [Route("api/Repacking/Repacking_List")]
        public IHttpActionResult Repacking_List(int WarehouseID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Repacking_List", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@WarehouseID", WarehouseID);
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

        [HttpGet]
        [Route("api/Repacking/RepackingReport")]
        public IHttpActionResult RepackingReport(int RepackingID)
        {
            try
            {
                DataTable dtReports = new DataTable();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_RepackingReport_Angular", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@RepackingID", RepackingID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            DevExpress.XtraReports.UI.XtraReport report12 = GetSelectedReport("RepackingReport_Angular");
                            //DevExpress.XtraReports.UI.XtraReport report13 = GetSelectedReport("Subreport");
                            
                            if (report12 != null)
                            {
                                //report13.DataSource = ds.Tables[0];
                                //report13.DataMember = ds.Tables[0].TableName;
                                //report13.Parameters["RepcID"].Value = ds.Tables[0].Rows[0][0];
                                report12.DataSource = ds.Tables[0];
                                report12.DataMember = ds.Tables[0].TableName;


                                System.IO.MemoryStream ms12 = new System.IO.MemoryStream();
                                report12.ExportToPdf(ms12);
                                //report12.ExportToPdf(ms12, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                                //DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report12);
                                //printTool.ShowRibbonPreview();
                                byte[] bytes;
                                bytes = ms12.ToArray();
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

        //DevExpress.XtraReports.UI.XtraReport GetSelectedReport(string ReportName1)
        //{
        //    if (string.IsNullOrEmpty(ReportName1))
        //        return null;
        //    SqlConnection con1 = new SqlConnection(connectionstring);
        //    string com1 = "Select ReportBuffer from ReportDesigner where ReportName=" + "'" + ReportName1 + "'";
        //    SqlDataAdapter adpt1 = new SqlDataAdapter(com1, con1);
        //    DataTable dt1 = new DataTable();
        //    adpt1.Fill(dt1);
        //    byte[] buffer12 = (byte[])dt1.Rows[0][0];
        //    using (MemoryStream stream12 = new MemoryStream(buffer12))
        //    {
        //        return DevExpress.XtraReports.UI.XtraReport.FromStream(stream12, true);
        //    }
        //}
        DevExpress.XtraReports.UI.XtraReport GetSelectedReport(string ReportName)
        {
            if (string.IsNullOrEmpty(ReportName))
                return null;

            SqlConnection con = new SqlConnection(connectionstring);
            string com = "Select ReportBuffer from ReportDesigner where ReportName=" + "'" + ReportName + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt1 = new DataTable();
            adpt.Fill(dt1);
            byte[] buffer = (byte[])dt1.Rows[0][0];
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                return DevExpress.XtraReports.UI.XtraReport.FromStream(stream, true);
            }
        }
        
    }
}
