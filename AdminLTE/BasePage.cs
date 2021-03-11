using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Pvn.Entity;
using System.Web.Script.Serialization;

namespace AdminLTE
{
    public class BasePage : Page
    {
        protected DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
        public static int RowPerPage = Pvn.Utils.Constants.ROW_PAGE;
        private int _curPage = 1;

        public int CurPage
        {
            get { return _curPage; }
            set { _curPage = value; }
        }
        public void RequestPage()
        {
            Int32.TryParse(Request["p"], out _curPage);
            _curPage = _curPage <= 0 ? 1 : _curPage;
        }
        private string _KeyWord = string.Empty;

        public string KeyWord
        {
            get { return _KeyWord; }
            set { _KeyWord = value; }
        }
        public BasePage()
        {
           
            dtfi.ShortDatePattern = "dd/MM/yyyy";
            dtfi.DateSeparator = "/";
        }

        public int USERID
        {
            get
            {
                if (Session["USERID"] != null)
                {
                    return Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {

                    return 0;
                }
            }
            set
            {
                Session["USERID"] = value;
            }
        }
        private void SetSessionDefaul(string UserID)
        {
            Sys_UserBL objBL = new Sys_UserBL();
            Sys_UserET objET = objBL.GetInfo(UserID);
            if (objET != null)
            {

                USERID = objET.UserID;
                USERNAME = objET.UserName.ToString();
                LOGINNAME = objET.LoginName.ToString();

                ROLESFULL = (int)objET.RolePermission == 1;
                if (!string.IsNullOrEmpty(objET.ImagePath))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<FileAttachForm> ltsFileForm = js.Deserialize<List<FileAttachForm>>(objET.ImagePath);
                    List<FileAttachForm> lstDataFile = new List<FileAttachForm>();
                    string path = "/UserControls/Upload/Images/";
                    if (ltsFileForm.Count > 0)
                    {
                        foreach (FileAttachForm item in ltsFileForm)
                        {
                            FileAttachForm objETAvata = new FileAttachForm();
                            int vitr = item.FileServer.LastIndexOf("/");
                            objETAvata.FileName = item.FileName;
                            objETAvata.FileServer = path + item.FileServer.Substring(vitr + 1);
                            USERAVATAR = objETAvata.FileServer;
                        }
                    }
                }
                UNITID = objET.UnitID;
                UNITNAME = objET.UnitName;
                USERROLESPAGE = objET.RolePage;
            }
        }
        public Guid? UNITID
        {
            get
            {
                if (Session["UnitID"] != null)
                {
                    return new Guid(Session["UnitID"].ToString());
                }
                else
                {

                    return null;
                }
            }
            set
            {
                Session["UnitID"] = value;
            }
        }
        public string UNITNAME
        {
            get
            {
                if (Session["UNITNAME"] != null)
                {
                    return Session["UNITNAME"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                Session["UNITNAME"] = value;
            }
        }
        public string USERNAME
        {
            get
            {
                if (Session["USERNAME"] != null)
                {
                    return Session["USERNAME"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                Session["USERNAME"] = value;
            }
        }
        public string LOGINNAME
        {
            get
            {
                if (Session["LOGINNAME"] != null)
                {
                    return Session["LOGINNAME"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                Session["LOGINNAME"] = value;
            }
        }
        public string USERAVATAR
        {
            get
            {
                if (Session["USERAVATAR"] != null)
                {
                    return Session["USERAVATAR"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                Session["USERAVATAR"] = value;
            }
        }
        public string USERROLESPAGE
        {
            get
            {
                if (Session["USERROLESPAGE"] != null)
                {
                    return Session["USERROLESPAGE"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                Session["USERROLESPAGE"] = value;
            }
        }
        public bool ROLESFULL
        {
            get
            {
                if (Session["ROLESFULL"] != null)
                {
                    return Convert.ToBoolean(Session["ROLESFULL"]);
                }
                else
                {

                    return false;
                }
            }
            set
            {
                Session["ROLESFULL"] = value;
            }
        }
        public bool RoleCheck(string filename)
        {
            if (!ROLESFULL)
            {
                List<string> roles = new List<string>(USERROLESPAGE.Split(','));
                if (roles.Count() > 0)
                {
                    if (roles.Where(p => p.ToLower() == filename.ToLower()).Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
           
            return true;

        }

        /// <summary>
        /// Accesss level:
        /// 0: no require login
        /// 1: require login
        /// </summary>
        int _pageaccessLevel = 1;
        public int PAGEACCESSLEVEL
        {
            get
            {
                return _pageaccessLevel;
            }
            set
            {
                _pageaccessLevel = value;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (PAGEACCESSLEVEL > 0)
            {
                if (USERID == 0)
                {
                    int UserID = new Sys_UserBL().GetUserLogin();
                    if (UserID == 0)
                    {
                        string returnUrl = HttpUtility.UrlEncode(Request.FilePath);
                        Response.Redirect("~/_layouts/15/Authenticate.aspx?returnUrl=" + returnUrl);
                    }
                    else
                    {
                        SetSessionDefaul(UserID.ToString());
                    }
                }
                if (USERID == 0)
                {
                    //string returnUrl = HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
                    if (PAGEACCESSLEVEL == 1)
                    {
                        string returnUrl = "";
                        if (Request.UrlReferrer != null)
                        {
                            returnUrl = HttpUtility.UrlEncode(Request.UrlReferrer.AbsoluteUri);
                        }
                        Response.Redirect("~/_layouts/15/Authenticate.aspx?returnUrl=" + returnUrl);
                        //Response.Write(string.Format("<script>window.location = '/_layouts/15/Authenticate.aspx?returnUrl={0}'</script>", returnUrl));
                    }
                    else
                    {
                        string returnUrl = HttpUtility.UrlEncode(Request.FilePath);
                        Response.Redirect("~/_layouts/15/Authenticate.aspx?returnUrl=" + returnUrl);
                    }
                }
                else
                {
                    if (PAGEACCESSLEVEL == 2)
                    {
                        string filename = Request.UrlReferrer.AbsolutePath;
                        if (RoleCheck(filename) == false)
                        {
                            Response.Redirect("~/_layouts/15/AccessDenied.aspx?FileName=" + filename);
                        }
                    }
                }
            }
        }
        public string RQSReturnUrl
        {
            get
            {
                string returnurl = System.Configuration.ConfigurationManager.AppSettings["RQSReturnUrl"];  //"~/manage/pages/index.aspx";
                if (Request.QueryString["ReturnUrl"] != null && Request.QueryString["ReturnUrl"] != "")
                {
                    returnurl = HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]);
                }

                return ResolveUrl(returnurl);
            }
        }
    }
}
