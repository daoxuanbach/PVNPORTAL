using Pvn.DA;
using Pvn.Web.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class Comment : System.Web.UI.UserControl
    {
        private Guid NewsID
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["NewsID"]) ? new Guid(Request.QueryString["NewsID"]) : Guid.Empty;
            }
        }
        /// <summary>
        /// user comment email
        /// </summary>
        public string UserEmail
        {
            get;
            set;
        }
        /// <summary>
        /// user comment name
        /// </summary>
        public string UserName
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    imgCaptcha.ImageUrl = @"/Usercontrols/GetCaptcha.ashx";
                    //ScriptManager.RegisterStartupScript(this.UpdatePanel2, typeof(Page), "popUpAlert", "imgsecuri_click()", true);
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    //CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
        }



        /// <summary>
        /// btnSend_Click: Send comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                CommentDA conmentDA = new CommentDA();
                string newsText = Convert.ToString(Session[CaptchaHelper.SESSION_CAPTCHA]);

                if (newsText.ToUpper() == txtMa.Text.Trim().ToUpper())
                {

                    conmentDA.AddNewsComment(
                        NewsID,
                        string.Empty,
                        txtNoiDung.Text.Trim(),
                        txtHoTen.Text.Trim(),
                        txtMa.Text.Trim(),
                        string.Empty,
                        string.Empty,
                        txtEmail.Text.Trim(),
                        DateTime.Now, null);
                    EmptyTextBox();
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "popUpAlert",
                    //                                             "$(document).ready(function () {alert('Gửi thông tin thành công !');});", true);
                    ScriptManager.RegisterClientScriptBlock(this.udpComment, this.GetType(), "popUpAlert", "alert('" + hdfPostSuccess.Value + "');imgsecuri_click()", true);
                }
                else
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "popUpAlert",
                    //                                             "$(document).ready(function () {alert('Mã xác nhận không đúng !');});", true);
                    ScriptManager.RegisterClientScriptBlock(this.udpComment, this.GetType(), "popUpAlert", "alert('" + hdfPostFail.Value + "');imgsecuri_click()", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        /// <summary>
        /// EmptyTextBox
        /// </summary>
        private void EmptyTextBox()
        {
            txtHoTen.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
            txtMa.Text = string.Empty;
        }
    }
}