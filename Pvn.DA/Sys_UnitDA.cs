using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_UnitDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016		Tạo mới
        ///</Modified>
        private Sys_UnitET setProperties(DataRow oReader)
        {
            try
            {
                Sys_UnitET objSys_UnitET = new Sys_UnitET();
                if (oReader["UnitID"] != DBNull.Value)
                    objSys_UnitET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                if (oReader["Language"] != DBNull.Value)
                    objSys_UnitET.Language = Convert.ToString(oReader["Language"]);
                if (oReader["Code"] != DBNull.Value)
                    objSys_UnitET.Code = Convert.ToString(oReader["Code"]);
                if (oReader["Name"] != DBNull.Value)
                    objSys_UnitET.Name = Convert.ToString(oReader["Name"]);

                if (oReader["GroupUnitID"] != DBNull.Value&& oReader.Table.Columns.Contains("GroupUnitID"))
                    objSys_UnitET.GroupUnitID = new Guid(Convert.ToString(oReader["GroupUnitID"]));
                if (oReader["Address"] != DBNull.Value)
                    objSys_UnitET.Address = Convert.ToString(oReader["Address"]);
                if (oReader["Tel"] != DBNull.Value)
                    objSys_UnitET.Tel = Convert.ToString(oReader["Tel"]);
                if (oReader["Fax"] != DBNull.Value)
                    objSys_UnitET.Fax = Convert.ToString(oReader["Fax"]);
                if (oReader["Email"] != DBNull.Value)
                    objSys_UnitET.Email = Convert.ToString(oReader["Email"]);
                if (oReader["Website"] != DBNull.Value)
                    objSys_UnitET.Website = Convert.ToString(oReader["Website"]);
                if (oReader["Infor"] != DBNull.Value)
                    objSys_UnitET.Infor = Convert.ToString(oReader["Infor"]);
                if (oReader["FileAttach"] != DBNull.Value)
                    objSys_UnitET.FileAttach = (byte[])(oReader["FileAttach"]);
                if (oReader["FileName"] != DBNull.Value)
                    objSys_UnitET.FileName = Convert.ToString(oReader["FileName"]);
                if (oReader["Note"] != DBNull.Value)
                    objSys_UnitET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["ParentUnitID"] != DBNull.Value)
                    objSys_UnitET.ParentUnitID = new Guid(Convert.ToString(oReader["ParentUnitID"]));

                if (oReader["ParentUnitName"] != DBNull.Value)
                    objSys_UnitET.ParentUnitName = Convert.ToString(oReader["ParentUnitName"]);

                if (oReader["Checksum"] != DBNull.Value)
                    objSys_UnitET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objSys_UnitET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_UnitET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objSys_UnitET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSys_UnitET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", "setProperties", ex.Message);
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
        ///Bachdx		31/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_UnitET> GetAll_Sys_Unit_Paging(string Language, string Code, string KeyWord, Guid ParentUnitID, bool Recusive, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_UnitET> lstSys_UnitET = new List<Sys_UnitET>();
                DataTable tblSys_UnitET = GetTableByProcedurePaging("sp_GetAll_Sys_Unit_Paging", new object[] { Language, Code, KeyWord, ParentUnitID, Recusive, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_UnitET.Rows.Count; i++)
                {
                    lstSys_UnitET.Add(setProperties(tblSys_UnitET.Rows[i]));
                }
                return lstSys_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public List<Sys_UnitET> GetAll_By_Sys_Unit_Paging(string Language, string Code, string KeyWord, Guid ParentUnitID, bool Recusive)
        {
            try
            {
                List<Sys_UnitET> lstSys_UnitET = new List<Sys_UnitET>();
                DataTable tblSys_UnitET = GetTableByProcedure("sp_GetAll_by_Sys_Unit", new object[] { Language, Code, KeyWord, ParentUnitID, Recusive });
                for (int i = 0; i < tblSys_UnitET.Rows.Count; i++)
                {
                    lstSys_UnitET.Add(setProperties(tblSys_UnitET.Rows[i]));
                }
                return lstSys_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " GetAll_.._Paging", ex.Message);
                return null;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_UnitET> GetAll_Sys_Unit()
        {
            try
            {
                List<Sys_UnitET> lstSys_UnitET = new List<Sys_UnitET>();
                DataTable tblSys_UnitET = GetTableByProcedure("sp_GetAll_Sys_Unit");
                for (int i = 0; i < tblSys_UnitET.Rows.Count; i++)
                {
                    lstSys_UnitET.Add(setProperties(tblSys_UnitET.Rows[i]));
                }
                return lstSys_UnitET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " GetAll_.._Paging", ex.Message);
                return null;
            }
        }



        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016Tạo mới
        ///</Modified>
        public Sys_UnitET GetInfo(Guid intItemID)
        {
            try
            {
                Sys_UnitET objSys_UnitET = new Sys_UnitET();
                DataTable tblSys_UnitET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_Unit", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["UnitID"] != DBNull.Value)
                            objSys_UnitET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                        if (oReader["Language"] != DBNull.Value)
                            objSys_UnitET.Language = Convert.ToString(oReader["Language"]);
                        if (oReader["Code"] != DBNull.Value)
                            objSys_UnitET.Code = Convert.ToString(oReader["Code"]);
                        if (oReader["Name"] != DBNull.Value)
                            objSys_UnitET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["GroupUnitID"] != DBNull.Value && Pvn.Utils.Common.ReaderContainsColumn(oReader, "GroupUnitID"))
                            objSys_UnitET.GroupUnitID = new Guid(Convert.ToString(oReader["GroupUnitID"]));
                        if (oReader["Address"] != DBNull.Value)
                            objSys_UnitET.Address = Convert.ToString(oReader["Address"]);
                        if (oReader["Tel"] != DBNull.Value)
                            objSys_UnitET.Tel = Convert.ToString(oReader["Tel"]);
                        if (oReader["Fax"] != DBNull.Value)
                            objSys_UnitET.Fax = Convert.ToString(oReader["Fax"]);
                        if (oReader["Email"] != DBNull.Value)
                            objSys_UnitET.Email = Convert.ToString(oReader["Email"]);
                        if (oReader["Website"] != DBNull.Value)
                            objSys_UnitET.Website = Convert.ToString(oReader["Website"]);
                        if (oReader["Infor"] != DBNull.Value)
                            objSys_UnitET.Infor = Convert.ToString(oReader["Infor"]);
                        if (oReader["FileAttach"] != DBNull.Value)
                            objSys_UnitET.FileAttach = (byte[])(oReader["FileAttach"]);
                        if (oReader["FileName"] != DBNull.Value)
                            objSys_UnitET.FileName = Convert.ToString(oReader["FileName"]);
                        if (oReader["Note"] != DBNull.Value)
                            objSys_UnitET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["ParentUnitID"] != DBNull.Value)
                            objSys_UnitET.ParentUnitID = new Guid(Convert.ToString(oReader["ParentUnitID"]));
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_UnitET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objSys_UnitET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_UnitET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objSys_UnitET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_UnitET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_UnitET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " GetInfo", ex.Message);
                return null;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_UnitET objSys_UnitET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_Unit"
                         , objSys_UnitET.UnitID
                         , objSys_UnitET.GroupUnitID
                         , objSys_UnitET.Language
                         , objSys_UnitET.Code
                         , objSys_UnitET.Name
                         , objSys_UnitET.Address
                         , objSys_UnitET.Tel
                         , objSys_UnitET.Fax
                         , objSys_UnitET.Email
                         , objSys_UnitET.Website
                         , objSys_UnitET.Infor
                         , objSys_UnitET.FileAttach
                         , objSys_UnitET.FileName
                         , objSys_UnitET.Note
                         , objSys_UnitET.ParentUnitID
                         , objSys_UnitET.Checksum
                         , objSys_UnitET.CreatedBy
                         , objSys_UnitET.CreatedDate
                         , objSys_UnitET.ModifiedBy
                         , objSys_UnitET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_UnitET objSys_UnitET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Sys_Unit", "UnitID"
                         , objSys_UnitET.GroupUnitID
                         , objSys_UnitET.Language
                         , objSys_UnitET.Code
                         , objSys_UnitET.Name
                         , objSys_UnitET.Address
                         , objSys_UnitET.Tel
                         , objSys_UnitET.Fax
                         , objSys_UnitET.Email
                         , objSys_UnitET.Website
                         , objSys_UnitET.Infor
                         , objSys_UnitET.FileAttach
                         , objSys_UnitET.FileName
                         , objSys_UnitET.Note
                         , objSys_UnitET.ParentUnitID
                         , objSys_UnitET.Checksum
                         , objSys_UnitET.CreatedBy
                         , objSys_UnitET.CreatedDate
                         , objSys_UnitET.ModifiedBy
                         , objSys_UnitET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_UnitET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		31/03/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Sys_Unit", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Sys_UnitDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }


    }
}
