using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_SchedulesDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        private CMS_SchedulesET setProperties(DataRow oReader)
        {
            try
            {
                CMS_SchedulesET objCMS_SchedulesET = new CMS_SchedulesET();
                if (oReader["ScheduleID"] != DBNull.Value)
                    objCMS_SchedulesET.ScheduleID = Convert.ToInt32(oReader["ScheduleID"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_SchedulesET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Descriptions"] != DBNull.Value)
                    objCMS_SchedulesET.Descriptions = Convert.ToString(oReader["Descriptions"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_SchedulesET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["BeginDate"] != DBNull.Value)
                    objCMS_SchedulesET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                if (oReader["BeginTime"] != DBNull.Value)
                    objCMS_SchedulesET.BeginTime = Convert.ToDateTime(oReader["BeginTime"]);
                if (oReader["BeginPMAM"] != DBNull.Value)
                    objCMS_SchedulesET.BeginPMAM = Convert.ToInt32(oReader["BeginPMAM"]);
                if (oReader["BeginDayWeek"] != DBNull.Value)
                    objCMS_SchedulesET.BeginDayWeek = Convert.ToInt32(oReader["BeginDayWeek"]);
                if (oReader["EndDate"] != DBNull.Value)
                    objCMS_SchedulesET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                if (oReader["FromAddress"] != DBNull.Value)
                    objCMS_SchedulesET.FromAddress = Convert.ToString(oReader["FromAddress"]);
                if (oReader["ToAddress"] != DBNull.Value)
                    objCMS_SchedulesET.ToAddress = Convert.ToString(oReader["ToAddress"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_SchedulesET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_SchedulesET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_SchedulesET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_SchedulesET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["Active"] != DBNull.Value)
                    objCMS_SchedulesET.Active = Convert.ToBoolean(oReader["Active"]);
                if (oReader["Private"] != DBNull.Value)
                    objCMS_SchedulesET.Private = Convert.ToBoolean(oReader["Private"]);
                return objCMS_SchedulesET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                   string currentLanguage,
                   string orderByColumn,
                   int pageIndex,
                   int rowsInPage,
                   ref int totalRows,
                   string title,
                   string descriptions,
                   DateTime? startbegin,
                   DateTime? endbegin,
                   DateTime? startenddate,
                   DateTime? endenddate,
                   string fromAddress,
                   string toAddress,
                   int? createdBy,
                   int? modifiedBy,
                   DateTime? createdDateFrom,
                   DateTime? createdDateTo)
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Schedules_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    title,
                    descriptions,
                    startbegin,
                    endbegin,
                    startenddate,
                    endenddate,
                    fromAddress,
                    toAddress,
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
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetSearchPaging", ex.Message);

                totalRows = 0;
                return null;
            }
        }
        /// <summary>
        /// get manager
        /// </summary>
        /// <returns></returns>
        public DataTable GetManager()
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetManagers");
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetManager", ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Get Schedule
        /// </summary>
        /// <param name="ScheduleDate"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(int managerID, DateTime? beginDate, DateTime? endDate, string userID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Schedule_GetPaging",
                     managerID, beginDate, endDate, userID);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetManager", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// get schedule for manager
        /// </summary>
        /// <param name="managerType"></param>
        /// <param name="fromDate">Should be in format dd.MM.yyyy</param>
        /// <param name="toDate">Should be in format dd.MM.yyyy</param>
        /// <returns></returns>
        public DataTable GetScheduleForManager(DateTime? currentDate, string userID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Schedule_GetManagers",
                     currentDate, userID);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetScheduleForManager", ex.Message);
                return null;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        public List<CMS_SchedulesET> GetAll_CMS_Schedules()
        {
            try
            {
                List<CMS_SchedulesET> lstCMS_SchedulesET = new List<CMS_SchedulesET>();
                DataTable tblCMS_SchedulesET = GetTableByProcedure("sp_GetAll_CMS_Schedules");
                for (int i = 0; i < tblCMS_SchedulesET.Rows.Count; i++)
                {
                    lstCMS_SchedulesET.Add(setProperties(tblCMS_SchedulesET.Rows[i]));
                }
                return lstCMS_SchedulesET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", " GetAll_..", ex.Message);
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
        ///Bachdx		23/08/2017Tạo mới
        ///</Modified>
        public CMS_SchedulesET GetInfo(int intItemID)
        {
            try
            {
                CMS_SchedulesET objCMS_SchedulesET = new CMS_SchedulesET();
                DataTable tblCMS_SchedulesET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Schedules", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ScheduleID"] != DBNull.Value)
                            objCMS_SchedulesET.ScheduleID = Convert.ToInt32(oReader["ScheduleID"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_SchedulesET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Descriptions"] != DBNull.Value)
                            objCMS_SchedulesET.Descriptions = Convert.ToString(oReader["Descriptions"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_SchedulesET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["BeginDate"] != DBNull.Value)
                            objCMS_SchedulesET.BeginDate = Convert.ToDateTime(oReader["BeginDate"]);
                        if (oReader["BeginTime"] != DBNull.Value)
                            objCMS_SchedulesET.BeginTime = Convert.ToDateTime(oReader["BeginTime"]);
                        if (oReader["BeginPMAM"] != DBNull.Value)
                            objCMS_SchedulesET.BeginPMAM = Convert.ToInt32(oReader["BeginPMAM"]);
                        if (oReader["BeginDayWeek"] != DBNull.Value)
                            objCMS_SchedulesET.BeginDayWeek = Convert.ToInt32(oReader["BeginDayWeek"]);
                        if (oReader["EndDate"] != DBNull.Value)
                            objCMS_SchedulesET.EndDate = Convert.ToDateTime(oReader["EndDate"]);
                        if (oReader["FromAddress"] != DBNull.Value)
                            objCMS_SchedulesET.FromAddress = Convert.ToString(oReader["FromAddress"]);
                        if (oReader["ToAddress"] != DBNull.Value)
                            objCMS_SchedulesET.ToAddress = Convert.ToString(oReader["ToAddress"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_SchedulesET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_SchedulesET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_SchedulesET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_SchedulesET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["Active"] != DBNull.Value)
                            objCMS_SchedulesET.Active = Convert.ToBoolean(oReader["Active"]);
                        if (oReader["Private"] != DBNull.Value)
                            objCMS_SchedulesET.Private = Convert.ToBoolean(oReader["Private"]);
                        return objCMS_SchedulesET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_SchedulesET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_SchedulesET objCMS_SchedulesET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Schedules"
                         , objCMS_SchedulesET.ScheduleID
                         , objCMS_SchedulesET.Title
                         , objCMS_SchedulesET.Descriptions
                         , objCMS_SchedulesET.Note
                         , objCMS_SchedulesET.BeginDate
                         , objCMS_SchedulesET.BeginTime
                         , objCMS_SchedulesET.BeginPMAM
                         , objCMS_SchedulesET.BeginDayWeek
                         , objCMS_SchedulesET.EndDate
                         , objCMS_SchedulesET.FromAddress
                         , objCMS_SchedulesET.ToAddress
                         , objCMS_SchedulesET.CreatedBy
                         , objCMS_SchedulesET.CreatedDate
                         , objCMS_SchedulesET.ModifiedBy
                         , objCMS_SchedulesET.ModifiedDate
                         , objCMS_SchedulesET.Active
                         , objCMS_SchedulesET.Private
                ))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            {
                                objMsg.Error = true;
                                objMsg.Message = Convert.ToString(oReader[0]);
                            }
                        }
                }
                return objMsg;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_SchedulesET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017Tạo mới
        ///</Modified>
        public int Insert(CMS_SchedulesET objCMS_SchedulesET)
        {
            try
            {
               return ExecuteNonQueryOut("sp_Add_CMS_Schedules", "ScheduleID"
                         , objCMS_SchedulesET.Title
                         , objCMS_SchedulesET.Descriptions
                         , objCMS_SchedulesET.Note
                         , objCMS_SchedulesET.BeginDate
                         , objCMS_SchedulesET.BeginTime
                         , objCMS_SchedulesET.BeginPMAM
                         , objCMS_SchedulesET.BeginDayWeek
                         , objCMS_SchedulesET.EndDate
                         , objCMS_SchedulesET.FromAddress
                         , objCMS_SchedulesET.ToAddress
                         , objCMS_SchedulesET.CreatedBy
                         , objCMS_SchedulesET.CreatedDate
                         , objCMS_SchedulesET.ModifiedBy
                         , objCMS_SchedulesET.ModifiedDate
                         , objCMS_SchedulesET.Active
                         , objCMS_SchedulesET.Private
                );
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_SchedulesET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int itemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Schedules", itemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_SchedulesDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
