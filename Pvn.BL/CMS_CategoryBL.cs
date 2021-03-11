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
	public class CMS_CategoryBL
	{
	#region Biến + thuộc tính
	 CMS_CategoryDA objDA;
	public CMS_CategoryBL()
	{
	   objDA = new CMS_CategoryDA();
	}
	#endregion
	#region Function
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
			return objDA.Insert(objCMS_CategoryET);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryBL", "Insert", ex.Message);
                return false;
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
			return objDA.Update(objCMS_CategoryET);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryBL", "Update", ex.Message);
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
		///Bachdx		19/05/2016		Tạo mới
		///</Modified>
        public List<CMS_CategoryET> GetAll_CMS_Category_Paging(string currentLanguage,
                  string orderByColumn,
                  int pageIndex,
                  int rowsInPage,
                  out long totalRows,
                  string code,
                  string title,
                  int? usedstate,
                  int? catPublishedType,
                  int? ratingState,
                  Guid? parentCategoryID,
                  string language,
                  DateTime? createdDateFrom,
                  DateTime? createdDateTo,
                  int userID)
		{
			try
			{
                return objDA.GetAll_CMS_Category_Paging(currentLanguage,
                      orderByColumn,
                        pageIndex,
                        rowsInPage,
                        out totalRows,
                        code,//Code
                       title,//Title
                       string.Empty,//Summary
                       usedstate,//UsedState
                       catPublishedType,//CatPublishedType
                       ratingState,//RatingState
                       null,//DataAccess
                       parentCategoryID,//ParentCategoryID
                       null,//Ordinal
                       string.Empty,//URL
                       string.Empty,//ImageURL
                       string.Empty,//ImageTitle
                       language,//Language
                       createdDateFrom,//CreatedDateFrom
                       userID,//UserID
                       createdDateTo,//CreatedDateTo
                       null);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryBL", "GetAll_CMS_Category_Paging", ex.Message);
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
			return objDA.GetAll_CMS_Category();			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryBL", "GetAll_CMS_Category", ex.Message);
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
        public List<CMS_CategoryET> GetTree()
        {
            try
            {
                return objDA.GetAll_CMS_Category();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Category to tree
        /// </summary>
        /// <returns>List of category by tree</returns>
        /// <remarks>
        ///     
        ///     2.CategoryList.ComboBox
        ///     3.CategoryEdit.ComboBox
        ///     4.UserCategoryList.ComboBox
        ///     5.UserCategoryNew.ComboBox
        ///     6.CategoryWorkflowTemplateList
        ///     7.AdvertisementList.ComboBox
        ///     8.AdvertisementEdit.ComboBox
        ///     9.GroupCategoryList.ComboBox
        /// </remarks>
        public DataTable GetTree(string currentLanguage, string language)
        {
            return objDA.GetTree(currentLanguage, language, null);
        }

        public DataTable GetTreeByLanguage(string currentLanguage, bool recursive, Guid? parentMenuID)
        {
            return objDA.GetTreeByLanguage(currentLanguage, recursive, parentMenuID);
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
			  return objDA.GetInfo(intItemID);
		 }
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_CategoryBL", "GetInfo", ex.Message);
                return null;
			}
		}
	#endregion Function

      
    }
}

