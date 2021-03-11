using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_CategoryDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016		Tạo mới
        ///</Modified>
        private CMS_CategoryET setProperties(DataRow oReader)
        {
            try
            {
                CMS_CategoryET objCMS_CategoryET = new CMS_CategoryET();
                if (oReader["CategoryID"] != DBNull.Value)
                    objCMS_CategoryET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                if (oReader.Table.Columns.Contains("TotalRows") && oReader["TotalRows"] != DBNull.Value)
                    objCMS_CategoryET.TotalRows = Convert.ToInt32(oReader["TotalRows"]);

                if (oReader["Code"] != DBNull.Value)
                    objCMS_CategoryET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_CategoryET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Summary"] != DBNull.Value)
                    objCMS_CategoryET.Summary = Convert.ToString(oReader["Summary"]);
                if (oReader.Table.Columns.Contains("Information") && oReader["Information"] != DBNull.Value)
                    objCMS_CategoryET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_CategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader.Table.Columns.Contains("CMSDataType") && oReader["CMSDataType"] != DBNull.Value)
                    objCMS_CategoryET.CMSDataType = Convert.ToInt32(oReader["CMSDataType"]);
                if (oReader.Table.Columns.Contains("CatPublishedType") && oReader["CatPublishedType"] != DBNull.Value)
                    objCMS_CategoryET.CatPublishedType = Convert.ToInt32(oReader["CatPublishedType"]);
                if (oReader.Table.Columns.Contains("RatingState") && oReader["RatingState"] != DBNull.Value)
                    objCMS_CategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["DataAccess"] != DBNull.Value)
                    objCMS_CategoryET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                if (oReader["ParentCategoryID"] != DBNull.Value)
                    objCMS_CategoryET.ParentCategoryID = new Guid(Convert.ToString(oReader["ParentCategoryID"]));
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_CategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["URL"] != DBNull.Value)
                    objCMS_CategoryET.URL = Convert.ToString(oReader["URL"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_CategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_CategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_CategoryET.Language = Convert.ToString(oReader["Language"]);
                if (oReader.Table.Columns.Contains("PortalID") && oReader["PortalID"] != DBNull.Value)
                    objCMS_CategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_CategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_CategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_CategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_CategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_CategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", "setProperties", ex.Message);
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
        ///Bachdx		19/05/2016		Tạo mới
        ///</Modified>
        public List<CMS_CategoryET> GetAll_CMS_Category_Paging(string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    string code,
                    string title,
                    string summary,
                    int? usedState,
                    int? catPublishedType,
                    int? ratingState,
                    int? dataAccess,
                    Guid? parentCategoryID,
                    int? ordinal,
                    string url,
                    string imageURL,
                    string imageTitle,
                    string language,
                    DateTime? createdDateFrom,
                    int? userID,
                    DateTime? createdDateTo,
                    int? modifiedBy)
        {
            try
            {
                totalRows = 0;
                List<CMS_CategoryET> lstCMS_CategoryET = new List<CMS_CategoryET>();
                DataTable tblCMS_CategoryET = GetTableByProcedurePaging("sp_CMS_Category_SearchPaging", new object[] {
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    code,
                    title,
                    summary,
                    usedState,
                    catPublishedType,
                    ratingState,
                    dataAccess,
                    parentCategoryID,
                    ordinal,
                    url,
                    imageURL,
                    imageTitle,
                    language,
                    createdDateFrom,
                    userID,
                    createdDateTo,
                    modifiedBy}, out totalRows);
                totalRows = 0;
                for (int i = 0; i < tblCMS_CategoryET.Rows.Count; i++)
                {
                    lstCMS_CategoryET.Add(setProperties(tblCMS_CategoryET.Rows[i]));
                }
                if (lstCMS_CategoryET != null && lstCMS_CategoryET.Count > 0)
                {
                    totalRows = lstCMS_CategoryET.FirstOrDefault().TotalRows;
                }
                return lstCMS_CategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016		Tạo mới
        ///</Modified>
        public List<CMS_CategoryET> GetAll_CMS_Category()
        {
            try
            {
                List<CMS_CategoryET> lstCMS_CategoryET = new List<CMS_CategoryET>();
                DataTable tblCMS_CategoryET = GetTableByProcedure("sp_GetAll_CMS_Category");
                for (int i = 0; i < tblCMS_CategoryET.Rows.Count; i++)
                {
                    lstCMS_CategoryET.Add(setProperties(tblCMS_CategoryET.Rows[i]));
                }
                return lstCMS_CategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public DataTable GetTreeAdmin_UsedState(string currentLanguage, string language, Guid? parentCategoryID, int UsedState)
        {
            try
            {
                DataTable tblCMS_CategoryET = GetTableByProcedure("sp_CMS_Category_Tree_UsedState", new object[] { currentLanguage, language, parentCategoryID, UsedState });
                return tblCMS_CategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public DataTable GetTree(string currentLanguage, string language, Guid? parentCategoryID)
        {
            try
            {
                DataTable tblCMS_CategoryET = GetTableByProcedure("sp_CMS_Category_Tree", new object[] { currentLanguage, language, parentCategoryID });
                return tblCMS_CategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Cay menu tu mot goc cu the
        /// </summary>
        /// <param name="language">Ngon ngu</param>
        /// <param name="recursive">De quy</param>
        /// <param name="parentMenuID">Goc</param>
        /// <returns></returns>
        public DataTable GetTreeByLanguage(string language, bool recursive, Guid? parentMenuID)
        {
            try
            {
                return GetTableByProcedure("sp_Presentation_Category_GetTree", language, recursive, parentMenuID);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetTreeByLanguage..", ex.Message);
                throw ex;
            }
        }
        public DataTable GetMenuBreadCumb(string currentLanguage, Guid? categoryID, int menuType)
        {
            return GetTableByProcedure("sp_Presentation_MenuBreadCumbByType", currentLanguage, categoryID, menuType);
        }
        public DataTable GetBreadCumbNews(Guid? categoryID, Guid? newsPublishingID, string urlPath)
        {
            return GetTableByProcedure("sp_Presentation_MenuBreadCumb", categoryID, newsPublishingID, urlPath);
        }

        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016Tạo mới
        ///</Modified>
        public CMS_CategoryET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_CategoryET objCMS_CategoryET = new CMS_CategoryET();
                DataTable tblCMS_CategoryET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Category", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["CategoryID"] != DBNull.Value)
                            objCMS_CategoryET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                        if (oReader["Code"] != DBNull.Value)
                            objCMS_CategoryET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_CategoryET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Summary"] != DBNull.Value)
                            objCMS_CategoryET.Summary = Convert.ToString(oReader["Summary"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_CategoryET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_CategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["CMSDataType"] != DBNull.Value)
                            objCMS_CategoryET.CMSDataType = Convert.ToInt32(oReader["CMSDataType"]);
                        if (oReader["CatPublishedType"] != DBNull.Value)
                            objCMS_CategoryET.CatPublishedType = Convert.ToInt32(oReader["CatPublishedType"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_CategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["DataAccess"] != DBNull.Value)
                            objCMS_CategoryET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                        if (oReader["ParentCategoryID"] != DBNull.Value)
                            objCMS_CategoryET.ParentCategoryID = new Guid(Convert.ToString(oReader["ParentCategoryID"]));
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_CategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["URL"] != DBNull.Value)
                            objCMS_CategoryET.URL = Convert.ToString(oReader["URL"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_CategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_CategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_CategoryET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_CategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_CategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_CategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_CategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_CategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_CategoryET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_CategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016Tạo mới
        ///</Modified>
        public bool Update(CMS_CategoryET objCMS_CategoryET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_CMS_Category"
                         , objCMS_CategoryET.CategoryID
                         , objCMS_CategoryET.Code
                         , objCMS_CategoryET.Title
                         , objCMS_CategoryET.Summary
                         , objCMS_CategoryET.Information
                         , objCMS_CategoryET.UsedState
                         //, objCMS_CategoryET.CMSDataType
                         , objCMS_CategoryET.CatPublishedType
                         , objCMS_CategoryET.RatingState
                         , objCMS_CategoryET.DataAccess
                         , objCMS_CategoryET.ParentCategoryID
                         , objCMS_CategoryET.Ordinal
                         , objCMS_CategoryET.URL
                         , objCMS_CategoryET.ImageURL
                         , objCMS_CategoryET.ImageTitle
                         , objCMS_CategoryET.Language
                         //, objCMS_CategoryET.PortalID
                         , objCMS_CategoryET.CreatedDate
                         , objCMS_CategoryET.CreatedBy
                         , objCMS_CategoryET.ModifiedDate
                         , objCMS_CategoryET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_CategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_CategoryET objCMS_CategoryET)
        {
            try
            {
                string Message =
                ExecuteNonQueryOutToGuid("sp_Add_CMS_Category", "CategoryID"
                         , objCMS_CategoryET.Code
                         , objCMS_CategoryET.Title
                         , objCMS_CategoryET.Summary
                         , objCMS_CategoryET.Information
                         , objCMS_CategoryET.UsedState
                         // , objCMS_CategoryET.CMSDataType
                         , objCMS_CategoryET.CatPublishedType
                         , objCMS_CategoryET.RatingState
                         , objCMS_CategoryET.DataAccess
                         , objCMS_CategoryET.ParentCategoryID
                         , objCMS_CategoryET.Ordinal
                         , objCMS_CategoryET.URL
                         , objCMS_CategoryET.ImageURL
                         , objCMS_CategoryET.ImageTitle
                         , objCMS_CategoryET.Language
                         //, objCMS_CategoryET.PortalID
                         , objCMS_CategoryET.CreatedDate
                         , objCMS_CategoryET.CreatedBy
                         , objCMS_CategoryET.ModifiedDate
                         , objCMS_CategoryET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_CategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		19/05/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();

            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Category", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

