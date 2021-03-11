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
    public partial class ucImagesVideoMain : System.Web.UI.UserControl
    {
        #region Khai bao
        public string ChuyenMucAnh = string.Empty;
        private Guid? cateAnhId;
        private Guid? cateVideoId;
        private String _UrlLinkAnh;
        public String UrlLinkAnh
        {
            get { return _UrlLinkAnh; }
            set { _UrlLinkAnh = value; }
        }
        private String _UrlLinkVideo;
        public String UrlLinkVideo
        {
            get { return _UrlLinkVideo; }
            set { _UrlLinkVideo = value; }
        }
        private string _TenTab;

        public string TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
        private string _TenTabVideo;

        public string TenTabVideo
        {
            get { return _TenTabVideo; }
            set { _TenTabVideo = value; }
        }
        
        private String _CategoryAnhId;
        public String CategoryAnhId
        {
            get { return _CategoryAnhId; }
            set { _CategoryAnhId = value; }
        }
        private String _CategoryVideoId;
        public String CategoryVideoId
        {
            get { return _CategoryVideoId; }
            set { _CategoryVideoId = value; }
        }
        private int _TotalItems;
        public int TotalItems
        {
            get { return _TotalItems; }
            set { _TotalItems = value; }
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
            BindDataAnh();
            BindDataVideo();
        }
        #region BindData

        /// <summary>
        /// Bind video data
        /// </summary>
        private void BindDataVideo()
        {
            try
            {
                CMS_VideoBL objBL = new CMS_VideoBL();

                if (!string.IsNullOrEmpty(CategoryVideoId))
                {
                    cateVideoId = new Guid(CategoryVideoId);
                }
                DataTable dtVideoResult = objBL.GetVideoMain(Pvn.Utils.Constants.Language.VIETNAMESE, cateVideoId);
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
        /// <summary>
        /// Bind video data
        /// </summary>
        private void BindDataAnh()
        {
            try
            {

                CMS_ImageBL objBL = new CMS_ImageBL();
                if (!string.IsNullOrEmpty(CategoryAnhId))
                {
                    cateAnhId = new Guid(CategoryAnhId);
                }
                DataTable dtVideoResult = objBL.GetImageMain(Pvn.Utils.Constants.Language.VIETNAMESE, cateAnhId, TotalItems);
                //display image
                if (dtVideoResult == null || dtVideoResult.Rows.Count == 0)
                    return;
                else
                {
                    ChuyenMucAnh = Convert.ToString(dtVideoResult.Rows[0]["ChuyenMuc"]);
                    rptImageList.DataSource = dtVideoResult;
                    rptImageList.DataBind();
                }




            }
            catch (Exception exc)
            {
                //Module failed to load 
                // CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }
        #endregion
    }
}