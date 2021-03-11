using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucDocBao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    //init paging
                    pgMain.PageSize = TotalItems;
                    pgMain.ShowFirstLast = false;
                    pgMain.ShowFirstLast = false;
                    pgMain.CurrentPageIndex = 1;

                  
                    //bind data
                    BindData();
                }
                catch (Exception exc)
                {
                    Pvn.Utils.LogFile.WriteLogFile("wpDocumentListUserControl", "Page_Load", exc.Message);

                }
            }
        }
        protected void pgMain_PageChanged(object src, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// bind news list data
        /// </summary>
        private void BindData()
        {
            try
            {
                DocumentBL objBL = new DocumentBL();
                Guid idLoaiVanBan = new Guid(IDLoaiVanBan);
                int totalRows = 0;
                string categoryName = string.Empty;
                DataTable dt = objBL.GetDocBaoPagingSort(pgMain.CurrentPageIndex - 1,
                    TotalItems, ref totalRows, idLoaiVanBan);

                ltrDocTitle.Text = TieuDe;

                //bind griddata
                pgMain.RecordCount = totalRows;
                rptDocumentList.DataSource = ProcessDocData(dt);
                rptDocumentList.DataBind();


            }
            catch (Exception exc)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpDocumentListUserControl", "BindData", exc.Message);
                //CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }
        protected void rptDocumentList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            try
            {
                //ImageButton ImagesortSoVb = (ImageButton)e.Item.FindControl("ImagesortSoVb");
                //ImagesortSoVb.im
                switch (e.CommandName)
                {
                    case "DownloadDocAttach":

                        string keyID = Convert.ToString(e.CommandArgument);
                        if (!string.IsNullOrEmpty(keyID))
                        {
                            Sys_FileBinaryBL binaryDAO = new Sys_FileBinaryBL();
                            Sys_FileBinary sfInfo = new Sys_FileBinary();
                            sfInfo.FileBinaryID = new Guid(keyID);
                            binaryDAO.GetItemByPK(ref sfInfo);
                            if (sfInfo != null)
                            {
                                byte[] fileDownload = sfInfo.FileAttach;
                                if (fileDownload != null && fileDownload.Length > 0 && !string.IsNullOrEmpty(sfInfo.FileName))
                                {
                                    HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=\"" + sfInfo.FileName + "\"");
                                    HttpContext.Current.Response.ContentType = Path.GetExtension(sfInfo.FileName).Replace(@".", "");
                                    HttpContext.Current.Response.BinaryWrite(fileDownload);
                                    HttpContext.Current.Response.Flush();
                                    HttpContext.Current.Response.End();
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpDocumentListUserControl", "rptDocumentList_ItemCommand", ex.Message);
            }
        }
        private List<DocInfo> ProcessDocData(DataTable dtDocVanBan)
        {
            if (dtDocVanBan != null && dtDocVanBan.Rows.Count > 0)
            {
                //first select companyid
                DataView dvDocID = new DataView(dtDocVanBan);
                DataTable dtDocID = dvDocID.ToTable(true, "VanBanID");

                List<DocInfo> lstDocInfo = new List<DocInfo>();
                for (int i = 0; i < dtDocID.Rows.Count; i++)
                {
                    DataRow[] drDocInfo = dtDocVanBan.Select(string.Format("VanBanID = '{0}'", dtDocID.Rows[i]["VanBanID"]));
                    if (drDocInfo != null && drDocInfo.Length > 0)
                    {
                        DocInfo objDocInfo = new DocInfo();
                        //set tieu de and ngay ban hanh
                        objDocInfo.STT = Convert.ToString(drDocInfo[0]["STT"]);
                        objDocInfo.TieuDe = Convert.ToString(drDocInfo[0]["TieuDe"]);
                        objDocInfo.SoVanBan = Convert.ToString(drDocInfo[0]["SoVanBan"]);
                        try
                        {
                            objDocInfo.NgayBanHanh = Convert.ToDateTime(drDocInfo[0]["NgayBanHanh"]);
                        }
                        catch (Exception ex)
                        {
                            objDocInfo.NgayBanHanh = null;
                        }

                        //set file
                        //dictionary<filebinaryid, file title>
                        Dictionary<string, string> dicFile = new Dictionary<string, string>();
                        foreach (DataRow dr in drDocInfo)
                        {
                            dicFile.Add(Convert.ToString(dr["FileBinaryID"]), Convert.ToString(dr["NgayBanHanh"]));// Convert.ToString(dr["FileName"]));
                        }
                        objDocInfo.FileAttach = dicFile;
                        lstDocInfo.Add(objDocInfo);
                    }
                }
                return lstDocInfo;
            }
            return null;
        }

        private string _TieuDe = string.Empty;
        public String TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        private string _idLoaiVanBan = string.Empty;
        public String IDLoaiVanBan
        {
            get { return _idLoaiVanBan; }
            set { _idLoaiVanBan = value; }
        }
        private int _totalItems;
      
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }
    }
}