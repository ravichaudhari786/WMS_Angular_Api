using Newtonsoft.Json;
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
    //[Authorize]
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        WMS_Entities _context = new WMS_Entities();
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;


        #region write code by dharmendra bhadoria on 11-09-2022
        private bool ColumnEqual(object A, object B)
        {
            // Compares two values to see if they are equal. Also compares DBNULL.Value.             
            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value  
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value  
                return false;
            return (A.Equals(B)); // value type standard comparison  
        }
        public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            // Create a Datatable – datatype same as FieldName  
            DataTable dt = new DataTable(SourceTable.TableName);
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
            // Loop each row & compare each value with one another  
            // Add it to datatable if the values are mismatch  
            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            return dt;
        }
        #endregion

        [HttpGet]
        [Route("GetMenu")]
        public IHttpActionResult GetMenu(int userid)
        {
            Cls_menu obj = new Cls_menu();
            try
            {

                DataTable dtDistinctGroupName = new DataTable();
                DataTable dtdataBasedOnGroupName = new DataTable(); ;
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("GetUserMenus_angular", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter[] param = new SqlParameter[1];
                        param[0] = new SqlParameter("@UserID", userid);
                        command.Parameters.AddRange(param);
                        connection.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(ds);
                        }
                        connection.Close();
                    }

                    #region added this code by dharmendra bhadoria on 11-09-2022
                    //if(ds!=null && ds.Tables!=null && ds.Tables[0].Rows.Count > 0)
                    //{


                    //    dtdataBasedOnGroupName = ds.Tables[0].Clone();
                    //    dtdataBasedOnGroupName.AcceptChanges();
                    //    dtDistinctGroupName = SelectDistinct(ds.Tables[0], "GroupName");


                    //    if(dtDistinctGroupName != null && dtDistinctGroupName.Rows.Count > 0)
                    //    {


                    //            Cls_menu obj = new Cls_menu();
                    //        Menu[] MenuList = new Menu[dtDistinctGroupName.Rows.Count];
                    //        for (int i = 0; i < dtDistinctGroupName.Rows.Count; i++)
                    //        {

                    //            string Exp = "GroupName = '" + Convert.ToString(dtDistinctGroupName.Rows[i][0]) + "'";
                    //             DataRow[] dr = ds.Tables[0].Select(Exp);
                    //            Menu MenuObj = new Menu();
                    //            Child[] ChildList = new Child[dr.Length];

                    //            //DataRow[] rowsFilteredSorting = dataTable.Select("GroupName=1000", "Empid desc");
                    //            if (dr!=null && dr.Length > 0)
                    //            {

                    //                MenuObj.route = Convert.ToString(dtDistinctGroupName.Rows[i][0]);
                    //                MenuObj.name = Convert.ToString(dtDistinctGroupName.Rows[i][0]);
                    //                MenuObj.type = "link";// Convert.ToString(dtDistinctGroupName.Rows[i][0]);
                    //                MenuObj.icon = Convert.ToString(dtDistinctGroupName.Rows[i][0]);



                    //                //string avalue = dr[0]["AColumnName"].ToString();
                    //                for (int j = 0; j < dr.Length; j++)
                    //                {
                    //                    Child ChildObj = new Child();

                    //                    ChildObj.route = Convert.ToString(dr[j]["UIName"]);
                    //                    ChildObj.name = Convert.ToString(dr[j]["UIName"]);
                    //                    ChildObj.type = Convert.ToString(dr[j]["UIName"]);
                    //                    ChildList[j] = ChildObj;

                    //                    //  dtdataBasedOnGroupName.ImportRow(dr[j]);


                    //                }
                    //                MenuObj.children = ChildList;

                    //              // dtdataBasedOnGroupName.AcceptChanges();

                    //            }
                    //            MenuList[i] = MenuObj;
                    //        }
                    //        obj.menu = MenuList;
                    //      string str=  JsonConvert.SerializeObject(obj);


                    //    }
                    //}
                    #endregion

                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {


                       

                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {


                           
                            Menu[] MenuList = new Menu[ds.Tables[1].Rows.Count];
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {

                                string Exp = "MasterMenu = '" + Convert.ToString(ds.Tables[1].Rows[i]["MasterMenu"]) + "'";
                                DataRow[] dr = ds.Tables[0].Select(Exp);
                                Menu MenuObj = new Menu();
                                Child[] ChildList = new Child[dr.Length];

                                //DataRow[] rowsFilteredSorting = dataTable.Select("GroupName=1000", "Empid desc");
                                if (dr != null && dr.Length > 0)
                                {

                                    MenuObj.route = Convert.ToString(ds.Tables[1].Rows[i]["AngularParentRoute"]);
                                    MenuObj.name = Convert.ToString(ds.Tables[1].Rows[i]["AngularParentName"]);
                                    MenuObj.type = Convert.ToString(ds.Tables[1].Rows[i]["type"]);
                                    MenuObj.icon = Convert.ToString(ds.Tables[1].Rows[i]["AngularIcon"]);



                                    //string avalue = dr[0]["AColumnName"].ToString();
                                    for (int j = 0; j < dr.Length; j++)
                                    {
                                        Child ChildObj = new Child();

                                        ChildObj.route = Convert.ToString(dr[j]["AngularChildRoute"]);
                                        ChildObj.name = Convert.ToString(dr[j]["AngularChildName"]);
                                        ChildObj.type = Convert.ToString(dr[j]["type"]);
                                        ChildList[j] = ChildObj;

                                        //  dtdataBasedOnGroupName.ImportRow(dr[j]);


                                    }
                                    MenuObj.children = ChildList;

                                    // dtdataBasedOnGroupName.AcceptChanges();

                                }
                                MenuList[i] = MenuObj;
                            }
                            obj.menu = MenuList;
                            string str = JsonConvert.SerializeObject(obj);


                        }
                    }


                }
                //return Ok(ds);
                return Ok(obj);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
