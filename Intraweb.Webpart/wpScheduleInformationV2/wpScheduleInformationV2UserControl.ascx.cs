using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
namespace Intraweb.Webpart
{
    public partial class wpScheduleInformationV2UserControl : UserControl
    {

        private String _UrlLink;
        public String UrlLink
        {
            get { return _UrlLink; }
            set { _UrlLink = value; }
        }
        private string _TenTab;

        public string TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                   //default date
                    DateTime baseDate = DateTime.Today;
                    //set begin of current week -> start at monday
                    DateTime thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek + 1);
                    dtFromDate.SelectedDate = thisWeekStart;
                    //set end of current week
                    DateTime thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
                    dtToDate.SelectedDate = thisWeekEnd;
                    //bind manager
                    BindManager();
                    BindData();
                }
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }

        #region BindData
        /// <summary>
        /// Bind managers to dropdownlist
        /// </summary>
        private void BindManager()
        {
            ScheduleBL objScheduleBL = new ScheduleBL();
            DataTable dt = objScheduleBL.GetManager();
            ddlManager.DataValueField = "ManagerID";
            ddlManager.DataTextField = "Name";
            ddlManager.DataSource = dt;
            ddlManager.DataBind();

            //insert default value
            ddlManager.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Tất cả--", "0"));
        }

        private void BindData()
        {
            string userid = string.Empty;
            try
            {
                var applicationInfo = new CommonLib.Application.ApplicationInfo();                //userid

                if (applicationInfo != null)
                {
                    userid = applicationInfo.LoginUserUserID;
                }
            }
            catch (Exception ex)
            {

            }
            ScheduleBL objScheduleBL = new ScheduleBL();
            List < ScheduleInfo > lstScheduleInfo = objScheduleBL.GetSearchPaging2(Convert.ToInt32(ddlManager.SelectedValue), dtFromDate.SelectedDate, dtToDate.SelectedDate, userid);
            rptScheduleInfo.DataSource = lstScheduleInfo;
            rptScheduleInfo.DataBind();
            //grvSchedule.DataSource = dt;
            //grvSchedule.DataBind();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
            }

        }

    }
}
