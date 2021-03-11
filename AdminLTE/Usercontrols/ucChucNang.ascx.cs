using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols
{
    public partial class ucChucNang : System.Web.UI.UserControl
    {
        public Guid? FunctionID = Guid.Empty;
        private int _ViTri = -1;
        private int? _TrangThaiQT;

        public int? TrangThaiQT
        {
            get { return _TrangThaiQT; }
            set { _TrangThaiQT = value; }
        }
        public int ViTri
        {
            get { return _ViTri; }
            set { _ViTri = value; }
        }
        private int? _QuyTrinh;

        public int? QuyTrinh
        {
            get { return _QuyTrinh; }
            set { _QuyTrinh = value; }
        }
        public string ChucNang = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["FunctionID"]))
                {
                    FunctionID = new Guid(HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["FunctionID"]);
                }
                if (!IsPostBack)
                {
                    BindData();
                    if (ViTri == Convert.ToInt16(Pvn.Utils.EnumET.PositionView.Item))
                    {
                        menuTop.Visible = false;
                        ltlchucnang.Visible = true;
                    }
                    else
                    {
                        menuTop.Visible = true;
                        ltlchucnang.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }

        private void BindData()
        {
            try
            {
                int UserID = new Sys_UserBL().GetUserLogin();
                SysRoleDA objBL = new SysRoleDA();
                List<SysRoleET> lstRole = new List<SysRoleET>();
                if (QuyTrinh !=null || TrangThaiQT != null )
                {
                    lstRole = objBL.GetAll_SysRole_By_QuyTrinh(FunctionID, UserID, ViTri, TrangThaiQT, QuyTrinh);
                }
                else
                {
                    lstRole = objBL.GetAll_SysRole_By_default(FunctionID, UserID, ViTri);
                }

                if (ViTri == -1)
                {
                    List<SysRoleET> lstRoleDefauld = lstRole.Where(p => p.ViTri == Convert.ToInt16(Pvn.Utils.EnumET.PositionView.Default)).ToList();
                    rptchucnang.DataSource = lstRoleDefauld;
                    rptchucnang.DataBind();
                }
                else
                {
                    rptchucnang.DataSource = lstRole;
                    rptchucnang.DataBind();
                }
                List<SysRoleET> lstRoleItem = lstRole.Where(p => p.ViTri == Convert.ToInt16(Pvn.Utils.EnumET.PositionView.Item)).ToList();
                int lstCount = lstRoleItem.Count();
                bool dropdownshow = lstCount > 1;
                string cssfullwidth = "";
                if (!dropdownshow)
                {
                    cssfullwidth= "cssfullwidth";
                }
                if (lstCount > 0)
                {
                    for (int i = 0; i < lstCount; i++)
                    {
                        SysRoleET itemET = lstRoleItem[i];
                        if (i == 0)
                        {
                            ChucNang += "<div class='btn-group'>"
                                         + "<button type = 'button' class='" + itemET.ClassView +" "+ cssfullwidth+ " btn btn-info'><i class='" + itemET.IconView + "'></i>" + itemET.Name + "</button>";
                            if (dropdownshow)
                            {
                                ChucNang += "<button type = 'button' class='btn btn-info dropdown-toggle' data-toggle='dropdown'>"
                                        + "<span class='caret'></span>"
                                        + "<span class='sr-only'>Toggle Dropdown</span>"
                                        + "</button>"
                                        + "<ul class='dropdown-menu' role='menu'>";
                            }

                        }
                        else
                        {
                            ChucNang += "<li><a  class='" + itemET.ClassView + "' title='" + itemET.Name + "' href='javascript: void(0)'> <i class='" + itemET.IconView + "'></i>" + itemET.Name + " </a></li>";
                        }
                        if (i == lstCount - 1)
                        {
                            if (dropdownshow)
                            {
                                ChucNang += "</ul >"
                                    + "</div>";
                            }
                        }

                    }
                    ltlchucnang.Text = ChucNang;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ucChucNang", "BindData", ex.Message);
            }
        }
    }
}