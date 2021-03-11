using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.VanBan
{
    public partial class viewPheDuyet : System.Web.UI.Page
    {
        public string btnsubmit = "Gửi phê duyệt";
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Doc_VanBanET objItemET = new Doc_VanBanET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = "Quản lý hệ thống";
            BindComboBox();
            switch (action)
            {
                case "pheduyet":
                    btnsubmit = "Ban hành văn bản";
                    hidAction.Value = "pheduyet";
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
            JavaScriptSerializer js = new JavaScriptSerializer();

            Guid GuidID = new Guid(ItemID);
            Doc_VanBanDA objDA = new Doc_VanBanDA();
            objItemET = objDA.GetInfo(GuidID);
            if (!string.IsNullOrEmpty(objItemET.DuongDanVanBan))
            {
                var ltsFileForm = js.Deserialize<List<FileAttachForm>>(objItemET.DuongDanVanBan);
                rptAttach.DataSource = ltsFileForm;
                rptAttach.DataBind();
            }
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