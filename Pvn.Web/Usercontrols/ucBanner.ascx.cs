using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucBanner : System.Web.UI.UserControl
    {
        public string SpeedVar { get; set; }
        public string TextVar { get; set; }
        private short _totalItems;
        private short _bannerPosition;
        private bool _isBannerText;

        /// <summary>
        /// Number of news item
        /// </summary>
        public short TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }

        /// <summary>
        /// banner position
        /// </summary>
        public short BannerPosition
        {
            get { return _bannerPosition; }
            set { _bannerPosition = value; }
        }

        /// <summary>
        /// banner text
        /// </summary>
        public bool IsBannerText
        {
            get { return _isBannerText; }
            set { _isBannerText = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                //bind flash vars
                BindFlashVars();

                BindData();
            }
        }

        #region "BindData"
        private void BindData()
        {
            try
            {
                AdvertismentDA objDA = new AdvertismentDA();
                DataTable dt = objDA.getAdvertismentByPosition(Pvn.Utils.Constants.Language.VIETNAMESE, TotalItems, BannerPosition);
                if (IsBannerText)
                {
                    rptBannerText.DataSource = dt;
                    rptBannerText.DataBind();
                }
                else
                {
                    rptBanner.DataSource = dt;
                    rptBanner.DataBind();
                }
            }
            catch (Exception exc)
            {
            
            }
        }
        #endregion
        /// <summary>
        /// Is flash file or not
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public bool IsFlashFile(object imageUrl)
        {
            bool result = Convert.ToString(imageUrl).EndsWith(".swf");
            return result;
        }
        public void BindFlashVars()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable table = objDA.GetParameterByNameLanguage("Banner", Pvn.Utils.Constants.Language.VIETNAMESE);

                //Sys_Parameter objDAO = new Sys_ParameterDAO();
                //var table = objDAO.GetByLanguageAndNameAndUsedState(Pvn.Utils.Constants.Language.VIETNAMESE, "Banner", 1);
                //set speedvar
                DataRow[] drRate = table.Select("Value = '1'");
                if (drRate != null && drRate.Length > 0)
                {
                    SpeedVar = Convert.ToString(drRate[0]["Note"]);
                }
                else
                {
                    SpeedVar = "3";
                }
                //set textvar 
                DataRow[] drText = table.Select("Value = '2'");
                if (drText != null && drText.Length > 0)
                {
                    TextVar = Convert.ToString(drText[0]["Note"]);
                }
                else
                {
                    TextVar = string.Empty;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}