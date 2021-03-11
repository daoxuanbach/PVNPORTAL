using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;

namespace Pvn.DA
{
    public class CMS_ContactTypeDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/07/2017		Tạo mới
        ///</Modified>
        private CMS_ContactTypeET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ContactTypeET objCMS_ContactTypeET = new CMS_ContactTypeET();
                if (oReader["ContactTypeID"] != DBNull.Value)
                    objCMS_ContactTypeET.ContactTypeID = Convert.ToInt32(oReader["ContactTypeID"]);
                if (oReader["ContactType"] != DBNull.Value)
                    objCMS_ContactTypeET.ContactType = Convert.ToString(oReader["ContactType"]);
                if (oReader["ContactTypeEng"] != DBNull.Value)
                    objCMS_ContactTypeET.ContactTypeEng = Convert.ToString(oReader["ContactTypeEng"]);
                if (oReader["OrderNumber"] != DBNull.Value)
                    objCMS_ContactTypeET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_ContactTypeET.UsedState = Convert.ToInt16(oReader["UsedState"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_ContactTypeET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_ContactTypeET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_ContactTypeET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_ContactTypeET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_ContactTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", "setProperties", ex.Message);
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
        ///Bachdx		12/07/2017		Tạo mới
        ///</Modified>
        public List<CMS_ContactTypeET> GetAll_CMS_ContactType_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ContactTypeET> lstCMS_ContactTypeET = new List<CMS_ContactTypeET>();
                DataTable tblCMS_ContactTypeET = GetTableByProcedurePaging("sp_CMS_ContactType_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ContactTypeET.Rows.Count; i++)
                {
                    lstCMS_ContactTypeET.Add(setProperties(tblCMS_ContactTypeET.Rows[i]));
                }
                return lstCMS_ContactTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                  string currentLanguage,
                  string orderByColumn,
                  int pageIndex,
                  int rowsInPage,
                  out long totalRows,
                  string _title,
                  int? _ordernumber,
                  short? usedstate,
                  int? createdBy,
                  int? modifiedBy,
                  DateTime? createdDateFrom,
                  DateTime? createdDateTo)
        {
            DataTable dt;
            try
            {
                totalRows = 0;
                dt = GetTableByProcedure("sp_CMS_ContactType_SearchPaging", new object[] {
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    _title,
                    _ordernumber,
                    usedstate,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo });

                if (dt != null && dt.Rows.Count > 0)
                {

                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetSearchPaging", ex.Message);
                totalRows = 0;
                return null;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/07/2017		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_ContactType()
        {
            try
            {
                List<CMS_ContactTypeET> lstCMS_ContactTypeET = new List<CMS_ContactTypeET>();
                DataTable tblCMS_ContactTypeET = GetTableByProcedure("sp_GetAll_CMS_ContactType");
                //for (int i = 0; i < tblCMS_ContactTypeET.Rows.Count; i++)
                //{
                //    lstCMS_ContactTypeET.Add(setProperties(tblCMS_ContactTypeET.Rows[i]));
                //}
                return tblCMS_ContactTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " GetAll_..", ex.Message);
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
        ///Bachdx		12/07/2017Tạo mới
        ///</Modified>
        public CMS_ContactTypeET GetInfo(string intItemID)
        {
            try
            {
                CMS_ContactTypeET objCMS_ContactTypeET = new CMS_ContactTypeET();
                DataTable tblCMS_ContactTypeET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ContactType", Convert.ToInt32(intItemID)))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ContactTypeID"] != DBNull.Value)
                            objCMS_ContactTypeET.ContactTypeID = Convert.ToInt32(oReader["ContactTypeID"]);
                        if (oReader["ContactType"] != DBNull.Value)
                            objCMS_ContactTypeET.ContactType = Convert.ToString(oReader["ContactType"]);
                        if (oReader["ContactTypeEng"] != DBNull.Value)
                            objCMS_ContactTypeET.ContactTypeEng = Convert.ToString(oReader["ContactTypeEng"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_ContactTypeET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_ContactTypeET.UsedState = Convert.ToInt16(oReader["UsedState"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_ContactTypeET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_ContactTypeET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_ContactTypeET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_ContactTypeET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_ContactTypeET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ContactTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/07/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ContactTypeET objCMS_ContactTypeET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ContactType"
                        , objCMS_ContactTypeET.ContactTypeID
                         , objCMS_ContactTypeET.ContactType
                         , objCMS_ContactTypeET.ContactTypeEng
                         , objCMS_ContactTypeET.OrderNumber
                         , objCMS_ContactTypeET.UsedState
                         , objCMS_ContactTypeET.CreatedDate
                         , objCMS_ContactTypeET.CreatedBy
                         , objCMS_ContactTypeET.ModifiedDate
                         , objCMS_ContactTypeET.ModifiedBy))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ContactTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/07/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_ContactTypeET objCMS_ContactTypeET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_ContactType", "ContactTypeID"
                         , objCMS_ContactTypeET.ContactType
                         , objCMS_ContactTypeET.ContactTypeEng
                         , objCMS_ContactTypeET.OrderNumber
                         , objCMS_ContactTypeET.UsedState
                         , objCMS_ContactTypeET.CreatedDate
                         , objCMS_ContactTypeET.CreatedBy
                         , objCMS_ContactTypeET.ModifiedDate
                         , objCMS_ContactTypeET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ContactTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/07/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int ItemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {

                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ContactType", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ContactTypeDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}
