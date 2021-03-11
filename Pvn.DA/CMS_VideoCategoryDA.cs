using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_VideoCategoryDA : Pvn.DA.DataProvider
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
        private CMS_VideoCategoryET setProperties(DataRow oReader)
        {
            try
            {
                CMS_VideoCategoryET objCMS_VideoCategoryET = new CMS_VideoCategoryET();
                if (oReader["VideoCategoryID"] != DBNull.Value)
                    objCMS_VideoCategoryET.VideoCategoryID = new Guid(Convert.ToString(oReader["VideoCategoryID"]));
                if (oReader["Code"] != DBNull.Value)
                    objCMS_VideoCategoryET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_VideoCategoryET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Description"] != DBNull.Value)
                    objCMS_VideoCategoryET.Description = Convert.ToString(oReader["Description"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_VideoCategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMS_VideoCategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["ParentVideoCategoryID"] != DBNull.Value)
                    objCMS_VideoCategoryET.ParentVideoCategoryID = new Guid(Convert.ToString(oReader["ParentVideoCategoryID"]));
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_VideoCategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_VideoCategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_VideoCategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_VideoCategoryET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_VideoCategoryET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_VideoCategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_VideoCategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_VideoCategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_VideoCategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_VideoCategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_VideoCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", "setProperties", ex.Message);
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
        public List<CMS_VideoCategoryET> GetAll_CMS_VideoCategory_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_VideoCategoryET> lstCMS_VideoCategoryET = new List<CMS_VideoCategoryET>();
                DataTable tblCMS_VideoCategoryET = GetTableByProcedurePaging("sp_CMS_VideoCategory_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_VideoCategoryET.Rows.Count; i++)
                {
                    lstCMS_VideoCategoryET.Add(setProperties(tblCMS_VideoCategoryET.Rows[i]));
                }
                return lstCMS_VideoCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " GetAll_.._Paging", ex.Message);
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
        public List<CMS_VideoCategoryET> GetAll_CMS_VideoCategory()
        {
            try
            {
                List<CMS_VideoCategoryET> lstCMS_VideoCategoryET = new List<CMS_VideoCategoryET>();
                DataTable tblCMS_VideoCategoryET = GetTableByProcedure("sp_GetAll_CMS_VideoCategory");
                for (int i = 0; i < tblCMS_VideoCategoryET.Rows.Count; i++)
                {
                    lstCMS_VideoCategoryET.Add(setProperties(tblCMS_VideoCategoryET.Rows[i]));
                }
                return lstCMS_VideoCategoryET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Tao cay chuyen muc video trong phan quan tri
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="language"></param>
        /// <param name="usedState"></param>
        /// <returns></returns>
        /// <remarks>
        ///     1. VideoCategoryList.Grid
        /// </remarks>
        public DataTable GetTreeAdmin(string currentLanguage, string language, short? usedState)
        {
            try
            {
                DataTable dtTreeAdmin = GetTableByProcedure("sp_CMS_VideoCategory_TreeAdmin",
                    currentLanguage, language, usedState);
                return dtTreeAdmin;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " GetTreeAdmin..", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Lay cay chuyen muc video
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        /// <remarks>
        ///     1. VideoCategoryList.Grid
        ///     2. VideoCategoryList.ComboBox
        ///     3. VideoCategoryEdit.ComboBox
        ///     4. VideoEdit.ComboBox
        ///     3. VideoList.ComboBox
        /// </remarks>
        public DataTable GetTree(string currentLanguage, string language)
        {
            DataTable dtTree = GetTableByProcedure("sp_CMS_VideoCategory_Tree",
                currentLanguage, language);
            return dtTree;
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
        public CMS_VideoCategoryET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_VideoCategoryET objCMS_VideoCategoryET = new CMS_VideoCategoryET();
                DataTable tblCMS_VideoCategoryET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_VideoCategory", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["VideoCategoryID"] != DBNull.Value)
                            objCMS_VideoCategoryET.VideoCategoryID = new Guid(Convert.ToString(oReader["VideoCategoryID"]));
                        if (oReader["Code"] != DBNull.Value)
                            objCMS_VideoCategoryET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_VideoCategoryET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Description"] != DBNull.Value)
                            objCMS_VideoCategoryET.Description = Convert.ToString(oReader["Description"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_VideoCategoryET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMS_VideoCategoryET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["ParentVideoCategoryID"] != DBNull.Value)
                            objCMS_VideoCategoryET.ParentVideoCategoryID = new Guid(Convert.ToString(oReader["ParentVideoCategoryID"]));
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_VideoCategoryET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_VideoCategoryET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_VideoCategoryET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_VideoCategoryET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_VideoCategoryET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_VideoCategoryET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_VideoCategoryET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_VideoCategoryET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_VideoCategoryET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_VideoCategoryET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_VideoCategoryET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_VideoCategoryET objCMS_VideoCategoryET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_VideoCategory"
                         , objCMS_VideoCategoryET.VideoCategoryID
                         , objCMS_VideoCategoryET.Code
                         , objCMS_VideoCategoryET.Title
                         , objCMS_VideoCategoryET.Description
                         , objCMS_VideoCategoryET.UsedState
                         , objCMS_VideoCategoryET.RatingState
                         , objCMS_VideoCategoryET.ParentVideoCategoryID
                         , objCMS_VideoCategoryET.Ordinal
                         , objCMS_VideoCategoryET.ImageURL
                         , objCMS_VideoCategoryET.ImageTitle
                         , objCMS_VideoCategoryET.Language
                         , objCMS_VideoCategoryET.Note
                         , objCMS_VideoCategoryET.CreatedDate
                         , objCMS_VideoCategoryET.CreatedBy
                         , objCMS_VideoCategoryET.ModifiedDate
                         , objCMS_VideoCategoryET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_VideoCategoryET objCMS_VideoCategoryET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_VideoCategory", "VideoCategoryID"
                         , objCMS_VideoCategoryET.Code
                         , objCMS_VideoCategoryET.Title
                         , objCMS_VideoCategoryET.Description
                         , objCMS_VideoCategoryET.UsedState
                         , objCMS_VideoCategoryET.RatingState
                         , objCMS_VideoCategoryET.ParentVideoCategoryID
                         , objCMS_VideoCategoryET.Ordinal
                         , objCMS_VideoCategoryET.ImageURL
                         , objCMS_VideoCategoryET.ImageTitle
                         , objCMS_VideoCategoryET.Language
                         , objCMS_VideoCategoryET.Note
                         , objCMS_VideoCategoryET.CreatedDate
                         , objCMS_VideoCategoryET.CreatedBy
                         , objCMS_VideoCategoryET.ModifiedDate
                         , objCMS_VideoCategoryET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_VideoCategory", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideosCategoryDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_VideoCategory", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_VideoCategoryDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }


    }
}

