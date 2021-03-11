using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_MeetingDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        private CMS_MeetingET setProperties(DataRow oReader)
        {
            try
            {
                CMS_MeetingET objCMS_MeetingET = new CMS_MeetingET();
                if (oReader["MeetingID"] != DBNull.Value)
                    objCMS_MeetingET.MeetingID = Convert.ToInt32(oReader["MeetingID"]);
                if (oReader["MeetingDate"] != DBNull.Value)
                    objCMS_MeetingET.MeetingDate = Convert.ToDateTime(oReader["MeetingDate"]);
                if (oReader["RoomID"] != DBNull.Value)
                    objCMS_MeetingET.RoomID = Convert.ToInt32(oReader["RoomID"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_MeetingET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_MeetingET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["Active"] != DBNull.Value)
                    objCMS_MeetingET.Active = Convert.ToBoolean(oReader["Active"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_MeetingET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_MeetingET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_MeetingET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_MeetingET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objCMS_MeetingET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRows"></param>
        /// <param name="roomName"></param>
        /// <param name="orderNumber"></param>
        /// <param name="active"></param>
        /// <param name="deleted"></param>
        /// <param name="roomAddress"></param>
        /// <param name="createdBy"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="createdDateFrom"></param>
        /// <param name="createdDateTo"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    ref int totalRows,
                    DateTime? dateStart,
                    DateTime? dateEnd,
                    string roomName,
                    int? roomID,
                    string title,
                    string note,
                    bool? active,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Meeting_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    dateStart,
                    dateEnd,
                    roomName,
                    roomID,
                    title,
                    note,
                    active,
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
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        public List<CMS_MeetingET> GetAll_CMS_Meeting()
        {
            try
            {
                List<CMS_MeetingET> lstCMS_MeetingET = new List<CMS_MeetingET>();
                DataTable tblCMS_MeetingET = GetTableByProcedure("sp_GetAll_CMS_Meeting");
                for (int i = 0; i < tblCMS_MeetingET.Rows.Count; i++)
                {
                    lstCMS_MeetingET.Add(setProperties(tblCMS_MeetingET.Rows[i]));
                }
                return lstCMS_MeetingET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", " GetAll_..", ex.Message);
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
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public CMS_MeetingET GetInfo(int intItemID)
        {
            try
            {
                CMS_MeetingET objCMS_MeetingET = new CMS_MeetingET();
                DataTable tblCMS_MeetingET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Meeting", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["MeetingID"] != DBNull.Value)
                            objCMS_MeetingET.MeetingID = Convert.ToInt32(oReader["MeetingID"]);
                        if (oReader["MeetingDate"] != DBNull.Value)
                            objCMS_MeetingET.MeetingDate = Convert.ToDateTime(oReader["MeetingDate"]);
                        if (oReader["RoomID"] != DBNull.Value)
                            objCMS_MeetingET.RoomID = Convert.ToInt32(oReader["RoomID"]);
                        if (oReader["Title"] != DBNull.Value)
                            objCMS_MeetingET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_MeetingET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["Active"] != DBNull.Value)
                            objCMS_MeetingET.Active = Convert.ToBoolean(oReader["Active"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_MeetingET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_MeetingET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_MeetingET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_MeetingET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objCMS_MeetingET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_MeetingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_MeetingET objCMS_MeetingET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Meeting"
                         , objCMS_MeetingET.MeetingID
                         , objCMS_MeetingET.MeetingDate
                         , objCMS_MeetingET.RoomID
                         , objCMS_MeetingET.Title
                         , objCMS_MeetingET.Note
                         , objCMS_MeetingET.Active
                         , objCMS_MeetingET.CreatedBy
                         , objCMS_MeetingET.CreatedDate
                         , objCMS_MeetingET.ModifiedBy
                         , objCMS_MeetingET.ModifiedDate
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_MeetingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_MeetingET objCMS_MeetingET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_Meeting", "MeetingID"
                         , objCMS_MeetingET.MeetingDate
                         , objCMS_MeetingET.RoomID
                         , objCMS_MeetingET.Title
                         , objCMS_MeetingET.Note
                         , objCMS_MeetingET.Active
                         , objCMS_MeetingET.CreatedBy
                         , objCMS_MeetingET.CreatedDate
                         , objCMS_MeetingET.ModifiedBy
                         , objCMS_MeetingET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_MeetingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Meeting", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_MeetingDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
