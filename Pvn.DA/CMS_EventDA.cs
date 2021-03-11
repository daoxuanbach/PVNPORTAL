using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;

namespace Pvn.DA
{
    public class CMS_EventDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		16/05/2017		Tạo mới
        ///</Modified>
        private CMS_EventET setProperties(DataRow oReader)
        {
            try
            {
                CMS_EventET objCMS_EventET = new CMS_EventET();
                if (oReader["EventID"] != DBNull.Value)
                    objCMS_EventET.EventID = Convert.ToInt32(oReader["EventID"]);
                if (oReader["Name"] != DBNull.Value)
                    objCMS_EventET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["Body"] != DBNull.Value)
                    objCMS_EventET.Body = Convert.ToString(oReader["Body"]);
                if (oReader["BeginDate"] != DBNull.Value)
                    objCMS_EventET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                if (oReader["EndDate"] != DBNull.Value)
                    objCMS_EventET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                if (oReader["EventType"] != DBNull.Value)
                    objCMS_EventET.EventType = Convert.ToInt32(oReader["EventType"]);
                if (oReader["EventPlace"] != DBNull.Value)
                    objCMS_EventET.EventPlace = Convert.ToString(oReader["EventPlace"]);
                if (oReader["OrgaUnit"] != DBNull.Value)
                    objCMS_EventET.OrgaUnit = Convert.ToString(oReader["OrgaUnit"]);
                if (oReader["Estimate"] != DBNull.Value)
                    objCMS_EventET.Estimate = Convert.ToBoolean(oReader["Estimate"]);
                if (oReader["FilePath"] != DBNull.Value)
                    objCMS_EventET.FilePath = Convert.ToString(oReader["FilePath"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_EventET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_EventET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_EventET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_EventET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_EventET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_EventET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                return objCMS_EventET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public DataSet GetEventByID(int eventID, int totalOtherItems)
        {
            try
            {
                DataSet dt = GetDatasetByProcedure("dbo.sp_Presentation_EventAnnouncementGetByID", eventID, totalOtherItems);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetEventByID", ex.Message);

                return null;
            }
        }

        /// <summary>
        /// Get Event search paging
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventAnnouncementSearchPaging(Guid categoryID, int pageIndex, int rowsInPage, ref int totalRecords)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_EventAnnouncementSearchPaging", categoryID, pageIndex, rowsInPage);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetEventAnnouncementSearchPaging", ex.Message);

                return null;
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
        ///Bachdx		16/05/2017		Tạo mới
        ///</Modified>
        public DataTable GetSearchPaging(
                       string currentLanguage,
                       string orderByColumn,
                       int pageIndex,
                       int rowsInPage,
                       out long totalRows,
                       string name,
                       bool thongcao,
                       short? EventType,
                       DateTime? StartBeginDate,
                        DateTime? EndBeginDate,
                         DateTime? StartEndDate,
                        DateTime? EndEndDate,
                        int? CreatedBy,
                        int? ModifiedBy,
                        DateTime? CreatedDateFrom,
                        DateTime? CreatedDateTo,
                         bool? Estimate
                    )
        {
            DataTable dt;
            totalRows = 0;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Event_SearchPaging",
                    currentLanguage,
                       orderByColumn,
                       pageIndex,
                       rowsInPage,
                        name,
                       thongcao,
                       EventType,
                       StartBeginDate,
                        EndBeginDate,
                      StartEndDate,
                       EndEndDate,
                         CreatedBy,
                        ModifiedBy,
                        CreatedDateFrom,
                        CreatedDateTo,
                        Estimate
                   );

                if (dt != null && dt.Rows.Count > 0)
                {

                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", " GetAll_..", ex.Message);
                totalRows = 0;
                return null;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		16/05/2017		Tạo mới
        ///</Modified>
        public List<CMS_EventET> GetAll_CMS_Event()
        {
            try
            {
                List<CMS_EventET> lstCMS_EventET = new List<CMS_EventET>();
                DataTable tblCMS_EventET = GetTableByProcedure("sp_GetAll_CMS_Event");
                for (int i = 0; i < tblCMS_EventET.Rows.Count; i++)
                {
                    lstCMS_EventET.Add(setProperties(tblCMS_EventET.Rows[i]));
                }
                return lstCMS_EventET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", " GetAll_..", ex.Message);
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
        ///Bachdx		16/05/2017Tạo mới
        ///</Modified>
        public CMS_EventET GetInfo(int intItemID)
        {
            try
            {
                CMS_EventET objCMS_EventET = new CMS_EventET();
                DataTable tblCMS_EventET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Event", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["EventID"] != DBNull.Value)
                            objCMS_EventET.EventID = Convert.ToInt32(oReader["EventID"]);
                        if (oReader["Name"] != DBNull.Value)
                            objCMS_EventET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["Body"] != DBNull.Value)
                            objCMS_EventET.Body = Convert.ToString(oReader["Body"]);
                        if (oReader["BeginDate"] != DBNull.Value)
                            objCMS_EventET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                        if (oReader["EndDate"] != DBNull.Value)
                            objCMS_EventET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                        if (oReader["EventType"] != DBNull.Value)
                            objCMS_EventET.EventType = Convert.ToInt32(oReader["EventType"]);
                        if (oReader["EventPlace"] != DBNull.Value)
                            objCMS_EventET.EventPlace = Convert.ToString(oReader["EventPlace"]);
                        if (oReader["OrgaUnit"] != DBNull.Value)
                            objCMS_EventET.OrgaUnit = Convert.ToString(oReader["OrgaUnit"]);
                        if (oReader["Estimate"] != DBNull.Value)
                            objCMS_EventET.Estimate = Convert.ToBoolean(oReader["Estimate"]);
                        if (oReader["FilePath"] != DBNull.Value)
                            objCMS_EventET.FilePath = Convert.ToString(oReader["FilePath"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_EventET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_EventET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_EventET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_EventET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_EventET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_EventET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        return objCMS_EventET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_EventET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		16/05/2017Tạo mới
        ///</Modified>
        ///
        public MessageUtil Update(CMS_EventET objCMS_EventET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Event"
                        , objCMS_EventET.EventID
                         , objCMS_EventET.Name
                         , objCMS_EventET.Body
                         , objCMS_EventET.BeginDate
                         , objCMS_EventET.EndDate
                         , objCMS_EventET.EventType
                         , objCMS_EventET.EventPlace
                         , objCMS_EventET.OrgaUnit
                         , objCMS_EventET.Estimate
                         , objCMS_EventET.FilePath
                         , objCMS_EventET.Note
                         , objCMS_EventET.CreatedBy
                         , objCMS_EventET.CreatedDate
                         , objCMS_EventET.ModifiedBy
                         , objCMS_EventET.ModifiedDate
                         , objCMS_EventET.Ordinal))
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
        ///<param name="CMS_EventET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		16/05/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_EventET objCMS_EventET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_Event", "EventID"
                         , objCMS_EventET.Name
                         , objCMS_EventET.Body
                         , objCMS_EventET.BeginDate
                         , objCMS_EventET.EndDate
                         , objCMS_EventET.EventType
                         , objCMS_EventET.EventPlace
                         , objCMS_EventET.OrgaUnit
                         , objCMS_EventET.Estimate
                         , objCMS_EventET.FilePath
                         , objCMS_EventET.Note
                         , objCMS_EventET.CreatedBy
                         , objCMS_EventET.CreatedDate
                         , objCMS_EventET.ModifiedBy
                         , objCMS_EventET.ModifiedDate
                         , objCMS_EventET.Ordinal
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", " Insert", ex.Message);
                return false;
            }
        }
        public MessageUtil Delete(int ItemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {

                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Event", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_EventDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}

