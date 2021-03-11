using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.Manager
{
    public partial class viewManager : BasePage
    {
        public int totalRows = 0;
        public string Name = String.Empty;
        public string ShortName = String.Empty;
        public Int16? ManagerType;
        public Int16? UsedState;
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
                Pvn.Utils.LogFile.WriteLogFile("viewManager", "Page_Load", ex.Message);

            }
        }
        private void BindData()
        {

            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }
            HttpCookie mySearch = new HttpCookie("Name");
            mySearch = Request.Cookies["Name"];
            if (mySearch != null && mySearch.Value != "")
            {
                Name = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myShortName = new HttpCookie("ShortName");
            myShortName = Request.Cookies["ShortName"];
            if (myShortName != null && myShortName.Value != "")
            {
                ShortName = Server.UrlDecode((myShortName.Value)).Trim();
            }
            HttpCookie myManagerType = new HttpCookie("ManagerType");
            myManagerType = Request.Cookies["ManagerType"];
            if (myManagerType != null && myManagerType.Value != "")
            {
                ManagerType = Convert.ToInt16(myManagerType.Value);
            }
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            CMS_ListManagerDA objDA = new CMS_ListManagerDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                    Globals.CurrentLanguage,
                    string.Empty,
                    (CurPage - 1),
                    RowPerPage,
                    ref totalRows,
                    null,//txtCode.Text.Trim(),
                    Name,
                    ShortName, null,
                    ManagerType,
                    null, null, null, null, UsedState
                    );
            rptDatabind.DataSource = dt;
            rptDatabind.DataBind();
            if (totalRows == 0)
                litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
            else
            {
                var paging = new PagingUtil();
                litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
            }
        }
        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("UsedState");
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();

                DataTable dtrptManagerType = objDA.GetParameterByName("ManagerType");
                rptManagerType.DataSource = dtrptManagerType;
                rptManagerType.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
        public string HtmlEncode(string input)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                char last = input[input.Length - 1];
                input = input.Remove(input.LastIndexOf(last));
                str = input.Replace(last.ToString(), "<BR />");
            }
            return str;

        }
    }
}