using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using Pvn.Utils;
namespace Pvn.BL
{
    public class Sys_UnitBL
    {
        #region Biến + thuộc tính
        Sys_UnitDA objDA;
        public Sys_UnitBL()
        {
            objDA = new Sys_UnitDA();
        }
        #endregion
        #region Function
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
                return objDA.Insert(objSys_UnitET);
            }
            catch (Exception ex)
            {
                return false;
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
                return objDA.Update(objSys_UnitET);
            }
            catch (Exception ex)
            {
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
            return objDA.Delete(GuidID);
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
                return objDA.GetAll_Sys_Unit_Paging(Language, Code, KeyWord, ParentUnitID, Recusive, page, rownum, out totalRows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Sys_UnitET> GetAll_By_Sys_Unit_Paging(string Language, string Code, string KeyWord, Guid ParentUnitID, bool Recusive)
        {
            try
            {
                return objDA.GetAll_By_Sys_Unit_Paging(Language, Code, KeyWord, ParentUnitID, Recusive);
            }
            catch (Exception ex)
            {
                throw ex;
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
                return objDA.GetAll_Sys_Unit();
            }
            catch (Exception ex)
            {
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
        ///Bachdx		31/03/2016Tạo mới
        ///</Modified>
        public Sys_UnitET GetInfo(Guid intItemID)
        {
            try
            {
                return objDA.GetInfo(intItemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Function
    }
}
