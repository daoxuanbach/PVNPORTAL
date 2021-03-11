using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_CompanyChartDA : Pvn.DA.DataProvider
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
        private CMS_CompanyChartET setProperties(DataRow oReader)
        {
            try
            {
                CMS_CompanyChartET objCMS_CompanyChartET = new CMS_CompanyChartET();
                if (oReader["CompanyChartID"] != DBNull.Value)
                    objCMS_CompanyChartET.CompanyChartID = Convert.ToInt32(oReader["CompanyChartID"]);
                if (oReader["CompanyTitle"] != DBNull.Value)
                    objCMS_CompanyChartET.CompanyTitle = Convert.ToString(oReader["CompanyTitle"]);
                if (oReader["Ordinal"] != DBNull.Value)
                    objCMS_CompanyChartET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                if (oReader["Information"] != DBNull.Value)
                    objCMS_CompanyChartET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["CompanyType"] != DBNull.Value)
                    objCMS_CompanyChartET.CompanyType = Convert.ToInt32(oReader["CompanyType"]);
                if (oReader["IconPath"] != DBNull.Value)
                    objCMS_CompanyChartET.IconPath = Convert.ToString(oReader["IconPath"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_CompanyChartET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_CompanyChartET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_CompanyChartET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_CompanyChartET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_CompanyChartET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_CompanyChartET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                   string currentLanguage,
                   string orderByColumn,
                   int pageIndex,
                   int rowsInPage,
                   ref int totalRows,
                   string name,
                   short? companyType,
                   short? usedState)
        {
            DataTable dt;
            try
            {
                dt =GetTableByProcedure( "sp_CMS_CompanyChart_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    name,
                    companyType,
                    usedState
                   );

                if (dt != null && dt.Rows.Count > 0)
                {

                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewVanBanThuHoi", "Page_Load", ex.Message);
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
    ///Bachdx		23/08/2017		Tạo mới
    ///</Modified>
    public List<CMS_CompanyChartET> GetAll_CMS_CompanyChart()
        {
            try
            {
                List<CMS_CompanyChartET> lstCMS_CompanyChartET = new List<CMS_CompanyChartET>();
                DataTable tblCMS_CompanyChartET = GetTableByProcedure("sp_GetAll_CMS_CompanyChart");
                for (int i = 0; i < tblCMS_CompanyChartET.Rows.Count; i++)
                {
                    lstCMS_CompanyChartET.Add(setProperties(tblCMS_CompanyChartET.Rows[i]));
                }
                return lstCMS_CompanyChartET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", " GetAll_..", ex.Message);
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
        public CMS_CompanyChartET GetInfo(int intItemID)
        {
            try
            {
                CMS_CompanyChartET objCMS_CompanyChartET = new CMS_CompanyChartET();
                DataTable tblCMS_CompanyChartET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_CompanyChart", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["CompanyChartID"] != DBNull.Value)
                            objCMS_CompanyChartET.CompanyChartID = Convert.ToInt32(oReader["CompanyChartID"]);
                        if (oReader["CompanyTitle"] != DBNull.Value)
                            objCMS_CompanyChartET.CompanyTitle = Convert.ToString(oReader["CompanyTitle"]);
                        if (oReader["Ordinal"] != DBNull.Value)
                            objCMS_CompanyChartET.Ordinal = Convert.ToInt32(oReader["Ordinal"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_CompanyChartET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["CompanyType"] != DBNull.Value)
                            objCMS_CompanyChartET.CompanyType = Convert.ToInt32(oReader["CompanyType"]);
                        if (oReader["IconPath"] != DBNull.Value)
                            objCMS_CompanyChartET.IconPath = Convert.ToString(oReader["IconPath"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_CompanyChartET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_CompanyChartET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_CompanyChartET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_CompanyChartET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_CompanyChartET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_CompanyChartET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_CompanyChartET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_CompanyChartET objCMS_CompanyChartET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_CompanyChart"
                         , objCMS_CompanyChartET.CompanyChartID
                         , objCMS_CompanyChartET.CompanyTitle
                         , objCMS_CompanyChartET.Ordinal
                         , objCMS_CompanyChartET.Information
                         , objCMS_CompanyChartET.CompanyType
                         , objCMS_CompanyChartET.IconPath
                         , objCMS_CompanyChartET.UsedState
                         , objCMS_CompanyChartET.CreatedDate
                         , objCMS_CompanyChartET.CreatedBy
                         , objCMS_CompanyChartET.ModifiedDate
                         , objCMS_CompanyChartET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_CompanyChartET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017Tạo mới
        ///</Modified>
        public bool Insert(CMS_CompanyChartET objCMS_CompanyChartET)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_CMS_CompanyChart", "CompanyChartID"
                         , objCMS_CompanyChartET.CompanyTitle
                         , objCMS_CompanyChartET.Ordinal
                         , objCMS_CompanyChartET.Information
                         , objCMS_CompanyChartET.CompanyType
                         , objCMS_CompanyChartET.IconPath
                         , objCMS_CompanyChartET.UsedState
                         , objCMS_CompanyChartET.CreatedDate
                         , objCMS_CompanyChartET.CreatedBy
                         , objCMS_CompanyChartET.ModifiedDate
                         , objCMS_CompanyChartET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_CompanyChartET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_CompanyChart", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyChartDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
