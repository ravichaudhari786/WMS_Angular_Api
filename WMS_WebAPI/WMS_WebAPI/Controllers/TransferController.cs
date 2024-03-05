using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class TransferController : ApiController
    {

        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Transfer/Transfer_Insert")]
        public IHttpActionResult Transfer_Insert(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_Insert(obj.transferID,obj.wareHouseID,obj.companyID,obj.fromCustomerID,obj.toCustomerID,
                    obj.transferDate,obj.orderGivenBy,obj.remarks,obj.createdBy,obj.financialYearID,obj.storageAreaMasterID);
               
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        [Route("api/Transfer/Transfer_List")]
        public IHttpActionResult Transfer_List(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_List( obj.wareHouseID).ToList();
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
        [Route("api/Transfer/Transfer_Cancelled")]
        public IHttpActionResult Transfer_Cancelled(cls_Transfer obj)
        {
            try
            {
                var data = _context.Transfer_Cancelled(obj.transferID,obj.toCustomerID,obj.remarks,obj.createdBy,obj.wareHouseID).ToList();
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
        [Route("api/Transfer/Rep_TransferReport")]
        public IHttpActionResult Rep_TransferReport(cls_Transfer obj)
        {
            try
            {
                var data = _context.Rep_TransferReport(obj.transferID).ToList();
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
        [Route("api/Transfer/GetTransferProductList")]
        public IHttpActionResult GetTransferProductList(cls_Transfer obj)
        {
            try
            {
                var data = _context.GetTransferProductList(obj.fromCustomerID,obj.wareHouseID,obj.financialYearID).ToList();
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
        [Route("api/Transfer/GetTransferServices")]
        public IHttpActionResult GetTransferServices(cls_Inward obj)
        {
            try
            {
                var data = _context.GetTransferServices(obj.CustomerID,obj.ProductID,obj.WarehouseId).ToList();
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
        [Route("api/Transfer/GetStorageArea")]
        public IHttpActionResult GetStorageArea(cls_Transfer obj)
        {
            try
            {
                var data = _context.GetStorageArea(obj.wareHouseID,obj.toCustomerID).ToList();
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
        [Route("api/Transfer/TransferReceipt")]
        public IHttpActionResult TransferReceipt(int TransferID)
        {
            try
            {
                DataTable dtReports = new DataTable();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_TransferReport", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@TransferID", TransferID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            DevExpress.XtraReports.UI.XtraReport report = GetSelectedReport("TransferReport");
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