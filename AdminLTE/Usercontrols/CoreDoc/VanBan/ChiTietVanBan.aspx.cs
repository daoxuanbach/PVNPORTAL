using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.VanBan
{
    public partial class ChiTietVanBan : System.Web.UI.Page
    {
        public string btnsubmit = "Gửi phê duyệt";
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Doc_VanBanET objItemET = new Doc_VanBanET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
            if (action.ToUpper() == "viewApproved".ToUpper())
            {
                hidAction.Value = "viewApproved";
                Page.Title = Resources.vi.fSysFunctionEdit;
                bindingData(ItemID);
            }
            switch (action)
            {
                case "viewApproved":
                    hidAction.Value = "viewApproved";
                    Page.Title = "Xem và gửi phê duyệt";
                    bindingData(ItemID);
                    break;
                case "xuatban":
                    btnsubmit = "Ban hành văn bản";
                    hidAction.Value = "xuatban";
                    Page.Title = "Xem và xuất bản";
                    bindingData(ItemID);
                    break;
                default:
                    break;
            }
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["ItemID"]))
            {
                ItemID = Request["ItemID"].Trim();
            }
        }
        #region Bidingdata
        private void bindingData(string ItemID)
        {
            Guid GuidID = new Guid(ItemID);
            Doc_VanBanDA objDA = new Doc_VanBanDA();
            objItemET = objDA.GetInfo(GuidID);
        }

        private void BindComboBox()
        {
            try
            {
                Doc_LoaiVanBanDA LoaiVBDA = new Doc_LoaiVanBanDA();
                //LoaiVBDA.GetAllItemTree();
                rptLoaiVanBan.DataSource= LoaiVBDA.GetAllItemTree();
                rptLoaiVanBan.DataBind();

                Doc_LinhVucVanBanDA LinhvucDA = new Doc_LinhVucVanBanDA();
               
                rptLinhVuc.DataSource = LinhvucDA.GetAllData();
                rptLinhVuc.DataBind();

                Doc_DonViBanHanhDA DonViBanHanhDA = new Doc_DonViBanHanhDA();
                rptDonViBanHanh.DataSource = DonViBanHanhDA.GetAllData();
                rptDonViBanHanh.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}