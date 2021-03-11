using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucVideoMain : System.Web.UI.UserControl
    {
        #region Khai bao
         private Guid? cateId;
        private String _UrlLink;
        public String UrlLink
        {
            get { return _UrlLink; }
            set { _UrlLink = value; }
        }
        private string _TenTab;

        public string TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }

        private String _CategoryId;
        public String CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }
        private int _MaxLengthTitle;

        public int MaxLengthTitle
        {
            get { return _MaxLengthTitle; }
            set { _MaxLengthTitle = value; }
        }
        #endregion EndKhaiBao
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        #region BindData

        /// <summary>
        /// Bind video data
        /// </summary>
        private void BindData()
        {
            try
            {
                CMS_VideoBL objBL = new CMS_VideoBL();
              
                if (!string.IsNullOrEmpty(CategoryId))
                {
                    cateId = new Guid(CategoryId);
                }
                DataTable dtVideoResult = objBL.GetVideoMain(Pvn.Utils.Constants.Language.VIETNAMESE, cateId);
                //display video
                rptMainVideo.DataSource = dtVideoResult;
                rptMainVideo.DataBind();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("webVideoList", " BindData..", exc.Message);
            }

        }

        #endregion
        
    }
}