using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class CMSNewsPublishingET : BaseET
	{
	#region Attributes
		 public const String FIELD_NewsPublishingID = "NewsPublishingID"; 
		 public const String FIELD_CategoryID = "CategoryID"; 
		 public const String FIELD_NewsID = "NewsID"; 
		 public const String FIELD_NewsSPID = "NewsSPID"; 
		 public const String FIELD_Version = "Version"; 
		 public const String FIELD_RatingState = "RatingState"; 
		 public const String FIELD_PublishedState = "PublishedState"; 
		 public const String FIELD_BeginDate = "BeginDate"; 
		 public const String FIELD_EndDate = "EndDate"; 
		 public const String FIELD_PriorityPublishing = "PriorityPublishing"; 
		 public const String FIELD_BeginPriority = "BeginPriority"; 
		 public const String FIELD_EndPriority = "EndPriority"; 
		 public const String FIELD_Note = "Note"; 
		 public const String FIELD_PortalID = "PortalID"; 
	#endregion Attributes
		/// <summary>
		///NewsPublishingID NewsPublishingID
		/// </summary>
		private Guid _NewsPublishingID; 
		public Guid NewsPublishingID { get{ return _NewsPublishingID; } set{ _NewsPublishingID = value; } }
		/// <summary>
		///CategoryID CategoryID
		/// </summary>
		private Guid? _CategoryID; 
		public Guid? CategoryID { get{ return _CategoryID; } set{ _CategoryID = value; } }
		/// <summary>
		///NewsID NewsID
		/// </summary>
		private Guid? _NewsID; 
		public Guid? NewsID { get{ return _NewsID; } set{ _NewsID = value; } }
		/// <summary>
		///NewsSPID NewsSPID
		/// </summary>
		private long? _NewsSPID; 
		public long? NewsSPID { get{ return _NewsSPID; } set{ _NewsSPID = value; } }
		/// <summary>
		///Version Version
		/// </summary>
		private int? _Version; 
		public int? Version { get{ return _Version; } set{ _Version = value; } }
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
		///BeginDate BeginDate
		/// </summary>
		private DateTime? _BeginDate; 
		public DateTime? BeginDate { get{ return _BeginDate; } set{ _BeginDate = value; } }
		/// <summary>
		///EndDate EndDate
		/// </summary>
		private DateTime? _EndDate; 
		public DateTime? EndDate { get{ return _EndDate; } set{ _EndDate = value; } }
		/// <summary>
		///PriorityPublishing PriorityPublishing
		/// </summary>
		private int? _PriorityPublishing; 
		public int? PriorityPublishing { get{ return _PriorityPublishing; } set{ _PriorityPublishing = value; } }
		/// <summary>
		///BeginPriority BeginPriority
		/// </summary>
		private DateTime? _BeginPriority; 
		public DateTime? BeginPriority { get{ return _BeginPriority; } set{ _BeginPriority = value; } }
		/// <summary>
		///EndPriority EndPriority
		/// </summary>
		private DateTime? _EndPriority; 
		public DateTime? EndPriority { get{ return _EndPriority; } set{ _EndPriority = value; } }
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
		/// Bachdx		23/06/2016		Tạo mới
		///</Modified>
		public CMSNewsPublishingET()
		{
			NewsPublishingID = Guid.Empty;
			CategoryID = Guid.Empty;
			NewsID = Guid.Empty;
			NewsSPID = 0;
			Version = 0;
			RatingState = 0;
			PublishedState = 1;
			BeginDate = DateTime.Now;
			//EndDate = DateTime.Now;
			PriorityPublishing = 4;
			BeginPriority = DateTime.Now;
			EndPriority = DateTime.Now;
			Note = string.Empty;
			PortalID = string.Empty;
		}
	}
}

