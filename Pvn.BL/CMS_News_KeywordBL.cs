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
	public class CMS_News_KeywordBL
	{
	#region Biến + thuộc tính
	 CMS_News_KeywordDA objDA;
	public CMS_News_KeywordBL()
	{
	   objDA = new CMS_News_KeywordDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="CMS_News_KeywordET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		24/06/2016Tạo mới
		///</Modified>
		public bool Insert(CMS_News_KeywordET objCMS_News_KeywordET)
		{
			try
			{
			return objDA.Insert(objCMS_News_KeywordET);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordBL", "Insert", ex.Message);
                return false;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="CMS_News_KeywordET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		24/06/2016Tạo mới
		///</Modified>
		public bool Update(CMS_News_KeywordET objCMS_News_KeywordET)
		{
			try
			{
			return objDA.Update(objCMS_News_KeywordET);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordBL", "Update", ex.Message);
                return false;
			}
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="CMS_News_KeywordET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		24/06/2016		Tạo mới
		///</Modified>
        public MessageUtil DeleteByIdNews(Guid GuidID)
		{
            return objDA.DeleteByIdNews(GuidID);
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
		///Bachdx		24/06/2016		Tạo mới
		///</Modified>
		public List<CMS_News_KeywordET> GetAll_CMS_News_Keyword_Paging(string p_search, int page, int rownum, out long totalRows)
		{
			try
			{
			 return objDA.GetAll_CMS_News_Keyword_Paging(p_search, page,rownum, out totalRows);
			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordBL", "GetAll_CMS_News_Keyword_Paging", ex.Message);
                throw ex;
			}
		}
		///<summary>
		///Hàm lấy danh sách trả về đối tượng List
		///</summary>
		///<returns>List</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		24/06/2016		Tạo mới
		///</Modified>
		public List<CMS_News_KeywordET> GetAll_CMS_News_Keyword()
		{
			try
			{
			return objDA.GetAll_CMS_News_Keyword();			}
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordBL", "GetAll_CMS_News_Keyword", ex.Message);
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
		///Bachdx		24/06/2016Tạo mới
		///</Modified>
		public CMS_News_KeywordET GetInfo(Guid intItemID)
		{
			try
			{
			  return objDA.GetInfo(intItemID);
		 }
			catch (Exception ex)
			{
                Pvn.Utils.LogFile.WriteLogFile("CMS_News_KeywordBL", "GetInfo", ex.Message);
                return null;
			}
		}
	#endregion Function
  }
}

