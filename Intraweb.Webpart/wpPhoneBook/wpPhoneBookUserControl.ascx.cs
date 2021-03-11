using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public partial class wpPhoneBookUserControl : UserControl
    {
        private String _companyLevelID;
        private String _companyID;
        /// <summary>
        /// Url search combobox
        /// </summary>
        public String CompanyLevelID
        {
            get { return _companyLevelID; }
            set { _companyLevelID = value; }
        }

        /// <summary>
        /// Url search combobox
        /// </summary>
        public String CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }
        private String _urlSearchComboBox;

        public String UrlSearchComboBox
        {
            get { return _urlSearchComboBox; }
            set { _urlSearchComboBox = value; }
        }
        private String _urlSearchName;

        public String UrlSearchName
        {
            get { return _urlSearchName; }
            set { _urlSearchName = value; }
        }
        private string _TenTab;
        public string TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    //bind company level
                    BindCompanyLevel();

                    //bind company
                    BindCompany();

                    //bind data
                    BindData();

                    //bind department
                    BindDepartment();

                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    //CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
        }
        #region BindData
        /// <summary>
        /// Bind company level
        /// </summary>
        private void BindCompanyLevel()
        {
            CompanyBL objCompannyBl = new CompanyBL();
            DataTable dtCompany = objCompannyBl.GetAllCompanyByLevelAndParent(1, null); //cap cong ty
            ddlCompanyLevel.DataValueField = "CompanyID";
            ddlCompanyLevel.DataTextField = "IndentedTitle";
            ddlCompanyLevel.DataSource = dtCompany;
            ddlCompanyLevel.DataBind();
            ddlCompanyLevel.Items.Insert(0, new ListItem("---Lựa chọn---", string.Empty));
            ddlCompanyLevel.SelectedValue = CompanyLevelID; //for temp
        }
        /// <summary>
        /// Bind company data by level
        /// </summary>
        private void BindCompany()
        {
            if (!string.IsNullOrEmpty(ddlCompanyLevel.SelectedValue))
            {
                try
                {
                    CompanyBL objCompannyBl = new CompanyBL();
                    DataTable dtCompany = objCompannyBl.GetAllCompanyByLevelAndParent(2, Convert.ToInt32(ddlCompanyLevel.SelectedValue)); //company level
                    ddlCompany.DataValueField = "CompanyID";
                    ddlCompany.DataTextField = "IndentedTitle";
                    ddlCompany.DataSource = dtCompany;
                    ddlCompany.DataBind();
                    ddlCompany.Items.Insert(0, new ListItem("---Lựa chọn---", string.Empty));
                    if (ddlCompanyLevel.SelectedValue == CompanyLevelID)
                    {
                        ddlCompany.SelectedValue = CompanyID; 
                    }

                }
                catch (Exception ex)
                {
                    Pvn.Utils.LogFile.WriteLogFile("wpPhoneBookUserControl", "BindCompany", ex.Message);
                }
            }
        }
        private void BindDepartment()
        {
            //clear ddlDepartment
            ddlDepartment.Items.Clear();
            if (!string.IsNullOrEmpty(ddlCompany.SelectedValue))
            {
                //bind department
                try
                {
                    CompanyBL objCompannyBl = new CompanyBL();
                    DataTable dtCompany = objCompannyBl.GetAllCompanyByLevelAndParent(3, Convert.ToInt32(ddlCompany.SelectedValue));
                    ddlDepartment.DataValueField = "CompanyID";
                    ddlDepartment.DataTextField = "IndentedTitle";
                    ddlDepartment.DataSource = dtCompany;
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("---Lựa chọn---", string.Empty));
                }
                catch (Exception ex)
                {
                    Pvn.Utils.LogFile.WriteLogFile("wpPhoneBookUserControl", "BindDepartment", ex.Message);
                }
            }
        }
        /// <summary>
        /// Bind worker data
        /// </summary>
        private void BindData()
        {

            WorkerBL objPVNWorkerBL = new WorkerBL();
            if (string.IsNullOrEmpty(ddlCompanyLevel.SelectedValue))
            {
                return;
            }
            try
            {
                //clear datat
                rptCompany.DataSource = null;
                rptCompany.DataBind();
                rptDepartment.DataSource = null;
                rptDepartment.DataBind();

                //determine company level
                short companyLevel = 2; //company level
                int companyID = Convert.ToInt32(ddlCompany.SelectedValue);
                if (!string.IsNullOrEmpty(ddlDepartment.SelectedValue))
                {
                    companyLevel = 3;
                    companyID = Convert.ToInt32(ddlDepartment.SelectedValue);
                }

                DataSet dsWorker = objPVNWorkerBL.GetSearchPaging(companyID, companyLevel);
                if (dsWorker != null && dsWorker.Tables.Count == 2)
                {
                    //get company data
                    rptCompany.DataSource = dsWorker.Tables[0];
                    rptCompany.DataBind();

                    //bind worker data
                    BindWorkerData(dsWorker.Tables[1]);
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpPhoneBookUserControl", "BindData", ex.Message);
            }
        }

        /// <summary>
        /// process to display worker detail
        /// </summary>
        /// <param name="dtWorker"></param>
        private void BindWorkerData(DataTable dtWorker)
        {
            try
            {
                //get worker data
                if (dtWorker != null && dtWorker.Rows.Count > 0)
                {
                    //first select companyid
                    DataView dvCompanyID = new DataView(dtWorker);
                    DataTable dtCompanyID = dvCompanyID.ToTable(true, "CompanyID");
                    //sort by company order


                    //process to view department
                    List<DepartmentDetailET> lstDepartment = new List<DepartmentDetailET>();
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
                    rptDepartment.DataSource = lstDepartment;
                    rptDepartment.DataBind();
                }
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("wpPhoneBookUserControl", "BindWorkerData", ex.Message);
            }
           
        }
        protected void ddlCompanyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear ddlDepartment
            ddlCompany.Items.Clear();
            ddlDepartment.Items.Clear();
            BindCompany();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlCompany.Items.Count > 0)
            {
                BindData();
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear ddlDepartment
            ddlDepartment.Items.Clear();

            BindDepartment();
        }

        #endregion
    }
}
