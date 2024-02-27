using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPrinting;


//using DevExpress.Xpf.WindowsUI;
//using DevExpress.Xpf.Printing;




namespace WMS_WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //string connectionstring = "data source=apaar.southindia.cloudapp.azure.com,1433;initial catalog=ColdMan;user id=wmsuser;password=ColdMan@162";


        [HttpGet]
        [Route("api/Report/GetReports")]
        public IHttpActionResult GetReports()
        {
            try
            {
                var data = _context.GetReports().ToList();
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
        [Route("api/Report/GetInvoiceType")]
        public IHttpActionResult GetInvoiceType()
        {
            try
            {
                var data = _context.GetInvoiceType().ToList();
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
        [Route("api/Report/GetCustomerName")]
        public IHttpActionResult GetCustomerName(cls_CustomersStock obj)
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
        [Route("api/Report/GetAllLabourContractor")]
        public IHttpActionResult GetAllLabourContractor()
        {
            try
            {
                var data = _context.GetAllLabourContractor().ToList();
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
        [Route("api/Report/GetAllUserNames")]
        public IHttpActionResult GetAllUserNames()
        {
            try
            {                
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetAllUserName", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
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
        [Route("api/Report/AllCustomerGroup")]
        public IHttpActionResult AllCustomerGroup(cls_CustomersStock obj)
        {
            try
            {                
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("AllCustomerGroup", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@WarehousrID", obj.WarehouseID);
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
        [Route("api/Report/GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var data = _context.GetAllProducts().ToList();
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
        [Route("api/Report/GetAllBrands")]
        public IHttpActionResult GetAllBrands()
        {
            try
            {
                var data = _context.GetAllBrands().ToList();
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
        [Route("api/Report/GetAllStorageArea")]
        public IHttpActionResult GetAllStorageArea()
        {
            try
            {
                var data = _context.GetAllStorageArea().ToList();
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
        [Route("api/Report/GetReportDetails")]
        public IHttpActionResult GetReportDetails(int RID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetReport", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@ReportID", RID);
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
        [Route("api/Report/PrintReport")]
        public IHttpActionResult PrintReport(ReportPrintModel rpm)
        {
            try
            {
                DataTable dtReports = new DataTable();
                string ReportsNames = rpm.ReportName;
                DataSet ds = new DataSet();
                DataTable TD_CustomerReport = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_CustomerReport);
                DataTable TD_ProductReport = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_ProductReport);
                DataTable TD_StorageAreaReport = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_StorageAreaReport);
                DataTable TD_BrandReport = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_BrandReport);
                DataTable TD_UserName = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_UserName);
                DataTable TD_LabourContractor = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_LabourContractor);
                DataTable TD_CustomerGroup = CommanListToDataTableConverter.ConvertToDataTable(rpm.TD_CustomerGroup);
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(rpm.SPName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] par = new SqlParameter[14];
                        //param[0] = new SqlParameter("@ReportID", 0);
                        par[0] = new SqlParameter("@ReportID", Convert.ToInt32(rpm.ReportID));
                        par[1] = new SqlParameter("@WarehouseID", Convert.ToInt32(rpm.WarehouseID));
                        par[2] = new SqlParameter("@FromDate", Convert.ToDateTime(rpm.FromDate));
                        par[3] = new SqlParameter("@ToDate", Convert.ToDateTime(rpm.ToDate));
                        par[4] = new SqlParameter("@AsonDate", Convert.ToDateTime(rpm.AsonDate));
                        par[5] = new SqlParameter("@LotNo", Convert.ToString(rpm.LotNo));
                        par[6] = new SqlParameter("@TD_CustomerReport", TD_CustomerReport);
                        par[7] = new SqlParameter("@TD_ProductReport", TD_ProductReport);
                        par[8] = new SqlParameter("@TD_StorageAreaReport", TD_StorageAreaReport);
                        par[9] = new SqlParameter("@TD_BrandReport", TD_BrandReport);
                        par[10] = new SqlParameter("@TD_UserName", TD_UserName);
                        par[11] = new SqlParameter("@TD_LabourContractor", TD_LabourContractor);
                        par[12] = new SqlParameter("@TD_CustomerGroup", TD_CustomerGroup);
                        par[13] = new SqlParameter("@InvoiceTypeID", Convert.ToInt32(rpm.InvoiceTypeID));

                        command.Parameters.AddRange(par);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                if (rpm.ReportType == "Report")
                                {
                                    string path = AppDomain.CurrentDomain.BaseDirectory;
                                    string MyFolder = "MyDoc";
                                    string FinalPath = path + MyFolder;
                                    string reportName = rpm.ReportName.Replace(" ", "") + ".pdf";
                                    string reportPath = FinalPath + "\\" + reportName;
                                    if (!Directory.Exists(FinalPath))
                                    {
                                        Directory.CreateDirectory(FinalPath);
                                    }
                                    if (File.Exists(reportPath))
                                    {
                                        File.Delete(reportPath);
                                    }
                                    DevExpress.XtraReports.UI.XtraReport report = GetSelectedReport(ReportsNames);
                                    if (report != null)
                                    {
                                        report.DataSource = ds.Tables[0];
                                        report.DataMember = ds.Tables[0].TableName;

                                        //string reportPath = @"E:\\Ravi\\RND\\Test.pdf";
                                        PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
                                        pdfOptions.ConvertImagesToJpeg = false;
                                        pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;
                                        pdfOptions.PdfACompatibility = PdfACompatibility.PdfA3b;
                                        report.ExportToPdf(reportPath, pdfOptions);

                                        Byte[] fileBytes = File.ReadAllBytes(reportPath);
                                        var content = Convert.ToBase64String(fileBytes);
                                        dtReports.Columns.AddRange(new DataColumn[1]{
                                        new DataColumn("Base64Str",typeof(string))
                                    });
                                        dtReports.Rows.Add(content);

                                    }
                                }
                                else
                                {
                                    dtReports = ds.Tables[0];
                                }
                            }
                            else
                            {
                                dtReports = ds.Tables[0];
                            }
                        }
                        connection.Close();
                    }
                }
                return Ok(dtReports);
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;
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
