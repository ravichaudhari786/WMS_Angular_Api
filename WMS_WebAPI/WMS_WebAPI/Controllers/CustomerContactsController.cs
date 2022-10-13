using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WMS_WebAPI.Models;
using WMS_WebAPI.Models.Context;

namespace WMS_WebAPI.Controllers
{
    [Authorize]
    public class CustomerContactsController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        CommanListToDataTableConverter ConvertDataTable = new CommanListToDataTableConverter();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        [HttpGet]
        [Route("api/CustomerContacts")]
        public IHttpActionResult GetCustomerContacts()
        {
            var data = _context.CustomerContacts.ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("api/CustomerContacts/GetCustomerContactsList")]
        public IHttpActionResult GetCustomerContactsList(int CustomerID)
        {
          
            var data = _context.GetCustomerContacts(CustomerID).ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        #region created  by dharmendra  bhadoria
        [HttpPost]
        [Route("api/CustomerContacts/CustomerContractWarehouse_List")]
        public IHttpActionResult CustomerContractWarehouse_List(cls_CustomerContractWarehouse obj)
        {
            try
            {

                var data = _context.CustomerContractWarehouse_List(obj.CustomerRateID,obj.Mode,obj.WareHouseID).ToList();
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
        [Route("api/CustomerContacts/CustomerRateList_Insert")]
        public IHttpActionResult CustomerRateList_Insert(cls_customerRateList obj)
        {

            DataTable dtLTD_CustomerRateList = new DataTable();
            dtLTD_CustomerRateList = ConvertDataTable.ConvertToDataTable(obj.LTD_CustomerRateList);

            DataTable dtLTD_CustomerStorageArea1 = new DataTable();
            dtLTD_CustomerStorageArea1 = ConvertDataTable.ConvertToDataTable(obj.LTD_CustomerStorageArea1);

            DataTable dtLTD_CustomerAddOnServices1 = new DataTable();
            dtLTD_CustomerAddOnServices1 = ConvertDataTable.ConvertToDataTable(obj.LTD_CustomerAddOnServices1);

            DataTable dtLTD_WareHouses = new DataTable();
            dtLTD_WareHouses = ConvertDataTable.ConvertToDataTable(obj.LTD_WareHouses);
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("CustomerRateList_Insert", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[13];
                        param[0] = new SqlParameter("@CustomerRateListID", Convert.ToInt32(obj.CustomerRateListID));
                        param[1] = new SqlParameter("@CustomerID", Convert.ToInt32(obj.CustomerID));
                        param[2] = new SqlParameter("@wefDate", Convert.ToDateTime(obj.wefDate));
                        param[3] = new SqlParameter("@FromDate", Convert.ToDateTime(obj.FromDate));
                        param[4] = new SqlParameter("@EndDate", Convert.ToDateTime(obj.EndDate));
                        param[5] = new SqlParameter("@RateID", Convert.ToInt32(obj.RateID));
                        param[6] = new SqlParameter("@BillingCycleID", Convert.ToInt32(obj.BillingCycleID));

                        param[7] = new SqlParameter("@table", dtLTD_CustomerRateList);
                        param[8] = new SqlParameter("@CustomerStorageArea", dtLTD_CustomerStorageArea1);

                        param[9] = new SqlParameter("@TD_CustomerAddOnServices", dtLTD_CustomerAddOnServices1);
                        param[10] = new SqlParameter("@TD_WareHouses", dtLTD_WareHouses);

                        param[11] = new SqlParameter("@createdBy", Convert.ToInt32(obj.createdBy));
                        param[12] = new SqlParameter("@CompanyID", Convert.ToString(obj.CompanyID));



                        param[7].SqlDbType = SqlDbType.Structured;
                        param[8].SqlDbType = SqlDbType.Structured;
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

        [HttpPost]
        [Route("api/CustomerContacts/CustomerStorageArea_Select")]
        public IHttpActionResult CustomerStorageArea_Select(cls_customerRateList obj)
        {
            try
            {
                var data = _context.CustomerStorageArea_Select(obj.CustomerID).ToList();
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
        [Route("api/CustomerContacts/CustomerRateList_Service")]
        public IHttpActionResult CustomerRateList_Service(cls_customerRateList obj)
        {
            try
            {
                var data = _context.CustomerRateList_Service(obj.CustomerID).ToList();
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
        [Route("api/CustomerContacts/CustomerContact_Select")]
        public IHttpActionResult CustomerContact_Select(cls_CustomerUsers obj)
        {
            try
            {
                var data = _context.CustomerContact_Select(obj.CustomerID).ToList();
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

    }
}
