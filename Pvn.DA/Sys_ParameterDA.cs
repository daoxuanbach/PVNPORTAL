using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class Sys_ParameterDA : Pvn.DA.DataProvider
    {
        public DataTable GetParameterByName(string name)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Sys_Parameter_GetByName", name);
                DataTable data = new DataTable();
                data.Columns.Add("Note", typeof(string));
                data.Columns.Add("Value", typeof(string));
                //var data = dt.AsEnumerable().Where(x => Convert.ToInt32(x["Value"]) > 0).ToList();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Value"]!= DBNull.Value)
                    {
                        DataRow newRow = data.NewRow();
                        newRow["Value"] = row["Value"];
                        newRow["Note"] = row["Note"];

                        data.Rows.Add(newRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "", ex.Message);

                return null;
            }
        }
        public DataTable GetParameterByNameLanguage(string name, string Language)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Sys_Parameter_GetByNameLanguage", Language, name);
                //DataTable data = new DataTable();
                //data.Columns.Add("Note", typeof(string));
                //data.Columns.Add("Value", typeof(string));
                ////var data = dt.AsEnumerable().Where(x => Convert.ToInt32(x["Value"]) > 0).ToList();
                //foreach (DataRow row in dt.Rows)
                //{
                //    if (row["Value"] != DBNull.Value)
                //    {
                //        DataRow newRow = data.NewRow();
                //        newRow["Value"] = row["Value"];
                //        newRow["Note"] = row["Note"];

                //        data.Rows.Add(newRow);
                //    }
                //}

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "", ex.Message);

                return null;
            }
        }

    }
}
