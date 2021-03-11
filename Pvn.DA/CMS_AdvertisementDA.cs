using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_AdvertisementDA : Pvn.DA.DataProvider
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
        private CMS_AdvertisementET setProperties(DataRow oReader)
        {
            try
            {
                CMS_AdvertisementET objCMS_AdvertisementET = new CMS_AdvertisementET();
                if (oReader["AdvertisementID"] != DBNull.Value)
                    objCMS_AdvertisementET.AdvertisementID = new Guid(Convert.ToString(oReader["AdvertisementID"]));
                if (oReader["MenuID"] != DBNull.Value)
                    objCMS_AdvertisementET.MenuID = new Guid(Convert.ToString(oReader["MenuID"]));
                if (oReader["Title"] != DBNull.Value)
                    objCMS_AdvertisementET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Description"] != DBNull.Value)
                    objCMS_AdvertisementET.Description = Convert.ToString(oReader["Description"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_AdvertisementET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["AdvertisementPosition"] != DBNull.Value)
                    objCMS_AdvertisementET.AdvertisementPosition = Convert.ToInt32(oReader["AdvertisementPosition"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_AdvertisementET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ImageSize"] != DBNull.Value)
                    objCMS_AdvertisementET.ImageSize = Convert.ToString(oReader["ImageSize"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_AdvertisementET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader["ImageTitle"] != DBNull.Value)
                    objCMS_AdvertisementET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                if (oReader["Language"] != DBNull.Value)
                    objCMS_AdvertisementET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Link"] != DBNull.Value)
                    objCMS_AdvertisementET.Link = Convert.ToString(oReader["Link"]);
                if (oReader["IsNewWindow"] != DBNull.Value)
                    objCMS_AdvertisementET.IsNewWindow = Convert.ToInt32(oReader["IsNewWindow"]);
                if (oReader["BeginDate"] != DBNull.Value)
                    objCMS_AdvertisementET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                if (oReader["EndDate"] != DBNull.Value)
                    objCMS_AdvertisementET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                if (oReader["Monery"] != DBNull.Value)
                    objCMS_AdvertisementET.Monery = Convert.ToInt64(oReader["Monery"]);
                if (oReader["Hits"] != DBNull.Value)
                    objCMS_AdvertisementET.Hits = Convert.ToInt32(oReader["Hits"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_AdvertisementET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["PortalID"] != DBNull.Value)
                    objCMS_AdvertisementET.PortalID = Convert.ToString(oReader["PortalID"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_AdvertisementET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_AdvertisementET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_AdvertisementET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_AdvertisementET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_AdvertisementET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", "setProperties", ex.Message);
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
        public List<CMS_AdvertisementET> GetAll_CMS_Advertisement_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_AdvertisementET> lstCMS_AdvertisementET = new List<CMS_AdvertisementET>();
                DataTable tblCMS_AdvertisementET = GetTableByProcedurePaging("sp_CMS_Advertisement_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_AdvertisementET.Rows.Count; i++)
                {
                    lstCMS_AdvertisementET.Add(setProperties(tblCMS_AdvertisementET.Rows[i]));
                }
                return lstCMS_AdvertisementET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " GetAll_.._Paging", ex.Message);
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
        public List<CMS_AdvertisementET> GetAll_CMS_Advertisement()
        {
            try
            {
                List<CMS_AdvertisementET> lstCMS_AdvertisementET = new List<CMS_AdvertisementET>();
                DataTable tblCMS_AdvertisementET = GetTableByProcedure("sp_GetAll_CMS_Advertisement");
                for (int i = 0; i < tblCMS_AdvertisementET.Rows.Count; i++)
                {
                    lstCMS_AdvertisementET.Add(setProperties(tblCMS_AdvertisementET.Rows[i]));
                }
                return lstCMS_AdvertisementET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " GetAll_..", ex.Message);
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
        public CMS_AdvertisementET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_AdvertisementET objCMS_AdvertisementET = new CMS_AdvertisementET();
                DataTable tblCMS_AdvertisementET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Advertisement", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["AdvertisementID"] != DBNull.Value)
                            objCMS_AdvertisementET.AdvertisementID = new Guid(Convert.ToString(oReader["AdvertisementID"]));
                        if (oReader["MenuID"] != DBNull.Value)
                            objCMS_AdvertisementET.MenuID = new Guid(Convert.ToString(oReader["MenuID"]));
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_AdvertisementET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Description"] != DBNull.Value)
                            objCMS_AdvertisementET.Description = Convert.ToString(oReader["Description"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_AdvertisementET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["AdvertisementPosition"] != DBNull.Value)
                            objCMS_AdvertisementET.AdvertisementPosition = Convert.ToInt32(oReader["AdvertisementPosition"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_AdvertisementET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ImageSize"] != DBNull.Value)
                            objCMS_AdvertisementET.ImageSize = Convert.ToString(oReader["ImageSize"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_AdvertisementET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        if (oReader["ImageTitle"] != DBNull.Value)
                            objCMS_AdvertisementET.ImageTitle = Convert.ToString(oReader["ImageTitle"]);
                        if (oReader["Language"] != DBNull.Value)
                            objCMS_AdvertisementET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Link"] != DBNull.Value)
                            objCMS_AdvertisementET.Link = Convert.ToString(oReader["Link"]);
                        if (oReader["IsNewWindow"] != DBNull.Value)
                            objCMS_AdvertisementET.IsNewWindow = Convert.ToInt32(oReader["IsNewWindow"]);
                        if (oReader["BeginDate"] != DBNull.Value)
                            objCMS_AdvertisementET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                        if (oReader["EndDate"] != DBNull.Value)
                            objCMS_AdvertisementET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                        if (oReader["Monery"] != DBNull.Value)
                            objCMS_AdvertisementET.Monery = Convert.ToInt64(oReader["Monery"]);
                        if (oReader["Hits"] != DBNull.Value)
                            objCMS_AdvertisementET.Hits = Convert.ToInt32(oReader["Hits"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_AdvertisementET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["PortalID"] != DBNull.Value)
                            objCMS_AdvertisementET.PortalID = Convert.ToString(oReader["PortalID"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_AdvertisementET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_AdvertisementET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_AdvertisementET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_AdvertisementET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_AdvertisementET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Update(CMS_AdvertisementET objCMS_AdvertisementET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_CMS_Advertisement"
                         , objCMS_AdvertisementET.AdvertisementID
                         , objCMS_AdvertisementET.MenuID
                         , objCMS_AdvertisementET.Title
                         , objCMS_AdvertisementET.Description
                         , objCMS_AdvertisementET.UsedState
                         , objCMS_AdvertisementET.AdvertisementPosition
                         , objCMS_AdvertisementET.Ordinal
                         , objCMS_AdvertisementET.ImageSize
                         , objCMS_AdvertisementET.ImageURL
                         , objCMS_AdvertisementET.ImageTitle
                         , objCMS_AdvertisementET.Language
                         , objCMS_AdvertisementET.Link
                         , objCMS_AdvertisementET.IsNewWindow
                         , objCMS_AdvertisementET.BeginDate
                         , objCMS_AdvertisementET.EndDate
                         , objCMS_AdvertisementET.Monery
                         , objCMS_AdvertisementET.Hits
                         , objCMS_AdvertisementET.Note
                         , objCMS_AdvertisementET.PortalID
                         , objCMS_AdvertisementET.CreatedDate
                         , objCMS_AdvertisementET.CreatedBy
                         , objCMS_AdvertisementET.ModifiedDate
                         , objCMS_AdvertisementET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_AdvertisementET objCMS_AdvertisementET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_Advertisement", "AdvertisementID"
                         , objCMS_AdvertisementET.MenuID
                         , objCMS_AdvertisementET.Title
                         , objCMS_AdvertisementET.Description
                         , objCMS_AdvertisementET.UsedState
                         , objCMS_AdvertisementET.AdvertisementPosition
                         , objCMS_AdvertisementET.Ordinal
                         , objCMS_AdvertisementET.ImageSize
                         , objCMS_AdvertisementET.ImageURL
                         , objCMS_AdvertisementET.ImageTitle
                         , objCMS_AdvertisementET.Language
                         , objCMS_AdvertisementET.Link
                         , objCMS_AdvertisementET.IsNewWindow
                         , objCMS_AdvertisementET.BeginDate
                         , objCMS_AdvertisementET.EndDate
                         , objCMS_AdvertisementET.Monery
                         , objCMS_AdvertisementET.Hits
                         , objCMS_AdvertisementET.Note
                         , objCMS_AdvertisementET.PortalID
                         , objCMS_AdvertisementET.CreatedDate
                         , objCMS_AdvertisementET.CreatedBy
                         , objCMS_AdvertisementET.ModifiedDate
                         , objCMS_AdvertisementET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Advertisement", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

        public DataTable GetAdvertismentByPosition(string CurrentLanguage, short TotalItems, short BannerPosition)
        {
            try
            {
                DataTable tblCMS_AdvertisementET = GetTableByProcedure("sp_Presentation_AdvertisementGetByPosition", CurrentLanguage, TotalItems, BannerPosition);
                return tblCMS_AdvertisementET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_AdvertisementDA", " GetAdvertismentByPosition", ex.Message);
                throw ex;
            }
        }
    }
}

