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
    public partial class wpDocumentListUserControl : System.Web.UI.UserControl
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
                 
                    //bind combobox
                    BindCombobox();
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

        #region BindData
        /// <summary>
        /// bind news list data
        /// </summary>
        private void BindData()
        {
            try
            {
                DocumentBL objBL = new DocumentBL();
                //begin and end date
                DateTime? dtFromDate = null;
                DateTime? dtToDate = null;

                //set date time
                if (!string.IsNullOrEmpty(ddlNamBanHanh.SelectedValue))
                {
                    int year = Convert.ToInt32(ddlNamBanHanh.SelectedValue);
                    dtFromDate = new DateTime(year, 1, 1);
                    dtToDate = new DateTime(year, 12, 31);
                }



                int totalRows = 0;
                string categoryName = string.Empty;
                DataTable dt = objBL.GetSearchPagingSort(pgMain.CurrentPageIndex - 1,
                    TotalItems, ref totalRows, Pvn.Utils.Constants.Language.VIETNAMESE, txtSearchCondtion.Text.Trim(), txtSearchCondtion.Text.Trim(), LoaiVanBan, null, DonViBanHanh, dtFromDate, dtToDate, SortColumn.Value);

                //bind loai vanban
                string loaiVanBanName = GetLoaiVanBanName(dt);
                ltrSearchTitle.Text = loaiVanBanName;
                ltrDocTitle.Text = loaiVanBanName;

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

        private void BindCombobox()
        {

            //bind nam combobox
            List<int> lstYear = Enumerable.Range(1990, (DateTime.Now.Year - 1990) + 1).ToList<int>();
            //reverse the order
            lstYear.Reverse();
            ddlNamBanHanh.DataSource = lstYear;
            ddlNamBanHanh.DataBind();
            ddlNamBanHanh.Items.Insert(0, new ListItem("---Tất cả---", string.Empty));

        }

        /// <summary>
        /// Process doc data
        /// </summary>
        /// <param name="dtDocVanBan"></param>
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
                            dicFile.Add(Convert.ToString(dr["FileBinaryID"]), Convert.ToString(dr["FileName"]));
                        }
                        objDocInfo.FileAttach = dicFile;
                        lstDocInfo.Add(objDocInfo);
                    }
                }
                return lstDocInfo;
            }
            return null;
        }

        private string GetLoaiVanBanName(DataTable dtVB)
        {
            if (dtVB == null || dtVB.Rows.Count == 0)
            {
                return string.Empty;
            }
            string loaiVanBanName = Convert.ToString(dtVB.Rows[0]["LoaiVanBanName"]);
            return loaiVanBanName;
        }

        #endregion

        #region Custom Web part property
       
        //Task list name string
        private int _totalItems;
        private String _urlDetail;
        /// <summary>
        /// Number of news item
        /// </summary>
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }


        public Guid? DonViBanHanh
        {
            get
            {
                Guid _donViBanHanh = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["dvbh"], out _donViBanHanh))
                {
                    return _donViBanHanh;
                }
                return null;
            }
        }

        public Guid? LoaiVanBan
        {
            get
            {
                Guid _loaiVanBan = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["lvb"], out _loaiVanBan))
                {
                    return _loaiVanBan;
                }
                return null;
            }
        }

        /// <summary>
        /// Url detail
        /// </summary>
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }

        private string OrderByColumn = "[NgayBanHanh] DESC";

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //init paging
            pgMain.PageSize = TotalItems;
            pgMain.ShowFirstLast = false;
            pgMain.ShowFirstLast = false;
            pgMain.CurrentPageIndex = 1;
            BindData();
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
        protected void btnSortSoVanBan_Click(object sender, ImageClickEventArgs e)
        {
            if (SortColumn.Value == "[SoVanBan] DESC")
            {
             
                SortColumn.Value = "[SoVanBan]";
                btnSortSoVanBan.ImageUrl = "/DataStore/Icon/sort-ascending.png";
                btnSortNgayBanHanh.ImageUrl = "/DataStore/Icon/sort-up-down.png";
            }
            else
            {
              
                SortColumn.Value = "[SoVanBan] DESC";
                btnSortSoVanBan.ImageUrl = "/DataStore/Icon/sort-descending.png";
                btnSortNgayBanHanh.ImageUrl = "/DataStore/Icon/sort-up-down.png";
            }
            BindData();
        }

        protected void btnSortNgayBanHanh_Click(object sender, ImageClickEventArgs e)
        {
            if (SortColumn.Value == "[NgayBanHanh] DESC")
            {
              
                SortColumn.Value = "[NgayBanHanh]";
                btnSortNgayBanHanh.ImageUrl = "/DataStore/Icon/sort-ascending.png";
                btnSortSoVanBan.ImageUrl = "/DataStore/Icon/sort-up-down.png";
            }
            else
            {
             
                SortColumn.Value = "[NgayBanHanh] DESC";
                btnSortNgayBanHanh.ImageUrl = "/DataStore/Icon/sort-descending.png";
                btnSortSoVanBan.ImageUrl = "/DataStore/Icon/sort-up-down.png";
            }
            BindData();
           
        }

      

      
    }
}