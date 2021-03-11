using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_MeetingET : BaseET
    {
        #region Attributes
        public const String FIELD_MeetingID = "MeetingID";
        public const String FIELD_MeetingDate = "MeetingDate";
        public const String FIELD_RoomID = "RoomID";
        public const String FIELD_Title = "Title";
        public const String FIELD_Note = "Note";
        public const String FIELD_Active = "Active";
        #endregion Attributes
        /// <summary>
        ///MeetingID MeetingID
        /// </summary>
        private int _MeetingID;
        public int MeetingID { get { return _MeetingID; } set { _MeetingID = value; } }
        /// <summary>
        ///MeetingDate MeetingDate
        /// </summary>
        private DateTime? _MeetingDate;
        public DateTime? MeetingDate { get { return _MeetingDate; } set { _MeetingDate = value; } }
        /// <summary>
        ///RoomID RoomID
        /// </summary>
        private int? _RoomID;
        public int? RoomID { get { return _RoomID; } set { _RoomID = value; } }
        /// <summary>
        ///Title Title
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        /// <summary>
        ///Active Active
        /// </summary>
        private bool? _Active;
        public bool? Active { get { return _Active; } set { _Active = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private string _CreatedBy;
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///CreatedDate CreatedDate
        /// </summary>
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        /// <summary>
        ///ModifiedBy ModifiedBy
        /// </summary>
        private string _ModifiedBy;
        public string ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        /// <summary>
        ///ModifiedDate ModifiedDate
        /// </summary>
        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        public CMS_MeetingET()
        {
            //MeetingID = 0;
            //MeetingDate = DateTime.Now;
            //RoomID = 0;
            //Title = string.Empty;
            //Note = string.Empty;
            //Active = false;
        }
    }
}
