using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysPageRoleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        private SysPageRoleET setProperties(DataRow oReader)
        {
            try
            {
                SysPageRoleET objSysPageRoleET = new SysPageRoleET();
                if (oReader["Id"] != DBNull.Value)
                    objSysPageRoleET.Id = Convert.ToInt32(oReader["Id"]);
                if (oReader["PageID"] != DBNull.Value)
                    objSysPageRoleET.PageID = new Guid(Convert.ToString(oReader["PageID"]));
                if (oReader["RoleId"] != DBNull.Value)
                    objSysPageRoleET.RoleId = Convert.ToInt32(oReader["RoleId"]);
                return objSysPageRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", "setProperties", ex.Message);
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
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public List<SysPageRoleET> GetAll_SysPageRole_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysPageRoleET> lstSysPageRoleET = new List<SysPageRoleET>();
                DataTable tblSysPageRoleET = GetTableByProcedurePaging("sp_SysPageRole_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysPageRoleET.Rows.Count; i++)
                {
                    lstSysPageRoleET.Add(setProperties(tblSysPageRoleET.Rows[i]));
                }
                return lstSysPageRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public List<SysPageRoleET> GetAll_SysPageRole()
        {
            try
            {
                List<SysPageRoleET> lstSysPageRoleET = new List<SysPageRoleET>();
                DataTable tblSysPageRoleET = GetTableByProcedure("sp_GetAll_SysPageRole");
                for (int i = 0; i < tblSysPageRoleET.Rows.Count; i++)
                {
                    lstSysPageRoleET.Add(setProperties(tblSysPageRoleET.Rows[i]));
                }
                return lstSysPageRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public SysPageRoleET GetInfo(Guid intItemID)
        {
            try
            {
                SysPageRoleET objSysPageRoleET = new SysPageRoleET();
                DataTable tblSysPageRoleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysPageRole", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Id"] != DBNull.Value)
                            objSysPageRoleET.Id = Convert.ToInt32(oReader["Id"]);
                        if (oReader["PageID"] != DBNull.Value)
                            objSysPageRoleET.PageID = new Guid(Convert.ToString(oReader["PageID"]));
                        if (oReader["RoleId"] != DBNull.Value)
                            objSysPageRoleET.RoleId = Convert.ToInt32(oReader["RoleId"]);
                        return objSysPageRoleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(SysPageRoleET objSysPageRoleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_SysPageRole"
                        , objSysPageRoleET.Id
                        , objSysPageRoleET.PageID
                        , objSysPageRoleET.RoleId
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
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public bool Insert(SysPageRoleET objSysPageRoleET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_SysPageRole", "Id"
                         , objSysPageRoleET.PageID
                         , objSysPageRoleET.RoleId
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_SysPageRole", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_SysPageRole", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysPageRoleDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

