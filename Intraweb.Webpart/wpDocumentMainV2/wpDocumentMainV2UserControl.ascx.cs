using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public partial class wpDocumentMainV2UserControl : UserControl
    {
        private String currentLanguage ;
        private String _idLoaiVanBan;
        private String currentDBSource ;
        /// <summary>
        /// Url detail
        /// </summary>
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
        /// <summary>
        /// Url detail
        /// </summary>
        public String CurrentDBSource
        {
            get { return currentDBSource; }
            set { currentDBSource = value; }
        }
        /// <summary>
        /// Url detail
        /// </summary>
        public String IDLoaiVanBan
        {
            get { return _idLoaiVanBan; }
            set { _idLoaiVanBan = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {

                    //bind data
                    BindData();
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    Pvn.Utils.LogFile.WriteLogFile("wpDocumentMainV2UserControl", "Page_Load", exc.Message);
                }
            }
        }

        /// <summary>
        /// bind news list data
        /// </summary>
        private void BindData()
        {
            try
            {

                DocumentBL objBL = new DocumentBL();
                int totalRows = 0;
                string categoryName = string.Empty;
                DataTable dt = null;
                if (CurrentDBSource == "intraweb")
                {
                    //get db from intraweb
                    dt = objBL.GetSearchPagingV3(0,
                    99999, ref totalRows, CurrentLanguage, null, null, string.IsNullOrEmpty(IDLoaiVanBan) ? null : IDLoaiVanBan, null, null, null, null);
                }
                else
                {
                    dt = objBL.GetSearchPagingV2(0,
                    99999, ref totalRows, CurrentLanguage, null, null, string.IsNullOrEmpty(IDLoaiVanBan) ? null : IDLoaiVanBan, null, null, null, null);
                }


                rptDocInfo.DataSource = ProcessDocData(dt);
                rptDocInfo.DataBind();


            }
            catch (Exception exc)
            {
                //Module failed to load 
                //CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }

        protected void rptDocumentList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            try
            {
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
                                    //HttpContext.Current.Response.End();
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpDocumentMainV2UserControl", "rptDocumentList_ItemCommand", ex.Message);

            }
        }


        /// <summary>
        /// Process doc data
        /// </summary>
        /// <param name="dtDocVanBan"></param>
        private List<DocInfo> ProcessDocData(DataTable dtDocVanBan)
        {
            if (dtDocVanBan != null && dtDocVanBan.Rows.Count > 0)
            {

                //first select loaivanbanID
                DataView dvDocID = new DataView(dtDocVanBan);
                dvDocID.Sort = "ThuTu ASC";
                DataTable dtLoaiVanBanID = dvDocID.ToTable(true, "LoaiVanBanID", "LoaiVanBanName");
                //process each loaivanbanID
                List<DocInfo> lstDoc = new List<DocInfo>();
                int counter = 1;
                for (int j = 0; j < dtLoaiVanBanID.Rows.Count; j++)
                {
                    DocInfo objDocInfo = new DocInfo();
                    //second add loaivanban name
                    objDocInfo.LoaiVanBan = Convert.ToString(dtLoaiVanBanID.Rows[j]["LoaiVanBanName"]);
                    //third get vanban in each group                    
                    DataRow[] drDocInfo = dtDocVanBan.Select(string.Format("LoaiVanBanID = '{0}'", dtLoaiVanBanID.Rows[j]["LoaiVanBanID"]));
                    //fourth add each vanban to group                                    
                    if (drDocInfo != null && drDocInfo.Length > 0)
                    {
                        //convert to datatable
                        DataTable dtVanBan = drDocInfo.CopyToDataTable();
                        //convert to dataview
                        DataView dvVanBan = new DataView(dtVanBan);
                        //select distinct
                        DataTable dtDistinctVB = dvVanBan.ToTable(true, "VanBanID");
                        //process each vanban
                        List<DocInfoDetail> lstDocInfoDetail = new List<DocInfoDetail>();
                        for (int i = 0; i < dtDistinctVB.Rows.Count; i++)
                        {
                            DataRow[] drVanBanDistinct = dtVanBan.Select(string.Format("VanBanID = '{0}'", dtDistinctVB.Rows[i]["VanBanID"]));
                            if (drVanBanDistinct != null && drVanBanDistinct.Length > 0)
                            {
                                DocInfoDetail objDocInfoDetail = new DocInfoDetail();
                                //set tieu de and ngay ban hanh
                                //objDocInfoDetail.STT = Convert.ToString(drVanBanDistinct[0]["STT"]);
                                objDocInfoDetail.STT = Convert.ToString(counter);
                                objDocInfoDetail.TieuDe = Convert.ToString(drVanBanDistinct[0]["TieuDe"]);
                                objDocInfoDetail.SoVanBan = Convert.ToString(drVanBanDistinct[0]["SoVanBan"]);
                                try
                                {
                                    objDocInfoDetail.NgayBanHanh = Convert.ToDateTime(drVanBanDistinct[0]["NgayBanHanh"]);
                                }
                                catch (Exception ex)
                                {
                                    objDocInfoDetail.NgayBanHanh = null;
                                }

                                //set file
                                //dictionary<filebinaryid, file title>
                                Dictionary<string, string> dicFile = new Dictionary<string, string>();
                                foreach (DataRow dr in drVanBanDistinct)
                                {
                                    dicFile.Add(Convert.ToString(dr["FileBinaryID"]), Convert.ToString(dr["FileName"]));
                                }
                                objDocInfoDetail.FileAttach = dicFile;
                                lstDocInfoDetail.Add(objDocInfoDetail);
                                counter++;
                            }
                        }
                        objDocInfo.ListDocInfoDetail = lstDocInfoDetail;
                    }
                    lstDoc.Add(objDocInfo);
                }
                return lstDoc;
            }
            return null;
        }
    }
}
