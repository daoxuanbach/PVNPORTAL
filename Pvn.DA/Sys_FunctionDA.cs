using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_FunctionDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        private Sys_FunctionET setProperties(DataRow oReader)
        {
            try
            {
                Sys_FunctionET objSys_FunctionET = new Sys_FunctionET();
                if (oReader["FunctionID"] != DBNull.Value)
                    objSys_FunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader["Language"] != null)
                    objSys_FunctionET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["PageID"] != DBNull.Value)
                    objSys_FunctionET.PageID = new Guid(Convert.ToString(oReader["PageID"]));
                if (oReader["Name"] != null)
                    objSys_FunctionET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objSys_FunctionET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ParentFunctionID"] != DBNull.Value)
                    objSys_FunctionET.ParentFunctionID = new Guid(Convert.ToString(oReader["ParentFunctionID"]));
                if (oReader["UsedState"] != DBNull.Value)
                    objSys_FunctionET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Checksum"] != null)
                    objSys_FunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["Infor"] != null)
                    objSys_FunctionET.Infor = Convert.ToString(oReader["Infor"]);
                if (oReader["ImagePath"] != null)
                    objSys_FunctionET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                if (oReader["ImageFileName"] != null)
                    objSys_FunctionET.ImageFileName = Convert.ToString(oReader["ImageFileName"]);
                if (oReader["CreatedBy"] != null)
                    objSys_FunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_FunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != null)
                    objSys_FunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSys_FunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_FunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " setProperties", ex.Message);
                throw;
            }
            
        }
        private Sys_FunctionET setPropertiesET(DataRow oReader)
        {
            try
            {
                Sys_FunctionET objSys_FunctionET = new Sys_FunctionET();
                if (oReader["FunctionID"] != DBNull.Value)
                    objSys_FunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader["Language"] != null)
                    objSys_FunctionET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["PageID"] != DBNull.Value)
                    objSys_FunctionET.PageID = new Guid(Convert.ToString(oReader["PageID"]));
                if (oReader["Name"] != null)
                    objSys_FunctionET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objSys_FunctionET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ParentFunctionID"] != DBNull.Value)
                    objSys_FunctionET.ParentFunctionID = new Guid(Convert.ToString(oReader["ParentFunctionID"]));
                if (oReader["UsedState"] != DBNull.Value)
                    objSys_FunctionET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Checksum"] != null)
                    objSys_FunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader.Table.Columns.Contains("Infor") && oReader["Infor"] != null)
                    objSys_FunctionET.Infor = Convert.ToString(oReader["Infor"]);
                if (oReader.Table.Columns.Contains("ImagePath") && oReader["ImagePath"] != null)
                    objSys_FunctionET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                if (oReader.Table.Columns.Contains("ImageFileName") && oReader["ImageFileName"] != null)
                    objSys_FunctionET.ImageFileName = Convert.ToString(oReader["ImageFileName"]);
                if (oReader.Table.Columns.Contains("CreatedBy") && oReader["CreatedBy"] != null)
                    objSys_FunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader.Table.Columns.Contains("CreatedDate") && oReader["CreatedDate"] != DBNull.Value)
                    objSys_FunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader.Table.Columns.Contains("ModifiedBy") && oReader["ModifiedBy"] != null)
                    objSys_FunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader.Table.Columns.Contains("ModifiedDate") && oReader["ModifiedDate"] != DBNull.Value)
                    objSys_FunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["URL"] != DBNull.Value)
                    objSys_FunctionET.URL = oReader[Sys_FunctionET.FIELD_URL] as string;
                return objSys_FunctionET;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " setPropertiesET", ex.Message);
                throw ex;
            }
            
        }

        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<param name="p_search">Keyword Search</param>
        ///<param name="rownum">Số bản ghi trên trang</param>
        ///<param name="page">Trang cần lấy</param>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_FunctionET> GetAll_Sys_Function_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_FunctionET> lstSys_FunctionET = new List<Sys_FunctionET>();
                DataTable tblSys_FunctionET = GetTableByProcedurePaging("sp_Sys_Function_SearchPaging", new object[] { p_search, Guid.Empty, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_FunctionET.Rows.Count; i++)
                {
                    lstSys_FunctionET.Add(setPropertiesET(tblSys_FunctionET.Rows[i]));
                }
                return lstSys_FunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " GetAll_Sys_Function_Paging", ex.Message);

                throw ex;
            }
        }

        public List<Sys_FunctionET> GetAll_Sys_Function_Paging_Search4Admin(string Language, string p_search, int UsedState, Guid ParentFunction, string Url, bool Recusive, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_FunctionET> lstSys_FunctionET = new List<Sys_FunctionET>();
                DataTable tblSys_FunctionET = GetTableByProcedurePaging("sp_GetPaging_Sys_Function_Search4Admin", new object[] { Language,  p_search, UsedState, ParentFunction, Url, Recusive, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_FunctionET.Rows.Count; i++)
                {
                    lstSys_FunctionET.Add(setPropertiesET(tblSys_FunctionET.Rows[i]));
                }
                return lstSys_FunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " GetAll_Sys_Function_Paging_Search4Admin", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_FunctionET> GetAll_Sys_Function()
        {
            try
            {
                List<Sys_FunctionET> lstSys_FunctionET = new List<Sys_FunctionET>();
                DataTable tblSys_FunctionET = GetTableByProcedure("sp_GetAll_Sys_Function");
                for (int i = 0; i < tblSys_FunctionET.Rows.Count; i++)
                {
                    lstSys_FunctionET.Add(setProperties(tblSys_FunctionET.Rows[i]));
                }
                return lstSys_FunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " GetAll_Sys_Function", ex.Message);

                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng DataTable
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public DataTable GetAll_Sys_FunctionByUsedState( int UsedState)
        {
            try
            {
                DataTable tblSys_FunctionET = GetTableByProcedure("sp_GetAll_Sys_Function", UsedState);
                return tblSys_FunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " GetAll_Sys_FunctionByUsedState", ex.Message);

                throw ex;
            }
        }
        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public Sys_FunctionET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_FunctionET objSys_FunctionET = new Sys_FunctionET();
                DataTable tblSys_FunctionET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Function", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSys_FunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        if (oReader["Language"] != DBNull.Value)
                            objSys_FunctionET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["PageID"] != DBNull.Value)
                            objSys_FunctionET.PageID = new Guid(Convert.ToString(oReader["PageID"]));
                        if (oReader["Name"] != DBNull.Value)
                            objSys_FunctionET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objSys_FunctionET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ParentFunctionID"] != DBNull.Value)
                            objSys_FunctionET.ParentFunctionID = new Guid(Convert.ToString(oReader["ParentFunctionID"]));
                        if (oReader["UsedState"] != DBNull.Value)
                            objSys_FunctionET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_FunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["Infor"] != DBNull.Value)
                            objSys_FunctionET.Infor = Convert.ToString(oReader["Infor"]);
                        if (oReader["ImagePath"] != DBNull.Value)
                            objSys_FunctionET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                        if (oReader["ImageFileName"] != DBNull.Value)
                            objSys_FunctionET.ImageFileName = Convert.ToString(oReader["ImageFileName"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_FunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_FunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSys_FunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_FunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_FunctionET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " GetInfo", ex.Message);

                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_FunctionET objSys_FunctionET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_Function"
                         , objSys_FunctionET.FunctionID
                         , objSys_FunctionET.Language
                         , objSys_FunctionET.PageID
                         , objSys_FunctionET.Name
                         , objSys_FunctionET.Ordinal
                         , objSys_FunctionET.ParentFunctionID
                         , objSys_FunctionET.UsedState
                         , objSys_FunctionET.Checksum
                         , objSys_FunctionET.Infor
                         , objSys_FunctionET.ImagePath
                         , objSys_FunctionET.ImageFileName
                         , objSys_FunctionET.CreatedBy
                         , objSys_FunctionET.CreatedDate
                         , objSys_FunctionET.ModifiedBy
                         , objSys_FunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_FunctionET objSys_FunctionET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_Function", "FunctionID"
                         , objSys_FunctionET.Language
                         , objSys_FunctionET.PageID
                         , objSys_FunctionET.Name
                         , objSys_FunctionET.Ordinal
                         , objSys_FunctionET.ParentFunctionID
                         , objSys_FunctionET.UsedState
                         , objSys_FunctionET.Checksum
                         , objSys_FunctionET.Infor
                         , objSys_FunctionET.ImagePath
                         , objSys_FunctionET.ImageFileName
                         , objSys_FunctionET.CreatedBy
                         , objSys_FunctionET.CreatedDate
                         , objSys_FunctionET.ModifiedBy
                         , objSys_FunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " Insert", ex.Message);
                return false;
            }
        }
        /// <summary> 
        ///Lấy toàn bộ thông tin trong bảng Sys_FunctionET
        /// </summary> 
        /// <returns>Trả về kiểu List Sys_FunctionET </returns> 
        public List<Sys_FunctionET> GetAll_Sys_FunctionByLanguage_UsedState(string CurrentLanguage, int UsedState)
        {
            List<Sys_FunctionET> lstSys_FunctionET = new List<Sys_FunctionET>();

            DataTable tblSys_FunctionET = GetTableByProcedure("sp_GetAll_Sys_FunctionByLanguage_UsedState", CurrentLanguage, UsedState);
            for (int i = 0; i < tblSys_FunctionET.Rows.Count; i++)
            {
                //Sys_FunctionET objSys_FunctionET = new Sys_FunctionET();
                lstSys_FunctionET.Add(setPropertiesET(tblSys_FunctionET.Rows[i]));
            }
            return lstSys_FunctionET;
        }
        public List<Sys_FunctionET> GetAll_FunctionBy_UsedState_UserID(string UserID, string CurrentLanguage, int UsedState)
        {
            List<Sys_FunctionET> lstSys_FunctionET = new List<Sys_FunctionET>();

            DataTable tblSys_FunctionET = GetTableByProcedure("sp_Sys_User_Function_GetByUserID", UserID, CurrentLanguage, UsedState);
            for (int i = 0; i < tblSys_FunctionET.Rows.Count; i++)
            {
                //Sys_FunctionET objSys_FunctionET = new Sys_FunctionET();
                lstSys_FunctionET.Add(setPropertiesET(tblSys_FunctionET.Rows[i]));
            }
            return lstSys_FunctionET;
        }
       
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Function", GuidID))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            objMsg.Error = true;
                            objMsg.Message = Convert.ToString(oReader[0]);
                        }
                }
                return objMsg;

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_FunctionDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }


        
    }
}
