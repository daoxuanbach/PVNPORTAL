using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class WFWorkflowET : BaseET
    {
        #region Attributes
        public const String FIELD_WorkflowID = "WorkflowID";
        public const String FIELD_WorkflowTemplateID = "WorkflowTemplateID";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_Name = "Name";
        public const String FIELD_NameIndex = "NameIndex";
        public const String FIELD_NameEn = "NameEn";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_WFType = "WFType";
        public const String FIELD_WFOutType = "WFOutType";
        public const String FIELD_WFTimeType = "WFTimeType";
        public const String FIELD_WFResetTime = "WFResetTime";
        public const String FIELD_WFDoingBack = "WFDoingBack";
        public const String FIELD_WFJump = "WFJump";
        public const String FIELD_WFGetJump = "WFGetJump";
        public const String FIELD_WFEdit = "WFEdit";
        public const String FIELD_IconPath = "IconPath";
        public const String FIELD_ToP = "ToP";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///WorkflowID WorkflowID
        /// </summary>
        private Guid _WorkflowID;
        public Guid WorkflowID { get { return _WorkflowID; } set { _WorkflowID = value; } }
        /// <summary>
        ///WorkflowTemplateID WorkflowTemplateID
        /// </summary>
        private Guid? _WorkflowTemplateID;
        public Guid? WorkflowTemplateID { get { return _WorkflowTemplateID; } set { _WorkflowTemplateID = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///NameIndex NameIndex
        /// </summary>
        private string _NameIndex;
        public string NameIndex { get { return _NameIndex; } set { _NameIndex = value; } }
        /// <summary>
        ///NameEn NameEn
        /// </summary>
        private string _NameEn;
        public string NameEn { get { return _NameEn; } set { _NameEn = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///WFType WFType
        /// </summary>
        private int? _WFType;
        public int? WFType { get { return _WFType; } set { _WFType = value; } }
        /// <summary>
        ///WFOutType WFOutType
        /// </summary>
        private int? _WFOutType;
        public int? WFOutType { get { return _WFOutType; } set { _WFOutType = value; } }
        /// <summary>
        ///WFTimeType WFTimeType
        /// </summary>
        private int? _WFTimeType;
        public int? WFTimeType { get { return _WFTimeType; } set { _WFTimeType = value; } }
        /// <summary>
        ///WFResetTime WFResetTime
        /// </summary>
        private int? _WFResetTime;
        public int? WFResetTime { get { return _WFResetTime; } set { _WFResetTime = value; } }
        /// <summary>
        ///WFDoingBack WFDoingBack
        /// </summary>
        private int? _WFDoingBack;
        public int? WFDoingBack { get { return _WFDoingBack; } set { _WFDoingBack = value; } }
        /// <summary>
        ///WFJump WFJump
        /// </summary>
        private int? _WFJump;
        public int? WFJump { get { return _WFJump; } set { _WFJump = value; } }
        /// <summary>
        ///WFGetJump WFGetJump
        /// </summary>
        private int? _WFGetJump;
        public int? WFGetJump { get { return _WFGetJump; } set { _WFGetJump = value; } }
        /// <summary>
        ///WFEdit WFEdit
        /// </summary>
        private int? _WFEdit;
        public int? WFEdit { get { return _WFEdit; } set { _WFEdit = value; } }
        /// <summary>
        ///IconPath IconPath
        /// </summary>
        private string _IconPath;
        public string IconPath { get { return _IconPath; } set { _IconPath = value; } }
        /// <summary>
        ///ToP ToP
        /// </summary>
        private int? _ToP;
        public int? ToP { get { return _ToP; } set { _ToP = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
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
        /// Bachdx		17/01/2017		Tạo mới
        ///</Modified>
        public WFWorkflowET()
        {
            WorkflowID = Guid.Empty;
            WorkflowTemplateID = Guid.Empty;
            Ordinal = 0;
            Name = string.Empty;
            NameIndex = string.Empty;
            NameEn = string.Empty;
            UsedState = 0;
            WFType = 0;
            WFOutType = 0;
            WFTimeType = 0;
            WFResetTime = 0;
            WFDoingBack = 0;
            WFJump = 0;
            WFGetJump = 0;
            WFEdit = 0;
            IconPath = string.Empty;
            ToP = 0;
            Note = string.Empty;
        }
    }
}

