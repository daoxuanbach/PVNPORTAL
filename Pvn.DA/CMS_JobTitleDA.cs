using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_JobTitleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		13/07/2017		Tạo mới
        ///</Modified>
        private CMS_JobTitleET setProperties(DataRow oReader)
        {
            try
            {
                CMS_JobTitleET objCMS_JobTitleET = new CMS_JobTitleET();
                if (oReader["JobTitleID"] != DBNull.Value)
                    objCMS_JobTitleET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                if (oReader["JobTitle"] != DBNull.Value)
                    objCMS_JobTitleET.JobTitle = Convert.ToString(oReader["JobTitle"]);
                if (oReader["JobTitleEng"] != DBNull.Value)
                    objCMS_JobTitleET.JobTitleEng = Convert.ToString(oReader["JobTitleEng"]);
                if (oReader["CompanyLevel"] != DBNull.Value)
                    objCMS_JobTitleET.CompanyLevel = Convert.ToInt32(oReader["CompanyLevel"]);
                if (oReader["OrderNumber"] != DBNull.Value)
                    objCMS_JobTitleET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_JobTitleET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_JobTitleET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_JobTitleET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_JobTitleET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_JobTitleET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_JobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", "setProperties", ex.Message);
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
        ///Bachdx		13/07/2017		Tạo mới
        ///</Modified>
        public List<CMS_JobTitleET> GetAll_CMS_JobTitle_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_JobTitleET> lstCMS_JobTitleET = new List<CMS_JobTitleET>();
                DataTable tblCMS_JobTitleET = GetTableByProcedurePaging("sp_CMS_JobTitle_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_JobTitleET.Rows.Count; i++)
                {
                    lstCMS_JobTitleET.Add(setProperties(tblCMS_JobTitleET.Rows[i]));
                }
                return lstCMS_JobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }

        public DataTable GetSearchPaging(
                 string currentLanguage,
                 string orderByColumn,
                 int pageIndex,
                 int rowsInPage,
                 out long totalRows,
                 string _title,
                 int? _ordernumber,
                 short? _companylevel,
                 short? usedstate,
                 int? createdBy,
                 int? modifiedBy,
                 DateTime? createdDateFrom,
                 DateTime? createdDateTo)
        {
            totalRows = 0;
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_CMS_JobTitle_SearchPaging", new object[] {
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    _title,
                    _ordernumber,
                    _companylevel,
                    usedstate,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo });

                if (dt != null && dt.Rows.Count > 0)
                {

                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " GetAll_.._Paging", ex.Message);
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
        ///Bachdx		13/07/2017		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_JobTitle()
        {
            try
            {
                List<CMS_JobTitleET> lstCMS_JobTitleET = new List<CMS_JobTitleET>();
                DataTable tblCMS_JobTitleET = GetTableByProcedure("sp_GetAll_CMS_JobTitle");
                //for (int i = 0; i < tblCMS_JobTitleET.Rows.Count; i++)
                //{
                //    lstCMS_JobTitleET.Add(setProperties(tblCMS_JobTitleET.Rows[i]));
                //}
                return tblCMS_JobTitleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		13/07/2017Tạo mới
        ///</Modified>
        public CMS_JobTitleET GetInfo(int intItemID)
        {
            try
            {
                CMS_JobTitleET objCMS_JobTitleET = new CMS_JobTitleET();
                DataTable tblCMS_JobTitleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_JobTitle", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["JobTitleID"] != DBNull.Value)
                            objCMS_JobTitleET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                        if (oReader["JobTitle"] != DBNull.Value)
                            objCMS_JobTitleET.JobTitle = Convert.ToString(oReader["JobTitle"]);
                        if (oReader["JobTitleEng"] != DBNull.Value)
                            objCMS_JobTitleET.JobTitleEng = Convert.ToString(oReader["JobTitleEng"]);
                        if (oReader["CompanyLevel"] != DBNull.Value)
                            objCMS_JobTitleET.CompanyLevel = Convert.ToInt32(oReader["CompanyLevel"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_JobTitleET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_JobTitleET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_JobTitleET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_JobTitleET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_JobTitleET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_JobTitleET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_JobTitleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_JobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		13/07/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_JobTitleET objCMS_JobTitleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_JobTitle"
                         , objCMS_JobTitleET.JobTitleID
                         , objCMS_JobTitleET.JobTitle
                         , objCMS_JobTitleET.JobTitleEng
                         , objCMS_JobTitleET.CompanyLevel
                         , objCMS_JobTitleET.OrderNumber
                         , objCMS_JobTitleET.UsedState
                         , objCMS_JobTitleET.CreatedDate
                         , objCMS_JobTitleET.CreatedBy
                         , objCMS_JobTitleET.ModifiedDate
                         , objCMS_JobTitleET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_JobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		13/07/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_JobTitleET objCMS_JobTitleET)
        {
            try
            {
                ExecuteNonQuery("sp_Add_CMS_JobTitle",
                        objCMS_JobTitleET.JobTitleID
                        , objCMS_JobTitleET.JobTitle
                         , objCMS_JobTitleET.JobTitleEng
                         , objCMS_JobTitleET.CompanyLevel
                         , objCMS_JobTitleET.OrderNumber
                         , objCMS_JobTitleET.UsedState
                         , objCMS_JobTitleET.CreatedDate
                         , objCMS_JobTitleET.CreatedBy
                         , objCMS_JobTitleET.ModifiedDate
                         , objCMS_JobTitleET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_JobTitleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		13/07/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_JobTitle", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_JobTitleDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
