using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_CompanyJobTitleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2017		Tạo mới
        ///</Modified>
        private CMS_CompanyJobTitleET setProperties(DataRow oReader)
        {
            try
            {
                CMS_CompanyJobTitleET objCMS_CompanyJobTitleET = new CMS_CompanyJobTitleET();
                if (oReader["CompanyJobID"] != DBNull.Value)
                    objCMS_CompanyJobTitleET.CompanyJobID = Convert.ToInt32(oReader["CompanyJobID"]);
                if (oReader["CompanyID"] != DBNull.Value)
                    objCMS_CompanyJobTitleET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                if (oReader["JobTitleID"] != DBNull.Value)
                    objCMS_CompanyJobTitleET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                if (oReader["WorkerID"] != DBNull.Value)
                    objCMS_CompanyJobTitleET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                if (oReader["OrderNumber"] != DBNull.Value)
                    objCMS_CompanyJobTitleET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                return objCMS_CompanyJobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", "setProperties", ex.Message);
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
        ///Bachdx		17/08/2017		Tạo mới
        ///</Modified>
        public List<CMS_CompanyJobTitleET> GetAll_CMS_CompanyJobTitle_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_CompanyJobTitleET> lstCMS_CompanyJobTitleET = new List<CMS_CompanyJobTitleET>();
                DataTable tblCMS_CompanyJobTitleET = GetTableByProcedurePaging("sp_CMS_CompanyJobTitle_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_CompanyJobTitleET.Rows.Count; i++)
                {
                    lstCMS_CompanyJobTitleET.Add(setProperties(tblCMS_CompanyJobTitleET.Rows[i]));
                }
                return lstCMS_CompanyJobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2017		Tạo mới
        ///</Modified>
        public List<CMS_CompanyJobTitleET> GetAll_CMS_CompanyJobTitle()
        {
            try
            {
                List<CMS_CompanyJobTitleET> lstCMS_CompanyJobTitleET = new List<CMS_CompanyJobTitleET>();
                DataTable tblCMS_CompanyJobTitleET = GetTableByProcedure("sp_GetAll_CMS_CompanyJobTitle");
                for (int i = 0; i < tblCMS_CompanyJobTitleET.Rows.Count; i++)
                {
                    lstCMS_CompanyJobTitleET.Add(setProperties(tblCMS_CompanyJobTitleET.Rows[i]));
                }
                return lstCMS_CompanyJobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		17/08/2017Tạo mới
        ///</Modified>
        public CMS_CompanyJobTitleET GetInfo(Guid intItemID)
        {
            try
            {
                CMS_CompanyJobTitleET objCMS_CompanyJobTitleET = new CMS_CompanyJobTitleET();
                DataTable tblCMS_CompanyJobTitleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_CompanyJobTitle", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["CompanyJobID"] != DBNull.Value)
                            objCMS_CompanyJobTitleET.CompanyJobID = Convert.ToInt32(oReader["CompanyJobID"]);
                        if (oReader["CompanyID"] != DBNull.Value)
                            objCMS_CompanyJobTitleET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                        if (oReader["JobTitleID"] != DBNull.Value)
                            objCMS_CompanyJobTitleET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                        if (oReader["WorkerID"] != DBNull.Value)
                            objCMS_CompanyJobTitleET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_CompanyJobTitleET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        return objCMS_CompanyJobTitleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_CompanyJobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_CompanyJobTitleET objCMS_CompanyJobTitleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_CompanyJobTitle"
                         , objCMS_CompanyJobTitleET.CompanyJobID
                         , objCMS_CompanyJobTitleET.CompanyID
                         , objCMS_CompanyJobTitleET.JobTitleID
                         , objCMS_CompanyJobTitleET.WorkerID
                         , objCMS_CompanyJobTitleET.OrderNumber
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_CompanyJobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_CompanyJobTitleET objCMS_CompanyJobTitleET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_CMS_CompanyJobTitle", "CompanyJobID"
                         , objCMS_CompanyJobTitleET.CompanyID
                         , objCMS_CompanyJobTitleET.JobTitleID
                         , objCMS_CompanyJobTitleET.WorkerID
                         , objCMS_CompanyJobTitleET.OrderNumber
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_CompanyJobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_CompanyJobTitle", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyJobTitleDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
