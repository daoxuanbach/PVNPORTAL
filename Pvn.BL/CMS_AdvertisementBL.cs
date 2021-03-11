using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using System.Data;
using Pvn.Utils;
namespace Pvn.BL
{
    public class CMS_AdvertisementBL
    {
        #region Biến + thuộc tính
        CMS_AdvertisementDA objDA;
        public CMS_AdvertisementBL()
        {
            objDA = new CMS_AdvertisementDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_AdvertisementET objCMS_AdvertisementET)
        {
            try
            {
                return objDA.Insert(objCMS_AdvertisementET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public bool Update(CMS_AdvertisementET objCMS_AdvertisementET)
        {
            try
            {
                return objDA.Update(objCMS_AdvertisementET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_AdvertisementET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		17/08/2016		Tạo mới
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
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public List<CMS_AdvertisementET> GetAll_CMS_Advertisement_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMS_Advertisement_Paging(p_search, page, rownum, out totalRows);
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
        ///Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public List<CMS_AdvertisementET> GetAll_CMS_Advertisement()
        {
            try
            {
                return objDA.GetAll_CMS_Advertisement();
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
        ///Bachdx		17/08/2016Tạo mới
        ///</Modified>
        public CMS_AdvertisementET GetInfo(Guid intItemID)
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

        public DataTable GetAdvertismentByPosition(string CurrentLanguage, short TotalItems, short BannerPosition)
        {
            return objDA.GetAdvertismentByPosition(CurrentLanguage, TotalItems, BannerPosition);
        }
    }
}

