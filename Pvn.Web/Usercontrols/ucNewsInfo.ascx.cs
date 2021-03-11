using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucNewsInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {
                    //CommonLib.Common.Info.Instance.WriteToLog(ex);
                }
            }
        }

        #region BindData
        private void BindData()
        {
            if (SelectedInfoType.Count > 0)
            {
                List<NewsInfoContent> lstNewsInfo = new List<NewsInfoContent>();
                for (int i = 0; i < SelectedInfoType.Count; i++)
                {
                    var item = SelectedInfoType.ElementAt(i);
                    var tempDT = BindInfoByTypeID(Convert.ToInt32(item.Key));
                    if (tempDT == null || tempDT.Rows.Count == 0)
                    {
                        continue;
                    }
                    //bind detail 
                    NewsInfoContent objNewsInfo = new NewsInfoContent();
                    
                    //add to mail list
                    objNewsInfo.InfoTitle = Convert.ToString(tempDT.Rows[0]["Title"]);
                    objNewsInfo.InfoContent = Convert.ToString(tempDT.Rows[0]["Des"]);
                    lstNewsInfo.Add(objNewsInfo);
                }
                rptNewsContent.DataSource = lstNewsInfo;
                rptNewsContent.DataBind();
            }
        }

        /// <summary>
        /// get news by typeid
        /// </summary>
        /// <param name="infoTypeID"></param>
        /// <returns></returns>
        private DataTable BindInfoByTypeID(int infoTypeID)
        {
            NewsInfoBL objBL = new NewsInfoBL();
            DataTable dt = null;
            try
            {
                dt = objBL.GetNewsInfoByType(infoTypeID);
            }
            catch (Exception ex)
            {
               // CommonLib.Common.Info.Instance.WriteToLog(ex.Message);
            }
            return dt;
        }
        #endregion
        private Dictionary<string, string> dictionary;



        /// <summary>
        /// Number of news item
        /// </summary>
        
        public Dictionary<string, string> SelectedInfoType
        {
            get { return dictionary; }
            set { dictionary = value; }
        }
    }
}