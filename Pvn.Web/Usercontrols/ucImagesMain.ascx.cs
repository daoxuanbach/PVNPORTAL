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
    public partial class ucImagesMain : System.Web.UI.UserControl
    {
        #region Khai bao
        public string ChuyenMucAnh = string.Empty;
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
               
                CMS_ImageBL objBL = new CMS_ImageBL();
                if (!string.IsNullOrEmpty(CategoryId))
                {
                    cateId = new Guid(CategoryId);
                }
                int totalRows = 0;
                DataTable dtVideoResult = objBL.GetImageMain(Pvn.Utils.Constants.Language.VIETNAMESE, cateId, TotalItems);
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