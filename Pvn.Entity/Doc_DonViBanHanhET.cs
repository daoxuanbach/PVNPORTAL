using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Doc_DonViBanHanhET : BaseET
    {
        #region Attributes
        public const String FIELD_DonViBanHanhID = "DonViBanHanhID";
        public const String FIELD_NgonNgu = "NgonNgu";
        public const String FIELD_Ma = "Ma";
        public const String FIELD_Ten = "Ten";
        public const String FIELD_TenVietTat = "TenVietTat";
        public const String FIELD_TenTiengAnh = "TenTiengAnh";
        public const String FIELD_TrangThaiSuDung = "TrangThaiSuDung";
        public const String FIELD_GhiChu = "GhiChu";
        public const String FIELD_NgayTao = "NgayTao";
        public const String FIELD_NgaySua = "NgaySua";
        public const String FIELD_DonViBanHanhGroup = "DonViBanHanhGroup";
        #endregion Attributes
        /// <summary>
        ///DonViBanHanhID DonViBanHanhID
        /// </summary>
        private Guid _DonViBanHanhID;
        public Guid DonViBanHanhID { get { return _DonViBanHanhID; } set { _DonViBanHanhID = value; } }
        /// <summary>
        ///NgonNgu NgonNgu
        /// </summary>
        private string _NgonNgu;
        public string NgonNgu { get { return _NgonNgu; } set { _NgonNgu = value; } }
        /// <summary>
        ///Ma Ma
        /// </summary>
        private string _Ma;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        /// <summary>
        ///Ten Ten
        /// </summary>
        private string _Ten;
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        /// <summary>
        ///TenVietTat TenVietTat
        /// </summary>
        private string _TenVietTat;
        public string TenVietTat { get { return _TenVietTat; } set { _TenVietTat = value; } }
        /// <summary>
        ///TenTiengAnh TenTiengAnh
        /// </summary>
        private string _TenTiengAnh;
        public string TenTiengAnh { get { return _TenTiengAnh; } set { _TenTiengAnh = value; } }
        /// <summary>
        ///TrangThaiSuDung TrangThaiSuDung
        /// </summary>
        private int? _TrangThaiSuDung;
        public int? TrangThaiSuDung { get { return _TrangThaiSuDung; } set { _TrangThaiSuDung = value; } }
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
        ///DonViBanHanhGroup DonViBanHanhGroup
        /// </summary>
        private int? _DonViBanHanhGroup;
        public int? DonViBanHanhGroup { get { return _DonViBanHanhGroup; } set { _DonViBanHanhGroup = value; } }
        public Doc_DonViBanHanhET()
        {
            
            NgayTao = DateTime.Now;
            NgaySua = DateTime.Now;
         
        }
    }
}
