using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web
{
    public partial class ExportPVNPhoneBook : System.Web.UI.Page
    {
        string GetDanhBa()
        {
            List<DepartmentDetailET> lstDepartment = new List<DepartmentDetailET>();
            DataSet dsWorker = new DataSet();
            StringBuilder sbdSubContent = new StringBuilder();
            dsWorker = BindData();
            if (dsWorker != null && dsWorker.Tables.Count == 2)
            {
                //get company data
                //rptCompany.DataSource = dsWorker.Tables[0];
                //rptCompany.DataBind();
                //bind worker data
                foreach (DataRow row in dsWorker.Tables[0].Rows)
                {
                    //Ten Phong
                    sbdSubContent.AppendFormat(@"<div style='font-weight: bold; text-align: center; font-size: 16px;'>{0}</div>", row["CompanyName"].ToString().ToUpper());
                }
                lstDepartment = BindWorkerData(dsWorker.Tables[1]);
                if (lstDepartment != null && lstDepartment.Count > 0)
                {
                    // string html = "";
                    for (int i = 0; i < lstDepartment.Count; i++)
                    {
                        sbdSubContent.AppendFormat(@"<div style='font-weight: bold; text-align: left;'>{0}. {1}</div>", i + 1, lstDepartment[i].DepartmentName.ToUpper());
                        foreach (PhoneDetailET item in lstDepartment[i].ListPhoneDetail)
                        {
                            //chuc vu
                            sbdSubContent.AppendFormat(@"<div style='font-style: italic; border-bottom: 1px solid #D4D4D4; color: #f00; text-decoration: underline;'>{0}</div>",item.JobTitle);
                            foreach (WorkerDetailET itemWorkerDetail in item.ListWorkerDetail)
                            {
                                string strContact = itemWorkerDetail.Contact.Replace("<li>", "<li style='text-align: left; font-weight: normal; list-style: disc;'>");
                                //ho va ten
                                sbdSubContent.AppendFormat(@"<div style='font-size: 14px; border-bottom: 1px solid #D4D4D4; margin-left: 20px; font-weight: normal;'>{0}<b> {1}</b></div>", itemWorkerDetail.GioiTinh, itemWorkerDetail.HoTen);
                                //lien lac
                                sbdSubContent.Append(@"<div style='margin-left: 40px;'>");
                                sbdSubContent.Append(@"<table width='100%'><tr><td>");
                                sbdSubContent.AppendFormat(@"<ul>{0}<li></li></ul>", strContact);
                                sbdSubContent.AppendFormat(@"</td><td align='right'><img src='{0}' alt='{1}' style='height:100px;width:80px;'></td></tr></table>", itemWorkerDetail.ImageURL, itemWorkerDetail.HoTen);
                                sbdSubContent.Append(@"</div>");
                            }
                            
                        }
                    }

                    //ho va ten
                    //sbdSubContent.Append(@"<div style='font-size: 14px; border-bottom: 1px solid #D4D4D4; margin-left: 20px; font-weight: normal;'>Ông:<b>Nguyễn Quốc Khánh</b></div>");

                    ////lien lac
                    //sbdSubContent.Append(@"<div style='margin-left: 40px;'>");
                    //sbdSubContent.Append(@"<table width='100%'><tr><td>");
                    //sbdSubContent.Append(@"<ul>");
                    //sbdSubContent.Append(@"<li style='text-align: left; font-weight: normal; list-style: disc;'>Điện thoại trực tiếp : 04 - 37725649</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Máy cơ quan : 04 - 38252526 / 8815</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Máy di động : 0913921427</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Email : quockhanh@pvn.vn</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Máy NR : 04 - 62776182</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Máy NR : 04 - 62776182</li><li style='text-align: left; font-weight: normal; list-style: disc;'>Máy NR : 04 - 62776182</li><li></li>");
                    //sbdSubContent.Append(@"</ul>");
                    //sbdSubContent.Append(@"</td><td align='right'><img src='DataStore/Contacts/NguyenQuocKhanh.jpg' alt='Nguyễn Quốc Khánh' style='height:100px;width:80px;'></td></tr></table>");
                    //sbdSubContent.Append(@"</div>");

                }
            }
            
           
            return sbdSubContent.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = GetDanhBa();
            Create(html);
        }
        /// <summary>
        /// Bind worker data
        /// </summary>
        private DataSet BindData()
        {

            WorkerBL objPVNWorkerBL = new WorkerBL();
            DataSet dsWorker = new DataSet();
            try
            {
                //determine company level
                short companyLevel = 2; //Loai hinh don vi
                int companyID = 29294; //Cong ty
                if (!string.IsNullOrEmpty(Request["Company"]))
                {
                    companyID = Convert.ToInt32(Request["Company"]);
                }
                if (!string.IsNullOrEmpty(Request["Department"]))
                {
                    companyLevel = 3;
                    companyID = Convert.ToInt32(Request["Department"]);
                }

                dsWorker = objPVNWorkerBL.GetSearchPaging(companyID, companyLevel);
               
                return dsWorker;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                Pvn.Utils.LogFile.WriteLogFile("ExportPVNPhoneBook", "BindData", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// process to display worker detail
        /// </summary>
        /// <param name="dtWorker"></param>
        private List<DepartmentDetailET> BindWorkerData(DataTable dtWorker)
        {
            List<DepartmentDetailET> lstDepartment = new List<DepartmentDetailET>();
            //get worker data
            if (dtWorker != null && dtWorker.Rows.Count > 0)
            {
                //first select companyid
                DataView dvCompanyID = new DataView(dtWorker);
                DataTable dtCompanyID = dvCompanyID.ToTable(true, "CompanyID");
                //sort by company order
                //process to view department
                for (int k = 0; k < dtCompanyID.Rows.Count; k++)
                {
                    //get department infor
                    DataRow[] drDepartment = dtWorker.Select("CompanyID = " + dtCompanyID.Rows[k]["CompanyID"]);

                    DepartmentDetailET objDepartment = new DepartmentDetailET();
                    objDepartment.DepartmentName = Convert.ToString(drDepartment[0]["CompanyName"]);

                    //second select jobtitle 
                    DataTable dtJob = drDepartment.CopyToDataTable();
                    //dtJob.DefaultView.Sort = "CompanyOrder JobOrder";
                    DataView dvJobTitle = new DataView(dtJob);
                    DataTable dtJobTitle = dvJobTitle.ToTable(true, "JobTitleID");

                    //process to get view
                    List<PhoneDetailET> lstPhone = new List<PhoneDetailET>();
                    for (int i = 0; i < dtJobTitle.Rows.Count; i++)
                    {
                        PhoneDetailET objPhoneDetail = new PhoneDetailET();
                        //get worker by jobtitle
                        DataRow[] drWorker = dtJob.Select("JobTitleID = " + dtJobTitle.Rows[i]["JobTitleID"]);
                        //get jobj title name
                        objPhoneDetail.JobTitle = Convert.ToString(drWorker[0]["JobTitle"]);
                        //get detai;
                        List<WorkerDetailET> lstWorkerDetail = new List<WorkerDetailET>();
                        for (int j = 0; j < drWorker.Length; j++)
                        {
                            WorkerDetailET objWorker = new WorkerDetailET();
                            objWorker.GioiTinh = Convert.ToString(drWorker[j]["GioiTinh"]);
                            objWorker.HoTen = Convert.ToString(drWorker[j]["LastName"]) + " " + Convert.ToString(drWorker[j]["FirstName"]);
                            objWorker.ImageURL = Convert.ToString(drWorker[j]["ImageURL"]);
                            objWorker.Contact = Convert.ToString(drWorker[j]["WorkerContact"]);
                            lstWorkerDetail.Add(objWorker);
                        }
                        //add phone detail
                        objPhoneDetail.ListWorkerDetail = lstWorkerDetail;
                        //add to list
                        lstPhone.Add(objPhoneDetail);
                    }

                    objDepartment.ListPhoneDetail = lstPhone;
                    //add to list
                    lstDepartment.Add(objDepartment);
                }
                //bind to reperater

            }
            return lstDepartment;
        }

        static string BaseUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }

        private void Create(string html)
        {
            //string filename = String.Format("DanhBa_{0}.docx", DateTime.Now.Ticks);
            //filename = Server.MapPath(filename);

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new Document(new Body()).Save(mainPart);
                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    converter.ImageProcessing = ImageProcessing.ManualProvisioning;
                    converter.BaseImageUrl = new Uri(BaseUrl);
                    //converter.BaseImageUrl = new Uri("C:\\Users\\vmt47\\Documents\\Visual Studio 2013\\Projects\\Html2Word\\WebApplication1\\");
                    converter.ProvisionImage += OnProvisionImage;

                    Body body = mainPart.Document.Body;

                    var paragraphs = converter.Parse(html);
                    for (int i = 0; i < paragraphs.Count; i++)
                    {
                        body.Append(paragraphs[i]);
                    }
                    mainPart.Document.Save();
                }

                //File.WriteAllBytes(filename, generatedDocument.ToArray());

                HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=DanhBa.docx");
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                HttpContext.Current.Response.BinaryWrite(generatedDocument.ToArray());
                HttpContext.Current.Response.End();
            }
        }

        private void OnProvisionImage(object sender, ProvisionImageEventArgs e)
        {
            try
            {
                // Read the image from the file system:
                string imgurl = e.ImageUrl.OriginalString;

                byte[] img = GetImageFromUrl(imgurl);

                if (img != null)
                {
                    e.Data = img;
                }

                //e.Data = File.ReadAllBytes(imgurl);
                //e.ImageSize = new System.Drawing.Size(150, 150);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ExportPVNPhoneBook", "OnProvisionImage", ex.Message);
            }
        }

        private byte[] GetImageFromUrl(string url)
        {
            byte[] b = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (request.HaveResponse)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        using (BinaryReader br = new BinaryReader(receiveStream))
                        {
                            b = br.ReadBytes(Convert.ToInt32(response.ContentLength));
                            br.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ExportPVNPhoneBook", "GetImageFromUrl", ex.Message);
                b = null;
            }

            return b;
        }


    }
}