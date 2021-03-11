using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_MenuET : BaseET
    {
        #region Attributes
        public const String FIELD_MenuID = "MenuID";
        public const String FIELD_MenuAutoID = "MenuAutoID";
        public const String FIELD_Code = "Code";
        public const String FIELD_Title = "Title";
        public const String FIELD_Summary = "Summary";
        public const String FIELD_Information = "Information";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_MenuPosition = "MenuPosition";
        public const String FIELD_DataAccess = "DataAccess";
        public const String FIELD_Language = "Language";
        public const String FIELD_ParentMenuID = "ParentMenuID";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_ObjectType = "ObjectType";
        public const String FIELD_ObjectID = "ObjectID";
        public const String FIELD_URL = "URL";
        public const String FIELD_IsNewWindow = "IsNewWindow";
        public const String FIELD_ImageURL = "ImageURL";
        public const String FIELD_ImageTitle = "ImageTitle";
        public const String FIELD_Note = "Note";
        public const String FIELD_PortalID = "PortalID";
        #endregion Attributes
        /// <summary>
        ///MenuID MenuID
        /// </summary>
        private Guid _MenuID;
        public Guid MenuID { get { return _MenuID; } set { _MenuID = value; } }
        /// <summary>
        ///MenuAutoID MenuAutoID
        /// </summary>
        private int _MenuAutoID;
        public int MenuAutoID { get { return _MenuAutoID; } set { _MenuAutoID = value; } }
        /// <summary>
        ///Code Code
        /// </summary>
        private string _Code;
        public string Code { get { return _Code; } set { _Code = value; } }
        /// <summary>
        ///Title Title
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        ///Summary Summary
        /// </summary>
        private string _Summary;
        public string Summary { get { return _Summary; } set { _Summary = value; } }
        /// <summary>
        ///Information Information
        /// </summary>
        private string _Information;
        public string Information { get { return _Information; } set { _Information = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///MenuPosition MenuPosition
        /// </summary>
        private int? _MenuPosition;
        public int? MenuPosition { get { return _MenuPosition; } set { _MenuPosition = value; } }
        /// <summary>
        ///DataAccess DataAccess
        /// </summary>
        private int? _DataAccess;
        public int? DataAccess { get { return _DataAccess; } set { _DataAccess = value; } }
        /// <summary>
        ///Language Language
        /// </summary>
        private string _Language;
        public string Language { get { return _Language; } set { _Language = value; } }
        /// <summary>
        ///ParentMenuID ParentMenuID
        /// </summary>
        private Guid? _ParentMenuID;
        public Guid? ParentMenuID { get { return _ParentMenuID; } set { _ParentMenuID = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///ObjectType ObjectType
        /// </summary>
        private string _ObjectType;
        public string ObjectType { get { return _ObjectType; } set { _ObjectType = value; } }
        /// <summary>
        ///ObjectID ObjectID
        /// </summary>
        private Guid? _ObjectID;
        public Guid? ObjectID { get { return _ObjectID; } set { _ObjectID = value; } }
        /// <summary>
        ///URL URL
        /// </summary>
        private string _URL;
        public string URL { get { return _URL; } set { _URL = value; } }
        /// <summary>
        ///IsNewWindow IsNewWindow
        /// </summary>
        private bool _IsNewWindow;
        public bool IsNewWindow { get { return _IsNewWindow; } set { _IsNewWindow = value; } }
        /// <summary>
        ///ImageURL ImageURL
        /// </summary>
        private string _ImageURL;
        public string ImageURL { get { return _ImageURL; } set { _ImageURL = value; } }
        /// <summary>
        ///ImageTitle ImageTitle
        /// </summary>
        private string _ImageTitle;
        public string ImageTitle { get { return _ImageTitle; } set { _ImageTitle = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        /// <summary>
        ///PortalID PortalID
        /// </summary>
        private string _PortalID;
        public string PortalID { get { return _PortalID; } set { _PortalID = value; } }
        /// <summary>
        ///CreatedDate CreatedDate
        /// </summary>
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private int? _CreatedBy;
        public int? CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///ModifiedDate ModifiedDate
        /// </summary>
        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        /// <summary>
        ///ModifiedBy ModifiedBy
        /// </summary>
        private int? _ModifiedBy;
        public int? ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		17/08/2016		Tạo mới
        ///</Modified>
        public CMS_MenuET()
        {
            MenuID = Guid.Empty;
            MenuAutoID = 0;
            Code = string.Empty;
            Title = string.Empty;
            Summary = string.Empty;
            Information = string.Empty;
            UsedState = 0;
            MenuPosition = 0;
            DataAccess = 0;
            Language = Pvn.Utils.Constants.Language.VIETNAMESE;
            ParentMenuID = Guid.Empty;
            Ordinal = 0;
            ObjectType = string.Empty;
            ObjectID = Guid.Empty;
            URL = string.Empty;
            ImageURL = string.Empty;
            ImageTitle = string.Empty;
            Note = string.Empty;
            PortalID = string.Empty;
            IsNewWindow = false;
        }

        public string OrdinalTitle { get; set; }
    }
}

