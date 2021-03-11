using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_Group_UserDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/05/2016		Tạo mới
        ///</Modified>
        private Sys_Group_UserET setProperties(DataRow oReader)
        {
            try
            {
                Sys_Group_UserET objSys_Group_UserET = new Sys_Group_UserET();
                if (oReader["Group_UserID"] != DBNull.Value)
                    objSys_Group_UserET.Group_UserID = new Guid(Convert.ToString(oReader["Group_UserID"]));
                if (oReader["GroupID"] != DBNull.Value)
                    objSys_Group_UserET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                if (oReader["UserID"] != DBNull.Value)
                    objSys_Group_UserET.UserID = Convert.ToString(oReader["UserID"]);
                if (oReader.Table.Columns.Contains("UserName")& oReader["UserName"] != DBNull.Value)
                    objSys_Group_UserET.UserName = Convert.ToString(oReader["UserName"]);
                if (oReader.Table.Columns.Contains("LoginName") & oReader["LoginName"] != DBNull.Value)
                  objSys_Group_UserET.LoginName = Convert.ToString(oReader["LoginName"]);
                
                if (oReader["Checksum"] != DBNull.Value)
                    objSys_Group_UserET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSys_Group_UserET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_Group_UserET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objSys_Group_UserET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSys_Group_UserET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_Group_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", "setProperties", ex.Message);
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
        ///Bachdx		17/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_Group_UserET> GetAll_Sys_Group_User_Paging(Guid GroupID, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_Group_UserET> lstSys_Group_UserET = new List<Sys_Group_UserET>();
                DataTable tblSys_Group_UserET = GetTableByProcedurePaging("sp_Sys_Group_User_SearchPaging", new object[] { GroupID, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_Group_UserET.Rows.Count; i++)
                {
                    lstSys_Group_UserET.Add(setProperties(tblSys_Group_UserET.Rows[i]));
                }
                return lstSys_Group_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_Group_UserET> GetAll_Sys_Group_User()
        {
            try
            {
                List<Sys_Group_UserET> lstSys_Group_UserET = new List<Sys_Group_UserET>();
                DataTable tblSys_Group_UserET = GetTableByProcedure("sp_GetAll_Sys_Group_User");
                for (int i = 0; i < tblSys_Group_UserET.Rows.Count; i++)
                {
                    lstSys_Group_UserET.Add(setProperties(tblSys_Group_UserET.Rows[i]));
                }
                return lstSys_Group_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " GetAll_..", ex.Message);
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
        ///Bachdx		17/05/2016Tạo mới
        ///</Modified>
        public Sys_Group_UserET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_Group_UserET objSys_Group_UserET = new Sys_Group_UserET();
                DataTable tblSys_Group_UserET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Group_User", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Group_UserID"] != DBNull.Value)
                            objSys_Group_UserET.Group_UserID = new Guid(Convert.ToString(oReader["Group_UserID"]));
                        if (oReader["GroupID"] != DBNull.Value)
                            objSys_Group_UserET.GroupID = new Guid(Convert.ToString(oReader["GroupID"]));
                        if (oReader["UserID"] != DBNull.Value)
                            objSys_Group_UserET.UserID = Convert.ToString(oReader["UserID"]);
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_Group_UserET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_Group_UserET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_Group_UserET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSys_Group_UserET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_Group_UserET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_Group_UserET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_Group_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/05/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_Group_UserET objSys_Group_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_Group_User"
                         , objSys_Group_UserET.Group_UserID
                         , objSys_Group_UserET.GroupID
                         , objSys_Group_UserET.UserID
                         , objSys_Group_UserET.Checksum
                         , objSys_Group_UserET.CreatedBy
                         , objSys_Group_UserET.CreatedDate
                         , objSys_Group_UserET.ModifiedBy
                         , objSys_Group_UserET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_Group_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/05/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_Group_UserET objSys_Group_UserET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_Group_User", "Group_UserID"
                         , objSys_Group_UserET.GroupID
                         , objSys_Group_UserET.UserID
                         , objSys_Group_UserET.Checksum
                         , objSys_Group_UserET.CreatedBy
                         , objSys_Group_UserET.CreatedDate
                         , objSys_Group_UserET.ModifiedBy
                         , objSys_Group_UserET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_Group_UserET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/05/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {

                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Group_User", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_Group_UserDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

