using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    public class InwardUpdateController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        [HttpPost]
        [Route("api/InwardUpdate/InwardUpdate_insert")]
        public IHttpActionResult InwardUpdate_insert(cls_InwardUpdate obj)
        {
            try
            {
                var data = _context.InwardUpdate_insert(obj.inwardDID,obj.brandId,obj.itemsInPacket,obj.inQuantity,obj.lotno,obj.docID,
                    obj.unLoadingBy,obj.remarks,obj.truckNo,obj.containerNo,obj.inwardID,obj.storageAreaID).ToList();
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
        [Route("api/InwardUpdate/GetInwardByLotNo")]
        public IHttpActionResult GetInwardByLotNo(cls_GetInwardByLotNo obj)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetInwardByLotNo", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@LotNo", obj.LotNo);
                        param[1] = new SqlParameter("@WarehouseID", obj.WarehouseID);

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
    }
}