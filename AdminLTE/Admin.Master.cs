using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Timeout = 3600;
                Session.Add("UserID", "1");

                //if (Request.Cookies["PVN_CMS_Remember"] == null)
                //    Response.Redirect("/NguoiDung/DangNhap/DangNhap.aspx?ref=" + Request.RawUrl);
                //else
                //{
                //    HttpCookie cookie = Request.Cookies.Get("PVN_CMS_Remember");
                //    long IDNguoiDung = 0;
                //    //autologin
                //    objQTNguoiDung.Login(cookie.Values["PVN_CMS_Remember"], cookie.Values["SNV_LuuTru_Pwd"], out IDNguoiDung);
                //    if (IDNguoiDung > 0)
                //    {
                //        Session.Timeout = 3600;
                //        Session.Add("UserID", IDNguoiDung);
                //        Session.Add("UserName", cookie.Values["PVN_CMS_Remember"]);
                //        objNguoiSuDung = objQTNguoiDung.GetInfo(Convert.ToInt32(IDNguoiDung));
                //        if (objNguoiSuDung.YeuCauDoiMatKhau && !Request.RawUrl.Contains("/NguoiDung/DoiMatKhau/ChangePassword.aspx"))
                //            Response.Redirect("/NguoiDung/DoiMatKhau/ChangePassword.aspx");
                //    }
                //    else
                //        Response.Redirect("/NguoiDung/DangNhap/DangNhap.aspx?ref=" + Request.RawUrl);
                //}
            }
            else
            {
                
            }
        }
    }
}