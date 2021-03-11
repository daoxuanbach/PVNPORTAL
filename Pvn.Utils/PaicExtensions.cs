using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
    public static class PaicExtensions
    {
        /// <summary>
        /// Converts datatable to list<T> dynamically
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="dataTable">data table to convert</param>
        /// <returns>List<T></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("PaicExtensions", "ConvertDataTable", ex.Message);
                return null;
            }

        }
        private static T GetItem<T>(DataRow dr)
        {
            
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                        {
                            if (dr[column.ColumnName] != DBNull.Value)
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }

                        }
                        else
                            continue;
                    }
                }
                return obj;
            
        } 
    }
}
