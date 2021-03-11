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
	public class Sys_Group_UserBL
	{
	#region Biến + thuộc tính
	 Sys_Group_UserDA objDA;
	public Sys_Group_UserBL()
	{
	   objDA = new Sys_Group_UserDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="Sys_Group_UserET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		17/05/2016Tạo mới
		///</Modified>
		public bool Insert(Sys_Group_UserET objSys_Group_UserET)
		{
			try
			{
			return objDA.Insert(objSys_Group_UserET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="Sys_Group_UserET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		17/05/2016Tạo mới
		///</Modified>
		public bool Update(Sys_Group_UserET objSys_Group_UserET)
		{
			try
			{
			return objDA.Update(objSys_Group_UserET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="Sys_Group_UserET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		17/05/2016		Tạo mới
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
		///Bachdx		17/05/2016		Tạo mới
		///</Modified>
        public List<Sys_Group_UserET> GetAll_Sys_Group_User_Paging(Guid GroupID, int page, int rownum, out long totalRows)
		{
			try
			{
                return objDA.GetAll_Sys_Group_User_Paging(GroupID, page, rownum, out totalRows);
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
		///Bachdx		17/05/2016		Tạo mới
		///</Modified>
		public List<Sys_Group_UserET> GetAll_Sys_Group_User()
		{
			try
			{
			return objDA.GetAll_Sys_Group_User();			}
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
		///Bachdx		17/05/2016Tạo mới
		///</Modified>
		public Sys_Group_UserET GetInfo(Guid intItemID)
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

