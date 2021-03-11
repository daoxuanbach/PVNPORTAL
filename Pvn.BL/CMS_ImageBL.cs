using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.Utils;
using Pvn.DA;
using System.Data;
namespace Pvn.BL
{
    public class CMS_ImageBL
    {
        #region Biến + thuộc tính
        CMS_ImageDA objDA;
        public CMS_ImageBL()
        {
            objDA = new CMS_ImageDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ImageET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_ImageET objCMS_ImageET)
        {
            try
            {
                return objDA.Insert(objCMS_ImageET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ImageET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ImageET objCMS_ImageET)
        {
            return objDA.Update(objCMS_ImageET);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ImageET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                return objDA.Delete(GuidID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ImageET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            return objDA.DeleteOutMesage(GuidID);
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
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageET> GetAll_CMS_Image_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMS_Image_Paging(p_search, page, rownum, out totalRows);
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
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageET> GetAll_CMS_Image()
        {
            try
            {
                return objDA.GetAll_CMS_Image();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    Guid? imageCategoryID,
                    string title,
                    string desscription,
                    string language,
                    short? usedState,
                    short? ratingState,
                    short? publishedState,
                    string author,
                    string reference,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            return objDA.GetSearchPaging(
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    out totalRows,
                    imageCategoryID,//Tiêu đề
                    title,//Mô tả
                    desscription,//Ngôn ngữ
                    language,//Trạng thái sử dụng
                    usedState,//Trạng thái đáng giá
                    ratingState,//Trạng thái xuất bản
                    publishedState,//Số thứ tự
                    null,//Đường dẫn ảnh
                    string.Empty,//Tiêu đề ảnh
                    string.Empty,//Tác giả
                    author,//Nguồn
                    reference,//Ngày xuất bản
                    null,//Người xuất bản
                    null,//Số lần xem
                    null,//Tổng đánh giá
                    null,//Tổng điểm đáng giá
                    null,//Điểm đáng giá trung bình
                    null,//Ghi chú
                    string.Empty,//Ngày tạo
                    createdBy,//Người tạo
                    modifiedBy,//Ngày sửa
                    createdDateFrom,//Người sửa
                    createdDateTo);
        }
        public DataTable GetImageSearchPaging(string language, int startIndex, int rowsInPage, ref int totalRecords, Guid? ImageCategoryID, string title, string description)
        {
            return objDA.GetImageSearchPaging(language, startIndex, rowsInPage, ref  totalRecords, ImageCategoryID, title, description);
        }

        public DataTable GetImageMain(string language, Guid? cateId, int TotalItems)
        {
            return objDA.GetImageMain(language, cateId, TotalItems);
        }
        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public CMS_ImageET GetInfo(Guid intItemID)
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



        
    }
}

