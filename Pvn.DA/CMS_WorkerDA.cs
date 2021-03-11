using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_WorkerDA : Pvn.DA.DataProvider
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
        private CMS_WorkerET setProperties(DataRow oReader)
        {
            try
            {
                CMS_WorkerET objCMS_WorkerET = new CMS_WorkerET();
                if (oReader["WorkerID"] != DBNull.Value)
                    objCMS_WorkerET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                if (oReader["FirstName"] != DBNull.Value)
                    objCMS_WorkerET.FirstName = Convert.ToString(oReader["FirstName"]);
                if (oReader["LastName"] != DBNull.Value)
                    objCMS_WorkerET.LastName = Convert.ToString(oReader["LastName"]);
                if (oReader["Images"] != DBNull.Value)
                    objCMS_WorkerET.Images = Convert.ToString(oReader["Images"]);
                if (oReader["BornDate"] != DBNull.Value)
                    objCMS_WorkerET.BornDate = Convert.ToDateTime(oReader["BornDate"]);
                if (oReader["Sex"] != DBNull.Value)
                    objCMS_WorkerET.Sex = Convert.ToBoolean(oReader["Sex"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objCMS_WorkerET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Retire"] != DBNull.Value)
                    objCMS_WorkerET.Retire = Convert.ToBoolean(oReader["Retire"]);
                if (oReader["Note"] != DBNull.Value)
                    objCMS_WorkerET.Note = Convert.ToInt32(oReader["Note"]);

                if (oReader.Table.Columns.Contains("CompanyJobID") && oReader["CompanyJobID"] != DBNull.Value)
                    objCMS_WorkerET.CompanyJobID = Convert.ToInt32(oReader["CompanyJobID"]);
                if (oReader.Table.Columns.Contains("CompanyID") && oReader["CompanyID"] != DBNull.Value)
                    objCMS_WorkerET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                if (oReader.Table.Columns.Contains("JobTitleID") && oReader["JobTitleID"] != DBNull.Value)
                    objCMS_WorkerET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                if (oReader.Table.Columns.Contains("OrderNumber") && oReader["OrderNumber"] != DBNull.Value)
                    objCMS_WorkerET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);

                if (oReader["CreatedDate"] != DBNull.Value)
                    objCMS_WorkerET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objCMS_WorkerET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objCMS_WorkerET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objCMS_WorkerET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objCMS_WorkerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        public DataTable GetSearchPaging(
                  string currentLanguage,
                  string orderByColumn,
                  int pageIndex,
                  int rowsInPage,
                  out long totalRows,
                  string _firstname,
                  string _lastname,
                  DateTime? _fromdate,
                  DateTime? _todate,
                  bool? _sex,
                  int? _company,
                  int? _jobtitle,
                  short? _usedstate,
                  string _contactdetail,
                  int? createdBy,
                  int? modifiedBy,
                  DateTime? createdDateFrom,
                  DateTime? createdDateTo,
                  bool? year)
        {
            DataTable dt;
            totalRows = 0;
            try
            {
                dt = GetTableByProcedure("sp_CMS_Worker_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    _firstname,
                    _lastname,
                    _fromdate,
                    _todate,
                    _sex,
                    _company,
                    _jobtitle,
                    _usedstate,
                    _contactdetail,
                    createdBy,
                    modifiedBy,
                    createdDateFrom,
                    createdDateTo,
                    year);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DA", "", ex.Message);
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
        public List<CMS_WorkerET> GetAll_CMS_Worker()
        {
            try
            {
                List<CMS_WorkerET> lstCMS_WorkerET = new List<CMS_WorkerET>();
                DataTable tblCMS_WorkerET = GetTableByProcedure("sp_GetAll_CMS_Worker");
                for (int i = 0; i < tblCMS_WorkerET.Rows.Count; i++)
                {
                    lstCMS_WorkerET.Add(setProperties(tblCMS_WorkerET.Rows[i]));
                }
                return lstCMS_WorkerET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", " GetAll_..", ex.Message);
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
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public CMS_WorkerET GetInfo(int intItemID)
        {
            try
            {
                CMS_WorkerET objCMS_WorkerET = new CMS_WorkerET();
                DataTable tblCMS_WorkerET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_Worker", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["WorkerID"] != DBNull.Value)
                            objCMS_WorkerET.WorkerID = Convert.ToInt32(oReader["WorkerID"]);
                        if (oReader["FirstName"] != DBNull.Value)
                            objCMS_WorkerET.FirstName = Convert.ToString(oReader["FirstName"]);
                        if (oReader["LastName"] != DBNull.Value)
                            objCMS_WorkerET.LastName = Convert.ToString(oReader["LastName"]);
                        if (oReader["Images"] != DBNull.Value)
                            objCMS_WorkerET.Images = Convert.ToString(oReader["Images"]);
                        if (oReader["TaxCode"] != DBNull.Value)
                            objCMS_WorkerET.TaxCode = Convert.ToString(oReader["TaxCode"]);
                        if (oReader["BornDate"] != DBNull.Value)
                            objCMS_WorkerET.BornDate = Convert.ToDateTime(oReader["BornDate"]);
                        if (oReader["Sex"] != DBNull.Value)
                            objCMS_WorkerET.Sex = Convert.ToBoolean(oReader["Sex"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objCMS_WorkerET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Retire"] != DBNull.Value)
                            objCMS_WorkerET.Retire = Convert.ToBoolean(oReader["Retire"]);
                        if (oReader["Note"] != DBNull.Value)
                            objCMS_WorkerET.Note = Convert.ToInt32(oReader["Note"]);
                        if (oReader["CompanyJobID"] != DBNull.Value)
                            objCMS_WorkerET.CompanyJobID = Convert.ToInt32(oReader["CompanyJobID"]);
                        if (oReader["CompanyID"] != DBNull.Value)
                            objCMS_WorkerET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                        if (oReader["JobTitleID"] != DBNull.Value)
                            objCMS_WorkerET.JobTitleID = Convert.ToInt32(oReader["JobTitleID"]);
                        if (oReader["OrderNumber"] != DBNull.Value)
                            objCMS_WorkerET.OrderNumber = Convert.ToInt32(oReader["OrderNumber"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objCMS_WorkerET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objCMS_WorkerET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objCMS_WorkerET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objCMS_WorkerET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objCMS_WorkerET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_WorkerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_WorkerET objCMS_WorkerET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_Worker"
                         , objCMS_WorkerET.WorkerID
                         , objCMS_WorkerET.FirstName
                         , objCMS_WorkerET.LastName
                         , objCMS_WorkerET.Images
                         , objCMS_WorkerET.BornDate
                         , objCMS_WorkerET.Sex
                         , objCMS_WorkerET.UsedState
                         , objCMS_WorkerET.Retire
                         , objCMS_WorkerET.TaxCode
                         , objCMS_WorkerET.CardID
                         , objCMS_WorkerET.UserName
                         , objCMS_WorkerET.Note
                         , objCMS_WorkerET.CreatedDate
                         , objCMS_WorkerET.CreatedBy
                         , objCMS_WorkerET.ModifiedDate
                         , objCMS_WorkerET.ModifiedBy
                         , objCMS_WorkerET.CompanyID
                         , objCMS_WorkerET.JobTitleID
                         , objCMS_WorkerET.OrderNumber
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_WorkerET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		24/07/2017Tạo mới
        ///</Modified>
        public int Insert(CMS_WorkerET objCMS_WorkerET)
        {
            try
            {
                return ExecuteNonQueryOut("sp_Add_CMS_Worker_New", "WorkerID"
                         , objCMS_WorkerET.FirstName
                         , objCMS_WorkerET.LastName
                         , objCMS_WorkerET.Images
                         , objCMS_WorkerET.BornDate
                         , objCMS_WorkerET.Sex
                         , objCMS_WorkerET.UsedState
                         , objCMS_WorkerET.Retire
                         , objCMS_WorkerET.TaxCode
                         , objCMS_WorkerET.CardID
                         , objCMS_WorkerET.UserName
                         , objCMS_WorkerET.Note
                         , objCMS_WorkerET.CreatedDate
                         , objCMS_WorkerET.CreatedBy
                         , objCMS_WorkerET.ModifiedDate
                         , objCMS_WorkerET.ModifiedBy
                         , objCMS_WorkerET.CompanyID
                         , objCMS_WorkerET.JobTitleID
                         , objCMS_WorkerET.OrderNumber
                );
                
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_WorkerET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_Worker", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_WorkerDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}
