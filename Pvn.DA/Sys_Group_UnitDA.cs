using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_Group_UnitDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		01/04/2016		Tạo mới
        ///</Modified>
        private Sys_Group_UnitET setProperties(DataRow oReader)
        {
            try
            {
                Sys_Group_UnitET objSys_Group_UnitET = new Sys_Group_UnitET();
                if (oReader["GroupUnitID"] != DBNull.Value)
                    objSys_Group_UnitET.GroupUnitID = new Guid(Convert.ToString(oReader["GroupUnitID"]));
                if (oReader["Name"] != DBNull.Value)
                    objSys_Group_UnitET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objSys_Group_UnitET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSys_Group_UnitET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_Group_UnitET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objSys_Group_UnitET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSys_Group_UnitET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_Group_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", "setProperties", ex.Message);
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
        ///Bachdx		01/04/2016		Tạo mới
        ///</Modified>
        public List<Sys_Group_UnitET> GetAll_Sys_Group_Unit_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_Group_UnitET> lstSys_Group_UnitET = new List<Sys_Group_UnitET>();
                DataTable tblSys_Group_UnitET = GetTableByProcedurePaging("sp_Sys_Group_Unit_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_Group_UnitET.Rows.Count; i++)
                {
                    lstSys_Group_UnitET.Add(setProperties(tblSys_Group_UnitET.Rows[i]));
                }
                return lstSys_Group_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		01/04/2016		Tạo mới
        ///</Modified>
        public List<Sys_Group_UnitET> GetAll_Sys_Group_Unit()
        {
            try
            {
                List<Sys_Group_UnitET> lstSys_Group_UnitET = new List<Sys_Group_UnitET>();
                DataTable tblSys_Group_UnitET = GetTableByProcedure("sp_GetAll_Sys_Group_Unit");
                for (int i = 0; i < tblSys_Group_UnitET.Rows.Count; i++)
                {
                    lstSys_Group_UnitET.Add(setProperties(tblSys_Group_UnitET.Rows[i]));
                }
                return lstSys_Group_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " GetAll_..", ex.Message);
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
        ///Bachdx		01/04/2016Tạo mới
        ///</Modified>
        public Sys_Group_UnitET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_Group_UnitET objSys_Group_UnitET = new Sys_Group_UnitET();
                DataTable tblSys_Group_UnitET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Group_Unit", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["GroupUnitID"] != DBNull.Value)
                            objSys_Group_UnitET.GroupUnitID = new Guid(Convert.ToString(oReader["GroupUnitID"]));
                        if (oReader["Name"] != DBNull.Value)
                            objSys_Group_UnitET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objSys_Group_UnitET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_Group_UnitET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_Group_UnitET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSys_Group_UnitET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_Group_UnitET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_Group_UnitET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_Group_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		01/04/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_Group_UnitET objSys_Group_UnitET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_Group_Unit"
                         , objSys_Group_UnitET.GroupUnitID
                         , objSys_Group_UnitET.Name
                         , objSys_Group_UnitET.Ordinal
                         , objSys_Group_UnitET.CreatedBy
                         , objSys_Group_UnitET.CreatedDate
                         , objSys_Group_UnitET.ModifiedBy
                         , objSys_Group_UnitET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_Group_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		01/04/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_Group_UnitET objSys_Group_UnitET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_Group_Unit", "GroupUnitID"
                         , objSys_Group_UnitET.Name
                         , objSys_Group_UnitET.Ordinal
                         , objSys_Group_UnitET.CreatedBy
                         , objSys_Group_UnitET.CreatedDate
                         , objSys_Group_UnitET.ModifiedBy
                         , objSys_Group_UnitET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_Group_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		01/04/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Group_Unit", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UnitDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}
