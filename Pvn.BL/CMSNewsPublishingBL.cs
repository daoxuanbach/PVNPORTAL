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
    public class CMSNewsPublishingBL
    {
        #region Biến + thuộc tính
        CMSNewsPublishingDA objDA;
        public CMSNewsPublishingBL()
        {
            objDA = new CMSNewsPublishingDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMSNewsPublishingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public bool Insert(CMSNewsPublishingET objCMSNewsPublishingET)
        {
            try
            {
                return objDA.Insert(objCMSNewsPublishingET);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMSNewsPublishingBL", "Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMSNewsPublishingET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public bool Update(CMSNewsPublishingET objCMSNewsPublishingET)
        {
            try
            {
                return objDA.Update(objCMSNewsPublishingET);
            }
            catch
            {
                return false;
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
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        public List<CMSNewsPublishingET> GetAll_CMSNewsPublishing_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMSNewsPublishing_Paging(p_search, page, rownum, out totalRows);
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
        ///Bachdx		23/06/2016		Tạo mới
        ///</Modified>
        public List<CMSNewsPublishingET> GetAll_CMSNewsPublishing()
        {
            try
            {
                return objDA.GetAll_CMSNewsPublishing();
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
        ///Bachdx		23/06/2016Tạo mới
        ///</Modified>
        public CMSNewsPublishingET GetInfo(Guid intItemID)
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

