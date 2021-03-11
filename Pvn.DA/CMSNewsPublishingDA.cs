using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMSNewsPublishingDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        private CMSNewsPublishingET setProperties(DataRow oReader)
        {
            try
            {
                CMSNewsPublishingET objCMSNewsPublishingET = new CMSNewsPublishingET();
                if (oReader["NewsPublishingID"] != DBNull.Value)
                    objCMSNewsPublishingET.NewsPublishingID = new Guid(Convert.ToString(oReader["NewsPublishingID"]));
                if (oReader["CategoryID"] != DBNull.Value)
                    objCMSNewsPublishingET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                if (oReader["NewsID"] != DBNull.Value)
                    objCMSNewsPublishingET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                if (oReader["NewsSPID"] != DBNull.Value)
                    objCMSNewsPublishingET.NewsSPID = Convert.ToInt64(oReader["NewsSPID"]);
                if (oReader["Version"] != DBNull.Value)
                    objCMSNewsPublishingET.Version = Convert.ToInt32(oReader["Version"]);
                if (oReader["RatingState"] != DBNull.Value)
                    objCMSNewsPublishingET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                if (oReader["PublishedState"] != DBNull.Value)
                    objCMSNewsPublishingET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                if (oReader["BeginDate"] != DBNull.Value)
                    objCMSNewsPublishingET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                if (oReader["EndDate"] != DBNull.Value)
                    objCMSNewsPublishingET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                if (oReader["PriorityPublishing"] != DBNull.Value)
                    objCMSNewsPublishingET.PriorityPublishing = Convert.ToInt32(oReader["PriorityPublishing"]);
                if (oReader["BeginPriority"] != DBNull.Value)
                    objCMSNewsPublishingET.BeginPriority = Convert.ToDateTime(oReader["BeginPriority"]);
                if (oReader["EndPriority"] != DBNull.Value)
                    objCMSNewsPublishingET.EndPriority = Convert.ToDateTime(oReader["EndPriority"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMSNewsPublishingET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMSNewsPublishingET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMSNewsPublishingET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMSNewsPublishingET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMSNewsPublishingET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMSNewsPublishingET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMSNewsPublishingET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", "setProperties", ex.Message);
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
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        public List<CMSNewsPublishingET> GetAll_CMSNewsPublishing_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMSNewsPublishingET> lstCMSNewsPublishingET = new List<CMSNewsPublishingET>();
                DataTable tblCMSNewsPublishingET = GetTableByProcedurePaging("sp_CMS_NewsPublishing_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMSNewsPublishingET.Rows.Count; i++)
                {
                    lstCMSNewsPublishingET.Add(setProperties(tblCMSNewsPublishingET.Rows[i]));
                }
                return lstCMSNewsPublishingET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        public List<CMSNewsPublishingET> GetAll_CMSNewsPublishing()
        {
            try
            {
                List<CMSNewsPublishingET> lstCMSNewsPublishingET = new List<CMSNewsPublishingET>();
                DataTable tblCMSNewsPublishingET = GetTableByProcedure("sp_GetAll_CMS_NewsPublishing");
                for (int i = 0; i < tblCMSNewsPublishingET.Rows.Count; i++)
                {
                    lstCMSNewsPublishingET.Add(setProperties(tblCMSNewsPublishingET.Rows[i]));
                }
                return lstCMSNewsPublishingET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " GetAll_..", ex.Message);
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
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public CMSNewsPublishingET GetInfo(Guid intItemID)
        {
            try
            {
                CMSNewsPublishingET objCMSNewsPublishingET = new CMSNewsPublishingET();
                DataTable tblCMSNewsPublishingET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_NewsPublishing", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["NewsPublishingID"] != DBNull.Value)
                            objCMSNewsPublishingET.NewsPublishingID = new Guid(Convert.ToString(oReader["NewsPublishingID"]));
                        if (oReader["CategoryID"] != DBNull.Value)
                            objCMSNewsPublishingET.CategoryID = new Guid(Convert.ToString(oReader["CategoryID"]));
                        if (oReader["NewsID"] != DBNull.Value)
                            objCMSNewsPublishingET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                        if (oReader["NewsSPID"] != DBNull.Value)
                            objCMSNewsPublishingET.NewsSPID = Convert.ToInt64(oReader["NewsSPID"]);
                        if (oReader["Version"] != DBNull.Value)
                            objCMSNewsPublishingET.Version = Convert.ToInt32(oReader["Version"]);
                        if (oReader["RatingState"] != DBNull.Value)
                            objCMSNewsPublishingET.RatingState = Convert.ToInt32(oReader["RatingState"]);
                        if (oReader["PublishedState"] != DBNull.Value)
                            objCMSNewsPublishingET.PublishedState = Convert.ToInt32(oReader["PublishedState"]);
                        if (oReader["BeginDate"] != DBNull.Value)
                            objCMSNewsPublishingET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                        if (oReader["EndDate"] != DBNull.Value)
                            objCMSNewsPublishingET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                        if (oReader["PriorityPublishing"] != DBNull.Value)
                            objCMSNewsPublishingET.PriorityPublishing = Convert.ToInt32(oReader["PriorityPublishing"]);
                        if (oReader["BeginPriority"] != DBNull.Value)
                            objCMSNewsPublishingET.BeginPriority = Convert.ToDateTime(oReader["BeginPriority"]);
                        if (oReader["EndPriority"] != DBNull.Value)
                            objCMSNewsPublishingET.EndPriority = Convert.ToDateTime(oReader["EndPriority"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMSNewsPublishingET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMSNewsPublishingET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMSNewsPublishingET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMSNewsPublishingET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMSNewsPublishingET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMSNewsPublishingET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMSNewsPublishingET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMSNewsPublishingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public bool Update(CMSNewsPublishingET objCMSNewsPublishingET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_CMS_NewsPublishing"
                         , objCMSNewsPublishingET.NewsPublishingID
                         , objCMSNewsPublishingET.CategoryID
                         , objCMSNewsPublishingET.NewsID
                         , objCMSNewsPublishingET.NewsSPID
                         , objCMSNewsPublishingET.Version
                         , objCMSNewsPublishingET.RatingState
                         , objCMSNewsPublishingET.PublishedState
                         , objCMSNewsPublishingET.BeginDate
                         , objCMSNewsPublishingET.EndDate
                         , objCMSNewsPublishingET.PriorityPublishing
                         , objCMSNewsPublishingET.BeginPriority
                         , objCMSNewsPublishingET.EndPriority
                         , objCMSNewsPublishingET.Note
                         , objCMSNewsPublishingET.PortalID
                         , objCMSNewsPublishingET.CreatedDate
                         , objCMSNewsPublishingET.CreatedBy
                         , objCMSNewsPublishingET.ModifiedDate
                         , objCMSNewsPublishingET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMSNewsPublishingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public bool Insert(CMSNewsPublishingET objCMSNewsPublishingET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_NewsPublishing", "NewsPublishingID"
                         , objCMSNewsPublishingET.CategoryID
                         , objCMSNewsPublishingET.NewsID
                         , objCMSNewsPublishingET.NewsSPID
                         , objCMSNewsPublishingET.Version
                         , objCMSNewsPublishingET.RatingState
                         , objCMSNewsPublishingET.PublishedState
                         , objCMSNewsPublishingET.BeginDate
                         , objCMSNewsPublishingET.EndDate
                         , objCMSNewsPublishingET.PriorityPublishing
                         , objCMSNewsPublishingET.BeginPriority
                         , objCMSNewsPublishingET.EndPriority
                         , objCMSNewsPublishingET.Note
                         , objCMSNewsPublishingET.CreatedDate
                         , objCMSNewsPublishingET.CreatedBy
                         , null
                         , null
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMSNewsPublishingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteByIdNews(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByIdNews_CMSNewsPublishing", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

