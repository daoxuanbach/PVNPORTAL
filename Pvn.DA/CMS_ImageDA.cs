using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ImageDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        private CMS_ImageET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ImageET objCMS_ImageET = new CMS_ImageET();
                if (oReader["ImageID"] != DBNull.Value)
                    objCMS_ImageET.ImageID = new Guid(Convert.ToString(oReader["ImageID"]));
                if (oReader["ImageCategoryID"] != DBNull.Value)
                    objCMS_ImageET.ImageCategoryID = new Guid(Convert.ToString(oReader["ImageCategoryID"]));
                if (oReader["ImageAlbumID"] != DBNull.Value)
                    objCMS_ImageET.ImageAlbumID = new Guid(Convert.ToString(oReader["ImageAlbumID"]));
                if (oReader["Title"] != DBNull.Value)
                    objCMS_ImageET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Desscription"] != DBNull.Value)
                    objCMS_ImageET.Desscription = Convert.ToString(oReader["Desscription"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_ImageET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_ImageET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMS_ImageET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["PublishedState"] != DBNull.Value)
                    objCMS_ImageET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_ImageET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_ImageET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_ImageET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Author"] != DBNull.Value)
                    objCMS_ImageET.Author = Convert.ToString(oReader["Author"]);
                if (oReader["Reference"] != DBNull.Value)
                    objCMS_ImageET.Reference = Convert.ToString(oReader["Reference"]);
                if (oReader["PublishedDate"] != DBNull.Value)
                    objCMS_ImageET.PublishedDate = Convert.ToDateTime(oReader["PublishedDate"]);
                if (oReader["PublishedBy"] != DBNull.Value)
                    objCMS_ImageET.PublishedBy = Convert.ToInt32(oReader["PublishedBy"]);
                if (oReader["Hits"] != DBNull.Value)
                    objCMS_ImageET.Hits = Convert.ToInt32(oReader["Hits"]);
                if (oReader["TotalRating"] != DBNull.Value)
                    objCMS_ImageET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                if (oReader["TotalMark"] != DBNull.Value)
                    objCMS_ImageET.TotalMark = Convert.ToInt32(oReader["TotalMark"]);
                if (oReader["AvarageMark"] != DBNull.Value)
                    objCMS_ImageET.AvarageMark = Convert.ToInt32(oReader["AvarageMark"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_ImageET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_ImageET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_ImageET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_ImageET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_ImageET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_ImageET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_ImageET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", "setProperties", ex.Message);
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
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageET> GetAll_CMS_Image_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ImageET> lstCMS_ImageET = new List<CMS_ImageET>();
                DataTable tblCMS_ImageET = GetTableByProcedurePaging("sp_CMS_Image_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ImageET.Rows.Count; i++)
                {
                    lstCMS_ImageET.Add(setProperties(tblCMS_ImageET.Rows[i]));
                }
                return lstCMS_ImageET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetAll_.._Paging", ex.Message);
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
                List<CMS_ImageET> lstCMS_ImageET = new List<CMS_ImageET>();
                DataTable tblCMS_ImageET = GetTableByProcedure("sp_GetAll_CMS_Image");
                for (int i = 0; i < tblCMS_ImageET.Rows.Count; i++)
                {
                    lstCMS_ImageET.Add(setProperties(tblCMS_ImageET.Rows[i]));
                }
                return lstCMS_ImageET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetAll_..", ex.Message);
                throw ex;
            }
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
        /// <param name="imageCategoryID"> Chuyên mục ảnh</param>
        /// <param name="title"> Tiêu đề</param>
        /// <param name="desscription"> Mô tả</param>
        /// <param name="language"> Ngôn ngữ</param>
        /// <param name="usedState"> Trạng thái sử dụng</param>
        /// <param name="ratingState"> Trạng thái đáng giá</param>
        /// <param name="publishedState"> Trạng thái xuất bản</param>
        /// <param name="ordinal"> Số thứ tự</param>
        /// <param name="imageURL"> Đường dẫn ảnh</param>
        /// <param name="imageTitle"> Tiêu đề ảnh</param>
        /// <param name="author"> Tác giả</param>
        /// <param name="reference"> Nguồn</param>
        /// <param name="publishedDate"> Ngày xuất bản</param>
        /// <param name="publishedBy"> Người xuất bản</param>
        /// <param name="hits"> Số lần xem</param>
        /// <param name="totalRating"> Tổng đánh giá</param>
        /// <param name="totalMark"> Tổng điểm đáng giá</param>
        /// <param name="avarageMark"> Điểm đáng giá trung bình</param>
        /// <param name="note"> Ghi chú</param>
        /// <param name="createdDate"> Ngày tạo</param>
        /// <param name="createdBy"> Người tạo</param>
        /// <param name="modifiedDate"> Ngày sửa</param>
        /// <param name="modifiedBy"> Người sửa</param>
        /// <returns>DataTable + TotalRows</returns>
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
                    int? ordinal,
                    string imageURL,
                    string imageTitle,
                    string author,
                    string reference,
                    DateTime? publishedDate,
                    int? publishedBy,
                    int? hits,
                    double? totalRating,
                    double? totalMark,
                    double? avarageMark,
                    string note,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            totalRows = 0;
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Image_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    imageCategoryID,
                    title,
                    desscription,
                    language,
                    usedState,
                    ratingState,
                    publishedState,
                    ordinal,
                    imageURL,
                    imageTitle,
                    author,
                    reference,
                    publishedDate,
                    publishedBy,
                    hits,
                    totalRating,
                    totalMark,
                    avarageMark,
                    note,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetSearchPaging..", ex.Message);
                totalRows = 0;
                return null;
            }
        }



        public DataTable GetImageSearchPaging(string language, int startIndex, int rowsInPage, ref int totalRecords, Guid? ImageCategoryID, string title, string description)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_CMS_Image_SearchPaging", language,
                    startIndex, rowsInPage,
                 ImageCategoryID, title, description);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(Convert.ToString(dt.Rows[0]["TotalRows"]));
                }
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }

        public DataSet GetFodelAndImageSearchPaging(string language, int startIndex, int rowsInPage, Guid? ImageCategoryID, string title, string description)
        {
            try
            {
                DataSet dt = GetDatasetByProcedure("sp_Presentation_CMS_Image_SearchPagingEN", language,
                    startIndex, rowsInPage,
                 ImageCategoryID, title, description);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        public DataTable GetImageMain(string language, Guid? cateId, int TotalItems)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_CMS_Image_Main", language, cateId, TotalItems);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
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
                CMS_ImageET objCMS_ImageET = new CMS_ImageET();
                DataTable tblCMS_ImageET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Image", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ImageID"] != DBNull.Value)
                            objCMS_ImageET.ImageID = new Guid(Convert.ToString(oReader["ImageID"]));
                        if (oReader["ImageCategoryID"] != DBNull.Value)
                            objCMS_ImageET.ImageCategoryID = new Guid(Convert.ToString(oReader["ImageCategoryID"]));
                        if (oReader["ImageAlbumID"] != DBNull.Value)
                            objCMS_ImageET.ImageAlbumID = new Guid(Convert.ToString(oReader["ImageAlbumID"]));
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_ImageET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Desscription"] != DBNull.Value)
                            objCMS_ImageET.Desscription = Convert.ToString(oReader["Desscription"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_ImageET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_ImageET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_ImageET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["PublishedState"] != DBNull.Value)
                            objCMS_ImageET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_ImageET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_ImageET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_ImageET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Author"] != DBNull.Value)
                            objCMS_ImageET.Author = Convert.ToString(oReader["Author"]);
                        if (oReader["Reference"] != DBNull.Value)
                            objCMS_ImageET.Reference = Convert.ToString(oReader["Reference"]);
                        if (oReader["PublishedDate"] != DBNull.Value)
                            objCMS_ImageET.PublishedDate = Convert.ToDateTime(oReader["PublishedDate"]);
                        if (oReader["PublishedBy"] != DBNull.Value)
                            objCMS_ImageET.PublishedBy = Convert.ToInt32(oReader["PublishedBy"]);
                        if (oReader["Hits"] != DBNull.Value)
                            objCMS_ImageET.Hits = Convert.ToInt32(oReader["Hits"]);
                        if (oReader["TotalRating"] != DBNull.Value)
                            objCMS_ImageET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                        if (oReader["TotalMark"] != DBNull.Value)
                            objCMS_ImageET.TotalMark = Convert.ToInt32(oReader["TotalMark"]);
                        if (oReader["AvarageMark"] != DBNull.Value)
                            objCMS_ImageET.AvarageMark = Convert.ToInt32(oReader["AvarageMark"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_ImageET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_ImageET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_ImageET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_ImageET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_ImageET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_ImageET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_ImageET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ImageET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ImageET objCMS_ImageET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Image"
                        , objCMS_ImageET.ImageID
                        , objCMS_ImageET.ImageCategoryID
                        , objCMS_ImageET.Title
                        , objCMS_ImageET.Desscription
                        , objCMS_ImageET.Language
                        , objCMS_ImageET.UsedState
                        , objCMS_ImageET.RatingState
                        , objCMS_ImageET.PublishedState
                        , objCMS_ImageET.Ordinal
                        , objCMS_ImageET.ImageURL
                        , objCMS_ImageET.ImageTitle
                        , objCMS_ImageET.Author
                        , objCMS_ImageET.Reference
                        , objCMS_ImageET.PublishedDate
                        , objCMS_ImageET.PublishedBy
                        , objCMS_ImageET.Hits
                        , objCMS_ImageET.TotalRating
                        , objCMS_ImageET.TotalMark
                        , objCMS_ImageET.AvarageMark
                        , objCMS_ImageET.Note
                        , objCMS_ImageET.CreatedDate
                        , objCMS_ImageET.CreatedBy
                        , objCMS_ImageET.ModifiedDate
                        , objCMS_ImageET.ModifiedBy
                 ))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
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
                ExecuteNonQueryOutToGuid("sp_Add_CMS_Image", "ImageID"
                         , objCMS_ImageET.ImageCategoryID
                         , objCMS_ImageET.Title
                         , objCMS_ImageET.Desscription
                         , objCMS_ImageET.Language
                         , objCMS_ImageET.UsedState
                         , objCMS_ImageET.RatingState
                         , objCMS_ImageET.PublishedState
                         , objCMS_ImageET.Ordinal
                         , objCMS_ImageET.ImageURL
                         , objCMS_ImageET.ImageTitle
                         , objCMS_ImageET.Author
                         , objCMS_ImageET.Reference
                         , objCMS_ImageET.PublishedDate
                         , objCMS_ImageET.PublishedBy
                         , objCMS_ImageET.Hits
                         , objCMS_ImageET.TotalRating
                         , objCMS_ImageET.TotalMark
                         , objCMS_ImageET.AvarageMark
                         , objCMS_ImageET.Note
                         , objCMS_ImageET.CreatedDate
                         , objCMS_ImageET.CreatedBy
                         , objCMS_ImageET.ModifiedDate
                         , objCMS_ImageET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " Insert", ex.Message);
                return false;
            }
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
                ExecuteNonQuery("sp_RemoveByPK_CMS_Image", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " Delete", ex.Message);
                return false;
            }
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
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Image", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

        
    }
}
