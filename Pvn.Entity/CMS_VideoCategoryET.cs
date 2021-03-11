using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_VideoCategoryET : BaseET
    {
        #region Attributes
        public const String FIELD_VideoCategoryID = "VideoCategoryID";
        public const String FIELD_Code = "Code";
        public const String FIELD_Title = "Title";
        public const String FIELD_Description = "Description";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_RatingState = "RatingState";
        public const String FIELD_ParentVideoCategoryID = "ParentVideoCategoryID";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_ImageURL = "ImageURL";
        public const String FIELD_ImageTitle = "ImageTitle";
        public const String FIELD_Language = "Language";
        public const String FIELD_Note = "Note";
        public const String FIELD_PortalID = "PortalID";
        #endregion Attributes
        /// <summary>
        ///VideoCategoryID VideoCategoryID
        /// </summary>
        private Guid _VideoCategoryID;
        public Guid VideoCategoryID { get { return _VideoCategoryID; } set { _VideoCategoryID = value; } }
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
        ///RatingState RatingState
        /// </summary>
        private int? _RatingState;
        public int? RatingState { get { return _RatingState; } set { _RatingState = value; } }
        /// <summary>
        ///ParentVideoCategoryID ParentVideoCategoryID
        /// </summary>
        private Guid? _ParentVideoCategoryID;
        public Guid? ParentVideoCategoryID { get { return _ParentVideoCategoryID; } set { _ParentVideoCategoryID = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
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
        /// Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public CMS_VideoCategoryET()
        {
            VideoCategoryID = Guid.Empty;
            Code = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            UsedState = 0;
            RatingState = 0;
            ParentVideoCategoryID = Guid.Empty;
            Ordinal = 0;
            ImageURL = string.Empty;
            ImageTitle = string.Empty;
            Language = string.Empty;
            Note = string.Empty;
            PortalID = string.Empty;
        }
    }
}

