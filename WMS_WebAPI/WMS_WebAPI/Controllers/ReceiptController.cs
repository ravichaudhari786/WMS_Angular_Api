using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class ReceiptController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        [HttpPost]
        [Route("api/Receipt/Receipt_Insert")]
        public IHttpActionResult Receipt_Insert(Cls_Receipt obj)
        {
            DataTable dtLTD_ReceiptDetail = new DataTable();
            dtLTD_ReceiptDetail = ConvertDataTable.ConvertToDataTable(obj.LTD_ReceiptDetail);
            DataTable dtLTD_ReceiptInvoiceDetail = new DataTable();
            dtLTD_ReceiptInvoiceDetail = ConvertDataTable.ConvertToDataTable(obj.LTD_ReceiptInvoiceDetail);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("Receipt_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[9];
                        param[0] = new SqlParameter("@ReceiptID", Convert.ToInt32(obj.ReceiptID));
                        param[1] = new SqlParameter("@WarehouseID", Convert.ToInt32(obj.WarehouseID));
                        param[2] = new SqlParameter("@ReceiptDate", Convert.ToDateTime(obj.ReceiptDate));
                        param[3] = new SqlParameter("@Amount", Convert.ToDecimal(obj.Amount));
                        param[4] = new SqlParameter("@TDSAmount", Convert.ToDecimal(obj.TDSAmount));
                        param[5] = new SqlParameter("@ReceiptTypeID", Convert.ToInt32(obj.ReceiptTypeID));
                        param[6] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));

                        param[7] = new SqlParameter("@TD_ReceiptDetail", dtLTD_ReceiptDetail);
                        param[8] = new SqlParameter("@TD_ReceiptInvoiceDetail", dtLTD_ReceiptInvoiceDetail);

                        param[7].SqlDbType = SqlDbType.Structured;
                        param[8].SqlDbType = SqlDbType.Structured;

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
        [Route("api/Receipt/GetPaymentReceiptList")]
        public IHttpActionResult GetPaymentReceiptList(Cls_Receipt obj)
        {
            try
            {
                var data = _context.GetPaymentReceiptList(obj.WarehouseID).ToList();
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
        [Route("api/Receipt/Receipt_Cancelled")]
        public IHttpActionResult Receipt_Cancelled(Cls_Receipt obj)
        {
            try
            {
                var data = _context.Receipt_Cancelled(obj.ReceiptID,obj.ReceiptTypeID,obj.remarks,obj.CreatedBy).ToList();
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
        [Route("api/Receipt/Rep_PaymentReceiptReport")]
        public IHttpActionResult Rep_PaymentReceiptReport(Cls_Receipt obj)
        {
            try
            {
                var data = _context.Rep_PaymentReceiptReport(obj.ReceiptID, obj.WarehouseID).ToList();
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
        [Route("api/Receipt/Receipt_Detail_Edit")]
        public IHttpActionResult Receipt_Detail_Edit(Cls_Receipt obj)
        {
            try
            {
                var data = _context.Receipt_Detail_Edit(obj.ReceiptID,obj.WarehouseID,obj.ReceiptTypeID).ToList();
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
        [Route("api/Receipt/Receipt_SelectInvoice")]
        public IHttpActionResult Receipt_SelectInvoice(Cls_Receipt obj)
        {
            try
            {
                var data = _context.Receipt_SelectInvoice(obj.customerID, obj.WarehouseID, obj.ReceiptTypeID).ToList();
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



    }
}