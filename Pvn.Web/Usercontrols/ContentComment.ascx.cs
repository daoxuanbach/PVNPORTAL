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
    public partial class ContentComment : System.Web.UI.UserControl
    {
        private Guid NewsID
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["NewsID"]) ? new Guid(Request.QueryString["NewsID"]) : Guid.Empty;
            }
        }

        int totalRows = 0;

        public int TotalRows
        {
            set { totalRows = value; }
            get { return totalRows; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pgMain.PageSize = 5;
                pgMain.ShowFirstLast = false;
                pgMain.ShowFirstLast = false;
                pgMain.CurrentPageIndex = 1;

                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                CommentDA objCommentDA = new CommentDA();
                int totalRows = 0;
                DataTable dt = objCommentDA.GetPaging(pgMain.CurrentPageIndex - 1, pgMain.PageSize, ref totalRows, NewsID);
                if (dt == null || dt.Rows.Count == 0)
                {
                    rptComment.Visible = false;
                    pnlTitle.Visible = false;
                }
                pgMain.RecordCount = TotalRows = totalRows;
                rptComment.DataSource = dt;
                rptComment.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }



        protected void pgMain_PageChanged(object src, EventArgs e)
        {
            BindData();
        }
    }
}