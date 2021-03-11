using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class CMS_News_KeywordET : BaseET
	{
	#region Attributes
		 public const String FIELD_News_KeywordID = "News_KeywordID"; 
		 public const String FIELD_NewsID = "NewsID"; 
		 public const String FIELD_Version = "Version"; 
		 public const String FIELD_KeywordID = "KeywordID"; 
		 public const String FIELD_Keyword = "Keyword"; 
		 public const String FIELD_KeywordIndex = "KeywordIndex"; 
		 public const String FIELD_KeywordNoSign = "KeywordNoSign"; 
		 public const String FIELD_Hits = "Hits"; 
		 public const String FIELD_Note = "Note"; 
	#endregion Attributes
		/// <summary>
		///News_KeywordID News_KeywordID
		/// </summary>
		private Guid _News_KeywordID; 
		public Guid News_KeywordID { get{ return _News_KeywordID; } set{ _News_KeywordID = value; } }
		/// <summary>
		///NewsID NewsID
		/// </summary>
		private Guid? _NewsID; 
		public Guid? NewsID { get{ return _NewsID; } set{ _NewsID = value; } }
		/// <summary>
		///Version Version
		/// </summary>
		private int? _Version; 
		public int? Version { get{ return _Version; } set{ _Version = value; } }
		/// <summary>
		///KeywordID KeywordID
		/// </summary>
		private Guid? _KeywordID; 
		public Guid? KeywordID { get{ return _KeywordID; } set{ _KeywordID = value; } }
		/// <summary>
		///Keyword Keyword
		/// </summary>
		private string _Keyword; 
		public string Keyword { get{ return _Keyword; } set{ _Keyword = value; } }
		/// <summary>
		///KeywordIndex KeywordIndex
		/// </summary>
		private string _KeywordIndex; 
		public string KeywordIndex { get{ return _KeywordIndex; } set{ _KeywordIndex = value; } }
		/// <summary>
		///KeywordNoSign KeywordNoSign
		/// </summary>
		private string _KeywordNoSign; 
		public string KeywordNoSign { get{ return _KeywordNoSign; } set{ _KeywordNoSign = value; } }
		/// <summary>
		///Hits Hits
		/// </summary>
		private int? _Hits; 
		public int? Hits { get{ return _Hits; } set{ _Hits = value; } }
		/// <summary>
		///Note Note
		/// </summary>
		private string _Note; 
		public string Note { get{ return _Note; } set{ _Note = value; } }
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
		/// Bachdx		24/06/2016		Tạo mới
		///</Modified>
		public CMS_News_KeywordET()
		{
			News_KeywordID = Guid.Empty;
			NewsID = Guid.Empty;
			Version = 0;
			KeywordID = Guid.Empty;
			Keyword = string.Empty;
			KeywordIndex = string.Empty;
			KeywordNoSign = string.Empty;
			Hits = 0;
			Note = string.Empty;
		}
	}
}

