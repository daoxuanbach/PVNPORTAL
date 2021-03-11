using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_CompanyDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017		Tạo mới
        ///</Modified>
        private CMS_CompanyET setProperties(DataRow oReader)
        {
            try
            {
                CMS_CompanyET objCMS_CompanyET = new CMS_CompanyET();
                if (oReader["CompanyID"] != DBNull.Value)
                    objCMS_CompanyET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                if (oReader["CompanyName"] != DBNull.Value)
                    objCMS_CompanyET.CompanyName = Convert.ToString(oReader["CompanyName"]);
                if (oReader["InternationalName"] != DBNull.Value)
                    objCMS_CompanyET.InternationalName = Convert.ToString(oReader["InternationalName"]);
                if (oReader["ShortName"] != DBNull.Value)
                    objCMS_CompanyET.ShortName = Convert.ToString(oReader["ShortName"]);
                if (oReader["OrderNumber"] != DBNull.Value)
                    objCMS_CompanyET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                if (oReader["ParentCompanyID"] != DBNull.Value)
                    objCMS_CompanyET.ParentCompanyID = Convert.ToInt32(oReader["ParentCompanyID"]);
                if (oReader["CompanyLevel"] != DBNull.Value)
                    objCMS_CompanyET.CompanyLevel = Convert.ToInt32(oReader["CompanyLevel"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_CompanyET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Information"] != DBNull.Value)
                    objCMS_CompanyET.Information = Convert.ToString(oReader["Information"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_CompanyET.Note = Convert.ToInt32(oReader["Note"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_CompanyET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_CompanyET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_CompanyET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_CompanyET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                if (oReader["CompanyType"] != DBNull.Value)
                    objCMS_CompanyET.CompanyType = Convert.ToInt32(oReader["CompanyType"]);
                return objCMS_CompanyET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                   string currentLanguage,
                   string orderByColumn,
                   int pageIndex,
                   int rowsInPage,
                   out long totalRows,
                   string _companyname,
                   string _internationalname,
                   string _shortname,
                   int? _ordernumber,
                   int? _parentID,
                   short? _companylevel,
                   short? _usedstate,
                   string _contactdetail,
                   int? createdBy,
                   int? modifiedBy,
                   DateTime? createdDateFrom,
                   DateTime? createdDateTo)
        {
            DataTable dt;
            totalRows = 0;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Company_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    _companyname,
                    _internationalname,
                    _shortname,
                    _ordernumber,
                    _parentID,
                    _companylevel,
                    _usedstate,
                    _contactdetail,
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
                Pvn.Utils.LogFile.WriteLogFile("DA", "setProperties", ex.Message);
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
        ///Bachdx		24/07/2017		Tạo mới
        ///</Modified>
        public List<CMS_CompanyET> GetAll_CMS_Company()
        {
            try
            {
                List<CMS_CompanyET> lstCMS_CompanyET = new List<CMS_CompanyET>();
                DataTable tblCMS_CompanyET = GetTableByProcedure("sp_GetAll_CMS_Company");
                for (int i = 0; i < tblCMS_CompanyET.Rows.Count; i++)
                {
                    lstCMS_CompanyET.Add(setProperties(tblCMS_CompanyET.Rows[i]));
                }
                return lstCMS_CompanyET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        public DataTable GetAllCompanybyParent(int? _parentID)
        {
            DataTable dt;
            try
            {

                return dt = GetTableByProcedure("sp_CMS_Company_Tree", _parentID);

            }
            catch (Exception)
            {
                return dt = new DataTable();
                throw;
            }

        }
        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public CMS_CompanyET GetInfo(int intItemID)
        {
            try
            {
                CMS_CompanyET objCMS_CompanyET = new CMS_CompanyET();
                DataTable tblCMS_CompanyET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Company", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["CompanyID"] != DBNull.Value)
                            objCMS_CompanyET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                        if (oReader["CompanyName"] != DBNull.Value)
                            objCMS_CompanyET.CompanyName = Convert.ToString(oReader["CompanyName"]);
                        if (oReader["InternationalName"] != DBNull.Value)
                            objCMS_CompanyET.InternationalName = Convert.ToString(oReader["InternationalName"]);
                        if (oReader["ShortName"] != DBNull.Value)
                            objCMS_CompanyET.ShortName = Convert.ToString(oReader["ShortName"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_CompanyET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        if (oReader["ParentCompanyID"] != DBNull.Value)
                            objCMS_CompanyET.ParentCompanyID = Convert.ToInt32(oReader["ParentCompanyID"]);
                        if (oReader["CompanyLevel"] != DBNull.Value)
                            objCMS_CompanyET.CompanyLevel = Convert.ToInt32(oReader["CompanyLevel"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_CompanyET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Information"] != DBNull.Value)
                            objCMS_CompanyET.Information = Convert.ToString(oReader["Information"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_CompanyET.Note = Convert.ToInt32(oReader["Note"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_CompanyET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_CompanyET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_CompanyET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_CompanyET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        if (oReader["CompanyType"] != DBNull.Value)
                            objCMS_CompanyET.CompanyType = Convert.ToInt32(oReader["CompanyType"]);
                        return objCMS_CompanyET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_CompanyET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_CompanyET objCMS_CompanyET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Company"
                         , objCMS_CompanyET.CompanyID
                         , objCMS_CompanyET.CompanyName
                         , objCMS_CompanyET.InternationalName
                         , objCMS_CompanyET.ShortName
                         , objCMS_CompanyET.OrderNumber
                         , objCMS_CompanyET.ParentCompanyID
                         , objCMS_CompanyET.CompanyLevel
                         , objCMS_CompanyET.UsedState
                         , objCMS_CompanyET.Information
                         , objCMS_CompanyET.Note
                         , objCMS_CompanyET.CreatedDate
                         , objCMS_CompanyET.CreatedBy
                         , objCMS_CompanyET.ModifiedDate
                         , objCMS_CompanyET.ModifiedBy
                         , objCMS_CompanyET.CompanyType
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_CompanyET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public int Insert(CMS_CompanyET objCMS_CompanyET)
        {
            try
            {
              return  ExecuteNonQueryOut("sp_Add_CMS_Company", "CompanyID"
                         , objCMS_CompanyET.CompanyName
                         , objCMS_CompanyET.InternationalName
                         , objCMS_CompanyET.ShortName
                         , objCMS_CompanyET.OrderNumber
                         , objCMS_CompanyET.ParentCompanyID
                         , objCMS_CompanyET.CompanyLevel
                         , objCMS_CompanyET.UsedState
                         , objCMS_CompanyET.Information
                         , objCMS_CompanyET.Note
                         , objCMS_CompanyET.CreatedDate
                         , objCMS_CompanyET.CreatedBy
                         , objCMS_CompanyET.ModifiedDate
                         , objCMS_CompanyET.ModifiedBy
                         , objCMS_CompanyET.CompanyType
                );
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_CompanyET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int ItemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Company", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_CompanyDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
