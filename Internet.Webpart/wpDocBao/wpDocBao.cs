using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpDocBao : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols/ucDocBao.ascx";
        ucDocBao _uc = new ucDocBao();

        protected override void CreateChildControls()
        {
            _uc = (ucDocBao)Page.LoadControl(_ascxPath);
            _uc.IDLoaiVanBan = this.IDLoaiVanBan;
            _uc.TieuDe = this.TieuDe;
            _uc.TotalItems = this.TotalItems;
            this.Controls.Add(_uc);
        }
        private string _TieuDe = string.Empty;
          [Browsable(false),
        WebDisplayName("Tieu De"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        private string _idLoaiVanBan = "5D6B1A6E-4F64-4F69-BCCC-B0CB75319CC2";
        [Browsable(false),
        WebDisplayName("IDLoaiVanBan"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String IDLoaiVanBan
        {
            get { return _idLoaiVanBan; }
            set { _idLoaiVanBan = value; }
        }
        private int _totalItems =20;
          [Browsable(false),
        WebDisplayName("TotalItems"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }
       
    }
}
