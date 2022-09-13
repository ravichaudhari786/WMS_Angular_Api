using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class cls_Inward
    {
        public Nullable<int> InwardID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> serviceID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> FinantialYearId { get; set; }
        public string challan { get; set; }
        public Nullable<int> StorageAreaMasterID { get; set; }
        public string FinancialYear { get; set; }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}