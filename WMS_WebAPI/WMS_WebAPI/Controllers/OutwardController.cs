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
    public class OutwardController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();        
        CommanListToDataTableConverter CommanListToDataTableConverter = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/Outward/GetOutwardList")]
        public IHttpActionResult GetOutwardList(cls_Outward obj)
        {
            try
            {
                var data = _context.GetOutwardList(obj.warehouseID).ToList();
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
        [Route("api/Outward/OutWard_Cancelled")]
        public IHttpActionResult OutWard_Cancelled(cls_Outward obj )
        {
            try
            {
                var data = _context.OutWard_Cancelled(obj.outwardID,obj.warehouseID,obj.remarks,obj.createdBy).ToList();
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
        [Route("api/Outward/Rep_GatePass")]
        public IHttpActionResult Rep_GatePass(cls_Outward obj)
        {
            try
            {
                var data = _context.Rep_GatePass(obj.outwardID,obj.warehouseID).ToList();
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
        [Route("api/Outward/Outward_Insert")]
        public IHttpActionResult Outward_Insert([FromBody]OutwardSaveModel osm)
        {
            DataTable dtOutDetail = CommanListToDataTableConverter.ConvertToDataTable(osm.OutwardDetailModel);
            DataView dv = new DataView(dtOutDetail);
            DataTable dtDetail = dv.ToTable(false, "OutwardDID", "DeliveryOrderDID", "DispatchDID", "OutQuantity", "LabourContractorID");
            
            DataTable dtOutCharges = CommanListToDataTableConverter.ConvertToDataTable(osm.OutwardDetailModel);
            DataView dvcharges = new DataView(dtOutCharges);
            DataTable dtCharge = dv.ToTable(false, "OutwardDID", "ServiceID", "ServiceName", "Rate", "L_Rate");
            DataSet ds = new DataSet();
    
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand("DeliveryOrder_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[16];
                    param[0] = new SqlParameter("@OutwardID", osm.OutwardID);
                    param[1] = new SqlParameter("@WarehouseID", Convert.ToInt32(osm.WarehouseID));
                    param[2] = new SqlParameter("@OutWardDate", Convert.ToDateTime(osm.OutWardDate));
                    param[3] = new SqlParameter("@BillStartDate", Convert.ToDateTime(osm.OutWardDate));
                    param[4] = new SqlParameter("@DeliveryOrderID", osm.DeliveryOrderID);
                    param[5] = new SqlParameter("@CustomerPartyID", osm.CustomerPartyID);
                    param[6] = new SqlParameter("@TruckNo", Convert.ToString(osm.TruckNo));
                    param[7] = new SqlParameter("@ContainerNo", osm.ContainerNo);
                    param[8] = new SqlParameter("@TransporterName", osm.TransporterName);
                    param[9] = new SqlParameter("@Remarks", osm.Remarks);
                    param[10] = new SqlParameter("@CreatedBy", osm.CreatedBy);
                    param[11] = new SqlParameter("@CustomerID", Convert.ToInt32(osm.CustomerID));
                    param[12] = new SqlParameter("@TD_OutwardDetail", dtDetail);
                    param[13] = new SqlParameter("@TD_OutwardCharges", dtCharge);
                    param[14] = new SqlParameter("@DriverName", osm.DriverName);
                    param[15] = new SqlParameter("@DriverNo", osm.DriverNo);
                    param[16] = new SqlParameter("@DocID", osm.DocID);
                    param[17] = new SqlParameter("@LoadingBy", osm.LoadingBy);
                    param[18] = new SqlParameter("@TransferID", osm.TransferID);
                    param[19] = new SqlParameter("@DispatchID", osm.DispatchID);
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
        //public IHttpActionResult Outward_Insert(cls_Outward obj)
        //{
        //    try
        //    {
        //        var data = _context.Outward_Insert(obj.outwardID,obj.warehouseID,obj.outWardDate,obj.billStartDate,obj.deliveryOrderID,
        //            obj.customerPartyID,obj.truckNo,obj.containerNo,obj.transporterName,obj.remarks,
        //            obj.createdBy,obj.customerID,obj.driverName,obj.driverNo,obj.docID,obj.loadingBy,obj.transferID,obj.dispatchID);                
        //        return Ok(data);
        //    }
        //    catch (System.Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        [Route("api/Outward/GetDeliveryOrderByID")]
        public IHttpActionResult GetDeliveryOrderByID(Cls_GetDeliveryOrderByID obj)
        {
            try
            {
                var data = _context.GetDeliveryOrderByID(obj.CustomerID, obj.WarehouseId,obj.CompanyID);
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("api/Outward/GetDeliveryOrderDetail")]
        public IHttpActionResult GetDeliveryOrderDetail(cls_Outward obj)
        {
            try
            {
                var data = _context.GetDeliveryOrderDetail(obj.dispatchID);
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("api/Outward/GetOutwardServices")]
        public IHttpActionResult GetOutwardServices(Cls_GetDeliveryOrderByID obj)
        {
            try
            {
                var data = _context.GetOutwardServices(obj.CustomerID,obj.ProductID,obj.WarehouseId);
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        
        
    }
}
