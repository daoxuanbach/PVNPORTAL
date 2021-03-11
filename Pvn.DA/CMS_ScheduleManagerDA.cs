using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ScheduleManagerDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/09/2017		Tạo mới
        ///</Modified>
        private CMS_ScheduleManagerET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ScheduleManagerET objCMS_ScheduleManagerET = new CMS_ScheduleManagerET();
                if (oReader["SheduleManagerID"] != DBNull.Value)
                    objCMS_ScheduleManagerET.SheduleManagerID = Convert.ToInt32(oReader["SheduleManagerID"]);
                if (oReader["SheduleID"] != DBNull.Value)
                    objCMS_ScheduleManagerET.SheduleID = Convert.ToInt32(oReader["SheduleID"]);
                if (oReader["ManagerID"] != DBNull.Value)
                    objCMS_ScheduleManagerET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                if (oReader["SheduleRole"] != DBNull.Value)
                    objCMS_ScheduleManagerET.SheduleRole = Convert.ToInt32(oReader["SheduleRole"]);
                return objCMS_ScheduleManagerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        public DataSet GetManagerbyScheduleID(
                   int? scheduleID, short? type
           )
        {
            DataSet ds;
            try
            {
                ds = GetDatasetByProcedure("sp_CMS_ScheduleManager_GetManagerbyScheduleID",scheduleID, type);
                return ds;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetManagerbyScheduleID", ex.Message);
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
        ///Bachdx		12/09/2017		Tạo mới
        ///</Modified>
        public List<CMS_ScheduleManagerET> GetAll_CMS_ScheduleManager_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ScheduleManagerET> lstCMS_ScheduleManagerET = new List<CMS_ScheduleManagerET>();
                DataTable tblCMS_ScheduleManagerET = GetTableByProcedurePaging("sp_CMS_ScheduleManager_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ScheduleManagerET.Rows.Count; i++)
                {
                    lstCMS_ScheduleManagerET.Add(setProperties(tblCMS_ScheduleManagerET.Rows[i]));
                }
                return lstCMS_ScheduleManagerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/09/2017		Tạo mới
        ///</Modified>
        public List<CMS_ScheduleManagerET> GetAll_CMS_ScheduleManager()
        {
            try
            {
                List<CMS_ScheduleManagerET> lstCMS_ScheduleManagerET = new List<CMS_ScheduleManagerET>();
                DataTable tblCMS_ScheduleManagerET = GetTableByProcedure("sp_GetAll_CMS_ScheduleManager");
                for (int i = 0; i < tblCMS_ScheduleManagerET.Rows.Count; i++)
                {
                    lstCMS_ScheduleManagerET.Add(setProperties(tblCMS_ScheduleManagerET.Rows[i]));
                }
                return lstCMS_ScheduleManagerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " GetAll_..", ex.Message);
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
        ///Bachdx		12/09/2017Tạo mới
        ///</Modified>
        public CMS_ScheduleManagerET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_ScheduleManagerET objCMS_ScheduleManagerET = new CMS_ScheduleManagerET();
                DataTable tblCMS_ScheduleManagerET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ScheduleManager", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["SheduleManagerID"] != DBNull.Value)
                            objCMS_ScheduleManagerET.SheduleManagerID = Convert.ToInt32(oReader["SheduleManagerID"]);
                        if (oReader["SheduleID"] != DBNull.Value)
                            objCMS_ScheduleManagerET.SheduleID = Convert.ToInt32(oReader["SheduleID"]);
                        if (oReader["ManagerID"] != DBNull.Value)
                            objCMS_ScheduleManagerET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                        if (oReader["SheduleRole"] != DBNull.Value)
                            objCMS_ScheduleManagerET.SheduleRole = Convert.ToInt32(oReader["SheduleRole"]);
                        return objCMS_ScheduleManagerET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ScheduleManagerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/09/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ScheduleManagerET objCMS_ScheduleManagerET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ScheduleManager"
                         , objCMS_ScheduleManagerET.SheduleManagerID
                         , objCMS_ScheduleManagerET.SheduleID
                         , objCMS_ScheduleManagerET.ManagerID
                         , objCMS_ScheduleManagerET.SheduleRole
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ScheduleManagerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/09/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_ScheduleManagerET objCMS_ScheduleManagerET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_ScheduleManager", "SheduleManagerID"
                         , objCMS_ScheduleManagerET.SheduleID
                         , objCMS_ScheduleManagerET.ManagerID
                         , objCMS_ScheduleManagerET.SheduleRole
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ScheduleManagerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/09/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ScheduleManager", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ScheduleManagerDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
        public void RemoveAllManagerByScheduleID(int _scheduleID)
        {
            ExecuteNonQuery("sp_RemoveAll_CMS_ScheduleManagerbyScheduleID", _scheduleID);
        }
    }
}
