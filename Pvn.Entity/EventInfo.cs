using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptOut)]
    public class EventInfo
    {
        public const string format_date = "dd/MM/yyyy HH:mm";
        public class CompareEvent : Comparer<EventInfo>
        {
            public override int Compare(EventInfo x, EventInfo y)
            {
                return x.StartDate.CompareTo(y.StartDate);
            }
        }

        public EventInfo()
        {
        }

        public EventInfo(string code, string name, DateTime startdate, DateTime? enddate, string detail)
        {
            EventCode = code;
            EventName = name;
            StartDate = startdate;
            EndDate = enddate;
            EventDetail = detail;
            Estimate = false;
            EventPlace = string.Empty;
            EventTime = updateEventTimeDescription(StartDate, EndDate);
        }

        public static bool includeTime(DateTime? dateval)
        {
            if (dateval == null) return false;
            DateTime value = dateval.Value;
            return value.Hour != 0 || value.Minute != 0 || value.Second != 0;
        }

        public static string updateEventTimeDescription(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                if (EndDate == null) return string.Empty;
                else if (includeTime(EndDate)) return string.Format("Đến {0} ngày {1}", WebUtils.GetTimeDescription(EndDate.Value), EndDate.Value.ToString(WebUtils.formatDate));
                else return string.Format("End date {0}", EndDate.Value.ToString(WebUtils.formatDate));
            }
            if (EndDate == null)
            {
                if (includeTime(StartDate)) return string.Format("Từ {0} ngày {1}", WebUtils.GetTimeDescription(StartDate.Value), StartDate.Value.ToString(WebUtils.formatDate));
                else return string.Format("Start date {0}", StartDate.Value.ToString(WebUtils.formatDate));
            }

            if (includeTime(StartDate))//ngay bat dau co day du ngay gio
            {
                if (includeTime(EndDate))//ngay ket thuc co day du ngay gio
                {
                    if (StartDate.Value.Date == EndDate.Value.Date)
                    {
                        return string.Format("Start time {0} End time {1} date {2}", WebUtils.GetTimeDescription(StartDate.Value), WebUtils.GetTimeDescription(EndDate.Value), StartDate.Value.ToString(WebUtils.formatDate));
                    }
                    else return string.Format("Start time {0} Date {1} End time {2} Date {3}", WebUtils.GetTimeDescription(StartDate.Value), StartDate.Value.ToString(WebUtils.formatDate), WebUtils.GetTimeDescription(EndDate.Value), EndDate.Value.ToString(WebUtils.formatDate));
                }
                else
                {
                    if (StartDate.Value.Date == EndDate.Value.Date)
                    {
                        return string.Format("Start time {0} Date {1}", WebUtils.GetTimeDescription(StartDate.Value), StartDate.Value.ToString(WebUtils.formatDate));
                    }
                    else return string.Format("Start time {0} End time {1} Date {2}", WebUtils.GetTimeDescription(StartDate.Value), StartDate.Value.ToString(WebUtils.formatDate), EndDate.Value.ToString(WebUtils.formatDate));
                }
            }
            else
            {
                if (includeTime(EndDate))//ngay ket thuc co day du ngay gio
                {
                    if (StartDate.Value.Date == EndDate.Value.Date)
                    {
                        return string.Format("Start time  {0} End time {1} Date {2}", StartDate.Value.ToString(WebUtils.formatDate), WebUtils.GetTimeDescription(EndDate.Value), StartDate.Value.ToString(WebUtils.formatDate));
                    }
                    else return string.Format("Start date  {0} End time {1} Date {2}", StartDate.Value.ToString(WebUtils.formatDate), WebUtils.GetTimeDescription(EndDate.Value), EndDate.Value.ToString(WebUtils.formatDate));
                }
                else
                {
                    if (StartDate.Value.Date == EndDate.Value.Date)
                    {
                        return string.Format("Start date {0} Date {1}", WebUtils.GetTimeDescription(StartDate.Value), StartDate.Value.ToString(WebUtils.formatDate));
                    }
                    else return string.Format("Start date {0} Date {1}", StartDate.Value.ToString(WebUtils.formatDate), EndDate.Value.ToString(WebUtils.formatDate));
                }
            }
        }

        public static string GetTimeRenderWithHM(DateTime date)
        {
            string format = date.Minute == 0 ? "{0}h" : "{0}h{1}";
            return string.Format(format, date.Hour, date.Minute);
        }

        public static string GetDateRenderWithDMY(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        public static string updateEventTimeDescriptionForExport(DateTime StartDate, DateTime? EndDate)
        {
            bool sameday = EndDate == null ? true : StartDate.Date == EndDate.Value.Date;
            string startstr = null;
            if (sameday)
            {
                if (includeTime(StartDate)) startstr = GetTimeRenderWithHM(StartDate);
            }
            else
                if (includeTime(StartDate)) startstr = string.Format("{0} {1}", GetTimeRenderWithHM(StartDate), GetDateRenderWithDMY(StartDate));
                else startstr = GetDateRenderWithDMY(StartDate);
            //sameday ? string.Format("{0}h{1}", StartDate.Hour, StartDate.Minute) : string.Format("{0}h{1} {2}/{3}/{4}", StartDate.Hour, StartDate.Minute, StartDate.Day, StartDate.Month, StartDate.Year);
            string enddatestr = null;
            if (EndDate != null)
            {
                if (sameday)
                {
                    if (includeTime(EndDate)) enddatestr = GetTimeRenderWithHM(EndDate.Value);
                }
                if (includeTime(EndDate)) enddatestr = string.Format("{0} {1}", GetTimeRenderWithHM(EndDate.Value), GetDateRenderWithDMY(EndDate.Value));
                else enddatestr = GetDateRenderWithDMY(EndDate.Value);
            }
            if (startstr == null && enddatestr == null) return string.Empty;
            if (enddatestr == null) return startstr;
            return string.Format("{0}-{1}", startstr == null ? string.Empty : startstr, enddatestr);
        }
        public bool Estimate
        {
            get;
            set;
        }
        public string EventPlace
        {
            get;
            set;
        }

        public string OrgaUnit
        {
            get;
            set;
        }
        public string EventCode
        {
            get;
            set;
        }

        public string EventName
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonIgnore()]
        public DateTime StartDate
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonIgnore()]
        public DateTime? EndDate
        {
            get;
            set;
        }

        public string EventTime
        {
            get;
            set;
        }

        public string EventDetail
        {
            get;
            set;
        }

        public string GenReportText()
        {
            List<string> infos = new List<string>();
            infos.Add(updateEventTimeDescriptionForExport(StartDate, EndDate));
            infos.Add(OrgaUnit);
            infos.Add(EventPlace);
            string str = string.Empty;
            foreach (string item in infos)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (str == string.Empty) str = item;
                else
                {
                    str = str + ", ";
                    str = str + item;
                }
            }
            if (string.IsNullOrEmpty(str) == false) str = string.Format(" ({0})", str);
            str = string.Format("*{0}{1}", EventName, str);
            return str;
        }
    }
}
