using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace WMS_WebAPI.Models
{
    public class CommanListToDataTableConverter
    {
        public DataTable ConvertToDataTable<T>(List<T> data)
        {
            try
            {
                PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? null ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
            }
            catch (System.Exception ex)
            {
                return null;
            }          

        }
    }
}