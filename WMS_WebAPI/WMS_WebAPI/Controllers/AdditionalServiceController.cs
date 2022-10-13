using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;
namespace WMS_WebAPI.Controllers
{
    public class AdditionalServiceController : ApiController
    {
    
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpGet]
        [Route("api/AdditionalService/AdditionalServicesList")]
        public IHttpActionResult AdditionalServicesList()
        {
            try
            {
                var data = _context.AdditionalServicesList().ToList();
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

        /// <summary>
        /// all  parametr  are required
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/AdditionalService/AdditionalServices_Insert")]
        public IHttpActionResult AdditionalServices_Insert(Cls_AdditionalService obj)
        {

            DataTable dtAdditionalServiceCharges = new DataTable();
            dtAdditionalServiceCharges = ConvertDataTable.ConvertToDataTable(obj.LTD_AdditionalServiceCharges);
            DataTable dtAdditionalServiceDetailS = new DataTable();
            dtAdditionalServiceDetailS = ConvertDataTable.ConvertToDataTable(obj.LTD_AdditionalServiceDetailS);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("AdditionalServices_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[11];
                        param[0] = new SqlParameter("@AdditionalServiceID", Convert.ToInt32(obj.AdditionalServiceID));
                        param[1] = new SqlParameter("@WarehouseID", Convert.ToInt32(obj.WarehouseID));
                        param[2] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
                        param[3] = new SqlParameter("@BillDate", Convert.ToDateTime(obj.BillDate));
                        param[4] = new SqlParameter("@BillNumber", Convert.ToString(obj.BillNumber));
                        param[5] = new SqlParameter("@AddonMonthlyBill", Convert.ToBoolean(obj.AddonMonthlyBill));
                        param[6] = new SqlParameter("@Remarks", Convert.ToString(obj.Remarks));
                        param[7] = new SqlParameter("@CreatedBy", Convert.ToInt32(obj.CreatedBy));
                        param[8] = new SqlParameter("@Mode", Convert.ToString(obj.Mode));
                        param[9] = new SqlParameter("@TD_AdditionalServiceDetail", dtAdditionalServiceDetailS);
                        param[10] = new SqlParameter("@TD_AdditionalServiceCharges", dtAdditionalServiceCharges);
                       
                        param[9].SqlDbType = SqlDbType.Structured;
                        param[10].SqlDbType = SqlDbType.Structured;
                       
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

        #region Report Part
        [HttpPost]
        [Route("api/AdditionalService/Rep_AdditionalServiceList")]
        public IHttpActionResult Rep_AdditionalServiceList(Cls_AdditionalService obj)
        {
            try
            {
             var data=   _context.Rep_AdditionalServiceList(obj.CustomerID, obj.AdditionalServiceID).ToList();
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
        [Route("api/AdditionalService/Get_AdditionalServiceDetail")]
        public IHttpActionResult Get_AdditionalServiceDetail(Cls_AdditionalService obj)
        {
            try
            {
                var data = _context.Rep_AdditionalServiceList(obj.CustomerID, obj.AdditionalServiceID).ToList();
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

        #endregion
        [HttpPost]
        [Route("api/AdditionalService/Rep_AdditionalServiceList_Labour")]
        public IHttpActionResult Rep_AdditionalServiceList_Labour(Cls_AdditionalService obj)
        {
            try
            {
                var data = _context.Rep_AdditionalServiceList_Labour(obj.CustomerID, obj.AdditionalServiceID).ToList();
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
        [Route("api/AdditionalService/Get_AdditionalServiceCharges")]
        public IHttpActionResult Get_AdditionalServiceCharges(Cls_AdditionalService obj)
        {
           
            try
            {
                var data = _context.Get_AdditionalServiceCharges(obj.CustomerID, obj.AdditionalServiceID).ToList();
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
        [Route("api/AdditionalService/GetServiceIDfor_AddServiceCharges")]
        public IHttpActionResult GetServiceIDfor_AddServiceCharges()
        {
            try
            {
                var data = _context.GetServiceIDfor_AddServiceCharges().ToList();
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
        [Route("api/AdditionalService/GetServiceID")]
        public IHttpActionResult GetServiceID()
        {
            try
            {
                var data = _context.GetServiceID().ToList();
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
        [Route("api/AdditionalService/ServiesCharges_List")]
        public IHttpActionResult ServiesCharges_List(cls_GstStateCode obj)
        {
            try
            {
                var data = _context.ServiesCharges_List(obj.serviceID).ToList();
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
        [Route("api/AdditionalService/GetAdditionalServiceLabourCharges")]
        public IHttpActionResult GetAdditionalServiceLabourCharges(cls_GstStateCode obj)
        {
            try
            {
                var data = _context.GetAdditionalServiceLabourCharges(obj.customerID,obj.productID,obj.serviceID).ToList();
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