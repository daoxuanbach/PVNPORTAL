using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class SysGroupFunctionET : BaseET
	{
	#region Attributes
		 public const String FIELD_Group_FunctionID = "Group_FunctionID"; 
		 public const String FIELD_GroupID = "GroupID"; 
		 public const String FIELD_FunctionID = "FunctionID"; 
		 public const String FIELD_Checksum = "Checksum"; 
	#endregion Attributes
		/// <summary>
		///Group_FunctionID Group_FunctionID
		/// </summary>
		private Guid _Group_FunctionID; 
		public Guid Group_FunctionID { get{ return _Group_FunctionID; } set{ _Group_FunctionID = value; } }
		/// <summary>
		///GroupID GroupID
		/// </summary>
		private Guid? _GroupID; 
		public Guid? GroupID { get{ return _GroupID; } set{ _GroupID = value; } }
		/// <summary>
		///FunctionID FunctionID
		/// </summary>
		private Guid? _FunctionID; 
		public Guid? FunctionID { get{ return _FunctionID; } set{ _FunctionID = value; } }
		/// <summary>
		///Checksum Checksum
		/// </summary>
		private string _Checksum; 
		public string Checksum { get{ return _Checksum; } set{ _Checksum = value; } }
		/// <summary>
		///CreatedBy CreatedBy
		/// </summary>
		private string _CreatedBy; 
		public string CreatedBy { get{ return _CreatedBy; } set{ _CreatedBy = value; } }
		/// <summary>
		///CreatedDate CreatedDate
		/// </summary>
		private DateTime? _CreatedDate; 
		public DateTime? CreatedDate { get{ return _CreatedDate; } set{ _CreatedDate = value; } }
		/// <summary>
		///ModifiedBy ModifiedBy
		/// </summary>
		private string _ModifiedBy; 
		public string ModifiedBy { get{ return _ModifiedBy; } set{ _ModifiedBy = value; } }
		/// <summary>
		///ModifiedDate ModifiedDate
		/// </summary>
		private DateTime? _ModifiedDate; 
		public DateTime? ModifiedDate { get{ return _ModifiedDate; } set{ _ModifiedDate = value; } }

		/// <summary>
		/// Hàm khởi tạo mặc định
		/// </summary>
		///<Modified>
		/// Author		Date		Comment
		/// Bachdx		26/08/2016		Tạo mới
		///</Modified>
		public SysGroupFunctionET()
		{
			Group_FunctionID = Guid.Empty;
			GroupID = Guid.Empty;
			FunctionID = Guid.Empty;
			Checksum = string.Empty;
		}

        public string CheckGroupFunction { get; set; }
        public string FullName { get; set; }
    }
}

