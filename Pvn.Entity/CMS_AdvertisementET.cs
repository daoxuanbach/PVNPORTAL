using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_AdvertisementET : BaseET
    {
        #region Attributes
        public const String FIELD_AdvertisementID = "AdvertisementID";
        public const String FIELD_MenuID = "MenuID";
        public const String FIELD_Title = "Title";
        public const String FIELD_Description = "Description";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_AdvertisementPosition = "AdvertisementPosition";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_ImageSize = "ImageSize";
        public const String FIELD_ImageURL = "ImageURL";
        public const String FIELD_ImageTitle = "ImageTitle";
        public const String FIELD_Language = "Language";
        public const String FIELD_Link = "Link";
        public const String FIELD_IsNewWindow = "IsNewWindow";
        public const String FIELD_BeginDate = "BeginDate";
        public const String FIELD_EndDate = "EndDate";
        public const String FIELD_Monery = "Monery";
        public const String FIELD_Hits = "Hits";
        public const String FIELD_Note = "Note";
        public const String FIELD_PortalID = "PortalID";
        #endregion Attributes
        /// <summary>
        ///AdvertisementID AdvertisementID
        /// </summary>
        private Guid _AdvertisementID;
        public Guid AdvertisementID { get { return _AdvertisementID; } set { _AdvertisementID = value; } }
        /// <summary>
        ///MenuID MenuID
        /// </summary>
        private Guid? _MenuID;
        public Guid? MenuID { get { return _MenuID; } set { _MenuID = value; } }
        /// <summary>
        ///Title Title
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        ///Description Description
        /// </summary>
        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///AdvertisementPosition AdvertisementPosition
        /// </summary>
        private int? _AdvertisementPosition;
        public int? AdvertisementPosition { get { return _AdvertisementPosition; } set { _AdvertisementPosition = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///ImageSize ImageSize
        /// </summary>
        private string _ImageSize;
        public string ImageSize { get { return _ImageSize; } set { _ImageSize = value; } }
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
        ///Language Language
        /// </summary>
        private string _Language;
        public string Language { get { return _Language; } set { _Language = value; } }
        /// <summary>
        ///Link Link
        /// </summary>
        private string _Link;
        public string Link { get { return _Link; } set { _Link = value; } }
        /// <summary>
        ///IsNewWindow IsNewWindow
        /// </summary>
        private int? _IsNewWindow;
        public int? IsNewWindow { get { return _IsNewWindow; } set { _IsNewWindow = value; } }
        /// <summary>
        ///BeginDate BeginDate
        /// </summary>
        private DateTime? _BeginDate;
        public DateTime? BeginDate { get { return _BeginDate; } set { _BeginDate = value; } }
        /// <summary>
        ///EndDate EndDate
        /// </summary>
        private DateTime? _EndDate;
        public DateTime? EndDate { get { return _EndDate; } set { _EndDate = value; } }
        /// <summary>
        ///Monery Monery
        /// </summary>
        private long? _Monery;
        public long? Monery { get { return _Monery; } set { _Monery = value; } }
        /// <summary>
        ///Hits Hits
        /// </summary>
        private int? _Hits;
        public int? Hits { get { return _Hits; } set { _Hits = value; } }
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
        public CMS_AdvertisementET()
        {
            AdvertisementID = Guid.Empty;
            MenuID = Guid.Empty;
            Title = string.Empty;
            Description = string.Empty;
            UsedState = 0;
            AdvertisementPosition = 0;
            Ordinal = 0;
            ImageSize = string.Empty;
            ImageURL = string.Empty;
            ImageTitle = string.Empty;
            Language = string.Empty;
            Link = string.Empty;
            IsNewWindow = 0;
            BeginDate = DateTime.Now;
            EndDate = DateTime.Now;
            Monery = 0;
            Hits = 0;
            Note = string.Empty;
            PortalID = string.Empty;
        }
    }
}

