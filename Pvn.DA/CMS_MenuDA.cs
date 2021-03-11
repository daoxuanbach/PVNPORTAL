using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_MenuDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        private CMS_MenuET setProperties(DataRow oReader)
        {
            try
            {
                CMS_MenuET objCMS_MenuET = new CMS_MenuET();
                if (oReader["MenuID"] != DBNull.Value)
                    objCMS_MenuET.MenuID = new Guid(Convert.ToString(oReader["MenuID"]));
                if (oReader.Table.Columns.Contains("MenuAutoID") && oReader["MenuAutoID"] != DBNull.Value)
                    objCMS_MenuET.MenuAutoID = Convert.ToInt32(oReader["MenuAutoID"]);
                if (oReader["Code"] != DBNull.Value)
                    objCMS_MenuET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_MenuET.Title = Convert.ToString(oReader["Title"]);
                if (oReader.Table.Columns.Contains("IndentedTitle") && oReader["IndentedTitle"] != DBNull.Value)
                    objCMS_MenuET.Title = Convert.ToString(oReader["IndentedTitle"]);
                if (oReader["Summary"] != DBNull.Value)
                    objCMS_MenuET.Summary = Convert.ToString(oReader["Summary"]);
                if (oReader.Table.Columns.Contains("Information") && oReader["Information"] != DBNull.Value)
                    objCMS_MenuET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_MenuET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["MenuPosition"] != DBNull.Value)
                    objCMS_MenuET.MenuPosition = Convert.ToInt32(oReader["MenuPosition"]);
                if (oReader["DataAccess"] != DBNull.Value)
                    objCMS_MenuET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_MenuET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["ParentMenuID"] != DBNull.Value)
                    objCMS_MenuET.ParentMenuID = new Guid(Convert.ToString(oReader["ParentMenuID"]));
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_MenuET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader.Table.Columns.Contains("Information") && oReader["OrdinalTitle"] != DBNull.Value)
                    objCMS_MenuET.OrdinalTitle = Convert.ToString(oReader["OrdinalTitle"]);
                if (oReader["ObjectType"] != DBNull.Value)
                    objCMS_MenuET.ObjectType = Convert.ToString(oReader["ObjectType"]);
                if (oReader.Table.Columns.Contains("ObjectID") && oReader["ObjectID"] != DBNull.Value)
                    objCMS_MenuET.ObjectID = new Guid(Convert.ToString(oReader["ObjectID"]));
                if (oReader["URL"] != DBNull.Value)
                    objCMS_MenuET.URL = Convert.ToString(oReader["URL"]);
                if (oReader.Table.Columns.Contains("IsNewWindow") && oReader["IsNewWindow"] != DBNull.Value)
                    objCMS_MenuET.IsNewWindow = Convert.ToBoolean(oReader["IsNewWindow"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_MenuET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_MenuET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader.Table.Columns.Contains("Note") && oReader["Note"] != DBNull.Value)
                    objCMS_MenuET.Note = Convert.ToString(oReader["Note"]);
                if (oReader.Table.Columns.Contains("PortalID") && oReader["PortalID"] != DBNull.Value)
                    objCMS_MenuET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader.Table.Columns.Contains("CreatedDate") && oReader["CreatedDate"] != DBNull.Value)
                    objCMS_MenuET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader.Table.Columns.Contains("CreatedBy") && oReader["CreatedBy"] != DBNull.Value)
                    objCMS_MenuET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader.Table.Columns.Contains("ModifiedDate") && oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_MenuET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader.Table.Columns.Contains("ModifiedBy") && oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_MenuET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_MenuET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", "setProperties", ex.Message);
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
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public List<CMS_MenuET> GetAll_CMS_Menu_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_MenuET> lstCMS_MenuET = new List<CMS_MenuET>();
                DataTable tblCMS_MenuET = GetTableByProcedurePaging("sp_CMS_Menu_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_MenuET.Rows.Count; i++)
                {
                    lstCMS_MenuET.Add(setProperties(tblCMS_MenuET.Rows[i]));
                }
                return lstCMS_MenuET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetAll_.._Paging", ex.Message);
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
                List<CMS_MenuET> lstCMS_MenuET = new List<CMS_MenuET>();
                DataTable tblCMS_MenuET = GetTableByProcedure("sp_GetAll_CMS_Menu");
                for (int i = 0; i < tblCMS_MenuET.Rows.Count; i++)
                {
                    lstCMS_MenuET.Add(setProperties(tblCMS_MenuET.Rows[i]));
                }
                return lstCMS_MenuET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetAll_..", ex.Message);
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
                CMS_MenuET objCMS_MenuET = new CMS_MenuET();
                DataTable tblCMS_MenuET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Menu", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["MenuID"] != DBNull.Value)
                            objCMS_MenuET.MenuID = new Guid(Convert.ToString(oReader["MenuID"]));
                        if (oReader["MenuAutoID"] != DBNull.Value)
                            objCMS_MenuET.MenuAutoID = Convert.ToInt32(oReader["MenuAutoID"]);
                        if (oReader["Code"] != DBNull.Value)
                            objCMS_MenuET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_MenuET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Summary"] != DBNull.Value)
                            objCMS_MenuET.Summary = Convert.ToString(oReader["Summary"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_MenuET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_MenuET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["MenuPosition"] != DBNull.Value)
                            objCMS_MenuET.MenuPosition = Convert.ToInt32(oReader["MenuPosition"]);
                        if (oReader["DataAccess"] != DBNull.Value)
                            objCMS_MenuET.DataAccess = Convert.ToInt32(oReader["DataAccess"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_MenuET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["ParentMenuID"] != DBNull.Value)
                            objCMS_MenuET.ParentMenuID = new Guid(Convert.ToString(oReader["ParentMenuID"]));
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_MenuET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ObjectType"] != DBNull.Value)
                            objCMS_MenuET.ObjectType = Convert.ToString(oReader["ObjectType"]);
                        if (oReader["ObjectID"] != DBNull.Value)
                            objCMS_MenuET.ObjectID = new Guid(Convert.ToString(oReader["ObjectID"]));
                        if (oReader["URL"] != DBNull.Value)
                            objCMS_MenuET.URL = Convert.ToString(oReader["URL"]);
                        if (oReader["IsNewWindow"] != DBNull.Value)
                            objCMS_MenuET.IsNewWindow = Convert.ToBoolean(oReader["IsNewWindow"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_MenuET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_MenuET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_MenuET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_MenuET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_MenuET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_MenuET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_MenuET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_MenuET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_MenuET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetInfo", ex.Message);
                throw ex;
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
                ExecuteNonQuery("sp_UpdateByPK_CMS_Menu"
                         , objCMS_MenuET.MenuID
                         , objCMS_MenuET.Code
                         , objCMS_MenuET.Title
                         , objCMS_MenuET.Summary
                         , objCMS_MenuET.Information
                         , objCMS_MenuET.UsedState
                         , objCMS_MenuET.MenuPosition
                         , objCMS_MenuET.DataAccess
                         , objCMS_MenuET.Language
                         , objCMS_MenuET.ParentMenuID
                         , objCMS_MenuET.Ordinal
                         , objCMS_MenuET.ObjectType
                         , objCMS_MenuET.ObjectID
                         , objCMS_MenuET.URL
                         , objCMS_MenuET.IsNewWindow
                         , objCMS_MenuET.ImageURL
                         , objCMS_MenuET.ImageTitle
                         , objCMS_MenuET.Note
                         , objCMS_MenuET.CreatedDate
                         , objCMS_MenuET.CreatedBy
                         , objCMS_MenuET.ModifiedDate
                         , objCMS_MenuET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " Update", ex.Message);
                return false;
            }
        }
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
                ExecuteNonQueryOutToGuid("sp_Add_CMS_Menu", "MenuID"
                         , objCMS_MenuET.Code
                         , objCMS_MenuET.Title
                         , objCMS_MenuET.Summary
                         , objCMS_MenuET.Information
                         , objCMS_MenuET.UsedState
                         , objCMS_MenuET.MenuPosition
                         , objCMS_MenuET.DataAccess
                         , objCMS_MenuET.Language
                         , objCMS_MenuET.ParentMenuID
                         , objCMS_MenuET.Ordinal
                         , objCMS_MenuET.ObjectType
                         , objCMS_MenuET.ObjectID
                         , objCMS_MenuET.URL
                         , objCMS_MenuET.IsNewWindow
                         , objCMS_MenuET.ImageURL
                         , objCMS_MenuET.ImageTitle
                         , objCMS_MenuET.Note
                         , objCMS_MenuET.CreatedDate
                         , objCMS_MenuET.CreatedBy
                         , objCMS_MenuET.ModifiedDate
                         , objCMS_MenuET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " Insert", ex.Message);
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
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Menu", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        public DataSet GetTreeByLanguagePositionDataset(string language, int position, bool recursive, Guid? parentMenuID)
        {
            try
            {
                List<CMS_MenuET> lstCMS_MenuET = new List<CMS_MenuET>();
                DataSet ds = GetDatasetByProcedure("sp_Presentation_Menu_GetTree", language, position, recursive, parentMenuID);
                //DataTable tblCMS_MenuET = ds.Tables[0];
                return ds;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetTreeByLanguagePosition", ex.Message);
                return null;
            }
        }
        public DataTable GetTreeByLanguagePosition(string language, int position, bool recursive, Guid? parentMenuID)
        {
            try
            {
                List<CMS_MenuET> lstCMS_MenuET = new List<CMS_MenuET>();
                DataSet ds = GetDatasetByProcedure("sp_Presentation_Menu_GetTree", language, position, recursive, parentMenuID);
                DataTable tblCMS_MenuET = ds.Tables[0];
                return tblCMS_MenuET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetTreeByLanguagePosition", ex.Message);
                return null;
            }
        }
        public List<CMS_MenuET> GetTree(string curentLanguage, string Language, int Position)
        {
            try
            {
                List<CMS_MenuET> lstCMS_MenuET = new List<CMS_MenuET>();
                DataTable tblCMS_MenuET = GetTableByProcedure("sp_CMS_Menu_Tree", curentLanguage, Language, 1, Position); //1@UsedState
                for (int i = 0; i < tblCMS_MenuET.Rows.Count; i++)
                {
                    lstCMS_MenuET.Add(setProperties(tblCMS_MenuET.Rows[i]));
                }
                return lstCMS_MenuET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetTree", ex.Message);
                return null;
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
        public DataTable GetSearchPaging(string currentLanguage, string orderByColumn, int pageIndex, int rowsInPage, ref int totalRows, string code, string title, string summary, short? usedState, short? menuPosition, short? dataAccess, string language, Guid? parentMenuID, int? ordinal, string ojectType, Guid? ojectID, string url, string imageURL, string imageTitle, string note, DateTime? createdDateFrom, int? createdBy, DateTime? createdDateTo, int? modifiedBy)
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Menu_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    code,
                    title,
                    summary,
                    usedState,
                    menuPosition,
                    dataAccess,
                    language,
                    parentMenuID,
                    ordinal,
                    ojectType,
                    ojectID,
                    url,
                    imageURL,
                    imageTitle,
                    note,
                    createdDateFrom,
                    createdBy,
                    createdDateTo,
                    modifiedBy);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                totalRows = 0;
                return null;
            }
        }

        /// <summary>
        /// Get menu Breadcumb by type
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="newsPublishingID"></param>
        /// <returns></returns>
        public DataTable GetMenuBreadCumb(Guid? categoryID, int menuType)
        {
            try
            {
                return GetTableByProcedure("sp_Presentation_MenuBreadCumbByType", categoryID, menuType);
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", " GetMenuBreadCumb", ex.Message);
                return null;
            }

        }
    }
}

