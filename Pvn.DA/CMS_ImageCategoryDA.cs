using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ImageCategoryDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        private CMS_ImageCategoryET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ImageCategoryET objCMS_ImageCategoryET = new CMS_ImageCategoryET();
                if (oReader["ImageCategoryID"] != DBNull.Value)
                    objCMS_ImageCategoryET.ImageCategoryID = new Guid(Convert.ToString(oReader["ImageCategoryID"]));
                if (oReader["Code"] != DBNull.Value)
                    objCMS_ImageCategoryET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_ImageCategoryET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Description"] != DBNull.Value)
                    objCMS_ImageCategoryET.Description = Convert.ToString(oReader["Description"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_ImageCategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMS_ImageCategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["ParentImageCategoryID"] != DBNull.Value)
                    objCMS_ImageCategoryET.ParentImageCategoryID = new Guid(Convert.ToString(oReader["ParentImageCategoryID"]));
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_ImageCategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_ImageCategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_ImageCategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_ImageCategoryET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_ImageCategoryET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_ImageCategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_ImageCategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_ImageCategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_ImageCategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_ImageCategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_ImageCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", "setProperties", ex.Message);
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
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageCategoryET> GetAll_CMS_ImageCategory_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ImageCategoryET> lstCMS_ImageCategoryET = new List<CMS_ImageCategoryET>();
                DataTable tblCMS_ImageCategoryET = GetTableByProcedurePaging("sp_CMS_ImageCategory_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ImageCategoryET.Rows.Count; i++)
                {
                    lstCMS_ImageCategoryET.Add(setProperties(tblCMS_ImageCategoryET.Rows[i]));
                }
                return lstCMS_ImageCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Lay cay chuyen muc anh
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="language"></param>
        /// <param name="usedState"></param>
        /// <returns></returns>
        /// <remarks>
        ///     1. ImageCategoryList.ComboBox
        ///     2. ImageCategoryEdit.ComboBox
        ///     3. ImageEdit.ComboBox
        ///     4. ImageList.ComboBox
        /// </remarks>
        public DataTable GetTree(string currentLanguage, string language)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_CMS_ImageCategory_Tree", currentLanguage, language);
                return dt;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " GetTree", ex.Message);
                throw ex;
            }
           
        }

        public DataTable GetTreeAdmin(string currentLanguage, string language, short? usedState)
        {

            try
            {
                DataTable dt = GetTableByProcedure("sp_CMS_ImageCategory_TreeAdmin", currentLanguage, language, usedState);
                return dt;
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " GetTree", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageCategoryET> GetAll_CMS_ImageCategory()
        {
            try
            {
                List<CMS_ImageCategoryET> lstCMS_ImageCategoryET = new List<CMS_ImageCategoryET>();
                DataTable tblCMS_ImageCategoryET = GetTableByProcedure("sp_GetAll_CMS_ImageCategory");
                for (int i = 0; i < tblCMS_ImageCategoryET.Rows.Count; i++)
                {
                    lstCMS_ImageCategoryET.Add(setProperties(tblCMS_ImageCategoryET.Rows[i]));
                }
                return lstCMS_ImageCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " GetAll_..", ex.Message);
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
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public CMS_ImageCategoryET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_ImageCategoryET objCMS_ImageCategoryET = new CMS_ImageCategoryET();
                DataTable tblCMS_ImageCategoryET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ImageCategory", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ImageCategoryID"] != DBNull.Value)
                            objCMS_ImageCategoryET.ImageCategoryID = new Guid(Convert.ToString(oReader["ImageCategoryID"]));
                        if (oReader["Code"] != DBNull.Value)
                            objCMS_ImageCategoryET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_ImageCategoryET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Description"] != DBNull.Value)
                            objCMS_ImageCategoryET.Description = Convert.ToString(oReader["Description"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_ImageCategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_ImageCategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["ParentImageCategoryID"] != DBNull.Value)
                            objCMS_ImageCategoryET.ParentImageCategoryID = new Guid(Convert.ToString(oReader["ParentImageCategoryID"]));
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_ImageCategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_ImageCategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_ImageCategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_ImageCategoryET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_ImageCategoryET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_ImageCategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_ImageCategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_ImageCategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_ImageCategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_ImageCategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_ImageCategoryET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ImageCategoryET objCMS_ImageCategoryET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ImageCategory", 
                           objCMS_ImageCategoryET.ImageCategoryID
                         , objCMS_ImageCategoryET.Code
                         , objCMS_ImageCategoryET.Title
                         , objCMS_ImageCategoryET.Description
                         , objCMS_ImageCategoryET.UsedState
                         , objCMS_ImageCategoryET.RatingState
                         , objCMS_ImageCategoryET.ParentImageCategoryID
                         , objCMS_ImageCategoryET.Ordinal
                         , objCMS_ImageCategoryET.ImageURL
                         , objCMS_ImageCategoryET.ImageTitle
                         , objCMS_ImageCategoryET.Language
                         , objCMS_ImageCategoryET.Note
                         , objCMS_ImageCategoryET.CreatedDate
                         , objCMS_ImageCategoryET.CreatedBy
                         , objCMS_ImageCategoryET.ModifiedDate
                         , objCMS_ImageCategoryET.ModifiedBy))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }

        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_ImageCategoryET objCMS_ImageCategoryET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_ImageCategory", "ImageCategoryID"
                         , objCMS_ImageCategoryET.Code
                         , objCMS_ImageCategoryET.Title
                         , objCMS_ImageCategoryET.Description
                         , objCMS_ImageCategoryET.UsedState
                         , objCMS_ImageCategoryET.RatingState
                         , objCMS_ImageCategoryET.ParentImageCategoryID
                         , objCMS_ImageCategoryET.Ordinal
                         , objCMS_ImageCategoryET.ImageURL
                         , objCMS_ImageCategoryET.ImageTitle
                         , objCMS_ImageCategoryET.Language
                         , objCMS_ImageCategoryET.Note
                         , objCMS_ImageCategoryET.CreatedDate
                         , objCMS_ImageCategoryET.CreatedBy
                         , objCMS_ImageCategoryET.ModifiedDate
                         , objCMS_ImageCategoryET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ImageCategory", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ImageCategory", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageCategoryDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }


       
    }
}

