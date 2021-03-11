using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class ScheduleForManagerET
    {
        //STT	LÃNH ĐẠO	HOẠT ĐỘNG	THỜI GIAN	ĐỊA ĐIỂM
        public DateTime? BeginDate { get; set; }

        private string _Descriptions;

        public string Descriptions
        {
            get { return _Descriptions; }
            set { _Descriptions = value; }
        }
        private Int64 _ManagerID;

        public Int64 ManagerID
        {
            get { return _ManagerID; }
            set { _ManagerID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private bool _Private;

        public bool Private
        {
            get { return _Private; }
            set { _Private = value; }
        }
        private Int64 _ScheduleID;

        public Int64 ScheduleID
        {
            get { return _ScheduleID; }
            set { _ScheduleID = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _ToAddress;

        public string ToAddress
        {
            get { return _ToAddress; }
            set { _ToAddress = value; }
        }
        private Int64 _Ordinal;

        public Int64 Ordinal
        {
            get { return _Ordinal; }
            set { _Ordinal = value; }
        }
        private Int64 _STT;

        public Int64 STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        private string _ListMangerName;

        public string ListMangerName
        {
            get { return _ListMangerName; }
            set { _ListMangerName = value; }
        }
    }
}
