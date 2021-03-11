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
    public class CMS_MenuBL
    {
        #region Biến + thuộc tính
        CMS_MenuDA objDA;
        public CMS_MenuBL()
        {
            objDA = new CMS_MenuDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_MenuET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_MenuET objCMS_MenuET)
        {
            try
            {
                return objDA.Insert(objCMS_MenuET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_MenuET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Update(CMS_MenuET objCMS_MenuET)
        {
            try
            {
                return objDA.Update(objCMS_MenuET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_MenuET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016		Tạo mới
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
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public List<CMS_MenuET> GetAll_CMS_Menu_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMS_Menu_Paging(p_search, page, rownum, out totalRows);
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
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public List<CMS_MenuET> GetAll_CMS_Menu()
        {
            try
            {
                return objDA.GetAll_CMS_Menu();
            }
            catch (Exception ex)
            {
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
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public CMS_MenuET GetInfo(Guid intItemID)
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
        #endregion Function

        public DataTable GetTreeByLanguagePosition(string language, int position, bool recursive, Guid? parentMenuID)
        {
            return objDA.GetTreeByLanguagePosition(language,
                        position,//Top
                        recursive,//No Recursive
                        parentMenuID);
        }

        public List<CMS_MenuET> GetTree(string curentLanguage, string Language, int Position)
        {
            return objDA.GetTree(curentLanguage,
                        Language,//Top
                        Position);
        }

        /// <summary>
        /// Search + Paging + Sort 
        /// </summary>
        /// <param name="currentLanguage">"vi-VN"</param>
        /// <param name="orderByColumn">
        ///  "[CreatedDate]" 
        ///  "[CreatedDate] DESC" 
        ///</param>
        /// <param name="pageIndex">0</param>
        /// <param name="rowsInPage">20</param>
        /// <param name="totalRows"></param>
        /// <param name="code"> Code</param>
        /// <param name="title"> Title</param>
        /// <param name="summary"> Summary</param>
        /// <param name="usedState"> UsedState</param>
        /// <param name="menuPosition"> MenuPosition</param>
        /// <param name="dataAccess"> DataAccess</param>
        /// <param name="language"> Language</param>
        /// <param name="parentMenuID"> ParentMenuID</param>
        /// <param name="ordinal"> Ordinal</param>
        /// <param name="ojectType"> ObjectType</param>
        /// <param name="ojectID"> ObjectID</param>
        /// <param name="url"> URL</param>
        /// <param name="imageURL"> ImageURL</param>
        /// <param name="imageTitle"> ImageTitle</param>
        /// <param name="note"> Note</param>
        /// <param name="createdDateFrom"> CreatedDate</param>
        /// <param name="createdBy"> CreatedBy</param>
        /// <param name="createdDateTo"> ModifiedDate</param>
        /// <param name="modifiedBy"> ModifiedBy</param>
        /// <returns>DataTable + TotalRows</returns>
        /// <remarks>
        ///     1.MenuList.Grid
        /// </remarks>
        public DataTable GetSearchPaging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    ref int totalRows,
                    string code,
                    string title,
                    string summary,
                    short? usedState,
                    short? menuPosition,
                    short? dataAccess,
                    string language,
                    Guid? parentMenuID,
                    int? ordinal,
                    string ojectType,
                    Guid? ojectID,
                    string url,
                    string imageURL,
                    string imageTitle,
                    string note,
                    DateTime? createdDateFrom,
                    int? createdBy,
                    DateTime? createdDateTo,
                    int? modifiedBy)
        {
            DataTable dt;
            try
            {

                return objDA.GetSearchPaging(
                        currentLanguage,
                        orderByColumn,
                        pageIndex,
                        rowsInPage,
                        ref totalRows,
                        code,//Mã chuyên mục
                        title,//Tiêu đề chuyên mục
                        summary,//Tóm tắt của chuyên mục
                        usedState,//Trạng thái sử dụng
                        menuPosition,//MenuPosition
                        dataAccess,//DataAccess,//Trạng thái truy nhập dữ liệu
                        language,//Ngôn ngữ sử dụng
                        parentMenuID,//Chuyên mục cha
                        ordinal,//Số thứ tự hiển thị trong chuyên mục cha
                        ojectType,//ObjectType
                        ojectID,//ObjectID
                        url,//URL
                        imageURL,//Ảnh hiển thị
                        imageTitle,//Tiêu đề ảnh hiển thị
                        note,//Note
                        createdDateFrom,//Ngày tạo
                        createdBy,//Người tạo
                        createdDateTo,//Ngày sửa
                        modifiedBy);
            }
            catch (Exception ex)
            {
                totalRows = 0;
                return null;
            }
        }


        public DataTable GetMenuBreadCumb(Guid? CategoryID, int MenuType)
        {
            return objDA.GetMenuBreadCumb(CategoryID, MenuType);
        }
    }
}

