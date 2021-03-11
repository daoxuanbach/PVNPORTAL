using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class WFWorkflowTemplateET : BaseET
    {
        #region Attributes
        public const String FIELD_WorkflowTemplateID = "WorkflowTemplateID";
        public const String FIELD_Code = "Code";
        public const String FIELD_Name = "Name";
        public const String FIELD_NameIndex = "NameIndex";
        public const String FIELD_NameEn = "NameEn";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_TotalToP = "TotalToP";
        public const String FIELD_TotalWorkflow = "TotalWorkflow";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///WorkflowTemplateID WorkflowTemplateID
        /// </summary>
        private Guid _WorkflowTemplateID;
        public Guid WorkflowTemplateID { get { return _WorkflowTemplateID; } set { _WorkflowTemplateID = value; } }
        /// <summary>
        ///Code Code
        /// </summary>
        private string _Code;
        public string Code { get { return _Code; } set { _Code = value; } }
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
        ///TotalToP TotalToP
        /// </summary>
        private int? _TotalToP;
        public int? TotalToP { get { return _TotalToP; } set { _TotalToP = value; } }
        /// <summary>
        ///TotalWorkflow TotalWorkflow
        /// </summary>
        private int? _TotalWorkflow;
        public int? TotalWorkflow { get { return _TotalWorkflow; } set { _TotalWorkflow = value; } }
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
        public WFWorkflowTemplateET()
        {
            WorkflowTemplateID = Guid.Empty;
            Code = string.Empty;
            Name = string.Empty;
            NameIndex = string.Empty;
            NameEn = string.Empty;
            UsedState = 0;
            TotalToP = 0;
            TotalWorkflow = 0;
            Note = string.Empty;
        }
    }
}

