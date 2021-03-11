using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_NewsDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		08/06/2016		Tạo mới
        ///</Modified>
        private CMS_NewsET setProperties(DataRow oReader)
        {
            try
            {
                CMS_NewsET objCMS_NewsET = new CMS_NewsET();
                if (oReader["NewsID"] != DBNull.Value)
                    objCMS_NewsET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                if (oReader["CategoryID"] != DBNull.Value)
                    objCMS_NewsET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                if (oReader.Table.Columns.Contains("NewsAutoID") && oReader["NewsAutoID"] != DBNull.Value)
                    objCMS_NewsET.NewsAutoID = Convert.ToInt64(oReader["NewsAutoID"]);
                if (oReader["NewsSPID"] != DBNull.Value)
                    objCMS_NewsET.NewsSPID = Convert.ToInt64(oReader["NewsSPID"]);
                if (oReader["NewsUsedState"] != DBNull.Value)
                    objCMS_NewsET.NewsUsedState = Convert.ToInt32(oReader["NewsUsedState"]);
                if (oReader["DataAccess"] != DBNull.Value)
                    objCMS_NewsET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMS_NewsET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["NewsState"] != DBNull.Value)
                    objCMS_NewsET.NewsState = Convert.ToInt32(oReader["NewsState"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_NewsET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["Version"] != DBNull.Value)
                    objCMS_NewsET.Version = Convert.ToInt32(oReader["Version"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_NewsET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["TitleNoSign"] != DBNull.Value)
                    objCMS_NewsET.TitleNoSign = Convert.ToString(oReader["TitleNoSign"]);
                if (oReader["PageURL"] != DBNull.Value)
                    objCMS_NewsET.PageURL = Convert.ToString(oReader["PageURL"]);
                if (oReader["Summary"] != DBNull.Value)
                    objCMS_NewsET.Summary = Convert.ToString(oReader["Summary"]);
                if (oReader["SummaryNoSign"] != DBNull.Value)
                    objCMS_NewsET.SummaryNoSign = Convert.ToString(oReader["SummaryNoSign"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_NewsET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Information"] != DBNull.Value)
                    objCMS_NewsET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_NewsET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_NewsET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Author"] != DBNull.Value)
                    objCMS_NewsET.Author = Convert.ToString(oReader["Author"]);
                if (oReader["AuthorNoSign"] != DBNull.Value)
                    objCMS_NewsET.AuthorNoSign = Convert.ToString(oReader["AuthorNoSign"]);
                if (oReader["Reference"] != DBNull.Value)
                    objCMS_NewsET.Reference = Convert.ToString(oReader["Reference"]);
                if (oReader["ApprovedDate"] != DBNull.Value)
                    objCMS_NewsET.ApprovedDate = Convert.ToDateTime(oReader["ApprovedDate"]);
                if (oReader["ApprovedBy"] != DBNull.Value)
                    objCMS_NewsET.ApprovedBy = Convert.ToInt32(oReader["ApprovedBy"]);
                if (oReader["Hits"] != DBNull.Value)
                    objCMS_NewsET.Hits = Convert.ToInt32(oReader["Hits"]);
                if (oReader["TotalRating"] != DBNull.Value)
                    objCMS_NewsET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                if (oReader["TotalMark"] != DBNull.Value)
                    objCMS_NewsET.TotalMark = Convert.ToInt64(oReader["TotalMark"]);
                if (oReader["AvarageMark"] != DBNull.Value)
                    objCMS_NewsET.AvarageMark = Convert.ToInt64(oReader["AvarageMark"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_NewsET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_NewsET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_NewsET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_NewsET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_NewsET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
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
        ///Bachdx		08/06/2016		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_News_Paging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    int userID,
                    short catPublishedType,
                    Guid? categoryID,
                    short? newsUsedState,
                    short? dataAccess,
                    short? ratingState,
                    short? newsState,
                    int? ordinal,
                    short? version,
                    string title,
                    string summary,
                    string language,
                    string imageTitle,
                    string author,
                    string reference,
                    DateTime? approvedDate,
                    int? approvedBy,
                    int? hits,
                    int? totalRating,
                    long? totalMark,
                    double? avarageMark,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            try
            {
                totalRows = 0;
                List<CMS_NewsET> lstCMS_NewsET = new List<CMS_NewsET>();
                DataTable tblCMS_NewsET = GetTableByProcedure("sp_CMS_News_SearchPaging", new object[] { currentLanguage,
                                                                                                        orderByColumn,
                                                                                                        pageIndex,
                                                                                                        rowsInPage,
                                                                                                        userID,
                                                                                                        catPublishedType,
                                                                                                        categoryID,
                                                                                                        newsUsedState,
                                                                                                        dataAccess,
                                                                                                        ratingState,
                                                                                                        newsState,
                                                                                                        ordinal,
                                                                                                        version,
                                                                                                        title,
                                                                                                        summary,
                                                                                                        language,
                                                                                                        imageTitle,
                                                                                                        author,
                                                                                                        reference,
                                                                                                        approvedDate,
                                                                                                        approvedBy,
                                                                                                        hits,
                                                                                                        totalRating,
                                                                                                        totalMark,
                                                                                                        avarageMark,
                                                                                                        createdBy,
                                                                                                        modifiedBy,
                                                                                                        createdDateFrom,
                                                                                                        createdDateTo });
                if (tblCMS_NewsET != null && tblCMS_NewsET.Rows.Count > 0)
                {
                    totalRows = int.Parse(tblCMS_NewsET.Rows[0]["TotalRows"].ToString());
                }

                //for (int i = 0; i < tblCMS_NewsET.Rows.Count; i++)
                //{
                //    lstCMS_NewsET.Add(setProperties(tblCMS_NewsET.Rows[i]));
                //}
                return tblCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetAll_.._Paging", ex.Message);
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
                List<CMS_NewsET> lstCMS_NewsET = new List<CMS_NewsET>();
                DataTable tblCMS_NewsET = GetTableByProcedure("sp_GetAll_CMS_News");
                for (int i = 0; i < tblCMS_NewsET.Rows.Count; i++)
                {
                    lstCMS_NewsET.Add(setProperties(tblCMS_NewsET.Rows[i]));
                }
                return lstCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public DataSet GetListTopNews(string Language, int TotalNews, int NewsPriority, int OtherTotalNews, int OtherNewsPriority, Guid? categoryID)
        {
            try
            {
                  return GetDatasetByProcedure("sp_Presentation_NewsMain_GetTop", new object[] { Language, TotalNews, NewsPriority, OtherTotalNews, OtherNewsPriority, categoryID});
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetListTopNews..", ex.Message);
                throw ex;
            }
        }

        public DataTable GetAll_CMS_NewsPublichByChuyenMuc(string NgonNgu, Guid? CateID)
        {
            try
            {

                DataTable tblCMS_NewsET = GetTableByProcedure("sp_GetAll_CMS_NewsPub_ByChuyenMuc", NgonNgu, CateID);
                return tblCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetAll_..", ex.Message);
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
        ///Bachdx		08/06/2016Tạo mới
        ///</Modified>
        public CMS_NewsET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_NewsET objCMS_NewsET = new CMS_NewsET();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_News", intItemID))
                {

                    if (oReader.Read())
                    {
                        if (oReader["NewsID"] != DBNull.Value)
                            objCMS_NewsET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                        if (oReader["CategoryID"] != DBNull.Value)
                            objCMS_NewsET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                        if (ReaderContainsColumn(oReader, "ListCategoryID") && oReader["ListCategoryID"] != DBNull.Value)
                            objCMS_NewsET.ListCategory = Convert.ToString(oReader["ListCategoryID"]).Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (ReaderContainsColumn(oReader, "NewsKeyword") && oReader["NewsKeyword"] != DBNull.Value)
                        {
                            objCMS_NewsET.NewsKeyword = Convert.ToString(oReader["NewsKeyword"]).Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            objCMS_NewsET.strNewsKeyword = string.Join(", ", objCMS_NewsET.NewsKeyword);
                        }
                        if (ReaderContainsColumn(oReader, "PriorityPublishing") && oReader["PriorityPublishing"] != DBNull.Value)
                        {
                            objCMS_NewsET.PriorityPublishing = Convert.ToInt32(oReader["PriorityPublishing"]); 
                        }
                        
                        if (oReader["NewsAutoID"] != DBNull.Value)
                            objCMS_NewsET.NewsAutoID = Convert.ToInt64(oReader["NewsAutoID"]);
                        if (oReader["NewsSPID"] != DBNull.Value)
                            objCMS_NewsET.NewsSPID = Convert.ToInt64(oReader["NewsSPID"]);
                        if (oReader["NewsUsedState"] != DBNull.Value)
                            objCMS_NewsET.NewsUsedState = Convert.ToInt32(oReader["NewsUsedState"]);
                        if (oReader["DataAccess"] != DBNull.Value)
                            objCMS_NewsET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_NewsET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["NewsState"] != DBNull.Value)
                            objCMS_NewsET.NewsState = Convert.ToInt32(oReader["NewsState"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_NewsET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["Version"] != DBNull.Value)
                            objCMS_NewsET.Version = Convert.ToInt32(oReader["Version"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_NewsET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["TitleNoSign"] != DBNull.Value)
                            objCMS_NewsET.TitleNoSign = Convert.ToString(oReader["TitleNoSign"]);
                        if (oReader["PageURL"] != DBNull.Value)
                            objCMS_NewsET.PageURL = Convert.ToString(oReader["PageURL"]);
                        if (oReader["Summary"] != DBNull.Value)
                            objCMS_NewsET.Summary = Convert.ToString(oReader["Summary"]);
                        if (oReader["SummaryNoSign"] != DBNull.Value)
                            objCMS_NewsET.SummaryNoSign = Convert.ToString(oReader["SummaryNoSign"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_NewsET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_NewsET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_NewsET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_NewsET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Author"] != DBNull.Value)
                            objCMS_NewsET.Author = Convert.ToString(oReader["Author"]);
                        if (oReader["AuthorNoSign"] != DBNull.Value)
                            objCMS_NewsET.AuthorNoSign = Convert.ToString(oReader["AuthorNoSign"]);
                        if (oReader["Reference"] != DBNull.Value)
                            objCMS_NewsET.Reference = Convert.ToString(oReader["Reference"]);
                        if (oReader["ApprovedDate"] != DBNull.Value)
                            objCMS_NewsET.ApprovedDate = Convert.ToDateTime(oReader["ApprovedDate"]);
                        if (oReader["ApprovedBy"] != DBNull.Value)
                            objCMS_NewsET.ApprovedBy = Convert.ToInt32(oReader["ApprovedBy"]);
                        if (oReader["Hits"] != DBNull.Value)
                            objCMS_NewsET.Hits = Convert.ToInt32(oReader["Hits"]);
                        if (oReader["TotalRating"] != DBNull.Value)
                            objCMS_NewsET.TotalRating = Convert.ToInt32(oReader["TotalRating"]);
                        if (oReader["TotalMark"] != DBNull.Value)
                            objCMS_NewsET.TotalMark = Convert.ToInt64(oReader["TotalMark"]);
                        if (oReader["AvarageMark"] != DBNull.Value)
                            objCMS_NewsET.AvarageMark = Convert.ToInt64(oReader["AvarageMark"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_NewsET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_NewsET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_NewsET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_NewsET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_NewsET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_NewsET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        public static bool ReaderContainsColumn(IDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Contains(name)) return true;
            }
            return false;
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
            MessageUtil objMsg = new MessageUtil();
            //Update CMS_News
            objMsg = Update_CMS_News(objCMS_NewsET);
            //Delete_CMS_Publich
            CMSNewsPublishingDA objPubDA = new CMSNewsPublishingDA();
            objPubDA.DeleteByIdNews(objCMS_NewsET.NewsID);
            //Delete KeyWord
            CMS_News_KeywordDA objKeyDA = new CMS_News_KeywordDA();
            objKeyDA.DeleteByIdNews(objCMS_NewsET.NewsID);
            bool statusAdd = false;
            //Thêm mới News thành công
            if (objCMS_NewsET.NewsID != Guid.Empty)
            {
                short PublishedState = (short)(Pvn.Utils.Parameter.PublishedState.DangKyXuatBan);
                //Thêm bản CMS_NewsPublishing
                if (objCMS_NewsET.NewsState == (short)Pvn.Utils.Parameter.NewsState.TinDangXuatBan)
                    PublishedState = (short)(Pvn.Utils.Parameter.PublishedState.ChoPhepXuatBan);
                statusAdd = Insert_CMS_NewPubliching(objCMS_NewsET, PublishedState);
                //Thêm vào bảng từ khóa
                statusAdd = Insert_CMS_News_KeywordET(objCMS_NewsET);
            }
            objMsg.Error = !statusAdd;
            return objMsg;
        }


        private MessageUtil Update_CMS_News(CMS_NewsET objCMS_NewsET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_News"
                        , objCMS_NewsET.NewsID
                         , objCMS_NewsET.CategoryID
                         , objCMS_NewsET.NewsSPID
                         , objCMS_NewsET.NewsUsedState
                         , objCMS_NewsET.DataAccess
                         , objCMS_NewsET.RatingState
                         , objCMS_NewsET.NewsState
                         , objCMS_NewsET.Ordinal
                         , objCMS_NewsET.Version
                         , objCMS_NewsET.Title
                         , objCMS_NewsET.TitleNoSign
                         , objCMS_NewsET.PageURL
                         , objCMS_NewsET.Summary
                         , objCMS_NewsET.SummaryNoSign
                         , objCMS_NewsET.Language
                         , objCMS_NewsET.Information
                         , objCMS_NewsET.ImageURL
                         , objCMS_NewsET.ImageTitle
                         , objCMS_NewsET.Author
                         , objCMS_NewsET.AuthorNoSign
                         , objCMS_NewsET.Reference
                         , objCMS_NewsET.ApprovedDate
                         , objCMS_NewsET.ApprovedBy
                         , objCMS_NewsET.Hits
                         , objCMS_NewsET.TotalRating
                         , objCMS_NewsET.TotalMark
                         , objCMS_NewsET.AvarageMark
                         , objCMS_NewsET.ModifiedDate
                         , objCMS_NewsET.ModifiedBy))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
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
                bool statusAdd = true;
                Guid NewsID = InsertCMS_NewsET(objCMS_NewsET);
                objCMS_NewsET.NewsID = NewsID;
                //Thêm mới News thành công
                if (NewsID != Guid.Empty)
                {
                    short PublishedState = (short)(Pvn.Utils.Parameter.PublishedState.DangKyXuatBan);
                    //Thêm bản CMS_NewsPublishing
                    if (objCMS_NewsET.NewsState == (short)Pvn.Utils.Parameter.NewsState.TinDangXuatBan)
                        PublishedState = (short)(Pvn.Utils.Parameter.PublishedState.ChoPhepXuatBan);
                    statusAdd = Insert_CMS_NewPubliching(objCMS_NewsET, PublishedState);
                    //Thêm vào bảng từ khóa
                    statusAdd = Insert_CMS_News_KeywordET(objCMS_NewsET);
                }
                return statusAdd;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " Insert", ex.Message);
                return false;
            }
        }
        private bool Insert_CMS_NewPubliching(CMS_NewsET objCMS_NewsET, short PublishedState)
        {
            bool statusAdd = false;
            try
            {
                CMSNewsPublishingDA objPubDA = new CMSNewsPublishingDA();
                //Thêm bản CMS_NewsPublishing
                objCMS_NewsET.ListCategory.Add(objCMS_NewsET.CategoryID.ToString());
                foreach (var itemCategoryID in objCMS_NewsET.ListCategory.Distinct())
                {
                    CMSNewsPublishingET objPubET = new CMSNewsPublishingET();
                    objPubET.CategoryID = new Guid(itemCategoryID);
                    objPubET.NewsID = objCMS_NewsET.NewsID;
                    objPubET.Version = objCMS_NewsET.Version;
                    objPubET.RatingState = objCMS_NewsET.RatingState;
                    if (PublishedState != null)
                        objPubET.PublishedState = PublishedState;//Xuat ban hoac huy xuat ban
                    else
                    {
                        if (objCMS_NewsET.NewsState == (short)Pvn.Utils.Parameter.NewsState.TinDangChoXuatBan)
                            objPubET.PublishedState = (short)Pvn.Utils.Parameter.PublishedState.DangKyXuatBan;
                        if (objCMS_NewsET.NewsState == (short)Pvn.Utils.Parameter.NewsState.TinDangXuatBan)
                            objPubET.PublishedState = (short)Pvn.Utils.Parameter.PublishedState.ChoPhepXuatBan;
                    }

                    objPubET.BeginDate = objCMS_NewsET.PublishedDate;
                    // objPubET.EndDate
                    objPubET.PriorityPublishing = objCMS_NewsET.PriorityPublishing;
                    objPubET.BeginPriority = objCMS_NewsET.BeginPriority;
                    objPubET.EndPriority = objCMS_NewsET.EndPriority;
                    statusAdd = objPubDA.Insert(objPubET);
                }
                return statusAdd;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " Insert_CMS_NewPubliching", ex.Message);
                return statusAdd;
            }
        }
        private bool Insert_CMS_News_KeywordET(CMS_NewsET objCMS_NewsET)
        {
            bool statusAdd = false;
            try
            {
                //Thêm vào bảng từ khóa
                CMS_News_KeywordDA objKeyDA = new CMS_News_KeywordDA();
                foreach (var itemKeyword in objCMS_NewsET.NewsKeyword)
                {
                    CMS_News_KeywordET objKeyET = new CMS_News_KeywordET();
                    objKeyET.NewsID = objCMS_NewsET.NewsID;
                    objKeyET.Version = objCMS_NewsET.Version;
                    //objKeyET.KeywordID uniqueidentifier,
                    objKeyET.Keyword = itemKeyword;
                    objKeyET.KeywordIndex = itemKeyword;
                    objKeyET.KeywordNoSign = itemKeyword;
                    objKeyET.Hits = 0;
                    // objKeyET.Note nvarchar(512),
                    objKeyET.CreatedDate = objCMS_NewsET.CreatedDate;
                    objKeyET.CreatedBy = objCMS_NewsET.CreatedBy;
                    statusAdd = objKeyDA.Insert(objKeyET);

                }

                return statusAdd;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " Insert_CMS_News_KeywordET", ex.Message);
                return statusAdd;
            }

        }
        private Guid InsertCMS_NewsET(CMS_NewsET objCMS_NewsET)
        {
            try
            {
                // Thêm bảng CMS_News
                string idNew = ExecuteNonQueryOutToGuid("sp_Add_CMS_News", "NewsID"
                                                            , objCMS_NewsET.CategoryID
                                                            , objCMS_NewsET.NewsSPID
                                                            , objCMS_NewsET.NewsUsedState
                                                            , objCMS_NewsET.DataAccess
                                                            , objCMS_NewsET.RatingState
                                                            , objCMS_NewsET.NewsState
                                                            , objCMS_NewsET.Ordinal
                                                            , objCMS_NewsET.Version
                                                            , objCMS_NewsET.Title
                                                            , objCMS_NewsET.TitleNoSign
                                                            , objCMS_NewsET.PageURL
                                                            , objCMS_NewsET.Summary
                                                            , objCMS_NewsET.SummaryNoSign
                                                            , objCMS_NewsET.Language
                                                            , objCMS_NewsET.Information
                                                            , objCMS_NewsET.ImageURL
                                                            , objCMS_NewsET.ImageTitle
                                                            , objCMS_NewsET.Author
                                                            , objCMS_NewsET.AuthorNoSign
                                                            , objCMS_NewsET.Reference
                                                            , objCMS_NewsET.ApprovedDate
                                                            , objCMS_NewsET.ApprovedBy
                                                            , objCMS_NewsET.Hits
                                                            , objCMS_NewsET.TotalRating
                                                            , objCMS_NewsET.TotalMark
                                                            , objCMS_NewsET.AvarageMark
                                                            , objCMS_NewsET.CreatedDate
                                                            , objCMS_NewsET.CreatedBy
                                                            , null
                                                            , null
                   );
                return new Guid(idNew);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " InsertCMS_NewsET", ex.Message);
                return Guid.Empty;
            }

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
            MessageUtil objMsg = new MessageUtil();
            try
            {

                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_News", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

        public DataSet GetNewsWithPaging(string language, int pageIndex, int rowsInPage, ref int totalRecords, Guid? categoryID)
        {
            try
            {
                DataSet ds = GetDatasetByProcedure("sp_Presentation_NewsList_GetPageWithRootCategoryName", language, pageIndex, rowsInPage, categoryID);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(Convert.ToString(dt.Rows[0]["TotalRows"]));
                }
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsWithPaging", ex.Message);
                return null;
            }

        }
        public List<CMS_NewsPubET> get_CMS_News_ByCateID(string language, int pageIndex, int rowsInPage, ref int totalRecords, Guid categoryID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_NewsList_By_CateID", language, pageIndex, rowsInPage, categoryID);
                List<CMS_NewsPubET> lstCMS_NewsET = new List<CMS_NewsPubET>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow oReader = dt.Rows[i];
                    CMS_NewsPubET objCMS_NewsET = new CMS_NewsPubET();
                    if (oReader["NewsPublishingID"] != DBNull.Value)
                        objCMS_NewsET.NewsPublishingID = new Guid(Convert.ToString(oReader["NewsPublishingID"]));
                    if (oReader["CategoryID"] != DBNull.Value)
                        objCMS_NewsET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                    if (oReader["ImageURL"] != DBNull.Value)
                        objCMS_NewsET.ImageURL = (Convert.ToString(oReader["ImageURL"]));
                    if (oReader["Title"] != DBNull.Value)
                        objCMS_NewsET.Title = (Convert.ToString(oReader["Title"]));
                    if (oReader["Information"] != DBNull.Value)
                        objCMS_NewsET.Information = (Convert.ToString(oReader["Information"]));
                    if (oReader["CategoryName"] != DBNull.Value)
                        objCMS_NewsET.CategoryName = (Convert.ToString(oReader["CategoryName"]));
                    if (oReader["Summary"] != DBNull.Value)
                        objCMS_NewsET.Summary = (Convert.ToString(oReader["Summary"]));
                    if (oReader["BeginDate"] != DBNull.Value)
                        objCMS_NewsET.BeginDate = (Convert.ToDateTime(oReader["BeginDate"]));
                    if (oReader["CreatedDate"] != DBNull.Value)
                        objCMS_NewsET.CreatedDate = (Convert.ToDateTime(oReader["CreatedDate"]));
                    if (oReader["ApprovedDate"] != DBNull.Value)
                        objCMS_NewsET.CreatedDate = (Convert.ToDateTime(oReader["ApprovedDate"]));
                    lstCMS_NewsET.Add(objCMS_NewsET);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(Convert.ToString(dt.Rows[0]["TotalRows"]));
                }
                return lstCMS_NewsET;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsMain", ex.Message);
                return null;
            }

        }
        
        public DataTable GetNewsMain(string language,int TotalNews, int PriorityPublishing, Guid? categoryID)
        {
            try
            {
                DataTable ds = GetTableByProcedure("sp_Presentation_NewsListMain", language, TotalNews, PriorityPublishing, categoryID);
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsMain", ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Get all news detail data
        /// </summary>
        /// <param name="inputParameter"></param>
        /// <returns></returns>
        public DataSet GetNewsDetailData(string language, int numberMain, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            try
            {
                DataSet ds = GetDatasetByProcedure("sp_Presentation_NewsDetail_GetNewsDetailData", language, numberMain, newsID, numberNewsOther, numberTimeline);
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsDetailData", ex.Message);
                return null;
            }

        }
        public DataSet GetNewsDetailData_2(string language, int numberMain, Guid? CateID, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            try
            {
                DataSet ds = GetDatasetByProcedure("sp_Presentation_NewsDetail2_GetNewsDetailData", language, numberMain,CateID, newsID, numberNewsOther, numberTimeline);
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsDetailData", ex.Message);
                return null;
            }

        }
        public DataTable GetOtherRelatedNews(string CurrentLanguage, int TotalNews, Guid? NewsID)
        {
            try
            {
                DataTable ds = GetTableByProcedure("sp_Presentation_NewsDetail_GetOtherRelatedNews", CurrentLanguage, TotalNews, NewsID);
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetNewsDetailData", ex.Message);
                return null;
            }

        }
        public DataTable GetOtherNewsInCate(string CurrentLanguage, int TotalNews, Guid? NewsID)
        {
            try
            {
                DataTable ds = GetTableByProcedure("sp_Presentation_NewsDetail_GetMostView", CurrentLanguage, TotalNews, NewsID);
                return ds;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", " GetOtherNewsInCate", ex.Message);
                return null;
            }

        }
       
    }
}

