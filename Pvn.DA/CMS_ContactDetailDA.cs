using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ContactDetailDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		28/07/2017		Tạo mới
        ///</Modified>
        private CMS_ContactDetailET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ContactDetailET objCMS_ContactDetailET = new CMS_ContactDetailET();
                if (oReader["ContactDetailID"] != DBNull.Value)
                    objCMS_ContactDetailET.ContactDetailID = Convert.ToInt32(oReader["ContactDetailID"]);
                if (oReader["Contact"] != DBNull.Value)
                    objCMS_ContactDetailET.Contact = Convert.ToString(oReader["Contact"]);
                if (oReader["OwnerID"] != DBNull.Value)
                    objCMS_ContactDetailET.OwnerID = Convert.ToInt32(oReader["OwnerID"]);
                if (oReader["OwnerType"] != DBNull.Value)
                    objCMS_ContactDetailET.OwnerType = Convert.ToInt32(oReader["OwnerType"]);
                if (oReader["ContactTypeID"] != DBNull.Value)
                    objCMS_ContactDetailET.ContactTypeID = Convert.ToInt32(oReader["ContactTypeID"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_ContactDetailET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_ContactDetailET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_ContactDetailET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_ContactDetailET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_ContactDetailET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_ContactDetailET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_ContactDetailET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", "setProperties", ex.Message);
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
        ///Bachdx		28/07/2017		Tạo mới
        ///</Modified>
        public List<CMS_ContactDetailET> GetAll_CMS_ContactDetail_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ContactDetailET> lstCMS_ContactDetailET = new List<CMS_ContactDetailET>();
                DataTable tblCMS_ContactDetailET = GetTableByProcedurePaging("sp_CMS_ContactDetail_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ContactDetailET.Rows.Count; i++)
                {
                    lstCMS_ContactDetailET.Add(setProperties(tblCMS_ContactDetailET.Rows[i]));
                }
                return lstCMS_ContactDetailET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		28/07/2017		Tạo mới
        ///</Modified>
        public List<CMS_ContactDetailET> GetAll_CMS_ContactDetail()
        {
            try
            {
                List<CMS_ContactDetailET> lstCMS_ContactDetailET = new List<CMS_ContactDetailET>();
                DataTable tblCMS_ContactDetailET = GetTableByProcedure("sp_GetAll_CMS_ContactDetail");
                for (int i = 0; i < tblCMS_ContactDetailET.Rows.Count; i++)
                {
                    lstCMS_ContactDetailET.Add(setProperties(tblCMS_ContactDetailET.Rows[i]));
                }
                return lstCMS_ContactDetailET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public DataTable GetAll_CMS_ContactDetailByContactbyID( int OwnerID, int OwnerType)
        {
            try
            {
                DataTable tblCMS_ContactDetailET = GetTableByProcedure("sp_CMS_ContactDetail_ByOwnerIDAndType", OwnerID, OwnerType);
                return tblCMS_ContactDetailET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " GetAll_..", ex.Message);
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
        ///Bachdx		28/07/2017Tạo mới
        ///</Modified>
        public CMS_ContactDetailET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_ContactDetailET objCMS_ContactDetailET = new CMS_ContactDetailET();
                DataTable tblCMS_ContactDetailET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ContactDetail", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ContactDetailID"] != DBNull.Value)
                            objCMS_ContactDetailET.ContactDetailID = Convert.ToInt32(oReader["ContactDetailID"]);
                        if (oReader["Contact"] != DBNull.Value)
                            objCMS_ContactDetailET.Contact = Convert.ToString(oReader["Contact"]);
                        if (oReader["OwnerID"] != DBNull.Value)
                            objCMS_ContactDetailET.OwnerID = Convert.ToInt32(oReader["OwnerID"]);
                        if (oReader["OwnerType"] != DBNull.Value)
                            objCMS_ContactDetailET.OwnerType = Convert.ToInt32(oReader["OwnerType"]);
                        if (oReader["ContactTypeID"] != DBNull.Value)
                            objCMS_ContactDetailET.ContactTypeID = Convert.ToInt32(oReader["ContactTypeID"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_ContactDetailET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_ContactDetailET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_ContactDetailET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_ContactDetailET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_ContactDetailET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_ContactDetailET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_ContactDetailET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ContactDetailET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		28/07/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ContactDetailET objCMS_ContactDetailET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ContactDetail"
                         , objCMS_ContactDetailET.ContactDetailID
                         , objCMS_ContactDetailET.Contact
                         , objCMS_ContactDetailET.OwnerID
                         , objCMS_ContactDetailET.OwnerType
                         , objCMS_ContactDetailET.ContactTypeID
                         , objCMS_ContactDetailET.UsedState
                         , objCMS_ContactDetailET.Note
                         , objCMS_ContactDetailET.CreatedDate
                         , objCMS_ContactDetailET.CreatedBy
                         , objCMS_ContactDetailET.ModifiedDate
                         , objCMS_ContactDetailET.ModifiedBy
                ))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            {
                                objMsg.Error = true;
                                objMsg.Message = Convert.ToString(oReader[0]);
                            }
                        }
                }
                return objMsg;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ContactDetailET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		28/07/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_ContactDetailET objCMS_ContactDetailET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_ContactDetail", "ContactDetailID"
                         , objCMS_ContactDetailET.Contact
                         , objCMS_ContactDetailET.OwnerID
                         , objCMS_ContactDetailET.OwnerType
                         , objCMS_ContactDetailET.ContactTypeID
                         , objCMS_ContactDetailET.UsedState
                         , objCMS_ContactDetailET.Note
                         , objCMS_ContactDetailET.CreatedDate
                         , objCMS_ContactDetailET.CreatedBy
                         , objCMS_ContactDetailET.ModifiedDate
                         , objCMS_ContactDetailET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ContactDetailET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		28/07/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int ItemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ContactDetail", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactDetailDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
