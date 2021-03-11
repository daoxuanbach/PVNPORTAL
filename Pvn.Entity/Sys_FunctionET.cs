using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_FunctionET : BaseET
    {
        #region Attributes
        public const String FIELD_FunctionID = "FunctionID";
        public const String FIELD_Language = "Language";
        public const String FIELD_PageID = "PageID";
        public const String FIELD_Name = "Name";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_ParentFunctionID = "ParentFunctionID";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Checksum = "Checksum";
        public const String FIELD_Infor = "Infor";
        public const String FIELD_ImagePath = "ImagePath";
        public const String FIELD_ImageFileName = "ImageFileName";
        //custom 
        public const String FIELD_URL = "URL";
        #endregion Attributes
        /// <summary>
        ///FunctionID FunctionID
        /// </summary>
        private Guid _FunctionID;
        public Guid FunctionID { get { return _FunctionID; } set { _FunctionID = value; } }
        /// <summary>
        ///Language Language
        /// </summary>
        private string _Language;
        public string Language { get { return _Language; } set { _Language = value; } }
        /// <summary>
        ///PageID PageID
        /// </summary>
        private Guid? _PageID;
        public Guid? PageID { get { return _PageID; } set { _PageID = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///ParentFunctionID ParentFunctionID
        /// </summary>
        private Guid? _ParentFunctionID;
        public Guid? ParentFunctionID { get { return _ParentFunctionID; } set { _ParentFunctionID = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///Checksum Checksum
        /// </summary>
        private string _Checksum;
        public string Checksum { get { return _Checksum; } set { _Checksum = value; } }
        /// <summary>
        ///Infor Infor
        /// </summary>
        private string _Infor;
        public string Infor { get { return _Infor; } set { _Infor = value; } }
        /// <summary>
        ///ImagePath ImagePath
        /// </summary>
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
        /// <summary>
        ///ImageFileName ImageFileName
        /// </summary>
        private string _ImageFileName;
        public string ImageFileName { get { return _ImageFileName; } set { _ImageFileName = value; } }
        public string URL { get; set; }
        public const String FIELD_CreatedBy = "CreatedBy";
        public const String FIELD_ModifiedBy = "ModifiedBy";
        public const String FIELD_CreatedDate = "CreatedDate";
        public const String FIELD_ModifiedDate = "ModifiedDate";

        private string _CreatedBy = "1";
        private string _ModifiedBy = "1";


        private DateTime _CreatedDate = DateTime.Now;
        private DateTime _ModifiedDate = DateTime.Now;
        /// <summary>
        /// nguoi tao
        /// </summary>
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        /// <summary>
        /// ngay tao
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        /// <summary>
        /// Ngay sua
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		22/03/2016		Tạo mới
        ///</Modified>
        public Sys_FunctionET()
        {
            FunctionID = Guid.Empty;
            Language = "vi-VN";
            PageID = null;
            Name = string.Empty;
            Ordinal = 1;
            ParentFunctionID =null;
            UsedState = 1;
            Checksum = string.Empty;
            Infor = string.Empty;
            ImagePath = string.Empty;
            ImageFileName = string.Empty;
            URL = string.Empty;
        }



        
    }
}
