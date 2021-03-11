using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class Sys_PageDA : Pvn.DA.DataProvider
    {
        #region Methods
        /// <summary> 
        ///Xóa thông tin quản trị chức năng
        /// </summary> 
        /// <param name="Sys_PageET">Entity quản trị chức năng</param> 
        ///<returns>Trả về giá trị kiểu boolean</returns> 
        public MessageUtil Delete(Guid PageID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {

                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Page", PageID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_PageDA", "Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }

        }
        /// <summary> 
        ///Thêm mới thông tin bảo quản kho
        /// </summary> 
        /// <param name="Sys_PageET">Entity bảo quản kho</param> 
        /// ///<returns>Trả về giá trị kiểu int</returns> 
        public bool Insert(Sys_PageET objSys_PageET)
        {
            string PageID = ExecuteNonQueryOutToGuid("sp_Add_Sys_Page", "PageID",
                                               objSys_PageET.URL,
                                               objSys_PageET.ParentPageID,
                                               objSys_PageET.Checksum,
                                               objSys_PageET.CreatedBy,
                                               objSys_PageET.CreatedDate,
                                               objSys_PageET.ModifiedBy,
                                               objSys_PageET.ModifiedDate);
            if (PageID != Guid.Empty.ToString())
            {
                return true;
            }
            return false;
            //return true;

        }
        /// <summary> 
        ///Sửa thông tin bảo quản kho
        /// </summary> 
        /// <param name="Sys_PageET">Entity bảo quản kho</param> 
        ///<returns>Trả về giá trị kiểu boolean</returns> 
        public bool Update(Sys_PageET objSys_PageET)
        {
            int returnVal =
            ExecuteNonQuery("sp_UpdateByPK_Sys_Page",
                                                objSys_PageET.PageID,
                                               objSys_PageET.URL,
                                               objSys_PageET.ParentPageID,
                                               objSys_PageET.Checksum,
                                               objSys_PageET.CreatedBy,
                                               objSys_PageET.CreatedDate,
                                               objSys_PageET.ModifiedBy,
                                               objSys_PageET.ModifiedDate);
            if (returnVal != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary> 
        ///Lấy thông tin bảo quản kho theo id
        /// </summary> 
        /// <param name="ID">Id của bản ghi Sys_PageET</param> 
        /// <returns>Trả về thông tin Sys_PageET </returns> 
        public Sys_PageET GetInfo(Guid ID)
        {
            Sys_PageET objSys_PageET = new Sys_PageET();

            try
            {
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Page", ID))
                {
                    DataTable tblSys_FunctionET = new DataTable();
                    if (oReader.Read())
                    {
                        objSys_PageET.PageID = (oReader[Sys_PageET.FIELD_PageID] != DBNull.Value) ? new Guid(Convert.ToString(oReader[Sys_PageET.FIELD_PageID])) : new Guid();
                        objSys_PageET.URL = oReader[Sys_PageET.FIELD_URL] as string;
                        objSys_PageET.ParentPageID = (oReader[Sys_PageET.FIELD_ParentPageID] != DBNull.Value) ? new Guid(Convert.ToString(oReader[Sys_PageET.FIELD_ParentPageID])) : new Guid();
                        //objSys_PageET.Checksum = oReader[Sys_PageET.FIELD_Checksum] as string;
                        //objSys_PageET.CreatedBy = oReader[Sys_PageET.FIELD_CreatedBy] as string;
                        //objSys_PageET.ModifiedBy = oReader[Sys_PageET.FIELD_ModifiedBy] as string;
                        //objSys_PageET.CreatedDate = (oReader[Sys_PageET.FIELD_CreatedDate] != DBNull.Value) ? Convert.ToDateTime(oReader[Sys_PageET.FIELD_CreatedDate]) : DateTime.Now;
                        //objSys_PageET.ModifiedDate = (oReader[Sys_PageET.FIELD_ModifiedDate] != DBNull.Value) ? Convert.ToDateTime(oReader[Sys_PageET.FIELD_ModifiedDate]) : DateTime.Now;
                        return objSys_PageET;
                    }
                    return null;
                }
            }
            catch
            {
                return objSys_PageET;
            }

        }

        /// <summary> 
        ///Lấy toàn bộ thông tin trong bảng Sys_PageET
        /// </summary> 
        /// <returns>Trả về kiểu List Sys_PageET </returns> 
        public List<Sys_PageET> GetAll_Sys_Page()
        {
            List<Sys_PageET> lstSys_PageET = new List<Sys_PageET>();

            DataTable tblSys_PageET = GetTableByProcedure("sp_GetAll_Sys_Page");
            for (int i = 0; i < tblSys_PageET.Rows.Count; i++)
            {
                //Sys_PageET objSys_PageET = new Sys_PageET();
                lstSys_PageET.Add(SetProfile(tblSys_PageET.Rows[i]));
            }
            return lstSys_PageET;

        }
        public List<Sys_PageET> GetAll_Sys_Paging(string p_search, Guid? ParentPageID, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                string oValue = string.Empty;
                List<Sys_PageET> lstSys_PageET = new List<Sys_PageET>();
                DataTable tblSys_PageET = GetTableByProcedurePaging("sp_Sys_Page_SearchPaging", new object[] { p_search, ParentPageID, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_PageET.Rows.Count; i++)
                {
                    //Sys_PageET objSys_PageET = new Sys_PageET();
                    lstSys_PageET.Add(SetProfile(tblSys_PageET.Rows[i]));
                }
                return lstSys_PageET;
            }
            catch (Exception ex)
            {
                totalRows = 0;
                Pvn.Utils.LogFile.WriteLogFile("DA", "GetAll_Sys_Paging", ex.Message);
                return null;
            }

        }
        public Sys_PageET SetProfile(DataRow oReader)
        {
            Sys_PageET objSys_PageET = new Sys_PageET();
            objSys_PageET.PageID = (oReader[Sys_PageET.FIELD_PageID] != DBNull.Value) ? new Guid(Convert.ToString(oReader[Sys_PageET.FIELD_PageID])) : new Guid();
            objSys_PageET.URL = oReader[Sys_PageET.FIELD_URL] as string;
            objSys_PageET.ParentPageID = (oReader[Sys_PageET.FIELD_ParentPageID] != DBNull.Value) ? new Guid(Convert.ToString(oReader[Sys_PageET.FIELD_ParentPageID])) : new Guid();
            //objSys_PageET.Checksum = oReader[Sys_PageET.FIELD_Checksum] as string;
            if (oReader["CreatedBy"] != DBNull.Value && oReader.Table.Columns.Contains("CreatedBy"))
                objSys_PageET.CreatedBy = oReader[Sys_PageET.FIELD_CreatedBy] as string;
            if (oReader["ModifiedBy"] != DBNull.Value&&oReader.Table.Columns.Contains("ModifiedBy"))
                objSys_PageET.ModifiedBy = oReader[Sys_PageET.FIELD_ModifiedBy] as string;
            if (oReader["ModifiedBy"] != DBNull.Value && oReader.Table.Columns.Contains("ModifiedBy"))
                objSys_PageET.CreatedDate = (oReader[Sys_PageET.FIELD_CreatedDate] != DBNull.Value) ? Convert.ToDateTime(oReader[Sys_PageET.FIELD_CreatedDate]) : DateTime.Now;
            if (oReader["ModifiedBy"] != DBNull.Value && oReader.Table.Columns.Contains("ModifiedBy"))
                objSys_PageET.ModifiedDate = (oReader[Sys_PageET.FIELD_ModifiedDate] != DBNull.Value) ? Convert.ToDateTime(oReader[Sys_PageET.FIELD_ModifiedDate]) : DateTime.Now;
            return objSys_PageET;
        }
        #endregion
    }
}
