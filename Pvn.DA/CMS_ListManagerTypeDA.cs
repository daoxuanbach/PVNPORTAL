using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_ListManagerTypeDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/09/2017		Tạo mới
        ///</Modified>
        private CMS_ListManagerTypeET setProperties(DataRow oReader)
        {
            try
            {
                CMS_ListManagerTypeET objCMS_ListManagerTypeET = new CMS_ListManagerTypeET();
                if (oReader["ManagerTypeID"] != DBNull.Value)
                    objCMS_ListManagerTypeET.ManagerTypeID = Convert.ToInt32(oReader["ManagerTypeID"]);
                if (oReader["ManagerID"] != DBNull.Value)
                    objCMS_ListManagerTypeET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                if (oReader["ManagerType"] != DBNull.Value)
                    objCMS_ListManagerTypeET.ManagerType = Convert.ToInt32(oReader["ManagerType"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_ListManagerTypeET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["JobTitle"] != DBNull.Value)
                    objCMS_ListManagerTypeET.JobTitle = Convert.ToInt32(oReader["JobTitle"]);
                if (oReader["JobTitleName"] != DBNull.Value)
                    objCMS_ListManagerTypeET.JobTitleName = Convert.ToString(oReader["JobTitleName"]);
                return objCMS_ListManagerTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", "setProperties", ex.Message);
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
        ///Bachdx		10/09/2017		Tạo mới
        ///</Modified>
        public List<CMS_ListManagerTypeET> GetAll_CMS_ListManagerType_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_ListManagerTypeET> lstCMS_ListManagerTypeET = new List<CMS_ListManagerTypeET>();
                DataTable tblCMS_ListManagerTypeET = GetTableByProcedurePaging("sp_CMS_ListManagerType_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_ListManagerTypeET.Rows.Count; i++)
                {
                    lstCMS_ListManagerTypeET.Add(setProperties(tblCMS_ListManagerTypeET.Rows[i]));
                }
                return lstCMS_ListManagerTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }

       

        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/09/2017		Tạo mới
        ///</Modified>
        public List<CMS_ListManagerTypeET> GetAll_CMS_ListManagerType()
        {
            try
            {
                List<CMS_ListManagerTypeET> lstCMS_ListManagerTypeET = new List<CMS_ListManagerTypeET>();
                DataTable tblCMS_ListManagerTypeET = GetTableByProcedure("sp_GetAll_CMS_ListManagerType");
                for (int i = 0; i < tblCMS_ListManagerTypeET.Rows.Count; i++)
                {
                    lstCMS_ListManagerTypeET.Add(setProperties(tblCMS_ListManagerTypeET.Rows[i]));
                }
                return lstCMS_ListManagerTypeET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " GetAll_..", ex.Message);
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
        ///Bachdx		10/09/2017Tạo mới
        ///</Modified>
        public CMS_ListManagerTypeET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_ListManagerTypeET objCMS_ListManagerTypeET = new CMS_ListManagerTypeET();
                DataTable tblCMS_ListManagerTypeET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_ListManagerType", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ManagerTypeID"] != DBNull.Value)
                            objCMS_ListManagerTypeET.ManagerTypeID = Convert.ToInt32(oReader["ManagerTypeID"]);
                        if (oReader["ManagerID"] != DBNull.Value)
                            objCMS_ListManagerTypeET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                        if (oReader["ManagerType"] != DBNull.Value)
                            objCMS_ListManagerTypeET.ManagerType = Convert.ToInt32(oReader["ManagerType"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_ListManagerTypeET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["JobTitle"] != DBNull.Value)
                            objCMS_ListManagerTypeET.JobTitle = Convert.ToInt32(oReader["JobTitle"]);
                        if (oReader["JobTitleName"] != DBNull.Value)
                            objCMS_ListManagerTypeET.JobTitleName = Convert.ToString(oReader["JobTitleName"]);
                        return objCMS_ListManagerTypeET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ListManagerTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/09/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ListManagerTypeET objCMS_ListManagerTypeET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_ListManagerType"
                         , objCMS_ListManagerTypeET.ManagerTypeID
                         , objCMS_ListManagerTypeET.ManagerID
                         , objCMS_ListManagerTypeET.ManagerType
                         , objCMS_ListManagerTypeET.Ordinal
                         , objCMS_ListManagerTypeET.JobTitle
                         , objCMS_ListManagerTypeET.JobTitleName
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ListManagerTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/09/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_ListManagerTypeET objCMS_ListManagerTypeET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_ListManagerType", "ManagerTypeID"
                         , objCMS_ListManagerTypeET.ManagerID
                         , objCMS_ListManagerTypeET.ManagerType
                         , objCMS_ListManagerTypeET.Ordinal
                         , objCMS_ListManagerTypeET.JobTitle
                         , objCMS_ListManagerTypeET.JobTitleName
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ListManagerTypeET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/09/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_ListManagerType", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
        public MessageUtil DeleteByManagerID(int managerID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_CMS_ListManagerType_DeleteByManagerID", managerID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_ListManagerTypeDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
