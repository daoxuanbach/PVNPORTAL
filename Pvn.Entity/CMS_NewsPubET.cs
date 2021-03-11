using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class CMS_NewsPubET 
	{
	  
         /// <summary>
		///NewsID NewsID
		/// </summary>
		private Guid _NewsPublishingID; 
		public Guid NewsPublishingID { get{ return _NewsPublishingID; } set{ _NewsPublishingID = value; } }
		/// <summary>
		///CategoryID CategoryID
		/// </summary>
		private Guid? _CategoryID; 
		public Guid? CategoryID { get{ return _CategoryID; } set{ _CategoryID = value; } }
        /// <summary>
		///CategoryID CategoryID
		/// </summary>
		private String _CategoryName; 
		public String CategoryName { get{ return _CategoryName; } set{ _CategoryName = value; } }
		
		/// <summary>
		///RatingState RatingState
		/// </summary>
        //private int? _RatingState; 
        //public int? RatingState { get{ return _RatingState; } set{ _RatingState = value; } }
		
		/// <summary>
		///Title Title
		/// </summary>
		private string _Title; 
		public string Title { get{ return _Title; } set{ _Title = value; } }
		
		/// <summary>
		///Summary Summary
		/// </summary>
		private string _Summary; 
		public string Summary { get{ return _Summary; } set{ _Summary = value; } }
		
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
        private DateTime? _BeginDate;
        public DateTime? BeginDate { get { return _BeginDate; } set { _BeginDate = value; } }
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        private DateTime? _ApprovedDate;
        public DateTime? ApprovedDate { get { return _ApprovedDate; } set { _ApprovedDate = value; } }
    }
}

