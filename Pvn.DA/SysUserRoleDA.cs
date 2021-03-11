using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysUserRoleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        private SysUserRoleET setProperties(DataRow oReader)
        {
            try
            {
                SysUserRoleET objSysUserRoleET = new SysUserRoleET();
                if (oReader["User_RoleID"] != DBNull.Value)
                    objSysUserRoleET.User_RoleID = Convert.ToInt32(oReader["User_RoleID"]);
                if (oReader["RoleID"] != DBNull.Value)
                    objSysUserRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);
                if (oReader.Table.Columns.Contains("Name") && oReader["Name"] != DBNull.Value)
                    objSysUserRoleET.Name = Convert.ToString(oReader["Name"]);
                if (oReader.Table.Columns.Contains("Title") && oReader["Title"] != DBNull.Value)
                    objSysUserRoleET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["UserID"] != DBNull.Value)
                    objSysUserRoleET.UserID = Convert.ToInt32(oReader["UserID"]);
                if (oReader.Table.Columns.Contains("CheckGroupRole") && oReader["CheckGroupRole"] != DBNull.Value)
                    objSysUserRoleET.CheckGroupRole = Convert.ToString(oReader["CheckGroupRole"]);
                 return objSysUserRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", "setProperties", ex.Message);
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
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public List<SysUserRoleET> GetAll_SysUserRole_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysUserRoleET> lstSysUserRoleET = new List<SysUserRoleET>();
                DataTable tblSysUserRoleET = GetTableByProcedurePaging("sp_SysUserRole_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysUserRoleET.Rows.Count; i++)
                {
                    lstSysUserRoleET.Add(setProperties(tblSysUserRoleET.Rows[i]));
                }
                return lstSysUserRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public List<SysUserRoleET> GetAll_SysUserRole()
        {
            try
            {
                List<SysUserRoleET> lstSysUserRoleET = new List<SysUserRoleET>();
                DataTable tblSysUserRoleET = GetTableByProcedure("sp_GetAll_SysUserRole");
                for (int i = 0; i < tblSysUserRoleET.Rows.Count; i++)
                {
                    lstSysUserRoleET.Add(setProperties(tblSysUserRoleET.Rows[i]));
                }
                return lstSysUserRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public List<SysUserRoleET> GetAll_SysUserRole_Where(Guid? functionID, int userID)
        {
            try
            {
                List<SysUserRoleET> lstSysUserRoleET = new List<SysUserRoleET>();
                DataTable tblSysUserRoleET = GetTableByProcedure("sp_GetAll_SysUserRole_Where", new object[] { functionID, userID });
                for (int i = 0; i < tblSysUserRoleET.Rows.Count; i++)
                {
                    lstSysUserRoleET.Add(setProperties(tblSysUserRoleET.Rows[i]));
                }
                return lstSysUserRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		06/01/2017Tạo mới
        ///</Modified>
        public SysUserRoleET GetInfo(Guid intItemID)
        {
            try
            {
                SysUserRoleET objSysUserRoleET = new SysUserRoleET();
                DataTable tblSysUserRoleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysUserRole", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["User_RoleID"] != DBNull.Value)
                            objSysUserRoleET.User_RoleID = Convert.ToInt32(oReader["User_RoleID"]);
                        if (oReader["RoleID"] != DBNull.Value)
                            objSysUserRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);
                        if (oReader["UserID"] != DBNull.Value)
                            objSysUserRoleET.UserID = Convert.ToInt32(oReader["UserID"]);
                        return objSysUserRoleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysUserRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(SysUserRoleET objSysUserRoleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_SysUserRole"
                        , objSysUserRoleET.User_RoleID
                        , objSysUserRoleET.RoleID
                        , objSysUserRoleET.UserID
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
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysUserRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017Tạo mới
        ///</Modified>
        public int Insert(SysUserRoleET objSysUserRoleET)
        {
            try
            {
                return ExecuteScalar("sp_Add_SysUserRole",
                     objSysUserRoleET.RoleID
                      , objSysUserRoleET.UserID
                     , objSysUserRoleET.FunctionID
             );

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysUserRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public bool DeleteRoleByUser(int UserID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByUserID_SysUserRole", UserID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " DeleteRoleByUser", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysUserRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_SysUserRole", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysUserRoleDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

