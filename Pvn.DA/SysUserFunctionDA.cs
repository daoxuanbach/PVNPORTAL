using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysUserFunctionDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary> 
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        private SysUserFunctionET setProperties(DataRow oReader)
        {
            try
            {
                SysUserFunctionET objSysUserFunctionET = new SysUserFunctionET();
                if (oReader["User_FunctionID"] != DBNull.Value)
                    objSysUserFunctionET.User_FunctionID = new Guid(Convert.ToString(oReader["User_FunctionID"]));
                if (oReader.Table.Columns.Contains("FullName") && oReader["FullName"] != DBNull.Value)
                    objSysUserFunctionET.FullName = Convert.ToString(oReader["FullName"]);

                if (oReader.Table.Columns.Contains("CheckUserFunction") && oReader["CheckUserFunction"] != DBNull.Value)
                    objSysUserFunctionET.CheckUserFunction = Convert.ToString(oReader["CheckUserFunction"]);

                if (oReader.Table.Columns.Contains("UserIDType") && oReader["UserIDType"] != DBNull.Value)
                    objSysUserFunctionET.UserIDType = Convert.ToInt32(oReader["UserIDType"]);
                if (oReader.Table.Columns.Contains("UserID") && oReader["UserID"] != DBNull.Value)
                    objSysUserFunctionET.UserID = Convert.ToString(oReader["UserID"]);
                if (oReader.Table.Columns.Contains("FunctionID") && oReader["FunctionID"] != DBNull.Value)
                    objSysUserFunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader.Table.Columns.Contains("Checksum") && oReader["Checksum"] != DBNull.Value)
                    objSysUserFunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSysUserFunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSysUserFunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objSysUserFunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSysUserFunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", "setProperties", ex.Message);
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
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        public List<SysUserFunctionET> GetAll_SysUserFunction_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysUserFunctionET> lstSysUserFunctionET = new List<SysUserFunctionET>();
                DataTable tblSysUserFunctionET = GetTableByProcedurePaging("sp_SysUserFunction_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysUserFunctionET.Rows.Count; i++)
                {
                    lstSysUserFunctionET.Add(setProperties(tblSysUserFunctionET.Rows[i]));
                }
                return lstSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        public List<SysUserFunctionET> GetAll_SysUserFunction_GetByUserID_Fn_Tree(int UserID, string Language, int UsedState)
        {
            try
            {
                List<SysUserFunctionET> lstSysUserFunctionET = new List<SysUserFunctionET>();
                DataTable tblSysUserFunctionET = GetTableByProcedure("sp_Sys_User_Function_GetByUserID_NewFn_Tree", UserID, Language, UsedState);
                for (int i = 0; i < tblSysUserFunctionET.Rows.Count; i++)
                {
                    lstSysUserFunctionET.Add(setProperties(tblSysUserFunctionET.Rows[i]));
                }
                return lstSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public List<SysUserFunctionET> GetAll_SysUserFunction_Tree_ByUser(int UserID, string Language, int UsedState)
        {
            try
            {
                List<SysUserFunctionET> lstSysUserFunctionET = new List<SysUserFunctionET>();
                DataTable tblSysUserFunctionET = GetTableByProcedure("sp_Sys_User_Function_TreeByUserID", UserID, Language, UsedState);
                for (int i = 0; i < tblSysUserFunctionET.Rows.Count; i++)
                {
                    lstSysUserFunctionET.Add(setProperties(tblSysUserFunctionET.Rows[i]));
                }
                return lstSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public List<SysUserFunctionET> GetAll_Function_Tree_ByUserPermission(int UserID, string Language, int UsedState)
        {
            try
            {
                List<SysUserFunctionET> lstSysUserFunctionET = new List<SysUserFunctionET>();
                DataTable tblSysUserFunctionET = GetTableByProcedure("GetAll_Function_Tree_ByUserPermission", UserID, Language, UsedState);
                for (int i = 0; i < tblSysUserFunctionET.Rows.Count; i++)
                {
                    lstSysUserFunctionET.Add(setProperties(tblSysUserFunctionET.Rows[i]));
                }
                return lstSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public List<SysUserFunctionET> GetAll_SysUserFunction_GetByUserID(int UserID, string Language, int UsedState)
        {
            try
            {
                List<SysUserFunctionET> lstSysUserFunctionET = new List<SysUserFunctionET>();
                DataTable tblSysUserFunctionET = GetTableByProcedure("sp_Sys_User_Function_GetByUserID_NewFn", UserID, Language, UsedState);
                for (int i = 0; i < tblSysUserFunctionET.Rows.Count; i++)
                {
                    lstSysUserFunctionET.Add(setProperties(tblSysUserFunctionET.Rows[i]));
                }
                return lstSysUserFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetAll_..", ex.Message);
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
        ///Bachdx		26/08/2016Tạo mới
        ///</Modified>
        public SysUserFunctionET GetInfo(Guid intItemID)
        {
            try
            {
                SysUserFunctionET objSysUserFunctionET = new SysUserFunctionET();
                DataTable tblSysUserFunctionET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysUserFunction", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["User_FunctionID"] != DBNull.Value)
                            objSysUserFunctionET.User_FunctionID = new Guid(Convert.ToString(oReader["User_FunctionID"]));
                        if (oReader["UserIDType"] != DBNull.Value)
                            objSysUserFunctionET.UserIDType = Convert.ToInt32(oReader["UserIDType"]);
                        if (oReader["UserID"] != DBNull.Value)
                            objSysUserFunctionET.UserID = Convert.ToString(oReader["UserID"]);
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSysUserFunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        if (oReader["Checksum"] != DBNull.Value)
                            objSysUserFunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSysUserFunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSysUserFunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSysUserFunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSysUserFunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSysUserFunctionET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysUserFunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016Tạo mới
        ///</Modified>
        public bool Update(SysUserFunctionET objSysUserFunctionET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_SysUserFunction"
                         , objSysUserFunctionET.User_FunctionID
                         , objSysUserFunctionET.UserIDType
                         , objSysUserFunctionET.UserID
                         , objSysUserFunctionET.FunctionID
                         , objSysUserFunctionET.Checksum
                         , objSysUserFunctionET.CreatedBy
                         , objSysUserFunctionET.CreatedDate
                         , objSysUserFunctionET.ModifiedBy
                         , objSysUserFunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysUserFunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016Tạo mới
        ///</Modified>
        public bool Insert(SysUserFunctionET objSysUserFunctionET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_User_Function", "User_FunctionID"
                         , objSysUserFunctionET.UserIDType
                         , objSysUserFunctionET.UserID
                         , objSysUserFunctionET.FunctionID
                         , objSysUserFunctionET.Checksum
                         , objSysUserFunctionET.CreatedBy
                         , objSysUserFunctionET.CreatedDate
                         , objSysUserFunctionET.ModifiedBy
                         , objSysUserFunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysUserFunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_User_Function", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysUserFunctionDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

