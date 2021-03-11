using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_News_KeywordDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/06/2016		Tạo mới
        ///</Modified>
        private CMS_News_KeywordET setProperties(DataRow oReader)
        {
            try
            {
                CMS_News_KeywordET objCMS_News_KeywordET = new CMS_News_KeywordET();
                if (oReader["News_KeywordID"] != DBNull.Value)
                    objCMS_News_KeywordET.News_KeywordID = new Guid(Convert.ToString(oReader["News_KeywordID"]));
                if (oReader["NewsID"] != DBNull.Value)
                    objCMS_News_KeywordET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                if (oReader["Version"] != DBNull.Value)
                    objCMS_News_KeywordET.Version = Convert.ToInt32(oReader["Version"]);
                if (oReader["KeywordID"] != DBNull.Value)
                    objCMS_News_KeywordET.KeywordID = new Guid(Convert.ToString(oReader["KeywordID"]));
                if (oReader["Keyword"] != DBNull.Value)
                    objCMS_News_KeywordET.Keyword = Convert.ToString(oReader["Keyword"]);
                if (oReader["KeywordIndex"] != DBNull.Value)
                    objCMS_News_KeywordET.KeywordIndex = Convert.ToString(oReader["KeywordIndex"]);
                if (oReader["KeywordNoSign"] != DBNull.Value)
                    objCMS_News_KeywordET.KeywordNoSign = Convert.ToString(oReader["KeywordNoSign"]);
                if (oReader["Hits"] != DBNull.Value)
                    objCMS_News_KeywordET.Hits = Convert.ToInt32(oReader["Hits"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_News_KeywordET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_News_KeywordET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_News_KeywordET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_News_KeywordET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_News_KeywordET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_News_KeywordET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", "setProperties", ex.Message);
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
        ///Bachdx		24/06/2016		Tạo mới
        ///</Modified>
        public List<CMS_News_KeywordET> GetAll_CMS_News_Keyword_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_News_KeywordET> lstCMS_News_KeywordET = new List<CMS_News_KeywordET>();
                DataTable tblCMS_News_KeywordET = GetTableByProcedurePaging("sp_CMS_News_Keyword_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_News_KeywordET.Rows.Count; i++)
                {
                    lstCMS_News_KeywordET.Add(setProperties(tblCMS_News_KeywordET.Rows[i]));
                }
                return lstCMS_News_KeywordET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/06/2016		Tạo mới
        ///</Modified>
        public List<CMS_News_KeywordET> GetAll_CMS_News_Keyword()
        {
            try
            {
                List<CMS_News_KeywordET> lstCMS_News_KeywordET = new List<CMS_News_KeywordET>();
                DataTable tblCMS_News_KeywordET = GetTableByProcedure("sp_GetAll_CMS_News_Keyword");
                for (int i = 0; i < tblCMS_News_KeywordET.Rows.Count; i++)
                {
                    lstCMS_News_KeywordET.Add(setProperties(tblCMS_News_KeywordET.Rows[i]));
                }
                return lstCMS_News_KeywordET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " GetAll_..", ex.Message);
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
        ///Bachdx		24/06/2016Tạo mới
        ///</Modified>
        public CMS_News_KeywordET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_News_KeywordET objCMS_News_KeywordET = new CMS_News_KeywordET();
                DataTable tblCMS_News_KeywordET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_News_Keyword", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["News_KeywordID"] != DBNull.Value)
                            objCMS_News_KeywordET.News_KeywordID = new Guid(Convert.ToString(oReader["News_KeywordID"]));
                        if (oReader["NewsID"] != DBNull.Value)
                            objCMS_News_KeywordET.NewsID = new Guid(Convert.ToString(oReader["NewsID"]));
                        if (oReader["Version"] != DBNull.Value)
                            objCMS_News_KeywordET.Version = Convert.ToInt32(oReader["Version"]);
                        if (oReader["KeywordID"] != DBNull.Value)
                            objCMS_News_KeywordET.KeywordID = new Guid(Convert.ToString(oReader["KeywordID"]));
                        if (oReader["Keyword"] != DBNull.Value)
                            objCMS_News_KeywordET.Keyword = Convert.ToString(oReader["Keyword"]);
                        if (oReader["KeywordIndex"] != DBNull.Value)
                            objCMS_News_KeywordET.KeywordIndex = Convert.ToString(oReader["KeywordIndex"]);
                        if (oReader["KeywordNoSign"] != DBNull.Value)
                            objCMS_News_KeywordET.KeywordNoSign = Convert.ToString(oReader["KeywordNoSign"]);
                        if (oReader["Hits"] != DBNull.Value)
                            objCMS_News_KeywordET.Hits = Convert.ToInt32(oReader["Hits"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_News_KeywordET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_News_KeywordET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_News_KeywordET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_News_KeywordET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_News_KeywordET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_News_KeywordET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_News_KeywordET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/06/2016Tạo mới
        ///</Modified>
        public bool Update(CMS_News_KeywordET objCMS_News_KeywordET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_CMS_News_Keyword"
                         , objCMS_News_KeywordET.News_KeywordID
                         , objCMS_News_KeywordET.NewsID
                         , objCMS_News_KeywordET.Version
                         , objCMS_News_KeywordET.KeywordID
                         , objCMS_News_KeywordET.Keyword
                         , objCMS_News_KeywordET.KeywordIndex
                         , objCMS_News_KeywordET.KeywordNoSign
                         , objCMS_News_KeywordET.Hits
                         , objCMS_News_KeywordET.Note
                         , objCMS_News_KeywordET.CreatedDate
                         , objCMS_News_KeywordET.CreatedBy
                         , objCMS_News_KeywordET.ModifiedDate
                         , objCMS_News_KeywordET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_News_KeywordET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/06/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_News_KeywordET objCMS_News_KeywordET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_News_Keyword", "News_KeywordID"
                         , objCMS_News_KeywordET.NewsID
                         , objCMS_News_KeywordET.Version
                         , objCMS_News_KeywordET.KeywordID
                         , objCMS_News_KeywordET.Keyword
                         , objCMS_News_KeywordET.KeywordIndex
                         , objCMS_News_KeywordET.KeywordNoSign
                         , objCMS_News_KeywordET.Hits
                         , objCMS_News_KeywordET.Note
                         , objCMS_News_KeywordET.CreatedDate
                         , objCMS_News_KeywordET.CreatedBy
                         , objCMS_News_KeywordET.ModifiedDate
                         , objCMS_News_KeywordET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_News_KeywordET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/06/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteByIdNews(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByIdNews_CMS_News_Keyword", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

