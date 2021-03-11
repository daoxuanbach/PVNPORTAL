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
	public class SysUserFunctionBL
	{
	#region Biến + thuộc tính
	 SysUserFunctionDA objDA;
	public SysUserFunctionBL()
	{
	   objDA = new SysUserFunctionDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="SysUserFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public bool Insert(SysUserFunctionET objSysUserFunctionET)
		{
			try
			{
			return objDA.Insert(objSysUserFunctionET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="SysUserFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public bool Update(SysUserFunctionET objSysUserFunctionET)
		{
			try
			{
			return objDA.Update(objSysUserFunctionET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="SysUserFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016		Tạo mới
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
        ///Bachdx		26/08/2016		Tạo mới
        ///</Modified>
        public List<SysUserFunctionET> GetAll_SysUserFunction_Paging(string p_search, int page, int rownum, out long totalRows)
		{
			try
			{
			 return objDA.GetAll_SysUserFunction_Paging(p_search, page,rownum, out totalRows);
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
		///Bachdx		26/08/2016		Tạo mới
		///</Modified>
        public List<SysUserFunctionET> GetAll_SysUserFunction_GetByUserID_Fn_Tree(int UserID, string Language, int UsedState)
		{
			try
			{
                return objDA.GetAll_SysUserFunction_GetByUserID_Fn_Tree(UserID, Language, UsedState);
            }
			catch (Exception ex)
			{
			throw ex;
			}
		}
        public List<SysUserFunctionET> GetAll_SysUserFunction_Tree_ByUser(int UserID, string Language, int UsedState)
        {
            try
            {
                return objDA.GetAll_SysUserFunction_Tree_ByUser(UserID, Language, UsedState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SysUserFunctionET> GetAll_Function_Tree_ByUserPermission(int UserID, string Language, int UsedState)
        {
            try
            {
                return objDA.GetAll_Function_Tree_ByUserPermission(UserID, Language, UsedState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SysUserFunctionET> GetAll_SysUserFunction_GetByUserID(int UserID, string Language, int UsedState)
		{
			try
			{
                return objDA.GetAll_SysUserFunction_GetByUserID(UserID, Language, UsedState);
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
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public SysUserFunctionET GetInfo(Guid intItemID)
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

