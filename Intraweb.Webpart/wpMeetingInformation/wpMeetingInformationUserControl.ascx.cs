using Pvn.BL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public partial class wpMeetingInformationUserControl : UserControl
    {
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
                   // CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
        }

        #region BindData
        /// <summary>
        /// bind news list data
        /// </summary>
        private void BindData()
        {
            try
            {
                MeetingBL objBL = new MeetingBL();
                DataTable dt = objBL.GetSearchPaging(dtMeeting.SelectedDate);
                rptMeeting.DataSource = dt;
                rptMeeting.DataBind();

            }
            catch (Exception exc)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("wpMeetingInformationUserControl", "BindData", exc.Message);
            }
        }
        #endregion




        protected void lbtPrevious_Click(object sender, EventArgs e)
        {
            //set previous date
            DateTime currentDate = dtMeeting.SelectedDate;
            dtMeeting.SelectedDate = currentDate.AddDays(-1);
            BindData();
        }

        protected void lbtNext_Click(object sender, EventArgs e)
        {
            //set next date
            DateTime currentDate = dtMeeting.SelectedDate;
            dtMeeting.SelectedDate = currentDate.AddDays(1);
            BindData();
        }

        protected void dtMeeting_DateChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}
