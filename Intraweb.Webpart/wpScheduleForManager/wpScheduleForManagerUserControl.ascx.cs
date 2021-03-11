using Pvn.BL;
using Pvn.Web;
using Pvn.Web.Codes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public partial class wpScheduleForManagerUserControl : UserControl
    {
        public DateTime currentDate;
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
            if (!this.Page.IsPostBack)
            {
                try
                {
                    dtMeeting.SelectedDate = DateTime.Now;
                    //bind data
                    BindData();
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    //CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
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
            catch { }
            try
            {
                ScheduleBL objScheduleBL = new ScheduleBL();
                currentDate = dtMeeting.SelectedDate;
                DataTable dt = objScheduleBL.GetScheduleForManager(currentDate, userid);
                grvSchedule.DataSource = dt;
                grvSchedule.DataBind();
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        protected void lbtPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                currentDate = dtMeeting.SelectedDate;
                dtMeeting.SelectedDate = currentDate.AddDays(-1);
                BindData();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpScheduleForManagerUserControl", "lbtPrevious_Click", ex.Message);
                //throw;
            }
            //set previous date

        }

        protected void lbtNext_Click(object sender, EventArgs e)
        {
            try
            {
                //set next date
                currentDate = dtMeeting.SelectedDate;
                dtMeeting.SelectedDate = currentDate.AddDays(1);
                BindData();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpScheduleForManagerUserControl", "lbtNext_Click", ex.Message);
                // throw ex;
            }

        }
        protected void dtMeeting_DateChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("wpScheduleForManagerUserControl", "dtMeeting_DateChanged", ex.Message);
            }

        }

        protected void grvSchedule_PreRender(object sender, EventArgs e)
        {
            Pvn.Utils.Utilities.MergeRows(grvSchedule, 0, 1);
        }

        protected void imgbExport_Click(object sender, EventArgs e)
        {

            ReportLichCongtac report = new ReportLichCongtac();
            report.Export_Day(Response, dtMeeting.SelectedDate);

        }

        protected void grvSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbThoiGian = e.Row.FindControl("lbThoiGian") as Label;
                if (lbThoiGian != null)
                {
                   string stBeginDate =  ((DataRowView)e.Row.DataItem).Row["BeginDate"].ToString();
                   string stTitle = ((DataRowView)e.Row.DataItem).Row["Title"].ToString();
                   if (stTitle!="")
                   {
                       if (stBeginDate!="")
                       {
                           DateTime BeginDate = Convert.ToDateTime(stBeginDate);
                           if (BeginDate.Year == currentDate.Year && BeginDate.Month == currentDate.Month && BeginDate.Date == currentDate.Date)
                               lbThoiGian.Text = string.Format("Từ {0}", String.Format("{0:HH:mm}", BeginDate));
                       }
                   }
                }

            }
        }
    }
}
