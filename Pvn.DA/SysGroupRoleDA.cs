using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysGroupRoleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        private SysGroupRoleET setProperties(DataRow oReader)
        {
            try
            {
                SysGroupRoleET objSysGroupRoleET = new SysGroupRoleET();
                if (oReader["Group_RoleID"] != DBNull.Value)
                    objSysGroupRoleET.Group_RoleID = Convert.ToInt32(oReader["Group_RoleID"]);
                if (oReader["RoleID"] != DBNull.Value)
                    objSysGroupRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);

             
                if (oReader.Table.Columns.Contains("Name") && oReader["Name"] != DBNull.Value)
                    objSysGroupRoleET.Name = Convert.ToString(oReader["Name"]);
                if (oReader.Table.Columns.Contains("Title") && oReader["Title"] != DBNull.Value)
                    objSysGroupRoleET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["GroupID"] != DBNull.Value)
                    objSysGroupRoleET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                if (oReader["FunctionID"] != DBNull.Value)
                    objSysGroupRoleET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader.Table.Columns.Contains("CheckGroupRole") && oReader["CheckGroupRole"] != DBNull.Value)
                    objSysGroupRoleET.CheckGroupRole = Convert.ToString(oReader["CheckGroupRole"]);
                return objSysGroupRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        public bool DeleteRoleByGroup(Guid GroupID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByGroupID_SysGroupRole", GroupID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " DeleteRoleByUser", ex.Message);
                return false;
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
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public List<SysGroupRoleET> GetAll_SysGroupRole_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysGroupRoleET> lstSysGroupRoleET = new List<SysGroupRoleET>();
                DataTable tblSysGroupRoleET = GetTableByProcedurePaging("sp_SysGroupRole_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysGroupRoleET.Rows.Count; i++)
                {
                    lstSysGroupRoleET.Add(setProperties(tblSysGroupRoleET.Rows[i]));
                }
                return lstSysGroupRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }

        public List<SysGroupRoleET> GetAll_SysGroupRole_Where(Guid? functionID, Guid groupID)
        {
            try
            {
                List<SysGroupRoleET> lstSysGroupRoleET = new List<SysGroupRoleET>();
                DataTable tblSysGroupRoleET = GetTableByProcedure("sp_GetAll_SysGroupRole_Where", new object[] { functionID, groupID });
                for (int i = 0; i < tblSysGroupRoleET.Rows.Count; i++)
                {
                    lstSysGroupRoleET.Add(setProperties(tblSysGroupRoleET.Rows[i]));
                }
                return lstSysGroupRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " GetAll_SysGroupRole_Where..", ex.Message);
                throw ex;
            }
        }

        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public List<SysGroupRoleET> GetAll_SysGroupRole()
        {
            try
            {
                List<SysGroupRoleET> lstSysGroupRoleET = new List<SysGroupRoleET>();
                DataTable tblSysGroupRoleET = GetTableByProcedure("sp_GetAll_SysGroupRole");
                for (int i = 0; i < tblSysGroupRoleET.Rows.Count; i++)
                {
                    lstSysGroupRoleET.Add(setProperties(tblSysGroupRoleET.Rows[i]));
                }
                return lstSysGroupRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		09/01/2017Tạo mới
        ///</Modified>
        public SysGroupRoleET GetInfo(Guid intItemID)
        {
            try
            {
                SysGroupRoleET objSysGroupRoleET = new SysGroupRoleET();
                DataTable tblSysGroupRoleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysGroupRole", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Group_RoleID"] != DBNull.Value)
                            objSysGroupRoleET.Group_RoleID = Convert.ToInt32(oReader["Group_RoleID"]);
                        if (oReader["RoleID"] != DBNull.Value)
                            objSysGroupRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);
                        if (oReader["GroupID"] != DBNull.Value)
                            objSysGroupRoleET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSysGroupRoleET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        return objSysGroupRoleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysGroupRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(SysGroupRoleET objSysGroupRoleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_SysGroupRole"
                        , objSysGroupRoleET.Group_RoleID
                        , objSysGroupRoleET.RoleID
                        , objSysGroupRoleET.GroupID
                        , objSysGroupRoleET.FunctionID
                 ))
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
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysGroupRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017Tạo mới
        ///</Modified>
        public bool Insert(SysGroupRoleET objSysGroupRoleET)
        {
            try
            {
                ExecuteNonQuery("sp_Add_SysGroupRole"
                         , objSysGroupRoleET.RoleID
                         , objSysGroupRoleET.GroupID
                         , objSysGroupRoleET.FunctionID
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysGroupRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_SysGroupRole", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysGroupRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_SysGroupRole", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysGroupRoleDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

