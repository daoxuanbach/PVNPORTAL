using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_VideoDA : Pvn.DA.DataProvider
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
        private CMS_VideoET setProperties(DataRow oReader)
        {
            try
            {
                CMS_VideoET objCMS_VideoET = new CMS_VideoET();
                if (oReader["VideoID"] != DBNull.Value)
                    objCMS_VideoET.VideoID = new Guid(Convert.ToString(oReader["VideoID"]));
                if (oReader["VideoCategoryID"] != DBNull.Value)
                    objCMS_VideoET.VideoCategoryID = new Guid(Convert.ToString(oReader["VideoCategoryID"]));
                if (oReader["Title"] != DBNull.Value)
                    objCMS_VideoET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Desscription"] != DBNull.Value)
                    objCMS_VideoET.Desscription = Convert.ToString(oReader["Desscription"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_VideoET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_VideoET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMS_VideoET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["PublishedState"] != DBNull.Value)
                    objCMS_VideoET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_VideoET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["VideoURL"] != DBNull.Value)
                    objCMS_VideoET.VideoURL = Convert.ToString(oReader["VideoURL"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_VideoET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_VideoET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Author"] != DBNull.Value)
                    objCMS_VideoET.Author = Convert.ToString(oReader["Author"]);
                if (oReader["Reference"] != DBNull.Value)
                    objCMS_VideoET.Reference = Convert.ToString(oReader["Reference"]);
                if (oReader["PublishedDate"] != DBNull.Value)
                    objCMS_VideoET.PublishedDate = Convert.ToDateTime(oReader["PublishedDate"]);
                if (oReader["PublishedBy"] != DBNull.Value)
                    objCMS_VideoET.PublishedBy = Convert.ToInt32(oReader["PublishedBy"]);
                if (oReader["Hits"] != DBNull.Value)
                    objCMS_VideoET.Hits = Convert.ToInt32(oReader["Hits"]);
                if (oReader["TotalRating"] != DBNull.Value)
                    objCMS_VideoET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                if (oReader["TotalMark"] != DBNull.Value)
                    objCMS_VideoET.TotalMark = Convert.ToInt32(oReader["TotalMark"]);
                if (oReader["AvarageMark"] != DBNull.Value)
                    objCMS_VideoET.AvarageMark = Convert.ToInt32(oReader["AvarageMark"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_VideoET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_VideoET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_VideoET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_VideoET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_VideoET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_VideoET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_VideoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", "setProperties", ex.Message);
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
        public List<CMS_VideoET> GetAll_CMS_Video_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_VideoET> lstCMS_VideoET = new List<CMS_VideoET>();
                DataTable tblCMS_VideoET = GetTableByProcedurePaging("sp_CMS_Video_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_VideoET.Rows.Count; i++)
                {
                    lstCMS_VideoET.Add(setProperties(tblCMS_VideoET.Rows[i]));
                }
                return lstCMS_VideoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " GetAll_.._Paging", ex.Message);
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
        public DataTable GetSearchPaging(string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    Guid? videoCategoryID,
                    string title,
                    string desscription,
                    string language,
                    short? usedState,
                    short? ratingState,
                    short? publishedState,
                    int? ordinal,
                    string videoURL,
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
                dt = GetTableByProcedure("sp_CMS_Video_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    videoCategoryID,
                    title,
                    desscription,
                    language,
                    usedState,
                    ratingState,
                    publishedState,
                    ordinal,
                    videoURL,
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

        public DataTable GetVideoSearchPaging(string language, int startIndex, int rowsInPage, ref int totalRecords, Guid? videoCategoryID, string title, string description)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_CMS_Video_SearchPaging", language, startIndex, rowsInPage,
                 videoCategoryID, title, description);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(Convert.ToString(dt.Rows[0]["TotalRows"]));
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetVideoSearchPaging..", ex.Message);
                totalRecords = 0;
                return null;
            }
        }
        public DataTable GetVideoMain(string language, Guid? videoCategoryID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_CMS_Video_Main", language, videoCategoryID);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetVideoMain..", ex.Message);
                return null;
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
        public List<CMS_VideoET> GetAll_CMS_Video()
        {
            try
            {
                List<CMS_VideoET> lstCMS_VideoET = new List<CMS_VideoET>();
                DataTable tblCMS_VideoET = GetTableByProcedure("sp_GetAll_CMS_Video");
                for (int i = 0; i < tblCMS_VideoET.Rows.Count; i++)
                {
                    lstCMS_VideoET.Add(setProperties(tblCMS_VideoET.Rows[i]));
                }
                return lstCMS_VideoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " GetAll_..", ex.Message);
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
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public CMS_VideoET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_VideoET objCMS_VideoET = new CMS_VideoET();
                DataTable tblCMS_VideoET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Video", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["VideoID"] != DBNull.Value)
                            objCMS_VideoET.VideoID = new Guid(Convert.ToString(oReader["VideoID"]));
                        if (oReader["VideoCategoryID"] != DBNull.Value)
                            objCMS_VideoET.VideoCategoryID = new Guid(Convert.ToString(oReader["VideoCategoryID"]));
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_VideoET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Desscription"] != DBNull.Value)
                            objCMS_VideoET.Desscription = Convert.ToString(oReader["Desscription"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_VideoET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_VideoET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_VideoET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["PublishedState"] != DBNull.Value)
                            objCMS_VideoET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_VideoET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["VideoURL"] != DBNull.Value)
                            objCMS_VideoET.VideoURL = Convert.ToString(oReader["VideoURL"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_VideoET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_VideoET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Author"] != DBNull.Value)
                            objCMS_VideoET.Author = Convert.ToString(oReader["Author"]);
                        if (oReader["Reference"] != DBNull.Value)
                            objCMS_VideoET.Reference = Convert.ToString(oReader["Reference"]);
                        if (oReader["PublishedDate"] != DBNull.Value)
                            objCMS_VideoET.PublishedDate = Convert.ToDateTime(oReader["PublishedDate"]);
                        if (oReader["PublishedBy"] != DBNull.Value)
                            objCMS_VideoET.PublishedBy = Convert.ToInt32(oReader["PublishedBy"]);
                        if (oReader["Hits"] != DBNull.Value)
                            objCMS_VideoET.Hits = Convert.ToInt32(oReader["Hits"]);
                        if (oReader["TotalRating"] != DBNull.Value)
                            objCMS_VideoET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                        if (oReader["TotalMark"] != DBNull.Value)
                            objCMS_VideoET.TotalMark = Convert.ToInt32(oReader["TotalMark"]);
                        if (oReader["AvarageMark"] != DBNull.Value)
                            objCMS_VideoET.AvarageMark = Convert.ToInt32(oReader["AvarageMark"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_VideoET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_VideoET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_VideoET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_VideoET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_VideoET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_VideoET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_VideoET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " GetInfo", ex.Message);
                throw ex;
            }
        }

        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_VideoET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_VideoET objCMS_VideoET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Video"
                        , objCMS_VideoET.VideoID
                        , objCMS_VideoET.VideoCategoryID
                        , objCMS_VideoET.Title
                        , objCMS_VideoET.Desscription
                        , objCMS_VideoET.Language
                        , objCMS_VideoET.UsedState
                        , objCMS_VideoET.RatingState
                        , objCMS_VideoET.PublishedState
                        , objCMS_VideoET.Ordinal
                        , objCMS_VideoET.VideoURL
                        , objCMS_VideoET.ImageURL
                        , objCMS_VideoET.ImageTitle
                        , objCMS_VideoET.Author
                        , objCMS_VideoET.Reference
                        , objCMS_VideoET.PublishedDate
                        , objCMS_VideoET.PublishedBy
                        , objCMS_VideoET.Hits
                        , objCMS_VideoET.TotalRating
                        , objCMS_VideoET.TotalMark
                        , objCMS_VideoET.AvarageMark
                        , objCMS_VideoET.Note
                       // , objCMS_VideoET.PortalID
                        , objCMS_VideoET.CreatedDate
                        , objCMS_VideoET.CreatedBy
                        , objCMS_VideoET.ModifiedDate
                        , objCMS_VideoET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_VideoET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_VideoET objCMS_VideoET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_Video", "VideoID"
                         , objCMS_VideoET.VideoCategoryID
                         , objCMS_VideoET.Title
                         , objCMS_VideoET.Desscription
                         , objCMS_VideoET.Language
                         , objCMS_VideoET.UsedState
                         , objCMS_VideoET.RatingState
                         , objCMS_VideoET.PublishedState
                         , objCMS_VideoET.Ordinal
                         , objCMS_VideoET.VideoURL
                         , objCMS_VideoET.ImageURL
                         , objCMS_VideoET.ImageTitle
                         , objCMS_VideoET.Author
                         , objCMS_VideoET.Reference
                         , objCMS_VideoET.PublishedDate
                         , objCMS_VideoET.PublishedBy
                         , objCMS_VideoET.Hits
                         , objCMS_VideoET.TotalRating
                         , objCMS_VideoET.TotalMark
                         , objCMS_VideoET.AvarageMark
                         , objCMS_VideoET.Note
                         //, objCMS_VideoET.PortalID
                         , objCMS_VideoET.CreatedDate
                         , objCMS_VideoET.CreatedBy
                         , objCMS_VideoET.ModifiedDate
                         , objCMS_VideoET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		07/09/2016		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_CMS_Video", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Video", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

       
    }
}

