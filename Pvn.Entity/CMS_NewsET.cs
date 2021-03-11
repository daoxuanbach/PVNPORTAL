using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class CMS_NewsET : BaseET
	{
	#region Attributes
		 public const String FIELD_NewsID = "NewsID"; 
		 public const String FIELD_CategoryID = "CategoryID"; 
		 public const String FIELD_NewsAutoID = "NewsAutoID"; 
		 public const String FIELD_NewsSPID = "NewsSPID"; 
		 public const String FIELD_NewsUsedState = "NewsUsedState"; 
		 public const String FIELD_DataAccess = "DataAccess"; 
		 public const String FIELD_RatingState = "RatingState"; 
		 public const String FIELD_NewsState = "NewsState"; 
		 public const String FIELD_Ordinal = "Ordinal"; 
		 public const String FIELD_Version = "Version"; 
		 public const String FIELD_Title = "Title"; 
		 public const String FIELD_TitleNoSign = "TitleNoSign"; 
		 public const String FIELD_PageURL = "PageURL"; 
		 public const String FIELD_Summary = "Summary"; 
		 public const String FIELD_SummaryNoSign = "SummaryNoSign"; 
		 public const String FIELD_Language = "Language"; 
		 public const String FIELD_Information = "Information"; 
		 public const String FIELD_ImageURL = "ImageURL"; 
		 public const String FIELD_ImageTitle = "ImageTitle"; 
		 public const String FIELD_Author = "Author"; 
		 public const String FIELD_AuthorNoSign = "AuthorNoSign"; 
		 public const String FIELD_Reference = "Reference"; 
		 public const String FIELD_ApprovedDate = "ApprovedDate"; 
		 public const String FIELD_ApprovedBy = "ApprovedBy"; 
		 public const String FIELD_Hits = "Hits"; 
		 public const String FIELD_TotalRating = "TotalRating"; 
		 public const String FIELD_TotalMark = "TotalMark"; 
		 public const String FIELD_AvarageMark = "AvarageMark"; 
		 public const String FIELD_PortalID = "PortalID"; 
	#endregion Attributes
		/// <summary>
		///NewsID NewsID
		/// </summary>
		private Guid _NewsID; 
		public Guid NewsID { get{ return _NewsID; } set{ _NewsID = value; } }
		/// <summary>
		///CategoryID CategoryID
		/// </summary>
		private Guid? _CategoryID; 
		public Guid? CategoryID { get{ return _CategoryID; } set{ _CategoryID = value; } }
		/// <summary>
		///NewsAutoID NewsAutoID
		/// </summary>
		private long _NewsAutoID; 
		public long NewsAutoID { get{ return _NewsAutoID; } set{ _NewsAutoID = value; } }
		/// <summary>
		///NewsSPID NewsSPID
		/// </summary>
		private long? _NewsSPID; 
		public long? NewsSPID { get{ return _NewsSPID; } set{ _NewsSPID = value; } }
		/// <summary>
		///NewsUsedState NewsUsedState
		/// </summary>
		private int? _NewsUsedState; 
		public int? NewsUsedState { get{ return _NewsUsedState; } set{ _NewsUsedState = value; } }
		/// <summary>
		///DataAccess DataAccess
		/// </summary>
		private int? _DataAccess; 
		public int? DataAccess { get{ return _DataAccess; } set{ _DataAccess = value; } }
		/// <summary>
		///RatingState RatingState
		/// </summary>
		private int? _RatingState; 
		public int? RatingState { get{ return _RatingState; } set{ _RatingState = value; } }
		/// <summary>
		///NewsState NewsState
		/// </summary>
		private int? _NewsState; 
		public int? NewsState { get{ return _NewsState; } set{ _NewsState = value; } }
		/// <summary>
		///Ordinal Ordinal
		/// </summary>
		private int? _Ordinal; 
		public int? Ordinal { get{ return _Ordinal; } set{ _Ordinal = value; } }
		/// <summary>
		///Version Version
		/// </summary>
		private int? _Version; 
		public int? Version { get{ return _Version; } set{ _Version = value; } }
		/// <summary>
		///Title Title
		/// </summary>
		private string _Title; 
		public string Title { get{ return _Title; } set{ _Title = value; } }
		/// <summary>
		///TitleNoSign TitleNoSign
		/// </summary>
		private string _TitleNoSign; 
		public string TitleNoSign { get{ return _TitleNoSign; } set{ _TitleNoSign = value; } }
		/// <summary>
		///PageURL PageURL
		/// </summary>
		private string _PageURL; 
		public string PageURL { get{ return _PageURL; } set{ _PageURL = value; } }
		/// <summary>
		///Summary Summary
		/// </summary>
		private string _Summary; 
		public string Summary { get{ return _Summary; } set{ _Summary = value; } }
		/// <summary>
		///SummaryNoSign SummaryNoSign
		/// </summary>
		private string _SummaryNoSign; 
		public string SummaryNoSign { get{ return _SummaryNoSign; } set{ _SummaryNoSign = value; } }
		/// <summary>
		///Language Language
		/// </summary>
		private string _Language; 
		public string Language { get{ return _Language; } set{ _Language = value; } }
		/// <summary>
		///Information Information
		/// </summary>
		private string _Information; 
		public string Information { get{ return _Information; } set{ _Information = value; } }
		/// <summary>
		///ImageURL ImageURL
		/// </summary>
		private string _ImageURL; 
		public string ImageURL { get{ return _ImageURL; } set{ _ImageURL = value; } }
		/// <summary>
		///ImageTitle ImageTitle
		/// </summary>
		private string _ImageTitle; 
		public string ImageTitle { get{ return _ImageTitle; } set{ _ImageTitle = value; } }
		/// <summary>
		///Author Author
		/// </summary>
		private string _Author; 
		public string Author { get{ return _Author; } set{ _Author = value; } }
		/// <summary>
		///AuthorNoSign AuthorNoSign
		/// </summary>
		private string _AuthorNoSign; 
		public string AuthorNoSign { get{ return _AuthorNoSign; } set{ _AuthorNoSign = value; } }
		/// <summary>
		///Reference Reference
		/// </summary>
		private string _Reference; 
		public string Reference { get{ return _Reference; } set{ _Reference = value; } }
		/// <summary>
		///ApprovedDate ApprovedDate
		/// </summary>
		private DateTime? _ApprovedDate; 
		public DateTime? ApprovedDate { get{ return _ApprovedDate; } set{ _ApprovedDate = value; } }
		/// <summary>
		///ApprovedBy ApprovedBy
		/// </summary>
		private int? _ApprovedBy; 
		public int? ApprovedBy { get{ return _ApprovedBy; } set{ _ApprovedBy = value; } }
		/// <summary>
		///Hits Hits
		/// </summary>
		private int? _Hits; 
		public int? Hits { get{ return _Hits; } set{ _Hits = value; } }
		/// <summary>
		///TotalRating TotalRating
		/// </summary>
		private int? _TotalRating; 
		public int? TotalRating { get{ return _TotalRating; } set{ _TotalRating = value; } }
		/// <summary>
		///TotalMark TotalMark
		/// </summary>
		private long? _TotalMark; 
		public long? TotalMark { get{ return _TotalMark; } set{ _TotalMark = value; } }
		/// <summary>
		///AvarageMark AvarageMark
		/// </summary>
		private float _AvarageMark; 
		public float AvarageMark { get{ return _AvarageMark; } set{ _AvarageMark = value; } }
		/// <summary>
		///PortalID PortalID
		/// </summary>
		private string _PortalID; 
		public string PortalID { get{ return _PortalID; } set{ _PortalID = value; } }
		/// <summary>
		///CreatedDate CreatedDate
		/// </summary>
		private DateTime? _CreatedDate; 
		public DateTime? CreatedDate { get{ return _CreatedDate; } set{ _CreatedDate = value; } }
		/// <summary>
		///CreatedBy CreatedBy
		/// </summary>
		private int? _CreatedBy; 
		public int? CreatedBy { get{ return _CreatedBy; } set{ _CreatedBy = value; } }
		/// <summary>
		///ModifiedDate ModifiedDate
		/// </summary>
		private DateTime? _ModifiedDate; 
		public DateTime? ModifiedDate { get{ return _ModifiedDate; } set{ _ModifiedDate = value; } }
		/// <summary>
		///ModifiedBy ModifiedBy
		/// </summary>
		private int? _ModifiedBy; 
		public int? ModifiedBy { get{ return _ModifiedBy; } set{ _ModifiedBy = value; } }


        private List<string> _ListCategory;

        public List<string> ListCategory
        {
            get { return _ListCategory; }
            set { _ListCategory = value; }
        }

        private DateTime? _PublishedDate = DateTime.Now;

        public DateTime? PublishedDate
        {
            get { return _PublishedDate; }
            set { _PublishedDate = value; }
        }
        //<option value="4">Tin Thường</option>
        //<option value="3">Tin mới</option>
        //<option value="2">Tin hót</option>
        public int PriorityPublishing { get; set; }

        public DateTime? BeginPriority { get; set; }

        public DateTime? EndPriority { get; set; }

        public List<string> NewsKeyword { get; set; }
        public string strNewsKeyword { get; set; }
		/// <summary>
		/// Hàm khởi tạo mặc định
		/// </summary>
		///<Modified>
		/// Author		Date		Comment
		/// Bachdx		08/06/2016		Tạo mới
		///</Modified>
		public CMS_NewsET()
		{
			NewsID = Guid.Empty;
			CategoryID = Guid.Empty;
			NewsAutoID = 0;
			NewsSPID = 0;
			NewsUsedState = 1;
			DataAccess = 0;
			RatingState = 0;
			NewsState = 0;
			Ordinal = 0;
			Version = 0;
			Title = string.Empty;
			TitleNoSign = string.Empty;
			PageURL = string.Empty;
			Summary = string.Empty;
			SummaryNoSign = string.Empty;
			Language = string.Empty;
			Information = string.Empty;
			ImageURL = string.Empty;
			ImageTitle = string.Empty;
			Author = string.Empty;
			AuthorNoSign = string.Empty;
			Reference = string.Empty;
			ApprovedDate = DateTime.Now;
			ApprovedBy = 0;
			Hits = 0;
			TotalRating = 0;
			TotalMark = 0;
			AvarageMark = 0;
			PortalID = string.Empty;
            
            PublishedDate = DateTime.Now;
            BeginPriority = DateTime.Now;
            ListCategory = new List<string>();
		}



        
    }
}

