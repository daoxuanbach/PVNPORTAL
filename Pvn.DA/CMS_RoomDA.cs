using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_RoomDA : Pvn.DA.DataProvider
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
        private CMS_RoomET setProperties(DataRow oReader)
        {
            try
            {
                CMS_RoomET objCMS_RoomET = new CMS_RoomET();
                if (oReader["RoomID"] != DBNull.Value)
                    objCMS_RoomET.RoomID = Convert.ToInt32(oReader["RoomID"]);
                if (oReader["RoomCode"] != DBNull.Value)
                    objCMS_RoomET.RoomCode = Convert.ToString(oReader["RoomCode"]);
                if (oReader["RoomName"] != DBNull.Value)
                    objCMS_RoomET.RoomName = Convert.ToString(oReader["RoomName"]);
                if (oReader["OrderNumber"] != DBNull.Value)
                    objCMS_RoomET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                if (oReader["Active"] != DBNull.Value)
                    objCMS_RoomET.Active = Convert.ToBoolean(oReader["Active"]);
                if (oReader["Deleted"] != DBNull.Value)
                    objCMS_RoomET.Deleted = Convert.ToBoolean(oReader["Deleted"]);
                if (oReader["RoomAddress"] != DBNull.Value)
                    objCMS_RoomET.RoomAddress = Convert.ToString(oReader["RoomAddress"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_RoomET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_RoomET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_RoomET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_RoomET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objCMS_RoomET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", "setProperties", ex.Message);
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
                    out long totalRows,
                    string roomName,
                    int? orderNumber,
                    bool? active,
                    bool? deleted,
                    string roomAddress,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo)
        {
            DataTable dt;
            totalRows = 0;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Room_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    roomName,
                    orderNumber,
                    active,
                    deleted,
                    roomAddress,
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
        public DataTable GetAll_CMS_Room()
        {
            try
            {
               // List<CMS_RoomET> lstCMS_RoomET = new List<CMS_RoomET>();
                DataTable tblCMS_RoomET = GetTableByProcedure("sp_GetAll_CMS_Room");
                //for (int i = 0; i < tblCMS_RoomET.Rows.Count; i++)
                //{
                //    lstCMS_RoomET.Add(setProperties(tblCMS_RoomET.Rows[i]));
                //}
                return tblCMS_RoomET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", " GetAll_..", ex.Message);
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
        public CMS_RoomET GetInfo(int intItemID)
        {
            try
            {
                CMS_RoomET objCMS_RoomET = new CMS_RoomET();
                DataTable tblCMS_RoomET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Room", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["RoomID"] != DBNull.Value)
                            objCMS_RoomET.RoomID = Convert.ToInt32(oReader["RoomID"]);
                        if (oReader["RoomCode"] != DBNull.Value)
                            objCMS_RoomET.RoomCode = Convert.ToString(oReader["RoomCode"]);
                        if (oReader["RoomName"] != DBNull.Value)
                            objCMS_RoomET.RoomName = Convert.ToString(oReader["RoomName"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_RoomET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        if (oReader["Active"] != DBNull.Value)
                            objCMS_RoomET.Active = Convert.ToBoolean(oReader["Active"]);
                        if (oReader["Deleted"] != DBNull.Value)
                            objCMS_RoomET.Deleted = Convert.ToBoolean(oReader["Deleted"]);
                        if (oReader["RoomAddress"] != DBNull.Value)
                            objCMS_RoomET.RoomAddress = Convert.ToString(oReader["RoomAddress"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_RoomET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_RoomET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_RoomET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_RoomET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objCMS_RoomET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_RoomET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_RoomET objCMS_RoomET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Room"
                         , objCMS_RoomET.RoomID
                         , objCMS_RoomET.RoomCode
                         , objCMS_RoomET.RoomName
                         , objCMS_RoomET.OrderNumber
                         , objCMS_RoomET.Active
                         , objCMS_RoomET.Deleted
                         , objCMS_RoomET.RoomAddress
                         , objCMS_RoomET.CreatedBy
                         , objCMS_RoomET.CreatedDate
                         , objCMS_RoomET.ModifiedBy
                         , objCMS_RoomET.ModifiedDate
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_RoomET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_RoomET objCMS_RoomET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_Room", "RoomID"
                         , objCMS_RoomET.RoomCode
                         , objCMS_RoomET.RoomName
                         , objCMS_RoomET.OrderNumber
                         , objCMS_RoomET.Active
                         , objCMS_RoomET.Deleted
                         , objCMS_RoomET.RoomAddress
                         , objCMS_RoomET.CreatedBy
                         , objCMS_RoomET.CreatedDate
                         , objCMS_RoomET.ModifiedBy
                         , objCMS_RoomET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_RoomET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Room", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_RoomDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
