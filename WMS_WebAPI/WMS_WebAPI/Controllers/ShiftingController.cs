//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web.Http;
//using WMS_WebAPI.Models;
//using WMS_WebAPI.Models.Context;
//using System.Collections.Generic;

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
    public class ShiftingController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/Shifting/Shifting_insert")]
        public IHttpActionResult Shifting_insert([FromBody]ShiftingSaveModel ssm)
        {
            try
            {
                DataTable dtShiftDetail = CommanListToDataTableConverter.ConvertToDataTable(ssm.TD_ShiftingDetails);
                DataView dv = new DataView(dtShiftDetail);
                DataTable dtDetail = dv.ToTable(false, "ShiftingDID","InwardLocationID","LotNo","InwardDID","FromLocationID","ToLocationID","Quantity","LabourContractorID");

                DataTable dtOutCharges = CommanListToDataTableConverter.ConvertToDataTable(ssm.TD_ShiftingCharges);
                DataView dvcharges = new DataView(dtOutCharges);
                DataTable dtCharge = dvcharges.ToTable(false, "ShiftingDID","ServiceID","Rate","Rate_L");
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Shifting_insert", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[8];
                        param[0] = new SqlParameter("@ShiftingID", ssm.ShiftingID);
                        param[1] = new SqlParameter("@WarehouseID", ssm.WarehouseID);
                        param[2] = new SqlParameter("@CustomerID", ssm.CustomerID);
                        param[3] = new SqlParameter("@CreatedBy", ssm.CreatedBy);
                        param[4] = new SqlParameter("@TD_ShiftingDetails", dtDetail);
                        param[5] = new SqlParameter("@TD_ShiftingCharges", dtCharge);
                        param[6] = new SqlParameter("@ShiftingDate", Convert.ToDateTime(ssm.ShiftingDate));
                        param[7] = new SqlParameter("@LoadingBy", Convert.ToInt32(ssm.LoadingBy));
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
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("api/Shifting/Shifting_List")]
        public IHttpActionResult Shifting_List(cls_Shifting obj)
        {
            try
            {
                var data = _context.Shifting_List(obj.warehouseID).ToList();
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
        [Route("api/Shifting/Shifting_Cancelled")]
        public IHttpActionResult Shifting_Cancelled(cls_Shifting obj)
        {
            try
            {
                var data = _context.Shifting_Cancelled(obj.shiftingID,obj.shiftingDID,obj.remarks,obj.createdBy,obj.warehouseID).ToList();
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
        [Route("api/Shifting/Rep_Shifting")]
        public IHttpActionResult Rep_Shifting(cls_Shifting obj)
        {
            try
            {
                var data = _context.Rep_Shifting(obj.shiftingID).ToList();
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
        [Route("api/Shifting/ShiftingEdit_List")]
        public IHttpActionResult ShiftingEdit_List(cls_Shifting obj)
        {
            try
            {
                var data = _context.ShiftingEdit_List(obj.shiftingID,obj.shiftingDID,obj.warehouseID).ToList();
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
        [Route("api/Shifting/GetInwardDetails")]
        public IHttpActionResult GetInwardDetails(cls_Shifting obj)
        {
            try
            {
                var data = _context.GetInwardDetails(obj.customerID,obj.LotNo).ToList();
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
        [Route("api/Shifting/Shifting_services")]
        public IHttpActionResult Shifting_services()
        {
            try
            {
                var data = _context.Shifting_services().ToList();
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
        [Route("api/Shifting/ShiftingStatus_validation")]
        public IHttpActionResult ShiftingStatus_validation(cls_Shifting obj)
        {
            try
            {
                var data = _context.ShiftingStatus_validation(obj.shiftingID,obj.warehouseID,obj.StatusID).ToList();
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
        [Route("api/Shifting/ShiftingReceipt")]
        public IHttpActionResult ShiftingReceipt(int ShiftingID)
        {
            try
            {
                DataTable dtReports = new DataTable();
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Rep_Shifting", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@ShiftingID", ShiftingID);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                            DevExpress.XtraReports.UI.XtraReport report = GetSelectedReport("ShiftingReport");
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