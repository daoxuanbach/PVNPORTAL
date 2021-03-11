using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using System.Data;
using System.Data.Common;
using Pvn.Utils;
namespace Pvn.BL
{
    public class Sys_FunctionBL
    {
        #region Biến + thuộc tính
        Sys_FunctionDA objDA;
        public Sys_FunctionBL()
        {
            objDA = new Sys_FunctionDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_FunctionET objSys_FunctionET)
        {
            try
            {
                return objDA.Insert(objSys_FunctionET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_FunctionET objSys_FunctionET)
        {
            try
            {
                return objDA.Update(objSys_FunctionET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_FunctionET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/03/2016		Tạo mới
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
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_FunctionET> GetAll_Sys_Function_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_Sys_Function_Paging(p_search, page, rownum, out totalRows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sys_FunctionET> GetAll_Sys_Function_Paging_Search4Admin(string Language, string p_search, int UsedState, Guid ParentFunction, string Url, bool Recusive, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_Sys_Function_Paging_Search4Admin(Language, p_search, UsedState, ParentFunction, Url, Recusive, page, rownum, out totalRows);
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
        ///Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public List<Sys_FunctionET> GetAll_Sys_Function()
        {
            try
            {
                return objDA.GetAll_Sys_Function();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAll_Sys_FunctionByUsedState( int UsedState)
        {
            try
            {
                return objDA.GetAll_Sys_FunctionByUsedState(UsedState);
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
        ///Bachdx		22/03/2016Tạo mới
        ///</Modified>
        public Sys_FunctionET GetInfo(Guid intItemID)
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
        /// <summary> 
        ///Lấy toàn bộ thông tin trong bảng Sys_FunctionET
        /// </summary> 
        /// <returns>Trả về kiểu List Sys_FunctionET </returns> 
        public List<Sys_FunctionET> GetAll_Sys_FunctionByLanguage_UsedState(string CurrentLanguage, int UsedState)
        {

            return objDA.GetAll_Sys_FunctionByLanguage_UsedState(CurrentLanguage, UsedState);
        }
        public List<Sys_FunctionET> GetAll_FunctionBy_UsedState_UserID(string UserID, string CurrentLanguage, int UsedState)
        {
            //string cacheName = "lst_FunctionBy_UsedState_UserID_"+ UserID;
            //if (ServerCache.Get(cacheName) == null)
            //{
            //    ServerCache.Insert(cacheName, );
            //}
            //return (List<Sys_FunctionET>)ServerCache.Get(cacheName);

            return objDA.GetAll_FunctionBy_UsedState_UserID(UserID, CurrentLanguage, UsedState);
        }
        public string GetMenuByUser(string UserID, string CurrentLanguage, int UsedState, Guid FunctionID)
        {
            List<Sys_FunctionET> lstFunction = new List<Sys_FunctionET>();
            lstFunction = GetAll_FunctionBy_UsedState_UserID(UserID, CurrentLanguage, UsedState);
            List<Guid> ListPanelbarSelected = new List<Guid>();
            ListPanelbarSelected.Add(FunctionID);
            List<Guid> ListFunctionIDSelected = GetPanelbarSelected(FunctionID, lstFunction, ListPanelbarSelected);
            string strMenu = loadMenu(Guid.Empty, 1, lstFunction, ListFunctionIDSelected);
            return strMenu;
        }
        #region Hàm đệ quy menu đa cấp
        private string Menu1 = string.Empty;
        protected string loadMenu(Guid parentID, int level, List<Sys_FunctionET> lstQTChucNang, List<Guid> ListFunctionIDSelected)
        {
            if (lstQTChucNang.Count > 0)
            {
                if (parentID == Guid.Empty)
                {

                }
                List<Sys_FunctionET> lstQTChucNangByParentID = lstQTChucNang.Where(p => (parentID == Guid.Empty ? p.ParentFunctionID == null : p.ParentFunctionID == parentID)).ToList();
                if (lstQTChucNangByParentID != null && lstQTChucNangByParentID.Count > 0)
                {
                    if (level > 1)
                    {
                        Menu1 += "<ul class='treeview-menu'>";
                    }
                    else
                    {
                        //"<ul class='nav navbar-nav' id='item-menu'>"
                        Menu1 += "<ul class='sidebar-menu'>";
                    }
                    foreach (Sys_FunctionET item in lstQTChucNangByParentID.OrderBy(p => p.Ordinal))
                    {
                        if (parentID == Guid.Empty ? item.ParentFunctionID == null : item.ParentFunctionID == parentID)
                        {

                            //if (CheckQuyen(item.LienKet) == true) active
                            if (true)
                            {
                                string LienKet = string.Empty;
                                int CountTotal = lstQTChucNang.Where(p => p.ParentFunctionID == item.FunctionID).Count();
                                string classactive = string.Empty;
                                if (ListFunctionIDSelected.Contains(item.FunctionID))
                                {
                                    classactive = "active";
                                }
                                if (CountTotal == 0)
                                {
                                    string linkUrl = string.Format("{0}?FunctionID={1}", item.URL, Convert.ToString(item.FunctionID));
                                    Menu1 += string.Format("<li class='{0}' ><a href='{1}'><i class='fa {2}'></i> <span>{3}</span></a>", classactive, linkUrl, item.ImageFileName, item.Name);
                                }
                                else
                                {
                                    Menu1 += string.Format("<li class='treeview {0}'><a href='#'><i class='fa {1}'></i> <span>{2}</span> <i class='fa fa-angle-left pull-right'></i></a>", classactive, item.ImageFileName, item.Name);

                                }
                                loadMenu(item.FunctionID, level + 1, lstQTChucNang, ListFunctionIDSelected);
                                Menu1 += "</li>";
                            }
                        }
                    }
                    Menu1 += "</ul>";
                }
            }
            return Menu1;
        }
        #endregion Hàm đệ quy menu đa cấp
        protected List<Guid> GetPanelbarSelected(Guid FunctionID, List<Sys_FunctionET> lstQTChucNanglstQTChucNang, List<Guid> ListPanelbarSelected)
        {
            Sys_FunctionET obj = lstQTChucNanglstQTChucNang.Where(p => p.FunctionID == FunctionID).FirstOrDefault();
            if (obj != null)
            {
                Sys_FunctionET objParent = lstQTChucNanglstQTChucNang.Where(p => p.FunctionID == obj.ParentFunctionID).FirstOrDefault();
                if (objParent != null)
                {
                    ListPanelbarSelected.Add(objParent.FunctionID);
                    GetPanelbarSelected(objParent.FunctionID, lstQTChucNanglstQTChucNang, ListPanelbarSelected);
                }
            }

            return ListPanelbarSelected;
        }
        /// <summary> 
        ///Lấy toàn bộ thông tin trong bảng Sys_Function
        /// </summary> 
        /// <returns>Trả về kiểu List tree Sys_Function </returns> 
        public List<Sys_FunctionET> GetAll_Tree_Sys_FunctionByLanguage_UsedState(string CurrentLanguage, int UsedState)
        {
            List<Sys_FunctionET> lstTreeSysFunction =  new List<Sys_FunctionET>();
            List<Sys_FunctionET> lstGetAll = GetAll_Sys_FunctionByLanguage_UsedState(CurrentLanguage, UsedState);
            lstTreeSysFunction =loadMenu(lstTreeSysFunction, Guid.Empty, "", lstGetAll);
            List<Sys_FunctionET> lstData = lstGetAll.Where(p => ! lstTreeSysFunction.Select(i => i.FunctionID).Contains(p.FunctionID)).ToList();
            return lstTreeSysFunction;
        }


        protected List<Sys_FunctionET> loadMenu(List<Sys_FunctionET> lstTreeSysFunction, Guid parentID, string level, List<Sys_FunctionET> lstQTChucNang)
        {
            if (lstQTChucNang.Count > 0)
            {
               
                List<Sys_FunctionET> lstQTChucNangByParentID = lstQTChucNang.Where(p => (parentID == Guid.Empty ? p.ParentFunctionID == null : p.ParentFunctionID == parentID)).ToList();
                if (lstQTChucNangByParentID != null && lstQTChucNangByParentID.Count > 0)
                {
                    if (parentID != Guid.Empty)
                    {
                        level = level + "--";
                    }
                    foreach (Sys_FunctionET item in lstQTChucNangByParentID.OrderBy(p => p.Ordinal))
                    {
                        if (parentID == Guid.Empty ? item.ParentFunctionID == null : item.ParentFunctionID == parentID)
                        {
                            //Check quyen
                            if (true)
                            {
                                item.Name = level + item.Name;
                                lstTreeSysFunction.Add(item);
                                loadMenu(lstTreeSysFunction, item.FunctionID, level, lstQTChucNang);
                            }
                        }
                    }
                }
            }
            return lstTreeSysFunction;
        }
        #endregion Function
    }
}
