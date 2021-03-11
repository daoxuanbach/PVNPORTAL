using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_CategoryET : BaseET
    {
        #region Attributes
        public const String FIELD_CategoryID = "CategoryID";
        public const String FIELD_Code = "Code";
        public const String FIELD_Title = "Title";
        public const String FIELD_Summary = "Summary";
        public const String FIELD_Information = "Information";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_CMSDataType = "CMSDataType";
        public const String FIELD_CatPublishedType = "CatPublishedType";
        public const String FIELD_RatingState = "RatingState";
        public const String FIELD_DataAccess = "DataAccess";
        public const String FIELD_ParentCategoryID = "ParentCategoryID";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_URL = "URL";
        public const String FIELD_ImageURL = "ImageURL";
        public const String FIELD_ImageTitle = "ImageTitle";
        public const String FIELD_Language = "Language";
        public const String FIELD_PortalID = "PortalID";
        #endregion Attributes
        /// <summary>
        ///CategoryID CategoryID
        /// </summary>
        private Guid _CategoryID;
        public Guid CategoryID { get { return _CategoryID; } set { _CategoryID = value; } }
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
        ///CMSDataType CMSDataType
        /// </summary>
        private int? _CMSDataType;
        public int? CMSDataType { get { return _CMSDataType; } set { _CMSDataType = value; } }
        /// <summary>
        ///CatPublishedType CatPublishedType
        /// </summary>
        private int? _CatPublishedType;
        public int? CatPublishedType { get { return _CatPublishedType; } set { _CatPublishedType = value; } }
        /// <summary>
        ///RatingState RatingState
        /// </summary>
        private int? _RatingState;
        public int? RatingState { get { return _RatingState; } set { _RatingState = value; } }
        /// <summary>
        ///DataAccess DataAccess
        /// </summary>
        private int? _DataAccess;
        public int? DataAccess { get { return _DataAccess; } set { _DataAccess = value; } }
        /// <summary>
        ///ParentCategoryID ParentCategoryID
        /// </summary>
        private Guid? _ParentCategoryID;
        public Guid? ParentCategoryID { get { return _ParentCategoryID; } set { _ParentCategoryID = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///URL URL
        /// </summary>
        private string _URL;
        public string URL { get { return _URL; } set { _URL = value; } }
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
        /// Bachdx		19/05/2016		Tạo mới
        ///</Modified>
        public CMS_CategoryET()
        {
            CategoryID = Guid.Empty;
            Code = string.Empty;
            Title = string.Empty;
            Summary = string.Empty;
            Information = string.Empty;
            UsedState = 1;
            CMSDataType = 0;
            CatPublishedType = 0;
            RatingState = 0;
            DataAccess = 0;
            ParentCategoryID = Guid.Empty;
            Ordinal = 0;
            URL = string.Empty;
            ImageURL = string.Empty;
            ImageTitle = string.Empty;
            Language = string.Empty;
            PortalID = string.Empty;
          
        }

        public int TotalRows { get; set; }



    }
}

