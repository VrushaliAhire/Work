using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.BL.Utilities
{
    public static class DataTableExtensions
    {
        /// <summary> 
        /// Creates data table from source data. 
        /// </summary> 
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            DataTable table = new DataTable();
            try
            {
                //// get properties of T 
                var binding = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
                var options = PropertyReflectionOptions.IgnoreEnumerable | PropertyReflectionOptions.IgnoreIndexer;

                var properties = ReflectionExtensions.GetProperties<T>(binding, options).ToList();

                //// create table schema based on properties 
                foreach (var property in properties)
                {
                    table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                }

                //// create table data from T instances 
                object[] values = new object[properties.Count];

                foreach (T item in source)
                {
                    for (int i = 0; i < properties.Count; i++)
                    {
                        values[i] = properties[i].GetValue(item, null);
                    }

                    table.Rows.Add(values);
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
            
            return table;
        }
    }
}
