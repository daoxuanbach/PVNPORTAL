using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Doc_VanBanET : BaseET
    {
        #region Attributes
        public const String FIELD_VanBanID = "VanBanID";
        public const String FIELD_NgonNgu = "NgonNgu";
        public const String FIELD_SoVanBan = "SoVanBan";
        public const String FIELD_KieuVanBan = "KieuVanBan";
        public const String FIELD_TrangThaiVanBan = "TrangThaiVanBan";
        public const String FIELD_LoaiVanBanID = "LoaiVanBanID";
        public const String FIELD_LinhVucID = "LinhVucID";
        public const String FIELD_NgayBanHanh = "NgayBanHanh";
        public const String FIELD_NgayHetHan = "NgayHetHan";
        public const String FIELD_NgayThuHoi = "NgayThuHoi";
        public const String FIELD_NgayDangCongBao = "NgayDangCongBao";
        public const String FIELD_TieuDe = "TieuDe";
        public const String FIELD_PhamVi = "PhamVi";
        public const String FIELD_PhamViVanBan = "PhamViVanBan";
        public const String FIELD_NguonTrich = "NguonTrich";
        public const String FIELD_NgayHieuLuc = "NgayHieuLuc";
        public const String FIELD_NgayHetHieuLuc = "NgayHetHieuLuc";
        public const String FIELD_NgayApDung = "NgayApDung";
        public const String FIELD_LyDoHetHieuLuc = "LyDoHetHieuLuc";
        public const String FIELD_PhanHetHieuLuc = "PhanHetHieuLuc";
        public const String FIELD_ToanVanVanBan = "ToanVanVanBan";
        public const String FIELD_NoiDungVanBan = "NoiDungVanBan";
        public const String FIELD_DuongDanVanBan = "DuongDanVanBan";
        public const String FIELD_GhiChu = "GhiChu";
        public const String FIELD_NgayTao = "NgayTao";
        public const String FIELD_NgaySua = "NgaySua";
        public const String FIELD_DonViBanHanhID = "DonViBanHanhID";
        public const String FIELD_NguoiKy = "NguoiKy";
        public const String FIELD_ChucDanh = "ChucDanh";
        #endregion Attributes
        /// <summary>
        ///VanBanID VanBanID
        /// </summary>
        private Guid _VanBanID;
        public Guid VanBanID { get { return _VanBanID; } set { _VanBanID = value; } }
        /// <summary>
        ///NgonNgu NgonNgu
        /// </summary>
        private string _NgonNgu;
        public string NgonNgu { get { return _NgonNgu; } set { _NgonNgu = value; } }
        /// <summary>
        ///SoVanBan SoVanBan
        /// </summary>
        private string _SoVanBan;
        public string SoVanBan { get { return _SoVanBan; } set { _SoVanBan = value; } }
        /// <summary>
        ///KieuVanBan KieuVanBan
        /// </summary>
        private int? _KieuVanBan;
        public int? KieuVanBan { get { return _KieuVanBan; } set { _KieuVanBan = value; } }
        /// <summary>
        ///TrangThaiVanBan TrangThaiVanBan
        /// </summary>
        private int? _TrangThaiVanBan;
        public int? TrangThaiVanBan { get { return _TrangThaiVanBan; } set { _TrangThaiVanBan = value; } }
        /// <summary>
        ///LoaiVanBanID LoaiVanBanID
        /// </summary>
        private Guid? _LoaiVanBanID;
        public Guid? LoaiVanBanID { get { return _LoaiVanBanID; } set { _LoaiVanBanID = value; } }
        /// <summary>
        ///LinhVucID LinhVucID
        /// </summary>
        private Guid? _LinhVucID;
        public Guid? LinhVucID { get { return _LinhVucID; } set { _LinhVucID = value; } }
        /// <summary>
        ///NgayBanHanh NgayBanHanh
        /// </summary>
        private DateTime? _NgayBanHanh;
        public DateTime? NgayBanHanh { get { return _NgayBanHanh; } set { _NgayBanHanh = value; } }
        /// <summary>
        ///NgayHetHan NgayHetHan
        /// </summary>
        private DateTime? _NgayHetHan;
        public DateTime? NgayHetHan { get { return _NgayHetHan; } set { _NgayHetHan = value; } }
        /// <summary>
        ///NgayThuHoi NgayThuHoi
        /// </summary>
        private DateTime? _NgayThuHoi;
        public DateTime? NgayThuHoi { get { return _NgayThuHoi; } set { _NgayThuHoi = value; } }
        /// <summary>
        ///NgayDangCongBao NgayDangCongBao
        /// </summary>
        private DateTime? _NgayDangCongBao;
        public DateTime? NgayDangCongBao { get { return _NgayDangCongBao; } set { _NgayDangCongBao = value; } }
        /// <summary>
        ///TieuDe TieuDe
        /// </summary>
        private string _TieuDe;
        public string TieuDe { get { return _TieuDe; } set { _TieuDe = value; } }
        /// <summary>
        ///PhamVi PhamVi
        /// </summary>
        private int? _PhamVi;
        public int? PhamVi { get { return _PhamVi; } set { _PhamVi = value; } }
        /// <summary>
        ///PhamViVanBan PhamViVanBan
        /// </summary>
        private string _PhamViVanBan;
        public string PhamViVanBan { get { return _PhamViVanBan; } set { _PhamViVanBan = value; } }
        /// <summary>
        ///NguonTrich NguonTrich
        /// </summary>
        private string _NguonTrich;
        public string NguonTrich { get { return _NguonTrich; } set { _NguonTrich = value; } }
        /// <summary>
        ///NgayHieuLuc NgayHieuLuc
        /// </summary>
        private DateTime? _NgayHieuLuc;
        public DateTime? NgayHieuLuc { get { return _NgayHieuLuc; } set { _NgayHieuLuc = value; } }
        /// <summary>
        ///NgayHetHieuLuc NgayHetHieuLuc
        /// </summary>
        private DateTime? _NgayHetHieuLuc;
        public DateTime? NgayHetHieuLuc { get { return _NgayHetHieuLuc; } set { _NgayHetHieuLuc = value; } }
        /// <summary>
        ///NgayApDung NgayApDung
        /// </summary>
        private DateTime? _NgayApDung;
        public DateTime? NgayApDung { get { return _NgayApDung; } set { _NgayApDung = value; } }
        /// <summary>
        ///LyDoHetHieuLuc LyDoHetHieuLuc
        /// </summary>
        private string _LyDoHetHieuLuc;
        public string LyDoHetHieuLuc { get { return _LyDoHetHieuLuc; } set { _LyDoHetHieuLuc = value; } }
        /// <summary>
        ///PhanHetHieuLuc PhanHetHieuLuc
        /// </summary>
        private string _PhanHetHieuLuc;
        public string PhanHetHieuLuc { get { return _PhanHetHieuLuc; } set { _PhanHetHieuLuc = value; } }
        /// <summary>
        ///ToanVanVanBan ToanVanVanBan
        /// </summary>
        private byte[] _ToanVanVanBan;
        public byte[] ToanVanVanBan { get { return _ToanVanVanBan; } set { _ToanVanVanBan = value; } }
        /// <summary>
        ///NoiDungVanBan NoiDungVanBan
        /// </summary>
        private string _NoiDungVanBan;
        public string NoiDungVanBan { get { return _NoiDungVanBan; } set { _NoiDungVanBan = value; } }
        /// <summary>
        ///DuongDanVanBan DuongDanVanBan
        /// </summary>
        private string _DuongDanVanBan;
        public string DuongDanVanBan { get { return _DuongDanVanBan; } set { _DuongDanVanBan = value; } }
        /// <summary>
        ///GhiChu GhiChu
        /// </summary>
        private string _GhiChu;
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; } }
        /// <summary>
        ///NgayTao NgayTao
        /// </summary>
        private DateTime? _NgayTao;
        public DateTime? NgayTao { get { return _NgayTao; } set { _NgayTao = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private string _CreatedBy;
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///NgaySua NgaySua
        /// </summary>
        private DateTime? _NgaySua;
        public DateTime? NgaySua { get { return _NgaySua; } set { _NgaySua = value; } }
        /// <summary>
        ///ModifiedBy ModifiedBy
        /// </summary>
        private string _ModifiedBy;
        public string ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        /// <summary>
        ///DonViBanHanhID DonViBanHanhID
        /// </summary>
        private Guid? _DonViBanHanhID;
        public Guid? DonViBanHanhID { get { return _DonViBanHanhID; } set { _DonViBanHanhID = value; } }
        /// <summary>
        ///NguoiKy NguoiKy
        /// </summary>
        private string _NguoiKy;
        public string NguoiKy { get { return _NguoiKy; } set { _NguoiKy = value; } }
        /// <summary>
        ///ChucDanh ChucDanh
        /// </summary>
        private string _ChucDanh;
        public string ChucDanh { get { return _ChucDanh; } set { _ChucDanh = value; } }

        public int ThuTu { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		12/04/2017		Tạo mới
        ///</Modified>
        public Doc_VanBanET()
        {
            NgayTao = DateTime.Now;
            NgaySua = DateTime.Now;
        }
    }
}
