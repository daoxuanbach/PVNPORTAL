using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysGroupFunctionDA : Pvn.DA.DataProvider
    {
        //--Người dùng
        //SELECT * FROM dbo.Sys_User AS SU
        //--Người dùng chức nang
        //SELECT * FROM dbo.Sys_User_Function AS SUF
        //-- người dùng - nhóm
        //SELECT * FROM dbo.Sys_Group_User AS SGU
        //-- nhóm
        //SELECT * FROM dbo.Sys_Group AS SG
        //-- Chức năng thuộc nhóm
        //SELECT * FROM dbo.Sys_Group_Function AS SGF

        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        private SysGroupFunctionET setProperties(DataRow oReader)
        {
            try
            {
                SysGroupFunctionET objSysGroupFunctionET = new SysGroupFunctionET();
                if (oReader["Group_FunctionID"] != DBNull.Value)
                    objSysGroupFunctionET.Group_FunctionID = new Guid(Convert.ToString(oReader["Group_FunctionID"]));
                if (oReader.Table.Columns.Contains("GroupID") && oReader["GroupID"] != DBNull.Value)
                    objSysGroupFunctionET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                if (oReader["FunctionID"] != DBNull.Value)
                    objSysGroupFunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader.Table.Columns.Contains("FullName") && oReader["FullName"] != DBNull.Value)
                    objSysGroupFunctionET.FullName = (Convert.ToString(oReader["FullName"]));
                
                if (oReader["Checksum"] != DBNull.Value)
                    objSysGroupFunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSysGroupFunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSysGroupFunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objSysGroupFunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSysGroupFunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader.Table.Columns.Contains("CheckGroupFunction") && oReader["CheckGroupFunction"] != DBNull.Value)
                    objSysGroupFunctionET.CheckGroupFunction = Convert.ToString(oReader["CheckGroupFunction"]);

                return objSysGroupFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", "setProperties", ex.Message);
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
        public List<SysGroupFunctionET> GetAll_SysGroupFunction_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysGroupFunctionET> lstSysGroupFunctionET = new List<SysGroupFunctionET>();
                DataTable tblSysGroupFunctionET = GetTableByProcedurePaging("sp_SysGroupFunction_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysGroupFunctionET.Rows.Count; i++)
                {
                    lstSysGroupFunctionET.Add(setProperties(tblSysGroupFunctionET.Rows[i]));
                }
                return lstSysGroupFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " GetAll_.._Paging", ex.Message);
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
        public List<SysGroupFunctionET> GetAll_SysGroupFunction()
        {
            try
            {
                List<SysGroupFunctionET> lstSysGroupFunctionET = new List<SysGroupFunctionET>();
                DataTable tblSysGroupFunctionET = GetTableByProcedure("sp_GetAll_SysGroupFunction");
                for (int i = 0; i < tblSysGroupFunctionET.Rows.Count; i++)
                {
                    lstSysGroupFunctionET.Add(setProperties(tblSysGroupFunctionET.Rows[i]));
                }
                return lstSysGroupFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public DataTable GetAll_SysGroupFunction_By_GroupID(Guid GroupID, string Language, int UsedState)
        {
            try
            {
                DataTable tblSysGroupFunctionET = GetTableByProcedure("sp_GetAll_SysGroupFunction_By_GroupID", new object[] { GroupID, Language, UsedState });
                return tblSysGroupFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " GetAll_SysGroupFunction_By_GroupID..", ex.Message);
                throw ex;
            }
        }

        public List<SysGroupFunctionET> GetAllET_SysGroupFunction_By_GroupID(Guid GroupID, string Language, int UsedState)
        {
            try
            {
                List<SysGroupFunctionET> lstSysGroupFunctionET = new List<SysGroupFunctionET>();
                DataTable tblSysGroupFunctionET = GetTableByProcedure("sp_GetAll_SysGroupFunction_By_GroupID", new object[] { GroupID, Language, UsedState });
                for (int i = 0; i < tblSysGroupFunctionET.Rows.Count; i++)
                {
                    lstSysGroupFunctionET.Add(setProperties(tblSysGroupFunctionET.Rows[i]));
                }
                return lstSysGroupFunctionET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " GetAll_SysGroupFunction_By_GroupID..", ex.Message);
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
        public SysGroupFunctionET GetInfo(Guid intItemID)
        {
            try
            {
                SysGroupFunctionET objSysGroupFunctionET = new SysGroupFunctionET();
                DataTable tblSysGroupFunctionET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysGroupFunction", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Group_FunctionID"] != DBNull.Value)
                            objSysGroupFunctionET.Group_FunctionID = new Guid(Convert.ToString(oReader["Group_FunctionID"]));
                        if (oReader["GroupID"] != DBNull.Value)
                            objSysGroupFunctionET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSysGroupFunctionET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        if (oReader["Checksum"] != DBNull.Value)
                            objSysGroupFunctionET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSysGroupFunctionET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSysGroupFunctionET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSysGroupFunctionET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSysGroupFunctionET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSysGroupFunctionET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysGroupFunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016Tạo mới
        ///</Modified>
        public bool Update(SysGroupFunctionET objSysGroupFunctionET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_SysGroupFunction"
                         , objSysGroupFunctionET.Group_FunctionID
                         , objSysGroupFunctionET.GroupID
                         , objSysGroupFunctionET.FunctionID
                         , objSysGroupFunctionET.Checksum
                         , objSysGroupFunctionET.CreatedBy
                         , objSysGroupFunctionET.CreatedDate
                         , objSysGroupFunctionET.ModifiedBy
                         , objSysGroupFunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysGroupFunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		26/08/2016Tạo mới
        ///</Modified>
        public bool Insert(SysGroupFunctionET objSysGroupFunctionET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_SysGroupFunction", "Group_FunctionID"
                         , objSysGroupFunctionET.GroupID
                         , objSysGroupFunctionET.FunctionID
                         , objSysGroupFunctionET.Checksum
                         , objSysGroupFunctionET.CreatedBy
                         , objSysGroupFunctionET.CreatedDate
                         , objSysGroupFunctionET.ModifiedBy
                         , objSysGroupFunctionET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysGroupFunctionET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_SysGroupFunction", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysGroupFunctionDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

    }  
}

