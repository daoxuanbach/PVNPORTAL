using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using System.Data;
using Pvn.Utils;
namespace Pvn.BL
{
    public class CMS_NewsBL
    {
        #region Biến + thuộc tính
        CMS_NewsDA objDA;
        public CMS_NewsBL()
        {
            objDA = new CMS_NewsDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_NewsET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_NewsET objCMS_NewsET)
        {
            try
            {
                return objDA.Insert(objCMS_NewsET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_NewsET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_NewsET objCMS_NewsET)
        {
            return objDA.Update(objCMS_NewsET);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_NewsET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            return objDA.Delete(GuidID);
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
        ///Bachdx		08/06/2016		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_News_Paging(string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    int userID,
                    short catPublishedType,
                    Guid? categoryID,
                    short? dataAccess,
                    short? ratingState,
                    short? newsState,
                    string title,
                    string summary,
                    string language,
                    string author,
                    string reference,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            try
            {
                return objDA.GetAll_CMS_News_Paging(currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    out totalRows,
                    userID,
                    catPublishedType,
                    categoryID,
                    1,
                    dataAccess,
                    ratingState,
                    newsState,
                    null,
                    null,
                    title,
                    summary,
                    language,
                    null,
                    author,
                    reference,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016		Tạo mới
        ///</Modified>
        public List<CMS_NewsET> GetAll_CMS_News()
        {
            try
            {
                return objDA.GetAll_CMS_News();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNewsWithPaging(string language, int pageIndex, int rowsInPage, ref int totalRecords,
            Guid? categoryID)
        {
            return objDA.GetNewsWithPaging(language,
                    pageIndex,
                    rowsInPage,
                    ref totalRecords,
                    categoryID);
        }

        public DataTable GetOtherRelatedNews(string CurrentLanguage, int TotalNews, Guid? NewsID)
        {
            return objDA.GetOtherRelatedNews(CurrentLanguage,
                    TotalNews,
                    NewsID);
        }
        public DataTable GetOtherNewsInCate(string CurrentLanguage, int TotalNews, Guid? NewsID)
        {
            return objDA.GetOtherNewsInCate(CurrentLanguage,
                    TotalNews,
                    NewsID);
        }
        
        public DataTable GetNewsMain(string language, int TotalNews, int PriorityPublishing, Guid? categoryID)
        {
            return objDA.GetNewsMain(language,
                TotalNews,
                    PriorityPublishing,
                    categoryID);
        }
        
        /// <summary>
        /// Get all news detail data
        /// </summary>
        /// <param name="inputParameter"></param>
        /// <returns></returns>
        public DataSet GetNewsDetailData(string language, int numberMain, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            return objDA.GetNewsDetailData(language, numberMain, newsID, numberNewsOther, numberTimeline, ref categoryName);
        }

        public DataSet GetNewsDetailData_2(string language, int numberMain, Guid? CateID, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            return objDA.GetNewsDetailData_2(language, numberMain, CateID,newsID, numberNewsOther, numberTimeline, ref categoryName);
        }
        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016Tạo mới
        ///</Modified>
        public CMS_NewsET GetInfo(Guid intItemID)
        {
            try
            {
                return objDA.GetInfo(intItemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetListTopNews(string Language, int TotalNews, int NewsPriority, int OtherTotalNews, int OtherNewsPriority, Guid? nullable)
        {
            return objDA.GetListTopNews(Language,  TotalNews,  NewsPriority,  OtherTotalNews ,OtherNewsPriority,  nullable);
        }
        #endregion Function





      
    }
}

