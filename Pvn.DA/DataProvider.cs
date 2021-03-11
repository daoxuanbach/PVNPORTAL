using System;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
namespace Pvn.DA
{
    public class DataProvider
    {
        public static string UrlSiteSharepoint
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Site.Sharepint"].ConnectionString;
            }
        }

        /// <summary> 
        ///Lấy thông tin chuỗi kết nối database
        /// </summary>         
        /// <returns>Trả về kiểu string </returns> 
        public static string SQLConnectionString
        {
            get
            {
               // return ConfigurationManager.ConnectionStrings["Pvn.CMS"].ConnectionString;

                string connection = System.Configuration.ConfigurationManager.
                ConnectionStrings["Pvn.CMS"].ConnectionString;
                return connection;
            }
        }
        public static string SQLAppString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["sqlConnectionString"];
            }
        }
        public static SqlConnection getConnection()
        {
            string sConn = SQLConnectionString.ToString();
            SqlConnection conn = new SqlConnection(sConn);

            return conn;
        }
        public int ExecuteScalar(string spName, params object[] parameters)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SQLConnectionString, spName, parameters));
        }
        #region Thuc Hien Thu Tuc
        /// <summary> 
        ///Thực thi một chuỗi sql truyền vào
        /// </summary> 
        /// <param name="sql">Chuỗi sql</param> 
        /// <returns>Trả về kiểu dataset </returns> 
        public DataSet GetData(string sql)
        {
            return SqlHelper.ExecuteDataset(SQLConnectionString, CommandType.Text, sql);

        }




        /// <summary> 
        ///Thực thi thủ tục theo tên và tham số truyền vào
        /// </summary> 
        /// <param name="sql">Chuỗi sql</param>         
        /// <returns>Trả về kiểu số bản ghi thực thi </returns> 
        public int ExecuteNonQuery(string sql)
        {
            return SqlHelper.ExecuteNonQuery(SQLConnectionString, CommandType.Text, sql);
        }

        /// <summary> 
        ///Thực thi thủ tục theo tên và tham số truyền vào
        /// </summary> 
        /// <param name="spName">Tên thủ tục</param> 
        /// <param name="parameters">Các tham số truyền vào</param> 
        /// <returns>Trả về kiểu số bản ghi thực thi </returns> 

        public int ExecuteNonQuery(string spName, params object[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(SQLConnectionString, spName, parameters);
        }
        public int ExecuteNonQueryOut(string spName, string OutValue, params object[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(SQLConnectionString, spName, OutValue, parameters);

        }

        public string ExecuteNonQueryOutToGuid(string spName, string OutValue, params object[] parameters)
        {
            return SqlHelper.ExecuteNonQueryOutString(SQLConnectionString, spName, OutValue, parameters);

        }

        /// <summary> 
        ///Thực thi thủ tục theo tên và tham số truyền vào 
        /// </summary> 
        /// <param name="spName">Tên thủ tục</param> 
        /// /// <param name="parameters">Các tham số truyền vào</param> 
        /// <returns>Trả về kiểu datatable </returns> 
        public DataTable GetTableByProcedure(string spName, params object[] parameters)
        {
            return SqlHelper.ExecuteDataset(SQLConnectionString, spName, parameters).Tables[0];
        }
        /// <summary> 
        ///Thực thi thủ tục theo tên và tham số truyền vào 
        /// </summary> 
        /// <param name="spName">Tên thủ tục</param> 
        /// /// <param name="parameters">Các tham số truyền vào</param> 
        /// <returns>Trả về kiểu dataset </returns> 
        public DataSet GetDatasetByProcedure(string spName, params object[] parameters)
        {
            return SqlHelper.ExecuteDataset(SQLConnectionString, spName, parameters);
        }

        public string ExecuteNonQueryOutMessage(string spName, params object[] parameters)
        {
            SqlHelper.ExecuteDataset(SQLConnectionString, spName, parameters);
            return "";
        }
        /// <summary>
        /// Get dữ liệu với phân trang
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="strNameOfParamTotal"></param>
        /// <param name="strNameOfParamCursor"></param>
        /// <param name="oParamOrderName"></param>
        /// <param name="oParamOrderValue"></param>
        /// <param name="oParamSortFieldName"></param>
        /// <param name="oParamSortFieldValue"></param>
        /// <param name="oParamNumPerPageName"></param>
        /// <param name="rowsNum"></param>
        /// <param name="oParamPageName"></param>
        /// <param name="page"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        /// <Modified>
        /// Author      Date        Comment
        /// bachdx     26/11/2015  Tạo mới
        /// </Modified>
        public DataTable GetTableByProcedurePaging(string spName, string strNameOfParamTotal, string strNameOfParamCursor, string oParamOrderName, string oParamOrderValue, string oParamSortFieldName,
         string oParamSortFieldValue, string oParamNumPerPageName, int rowsNum,
         string oParamPageName, int page, out long totalRecords)
        {
            return SqlHelper.ExecuteNonQuery(SQLConnectionString, CommandType.StoredProcedure, spName, strNameOfParamTotal,
                strNameOfParamCursor, oParamOrderName, oParamOrderValue, oParamSortFieldName, oParamSortFieldValue, oParamNumPerPageName, rowsNum, oParamPageName, page, out totalRecords);
        }

        /// <summary>
        /// Get dữ liệu với phân trang
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="paramArray"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        /// <Modified>
        /// Author      Date        Comment
        /// bachdx     26/11/2015  Tạo mới
        /// </Modified>
        public DataTable GetTableByProcedurePaging(string spName, object[] paramArray, out long totalRecords)
        {
            return SqlHelper.ExecuteNonQuery(SQLConnectionString, CommandType.StoredProcedure, spName, paramArray, out totalRecords);
        }


        /// <summary> 
        ///Thực thi một chuỗi sql truyền vào
        /// </summary> 
        /// <param name="commandtext">Chuỗi sql</param> 
        /// <returns>Trả về kiểu dataset </returns> 
        public DataSet GetDatasetByCommand(string commandtext)
        {

            return SqlHelper.ExecuteDataset(SQLConnectionString, CommandType.Text, commandtext);
        }
        /// <summary> 
        ///Thực thi thủ tục theo tên và tham số truyền vào 
        /// </summary> 
        /// <param name="spName">Tên thủ tục</param> 
        /// <param name="parameters">Các tham số truyền vào</param> 
        /// <returns>Trả về kiểu SqlDataReader </returns> 
        public SqlDataReader GetIDataReader(string spName, params object[] parameters)
        {
            return SqlHelper.ExecuteReader(SQLConnectionString, spName, parameters);
        }

        /// <summary>
        /// Thực thi thủ tục theo tên và tham số tên bảng danh mục, id dữ liệu truyền vào
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <returns>Trả về kiểu SqlDataReader </returns>
        public SqlDataReader GetDanhMucBySqlDataReader(string spName, string tableName, int ID)
        {
            SqlParameter pramOut = new SqlParameter();
            //pramOut.OracleType = OracleType.Cursor;
            pramOut.ParameterName = "out_DATA1";
            pramOut.Direction = ParameterDirection.Output;

            return SqlHelper.ExecuteReader(SQLConnectionString, spName, tableName, ID, pramOut);
        }

        /// <summary>
        /// Thực thi thủ tục
        /// </summary>
        /// <param name="spName"></param>
        /// <returns>Trả về kiểu SqlDataReader </returns>
        public SqlDataReader GetIDataReader(string spName)
        {

            return SqlHelper.ExecuteReader(SQLConnectionString, spName, null);
        }

        ///  <summary>  
        ///Thực thi thủ tục theo tên và tham số truyền vào 
        ///  </summary>  
        ///  <param name="spName">Tên thủ tục</param>  
        ///  <returns>Trả về kiểu dataset </returns>  
        public DataSet GetSelectAllData(string spName)
        {

            SqlParameter pramOut = new SqlParameter();
            return SqlHelper.ExecuteDataset(SQLConnectionString, CommandType.StoredProcedure, spName);
        }

        #endregion

    }
}
