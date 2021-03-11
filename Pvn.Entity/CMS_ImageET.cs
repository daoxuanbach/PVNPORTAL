using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class CMS_ImageET : BaseET
	{
	#region Attributes
		 public const String FIELD_ImageID = "ImageID"; 
		 public const String FIELD_ImageCategoryID = "ImageCategoryID"; 
		 public const String FIELD_ImageAlbumID = "ImageAlbumID"; 
		 public const String FIELD_Title = "Title"; 
		 public const String FIELD_Desscription = "Desscription"; 
		 public const String FIELD_Language = "Language"; 
		 public const String FIELD_UsedState = "UsedState"; 
		 public const String FIELD_RatingState = "RatingState"; 
		 public const String FIELD_PublishedState = "PublishedState"; 
		 public const String FIELD_Ordinal = "Ordinal"; 
		 public const String FIELD_ImageURL = "ImageURL"; 
		 public const String FIELD_ImageTitle = "ImageTitle"; 
		 public const String FIELD_Author = "Author"; 
		 public const String FIELD_Reference = "Reference"; 
		 public const String FIELD_PublishedDate = "PublishedDate"; 
		 public const String FIELD_PublishedBy = "PublishedBy"; 
		 public const String FIELD_Hits = "Hits"; 
		 public const String FIELD_TotalRating = "TotalRating"; 
		 public const String FIELD_TotalMark = "TotalMark"; 
		 public const String FIELD_AvarageMark = "AvarageMark"; 
		 public const String FIELD_Note = "Note"; 
		 public const String FIELD_PortalID = "PortalID"; 
	#endregion Attributes
		/// <summary>
		///ImageID ImageID
		/// </summary>
		private Guid _ImageID; 
		public Guid ImageID { get{ return _ImageID; } set{ _ImageID = value; } }
		/// <summary>
		///ImageCategoryID ImageCategoryID
		/// </summary>
		private Guid? _ImageCategoryID; 
		public Guid? ImageCategoryID { get{ return _ImageCategoryID; } set{ _ImageCategoryID = value; } }
		/// <summary>
		///ImageAlbumID ImageAlbumID
		/// </summary>
		private Guid? _ImageAlbumID; 
		public Guid? ImageAlbumID { get{ return _ImageAlbumID; } set{ _ImageAlbumID = value; } }
		/// <summary>
		///Title Title
		/// </summary>
		private string _Title; 
		public string Title { get{ return _Title; } set{ _Title = value; } }
		/// <summary>
		///Desscription Desscription
		/// </summary>
		private string _Desscription; 
		public string Desscription { get{ return _Desscription; } set{ _Desscription = value; } }
		/// <summary>
		///Language Language
		/// </summary>
		private string _Language; 
		public string Language { get{ return _Language; } set{ _Language = value; } }
		/// <summary>
		///UsedState UsedState
		/// </summary>
		private int? _UsedState; 
		public int? UsedState { get{ return _UsedState; } set{ _UsedState = value; } }
		/// <summary>
		///RatingState RatingState
		/// </summary>
		private int? _RatingState; 
		public int? RatingState { get{ return _RatingState; } set{ _RatingState = value; } }
		/// <summary>
		///PublishedState PublishedState
		/// </summary>
		private int? _PublishedState; 
		public int? PublishedState { get{ return _PublishedState; } set{ _PublishedState = value; } }
		/// <summary>
		///Ordinal Ordinal
		/// </summary>
		private int? _Ordinal; 
		public int? Ordinal { get{ return _Ordinal; } set{ _Ordinal = value; } }
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
		///Reference Reference
		/// </summary>
		private string _Reference; 
		public string Reference { get{ return _Reference; } set{ _Reference = value; } }
		/// <summary>
		///PublishedDate PublishedDate
		/// </summary>
		private DateTime? _PublishedDate; 
		public DateTime? PublishedDate { get{ return _PublishedDate; } set{ _PublishedDate = value; } }
		/// <summary>
		///PublishedBy PublishedBy
		/// </summary>
		private int? _PublishedBy; 
		public int? PublishedBy { get{ return _PublishedBy; } set{ _PublishedBy = value; } }
		/// <summary>
		///Hits Hits
		/// </summary>
		private int? _Hits; 
		public int? Hits { get{ return _Hits; } set{ _Hits = value; } }
		/// <summary>
		///TotalRating TotalRating
		/// </summary>
		private float _TotalRating; 
		public float TotalRating { get{ return _TotalRating; } set{ _TotalRating = value; } }
		/// <summary>
		///TotalMark TotalMark
		/// </summary>
		private float _TotalMark; 
		public float TotalMark { get{ return _TotalMark; } set{ _TotalMark = value; } }
		/// <summary>
		///AvarageMark AvarageMark
		/// </summary>
		private float _AvarageMark; 
		public float AvarageMark { get{ return _AvarageMark; } set{ _AvarageMark = value; } }
		/// <summary>
		///Note Note
		/// </summary>
		private string _Note; 
		public string Note { get{ return _Note; } set{ _Note = value; } }
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

		/// <summary>
		/// Hàm khởi tạo mặc định
		/// </summary>
		///<Modified>
		/// Author		Date		Comment
		/// Bachdx		07/09/2016		Tạo mới
		///</Modified>
		public CMS_ImageET()
		{
			ImageID = Guid.Empty;
			ImageCategoryID = Guid.Empty;
			ImageAlbumID = Guid.Empty;
			Title = string.Empty;
			Desscription = string.Empty;
			Language = string.Empty;
			UsedState = 0;
			RatingState = 0;
			PublishedState = 0;
			Ordinal = 0;
			ImageURL = string.Empty;
			ImageTitle = string.Empty;
			Author = string.Empty;
			Reference = string.Empty;
			PublishedDate = DateTime.Now;
			PublishedBy = 0;
			Hits = 0;
			TotalRating = 0;
			TotalMark = 0;
			AvarageMark = 0;
			Note = string.Empty;
			PortalID = string.Empty;
		}
	}
}

