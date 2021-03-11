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
    public class Sys_GroupBL
    {
        #region Biến + thuộc tính
        Sys_GroupDA objDA;
        public Sys_GroupBL()
        {
            objDA = new Sys_GroupDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_GroupET objSys_GroupET)
        {
            try
            {
                return objDA.Insert(objSys_GroupET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_GroupET objSys_GroupET)
        {
            try
            {
                return objDA.Update(objSys_GroupET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_GroupET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		10/05/2016		Tạo mới
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
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_GroupET> GetAll_Sys_Group_Paging(string p_search, string Name, Guid UnitID, int UsedState, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_Sys_Group_Paging(p_search,Name, UnitID, UsedState, page, rownum, out totalRows);
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
        ///Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public List<Sys_GroupET> GetAll_Sys_Group()
        {
            try
            {
                return objDA.GetAll_Sys_Group();
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
        ///Bachdx		10/05/2016Tạo mới
        ///</Modified>
        public Sys_GroupET GetInfo(Guid intItemID)
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
