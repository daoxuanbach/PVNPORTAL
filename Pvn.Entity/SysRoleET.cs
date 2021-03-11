using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class SysRoleET : BaseET
    {
        #region Attributes
        public const String FIELD_RoleID = "RoleID";
        public const String FIELD_Name = "Name";
        public const String FIELD_Title = "Title";
        public const String FIELD_ClassView = "ClassView";
        public const String FIELD_IconView = "IconView";
        #endregion Attributes
        private Guid? _FunctionID;
        public Guid? FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }
        /// <summary>
        ///RoleID RoleID
        /// </summary>
        private int _RoleID;
        public int RoleID { get { return _RoleID; } set { _RoleID = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///Title Title
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        ///ClassView ClassView
        /// </summary>
        private string _ClassView;
        public string ClassView { get { return _ClassView; } set { _ClassView = value; } }
        /// <summary>
        ///IconView IconView
        /// </summary>
        private string _IconView;
        public string IconView { get { return _IconView; } set { _IconView = value; } }

        public string FunctionName { get; set; }
        public short ViTri { get; set; }
        public short TrangThai { get; set; }


        private int _QuyTrinh;

        public int QuyTrinh
        {
            get { return _QuyTrinh; }
            set { _QuyTrinh = value; }
        }

        private bool _KetThuc;

        public bool KetThuc
        {
            get { return _KetThuc; }
            set { _KetThuc = value; }
        }
        private int _TrangThaiHienThi;

        public int TrangThaiHienThi
        {
            get { return _TrangThaiHienThi; }
            set { _TrangThaiHienThi = value; }
        }

        private string _TextTrangThaiHienThi;

        public string TextTrangThaiHienThi
        {
            get { return _TextTrangThaiHienThi; }
            set { _TextTrangThaiHienThi = value; }
        }
        private int _TrangThaiGuiDi;

        public int TrangThaiGuiDi
        {
            get { return _TrangThaiGuiDi; }
            set { _TrangThaiGuiDi = value; }
        }
        private string _TextTrangThaiGuiDi;

        public string TextTrangThaiGuiDi
        {
            get { return _TextTrangThaiGuiDi; }
            set { _TextTrangThaiGuiDi = value; }
        }
        private int _TrangThaiTraLai;

        public int TrangThaiTraLai
        {
            get { return _TrangThaiTraLai; }
            set { _TrangThaiTraLai = value; }
        }
        private string _TextTrangThaiTraLai;

        public string TextTrangThaiTraLai
        {
            get { return _TextTrangThaiTraLai; }
            set { _TextTrangThaiTraLai = value; }
        }
        private int _ThuTu;

        public int ThuTu
        {
            get { return _ThuTu; }
            set { _ThuTu = value; }
        }
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public SysRoleET()
        {
            RoleID = 0;
            QuyTrinh = Convert.ToInt16(Pvn.Utils.EnumET.QuyTrinh.Default);
            Name = string.Empty;
            TrangThai = 1;
            Title = string.Empty;
            ClassView = "btn btn-info btn-sm";
            IconView = "fa fa-plus";
        }


    }
}

