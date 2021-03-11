using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.FunctionList
{
    public partial class viewFunctionList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public int UsedState = 1;
        public Guid ParentFunction = Guid.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Quản lý hệ thống";
                RequestPage();

                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {
            HttpCookie mySearch = new HttpCookie("txtCode");
            mySearch = Request.Cookies["Search"];
            if (mySearch != null && mySearch.Value != "")
            {
                KeyWord = Server.UrlDecode(mySearch.Value);
            }

            HttpCookie myLanguage = new HttpCookie("Language");
            myLanguage = Request.Cookies["Language"];
            if (myLanguage != null && myLanguage.Value != "")
            {
                Language = (string)(myLanguage.Value);
            }
          
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            HttpCookie myParentFunctionID = new HttpCookie("ParentFunctionID");
            myParentFunctionID = Request.Cookies["ParentFunctionID"];
            if (myParentFunctionID != null && myParentFunctionID.Value != "")
            {
                ParentFunction = new Guid(myParentFunctionID.Value);
            }
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }
            Sys_FunctionBL objBL = new Sys_FunctionBL();
           // List<Sys_FunctionET> listPageAll = objBL.GetAll_Sys_Function_Paging(KeyWord, (CurPage - 1), RowPerPage, out totalRows);
            //string UserID = new Sys_UserBL().GetUserLogin().ToString();

            List<Sys_FunctionET> listPageAll = objBL.GetAll_Sys_Function_Paging_Search4Admin(Language, KeyWord,
                                                    UsedState, ParentFunction, "",true,
                                                    (CurPage - 1),RowPerPage,  out totalRows);
            rptDatabind.DataSource = listPageAll;
            rptDatabind.DataBind();
            if (totalRows == 0)
                litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
            else
            {
                var paging = new PagingUtil();
                litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
                //litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP, "#");
               // litMsg.Text = paging.getHtmlPagingJSCustomAll(Pvn.Utils.Constants.PAGE_STEP, CurPage, RowPerPage, (int)totalRows, "LoadContentPagging",
               //string.Format("'/UserControls/FunctionList/viewFunctionList.aspx?Search={0}&Language={1}&UsedState={2}&ParentFunctionID={3}'", KeyWord, Language,UsedState,ParentFunction));
            }

        }
        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptNgonNgu.DataSource = lstNgonNguET;
                rptNgonNgu.DataBind();

                Sys_FunctionBL objFunctionBL = new Sys_FunctionBL();
                rptNhomChucNang.DataSource = objFunctionBL.GetAll_Tree_Sys_FunctionByLanguage_UsedState(Pvn.Utils.Constants.Language.VIETNAMESE, 1);
                rptNhomChucNang.DataBind();


                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
    }
}