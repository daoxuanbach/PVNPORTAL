using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_LogET : BaseET
    {
        #region Attributes
        public const String FIELD_ID = "ID";
        public const String FIELD_FunctionID = "FunctionID";
        public const String FIELD_ThaoTac = "ThaoTac";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///ID ID
        /// </summary>
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        /// <summary>
        ///FunctionID FunctionID
        /// </summary>
        private Guid? _FunctionID;
        public Guid? FunctionID { get { return _FunctionID; } set { _FunctionID = value; } }
        /// <summary>
        ///ThaoTac ThaoTac
        /// </summary>
        private int? _ThaoTac;
        public int? ThaoTac { get { return _ThaoTac; } set { _ThaoTac = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        private string _ClientIP;
        public string ClientIP { get { return _ClientIP; } set { _ClientIP = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private string _CreatedBy;
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///CreatedDate CreatedDate
        /// </summary>
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		12/10/2017		Tạo mới
        ///</Modified>
        public Sys_LogET()
        {
            ID = 0;
            FunctionID = Guid.Empty;
            ThaoTac = 0;
            Note = string.Empty;
            CreatedDate = DateTime.Now;
        }
    }
}

