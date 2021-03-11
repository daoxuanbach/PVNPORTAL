using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_LogDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/10/2017		Tạo mới
        ///</Modified>
        private Sys_LogET setProperties(DataRow oReader)
        {
            try
            {
                Sys_LogET objSys_LogET = new Sys_LogET();
                if (oReader["ID"] != DBNull.Value)
                    objSys_LogET.ID = Convert.ToInt32(oReader["ID"]);
                if (oReader["FunctionID"] != DBNull.Value)
                    objSys_LogET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader["ThaoTac"] != DBNull.Value)
                    objSys_LogET.ThaoTac = Convert.ToInt32(oReader["ThaoTac"]);
                if (oReader["Note"] != DBNull.Value)
                    objSys_LogET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSys_LogET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_LogET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                return objSys_LogET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", "setProperties", ex.Message);
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
        ///Bachdx		12/10/2017		Tạo mới
        ///</Modified>
        public List<Sys_LogET> GetAll_Sys_Log_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_LogET> lstSys_LogET = new List<Sys_LogET>();
                DataTable tblSys_LogET = GetTableByProcedurePaging("sp_Sys_Log_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_LogET.Rows.Count; i++)
                {
                    lstSys_LogET.Add(setProperties(tblSys_LogET.Rows[i]));
                }
                return lstSys_LogET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/10/2017		Tạo mới
        ///</Modified>
        public List<Sys_LogET> GetAll_Sys_Log()
        {
            try
            {
                List<Sys_LogET> lstSys_LogET = new List<Sys_LogET>();
                DataTable tblSys_LogET = GetTableByProcedure("sp_GetAll_Sys_Log");
                for (int i = 0; i < tblSys_LogET.Rows.Count; i++)
                {
                    lstSys_LogET.Add(setProperties(tblSys_LogET.Rows[i]));
                }
                return lstSys_LogET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " GetAll_..", ex.Message);
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
        ///Bachdx		12/10/2017Tạo mới
        ///</Modified>
        public Sys_LogET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_LogET objSys_LogET = new Sys_LogET();
                DataTable tblSys_LogET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Log", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["ID"] != DBNull.Value)
                            objSys_LogET.ID = Convert.ToInt32(oReader["ID"]);
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSys_LogET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        if (oReader["ThaoTac"] != DBNull.Value)
                            objSys_LogET.ThaoTac = Convert.ToInt32(oReader["ThaoTac"]);
                        if (oReader["Note"] != DBNull.Value)
                            objSys_LogET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_LogET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_LogET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        return objSys_LogET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_LogET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/10/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(Sys_LogET objSys_LogET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_Sys_Log"
                         , objSys_LogET.ID
                         , objSys_LogET.FunctionID
                         , objSys_LogET.ThaoTac
                         , objSys_LogET.Note
                         , objSys_LogET.CreatedBy
                         , objSys_LogET.CreatedDate
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_LogET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/10/2017Tạo mới
        ///</Modified>
        public bool Insert (Guid? FunctionID, int? ThaoTac,string Note ,string ClientIP,string CreatedBy,DateTime? CreatedDate)
        {
            try
            {
                ExecuteNonQueryOut("sp_Add_Sys_Log", "ID"
                         , FunctionID
                         , ThaoTac
                         , Note
                         , ClientIP
                         , CreatedBy
                         , CreatedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_LogET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/10/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Log", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_LogDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}

