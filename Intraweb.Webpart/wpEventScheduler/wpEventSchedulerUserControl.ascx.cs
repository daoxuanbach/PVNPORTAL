using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using Pvn.Web.Usercontrols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public partial class wpEventSchedulerUserControl : UserControl
    {
        
        protected List<EventInfo> EventList
        {
            get;
            private set;
        }

        private Dictionary<string, EventInfo> LookupEvent
        {
            get;
            set;
        }

        private Dictionary<DateTime, List<EventInfo>> LookupByDate
        {
            get;
            set;
        }
        public string EventData
        {
            get;
            set;
        }

        private void BuildData(List<EventInfo> eventList)
        {
            EventList = eventList;
            //eventList.Sort(new EventInfo.CompareEvent());
            LookupEvent = new Dictionary<string, EventInfo>();
            LookupByDate = new Dictionary<DateTime, List<EventInfo>>();
            foreach (EventInfo item in eventList)
            {
                if (LookupEvent.ContainsKey(item.EventCode)) continue;
                LookupEvent.Add(item.EventCode, item);
                List<EventInfo> list;
                DateTime startdate = item.StartDate.Date;
                if (LookupByDate.TryGetValue(startdate, out list) == false)
                {
                    list = new List<EventInfo>();
                    LookupByDate.Add(startdate, list);
                }
                list.Add(item);
            }
        }

        private void initDropdown()
        {
            DateTime curDate = DateTime.Now;
            for (int i = -5; i <= 5; i++)
            {
                string year = (curDate.Year + i).ToString();
                ListItem item = new ListItem(year, year);
                if (i == 0) item.Selected = true;
                cbYear.Items.Add(item);
            }
            for (int i = 1; i <= 12; i++)
            {
                string month = i.ToString();
                ListItem item = new ListItem(month, month);
                item.Selected = i == curDate.Month;
                cbMonth.Items.Add(item);
            }
        }

        private DateTime getCurMonth()
        {
            return new DateTime(int.Parse(cbYear.SelectedValue), int.Parse(cbMonth.SelectedValue), 1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                initDropdown();
            }
            try
            {
                //bind data
                BindData();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                //CommonLib.Common.Info.Instance.WriteToLog(exc);
                Pvn.Utils.LogFile.WriteLogFile("wpEventSchedulerUserControl", "Page_Load", exc.Message);
            }

        }
        private void buildCalendar(DateTime startdate)
        {
            tblCalendar.Rows.Clear();
            DateTime beginDate = startdate.Date;
            while (beginDate.DayOfWeek != DayOfWeek.Monday) beginDate = beginDate.AddDays(-1);
            DateTime endmonth = startdate.AddMonths(1).AddDays(-1);//ngay cuoi cung cua thang
            DateTime enddate = endmonth;
            while (enddate.DayOfWeek != DayOfWeek.Sunday) enddate = enddate.AddDays(1);
            TimeSpan sp = new TimeSpan(enddate.Ticks - beginDate.Ticks);
            int totalDay = (int)sp.TotalDays;
            int i = 0;
            HtmlTableRow row = new HtmlTableRow();
            for (; i < WebUtils.DaySequeue.Length; i++)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.Attributes.Add("class", "tieudethu");
                //HtmlGenericControl div = new HtmlGenericControl("div");
                //div.Attributes.Add("class", "tieudethu");
                //cell.Controls.Add(div);
                cell.InnerHtml = WebUtils.dayOfWeekVN[WebUtils.DaySequeue[i]];
                row.Cells.Add(cell);
            }
            tblCalendar.Rows.Add(row);
            i = 0;
            DateTime dt = beginDate;
            while (i < totalDay)
            {
                //them dong chu thich ngay thang
                row = new HtmlTableRow();
                for (int j = 0; j < WebUtils.dayOfWeekVN.Length; j++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.Align = "left";
                    cell.VAlign = "Top";
                    if (dt.Month != startdate.Month) cell.Attributes.Add("class", "outofrange");
                    else
                    {
                        cell.Controls.Add(CreateDayView(dt));
                        cell.Attributes.Add("class", WebUtils.weekendList[WebUtils.DaySequeue[j]] ? "weekend" : "nonweekend");
                    }
                    cell.Attributes["class"] = cell.Attributes["class"] + " focuscell";
                    row.Cells.Add(cell);

                    i++;
                    dt = dt.AddDays(1);
                }
                tblCalendar.Rows.Add(row);
            }
        }

        private ScheduleDayView CreateDayView(DateTime dayview)
        {
            ScheduleDayView ctrl = Page.LoadControl("~/UserControls/ScheduleDayView.ascx") as ScheduleDayView;
            List<EventInfo> info;
            if (LookupByDate.TryGetValue(dayview, out info) == false) info = null;
            ctrl.BindData(dayview, info);
            return ctrl;
        }

        #region "BindData"
        private void BindData()
        {
            EventBL objBL = new EventBL();
            DateTime startdate = getCurMonth();
            DateTime enddate = startdate.AddMonths(1).AddDays(-1);//ngay cuoi cung trong thang
            using (DataTable dtEvent = objBL.GetEventByTimeAndType(1, startdate, enddate.AddDays(1)))
            {
                List<EventInfo> eventList = new List<EventInfo>();
                foreach (DataRow row in dtEvent.Rows)
                {
                    DateTime? eventenddate = row.IsNull("EndDate") ? null : (DateTime?)row["EndDate"];
                    EventInfo info = new EventInfo(row["EventID"].ToString(), row["Name"] as string, (DateTime)row["BeginDate"], eventenddate, row["Body"] as string);
                    string OrgaUnit = row.IsNull("OrgaUnit") ? string.Empty : row["OrgaUnit"] as string;
                    string EventPlace = row.IsNull("EventPlace") ? string.Empty : row["EventPlace"] as string;
                    info.OrgaUnit = OrgaUnit;
                    info.EventPlace = EventPlace;
                    bool Estimate = row.IsNull("Estimate") ? false : (bool)row["Estimate"];
                    info.Estimate = Estimate;
                    eventList.Add(info);
                }
                BuildData(eventList);
            }
            buildCalendar(startdate);
            JavaScriptSerializer js = new JavaScriptSerializer();
            //js.Serialize(LookupEvent);
            EventData = js.Serialize(LookupEvent);// Newtonsoft.Json.JsonConvert.SerializeObject(LookupEvent);
         
        }
        private void doBindata()
        {
            try
            {
                //bind data
                BindData();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("wpEventSchedulerUserControl", "doBindata", exc.Message);
            }

        }
        #endregion

        protected void lbtPrevious_Click(object sender, EventArgs e)
        {
            updateSelectedDate(getCurMonth().AddMonths(-1));
            doBindata();
        }

        protected void lbtNext_Click(object sender, EventArgs e)
        {
            updateSelectedDate(getCurMonth().AddMonths(1));
            doBindata();
        }
        private void updateSelectedDate(DateTime date)
        {
            updateDropdown(cbMonth, date.Month.ToString());
            updateDropdown(cbYear, date.Year.ToString());
        }
        private void updateDropdown(DropDownList dropdown, string selectedvalue)
        {
            if (string.IsNullOrEmpty(selectedvalue)) return;
            for (int i = 0; i < dropdown.Items.Count; i++)
            {
                if (dropdown.Items[i].Value == selectedvalue)
                {
                    dropdown.SelectedIndex = i;
                    return;
                }
            }
        }

    }
}
