using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ScheduleDayView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<EventInfo> InfoData
        {
            get;
            private set;
        }

        public DateTime DayView
        {
            get;
            private set;
        }

        private static string getDateName(DateTime date)
        {
            if (date.Day == 1)//ngay dau thang
            {
                return string.Format("{0} tháng {1}", date.Day, date.Month);
            }
            else return string.Format("{0}", date.Day);
        }

        public void BindData(DateTime dayView, List<EventInfo> infoData)
        {
            DayView = dayView;
            InfoData = infoData;
            lbDate.Text = getDateName(dayView);
            if (infoData == null || infoData.Count == 0)
            {
                pnEmpty.Visible = true;
                Repeater1.Visible = false;
            }
            else
            {
                pnEmpty.Visible = false;
                Repeater1.Visible = true;
                Repeater1.DataSource = infoData;
                Repeater1.DataBind();
            }
        }
    }
}