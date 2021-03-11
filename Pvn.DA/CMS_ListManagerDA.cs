using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ListManagerDA : Pvn.DA.DataProvider
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
        private CMS_ListManagerET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ListManagerET objCMS_ListManagerET = new CMS_ListManagerET();
                if (oReader["ManagerID"] != DBNull.Value)
                    objCMS_ListManagerET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                if (oReader["Code"] != DBNull.Value)
                    objCMS_ListManagerET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Name"] != DBNull.Value)
                    objCMS_ListManagerET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["ShortName"] != DBNull.Value)
                    objCMS_ListManagerET.ShortName = Convert.ToString(oReader["ShortName"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_ListManagerET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["ManagerType"] != DBNull.Value)
                    objCMS_ListManagerET.ManagerType = Convert.ToInt32(oReader["ManagerType"]);
                if (oReader["IconPath"] != DBNull.Value)
                    objCMS_ListManagerET.IconPath = Convert.ToString(oReader["IconPath"]);
                if (oReader["Information"] != DBNull.Value)
                    objCMS_ListManagerET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_ListManagerET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_ListManagerET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_ListManagerET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_ListManagerET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_ListManagerET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["WorkerID"] != DBNull.Value)
                    objCMS_ListManagerET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                return objCMS_ListManagerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        public DataTable GetAllByManagerID(int _managerID)
        {
            DataTable dt;
            try
            {

                return dt = GetTableByProcedure("sp_CMS_ListManagerType_GetAllByManagerID", _managerID);

            }
            catch (Exception)
            {
                return dt = new DataTable();
                throw;
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
                    string code,
                    string name,
                    string shortname,
                    short? ordinal,
                    short? managertype,
                    int? createdBy,
                    int? modifiedBy,
                    DateTime? createdDateFrom,
                    DateTime? createdDateTo,
                    short? usedState)
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_ListManager_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    code,
                    name,
                    shortname,
                    ordinal,
                    managertype,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo,
                    usedState);

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
        public DataTable GetAll_CMS_ListManager()
        {
            try
            {
                List<CMS_ListManagerET> lstCMS_ListManagerET = new List<CMS_ListManagerET>();
                DataTable tblCMS_ListManagerET = GetTableByProcedure("sp_GetAll_CMS_ListManager");
                return tblCMS_ListManagerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", " GetAll_CMS_ListManager", ex.Message);
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
        public CMS_ListManagerET GetInfo(int intItemID)
        {
            try
            {
                CMS_ListManagerET objCMS_ListManagerET = new CMS_ListManagerET();
                DataTable tblCMS_ListManagerET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ListManager", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ManagerID"] != DBNull.Value)
                            objCMS_ListManagerET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                        if (oReader["Code"] != DBNull.Value)
                            objCMS_ListManagerET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Name"] != DBNull.Value)
                            objCMS_ListManagerET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["ShortName"] != DBNull.Value)
                            objCMS_ListManagerET.ShortName = Convert.ToString(oReader["ShortName"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_ListManagerET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["ManagerType"] != DBNull.Value)
                            objCMS_ListManagerET.ManagerType = Convert.ToInt32(oReader["ManagerType"]);
                        if (oReader["IconPath"] != DBNull.Value)
                            objCMS_ListManagerET.IconPath = Convert.ToString(oReader["IconPath"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_ListManagerET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_ListManagerET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_ListManagerET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_ListManagerET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_ListManagerET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_ListManagerET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["WorkerID"] != DBNull.Value)
                            objCMS_ListManagerET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                        return objCMS_ListManagerET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ListManagerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ListManagerET objCMS_ListManagerET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ListManager"
                         , objCMS_ListManagerET.ManagerID
                         , objCMS_ListManagerET.Code
                         , objCMS_ListManagerET.Name
                         , objCMS_ListManagerET.ShortName
                         , objCMS_ListManagerET.Ordinal
                         , objCMS_ListManagerET.ManagerType
                         , objCMS_ListManagerET.IconPath
                         , objCMS_ListManagerET.Information
                         , objCMS_ListManagerET.CreatedBy
                         , objCMS_ListManagerET.CreatedDate
                         , objCMS_ListManagerET.ModifiedBy
                         , objCMS_ListManagerET.ModifiedDate
                         , objCMS_ListManagerET.UsedState
                         , objCMS_ListManagerET.WorkerID
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ListManagerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		18/08/2017Tạo mới
        ///</Modified>
        public int Insert(CMS_ListManagerET objCMS_ListManagerET)
        {
            try
            {
             return  ExecuteNonQueryOut("sp_Add_CMS_ListManager", "ManagerID"
                         , objCMS_ListManagerET.Code
                         , objCMS_ListManagerET.Name
                         , objCMS_ListManagerET.ShortName
                         , objCMS_ListManagerET.Ordinal
                         , objCMS_ListManagerET.ManagerType
                         , objCMS_ListManagerET.IconPath
                         , objCMS_ListManagerET.Information
                         , objCMS_ListManagerET.CreatedBy
                         , objCMS_ListManagerET.CreatedDate
                         , objCMS_ListManagerET.ModifiedBy
                         , objCMS_ListManagerET.ModifiedDate
                         , objCMS_ListManagerET.UsedState
                         , objCMS_ListManagerET.WorkerID
                );
              
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ListManagerET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ListManager", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
