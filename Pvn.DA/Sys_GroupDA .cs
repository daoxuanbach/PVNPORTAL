using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using System.Globalization;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_GroupDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        private Sys_GroupET setProperties(DataRow oReader)
        {
            try
            {
                Sys_GroupET objSys_GroupET = new Sys_GroupET();
                if (oReader["GroupID"] != DBNull.Value)
                    objSys_GroupET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                if (oReader["Language"] != DBNull.Value)
                    objSys_GroupET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Code"] != DBNull.Value)
                    objSys_GroupET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["RolePermission"] != DBNull.Value)
                    objSys_GroupET.RolePermission = Convert.ToInt32(oReader["RolePermission"]);
                if (oReader["Name"] != DBNull.Value)
                    objSys_GroupET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["UnitName"] != DBNull.Value)
                    objSys_GroupET.UnitName = Convert.ToString(oReader["UnitName"]);
                if (oReader["UnitID"] != DBNull.Value)
                    objSys_GroupET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                if (oReader["UsedState"] != DBNull.Value)
                    objSys_GroupET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Checksum"] != DBNull.Value)
                    objSys_GroupET.Checksum = Convert.ToString(oReader["Checksum"]);
               
                //if (oReader["CreatedBy"] != DBNull.Value)
                //    objSys_GroupET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                //if (oReader["CreatedDate"] != DBNull.Value)
                //    objSys_GroupET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                //if (oReader["ModifiedBy"] != DBNull.Value)
                //    objSys_GroupET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                //if (oReader["ModifiedDate"] != DBNull.Value)
                //    objSys_GroupET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_GroupET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", "setProperties", ex.Message);
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
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_GroupET> GetAll_Sys_Group_Paging(string p_search, string Name, Guid UnitID, int UsedState, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_GroupET> lstSys_GroupET = new List<Sys_GroupET>();
                DataTable tblSys_GroupET = GetTableByProcedurePaging("sp_Sys_Group_SearchPaging", new object[] { p_search,Name,UnitID,UsedState, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_GroupET.Rows.Count; i++)
                {
                    lstSys_GroupET.Add(setProperties(tblSys_GroupET.Rows[i]));
                }
                return lstSys_GroupET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_GroupET> GetAll_Sys_Group()
        {
            try
            {
                List<Sys_GroupET> lstSys_GroupET = new List<Sys_GroupET>();
                DataTable tblSys_GroupET = GetTableByProcedure("sp_GetAll_Sys_Group");
                for (int i = 0; i < tblSys_GroupET.Rows.Count; i++)
                {
                    lstSys_GroupET.Add(setProperties(tblSys_GroupET.Rows[i]));
                }
                return lstSys_GroupET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " GetAll_..", ex.Message);
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
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public Sys_GroupET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_GroupET objSys_GroupET = new Sys_GroupET();
                DataTable tblSys_GroupET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Group", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["GroupID"] != DBNull.Value)
                            objSys_GroupET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                        if (oReader["Language"] != DBNull.Value)
                            objSys_GroupET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Code"] != DBNull.Value)
                            objSys_GroupET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["RolePermission"] != DBNull.Value)
                            objSys_GroupET.RolePermission = Convert.ToInt32(oReader["RolePermission"]);
                        if (oReader["Name"] != DBNull.Value)
                            objSys_GroupET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["UnitID"] != DBNull.Value)
                            objSys_GroupET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                        if (oReader["UnitName"] != DBNull.Value)
                            objSys_GroupET.UnitName = Convert.ToString(oReader["UnitName"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objSys_GroupET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_GroupET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_GroupET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_GroupET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSys_GroupET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_GroupET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_GroupET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_GroupET objSys_GroupET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_Group"
                         , objSys_GroupET.GroupID
                         , objSys_GroupET.Language
                         , objSys_GroupET.Code
                         , objSys_GroupET.RolePermission
                         , objSys_GroupET.Name
                         , objSys_GroupET.UnitID
                         , objSys_GroupET.UsedState
                         , objSys_GroupET.Checksum
                         , objSys_GroupET.CreatedBy
                         , objSys_GroupET.CreatedDate
                         , objSys_GroupET.ModifiedBy
                         , objSys_GroupET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_GroupET objSys_GroupET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_Group", "GroupID"
                         , objSys_GroupET.Language
                         , objSys_GroupET.Code
                         , objSys_GroupET.RolePermission
                         , objSys_GroupET.Name
                         , objSys_GroupET.UnitID
                         , objSys_GroupET.UsedState
                         , objSys_GroupET.Checksum
                         , objSys_GroupET.CreatedBy
                         , objSys_GroupET.CreatedDate
                         , objSys_GroupET.ModifiedBy
                         , objSys_GroupET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
              
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Group", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_GroupDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}
