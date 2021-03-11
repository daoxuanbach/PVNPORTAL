using System;
using System.IO;
using IZ.WebFileManager;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;
using MB.FileBrowser;

namespace FileBrowser.FileBrowser
{
    public partial class ucFileBrowser : System.Web.UI.UserControl, System.Web.UI.ICallbackEventHandler
    {
        protected AjaxJsonResponse ajaxResponse = new AjaxJsonResponse();
        public string Opener;

        public string FilesFolder { get; set; }
        public bool UseDefaultRoots { get; set; }
        public bool UseCustomRoots { get; set; }
        public bool HideCommands { get; set; }

        // data- attributes for configuration of custom roots
        const string USE_CUSTOMROOTS = "data-usecustomroots";
        const string USE_DEFAULTROOTS = "data-usedefaultroots";
        const string ROOTS_NAMES = "data-roots-names";
        const string ROOTS_SMALLIMAGES = "data-roots-smallimages";
        const string ROOTS_LARGEIMAGES = "data-roots-largeimages";
        const string ROOTS_FOLDERS = "data-roots-folders";
        const string ROOTS_IMAGEFOLDER = "data-roots-imagefolder";
        const string READONLY_HIDECOMMANDS = "data-readonly-hidecommands";


        protected void Page_Load(object sender, EventArgs e)
        {
            FilesFolder = (!String.IsNullOrEmpty(HF_FileBrowserConfig.Attributes["data-filesfolder"]) ?
                    HF_FileBrowserConfig.Attributes["data-filesfolder"] : "files");

            string useCustomStr = String.IsNullOrEmpty(HF_CustomRoots.Attributes[USE_CUSTOMROOTS]) ? "" : HF_CustomRoots.Attributes[USE_CUSTOMROOTS];
            string useDefaultStr = String.IsNullOrEmpty(HF_CustomRoots.Attributes[USE_DEFAULTROOTS]) ? "" : HF_CustomRoots.Attributes[USE_DEFAULTROOTS];
            string hideCommandsStr = String.IsNullOrEmpty(HF_FileBrowserConfig.Attributes[READONLY_HIDECOMMANDS]) ? "" : HF_FileBrowserConfig.Attributes[READONLY_HIDECOMMANDS];

            UseCustomRoots = useCustomStr.ToLower() != "false";
            UseDefaultRoots = useDefaultStr.ToLower() == "true";
            HideCommands = hideCommandsStr != "false";


            //if (Request.Url.Host.IndexOf("localhost") > -1)
            //    FileManager1.DefaultAccessMode = AccessMode.Write;

            CultureInfo culture;
            try
            {
                culture = new CultureInfo(Request["langCode"]);
            }
            catch (Exception)
            {
                culture = CultureInfo.CurrentCulture;
            }
            FileManager1.ShowAddressBar = false;
            FileManager1.AllowUpload = false;
            FileManager1.AllowDelete = false;
            String cbReference =
                Page.ClientScript.GetCallbackEventReference(this,
                "arg", "ReceiveServerData", "context");
            String callbackScript;
            callbackScript = "function CallServer(arg, context)" +
                "{ " + cbReference + ";}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "CallServer", callbackScript, true);

            if (!IsPostBack)
            {
                int fnumber = 0;
                string caller, fn;

                // the caller is CKEditor
                if (!string.IsNullOrEmpty(Request["CKEditor"]))
                {
                    caller = "ckeditor";
                }
                else
                    caller = (String.IsNullOrEmpty(Request["caller"]) ? "parent" : Request["caller"]);
                string type = "";
                string mainRoot = "~/DataStore";
               
                if (FileManager1.Culture == null)
                    FileManager1.Culture = culture;

                FileManager1.ToolbarOptions.ShowCopyButton = false;
                FileManager1.ToolbarOptions.ShowMoveButton = false;
                FileManager1.ToolbarOptions.ShowDeleteButton = false;
                FileManager1.ToolbarOptions.ShowRenameButton = false;
                FileManager1.ToolbarOptions.ShowNewFolderButton = false;
                FileManager1.ToolbarOptions.ShowViewButton = true;

                if (!String.IsNullOrEmpty(FileManager1.MainDirectory))
                {
                    mainRoot = FileManager1.MainDirectory;
                }
                   
                //mainRoot = ResolveClientUrl(mainRoot);
                if (!Directory.Exists(Server.MapPath(ResolveClientUrl(mainRoot))))
                    throw new Exception("User directory with write privileges is needed.");

                DirectoryInfo mainRootInfo = new DirectoryInfo(Server.MapPath(ResolveClientUrl(mainRoot)));

                if (!String.IsNullOrEmpty(Request["type"]))
                {
                    type = Request["type"];
                }

                RootDirectory files;
                // Display text of root folders are localized using WebFileBrowser resources files
                // in "/App_GlobalResources/WebFileManager" and GetResoueceString method
                // of FileManager.Controller class

                FileManager1.RootDirectories.Clear();
                if (UseDefaultRoots)
                {
                    FileManager1.RootDirectories.Clear();
                    files = new RootDirectory();
                    files.ShowRootIndex = false;
                    files.DirectoryPath = VirtualPathUtility.AppendTrailingSlash(mainRoot)+ (String.IsNullOrEmpty(Request["Dic"]) ? "" : Request["Dic"]);
                    files.LargeImageUrl = "~/FileBrowser/img/32/folder-document-alt.png";
                    files.SmallImageUrl = "~/FileBrowser/img/16/folder-document-alt.png";
                    // Display text of root folders are localized using WebFileBrowser resources files
                    // in "/App_GlobalResources/WebFileManager" and GetResoueceString method
                    // of FileManager.Controller class

                    if (!String.IsNullOrEmpty(Request["title"]))
                    {
                        files.Text = Request["title"];
                    }
                    else
                    {
                        files.Text = FileManager1.Controller.GetResourceString("Root_File", "Files");
                    }
                    FileManager1.RootDirectories.Add(files);

                }


                if (UseCustomRoots)
                {
                    // Memorizza il parametro querystring "cs" che consente di visualizzare una sola customroot
                    int selectedCustomRoot;
                    if (!int.TryParse(Request["cs"], out selectedCustomRoot))
                        selectedCustomRoot = -1;

                    // Folder containing custom roots icon images
                    string rootsImageFolder = String.IsNullOrEmpty(HF_CustomRoots.Attributes[ROOTS_IMAGEFOLDER]) ? "" : HF_CustomRoots.Attributes[ROOTS_IMAGEFOLDER];

                    //Arrays: roots names, roots folders, small icons, large icons
                    string[] rootsNames, rootsFolders, rootsSmallImages, rootsLargeImages;

                    // Convert data-roots-names value in array
                    string temp = String.IsNullOrEmpty(HF_CustomRoots.Attributes[ROOTS_NAMES]) ? "" : HF_CustomRoots.Attributes[ROOTS_NAMES];
                    if (temp == "")
                    {
                        return;
                    }
                    rootsNames = temp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Count of custom roots
                    int rootsCount = rootsNames.Length;

                    // If data-roots-folder is empty, will use root names
                    if (String.IsNullOrEmpty(HF_CustomRoots.Attributes[ROOTS_FOLDERS]))
                    {
                        rootsFolders = temp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        rootsFolders = HF_CustomRoots.Attributes[ROOTS_FOLDERS].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    }


                    if (rootsCount > rootsFolders.Length)
                        rootsCount = rootsFolders.Length;

                    if (!String.IsNullOrEmpty(HF_CustomRoots.Attributes[ROOTS_SMALLIMAGES]))
                    {
                        rootsSmallImages = HF_CustomRoots.Attributes[ROOTS_SMALLIMAGES].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (rootsCount > rootsSmallImages.Length)
                            rootsCount = rootsSmallImages.Length;
                    }
                    else
                    {
                        rootsSmallImages = new string[] { };
                        rootsCount = 0;

                    }

                    if (!String.IsNullOrEmpty(HF_CustomRoots.Attributes[ROOTS_LARGEIMAGES]))
                    {
                        rootsLargeImages = HF_CustomRoots.Attributes[ROOTS_LARGEIMAGES].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (rootsCount > rootsLargeImages.Length)
                            rootsCount = rootsLargeImages.Length;
                    }
                    else
                    {
                        rootsLargeImages = new string[] { };
                        rootsCount = 0;

                    }

                    if (rootsCount == 0)
                    {
                        throw new Exception("If UseCustomRoots option is setted you must provide Custom Roots full info (Names, Folders, small an large images).");
                    }
                    else
                    {
                        if (selectedCustomRoot >= 0 && selectedCustomRoot < rootsCount)
                        {
                            mainRootInfo.CreateSubdirectory(rootsFolders[selectedCustomRoot]);
                            RootDirectory myCustomRoot = new RootDirectory();
                            myCustomRoot.ShowRootIndex = false;
                            myCustomRoot.DirectoryPath = VirtualPathUtility.AppendTrailingSlash(mainRoot) + rootsFolders[selectedCustomRoot];
                            myCustomRoot.LargeImageUrl = VirtualPathUtility.AppendTrailingSlash(rootsImageFolder) + rootsLargeImages[selectedCustomRoot];
                            myCustomRoot.SmallImageUrl = VirtualPathUtility.AppendTrailingSlash(rootsImageFolder) + rootsLargeImages[selectedCustomRoot];
                            myCustomRoot.Text = rootsNames[selectedCustomRoot];
                            FileManager1.RootDirectories.Add(myCustomRoot);
                        }
                        else
                        {
                            for (int i = 0; i < rootsCount; i++)
                            {
                                mainRootInfo.CreateSubdirectory(rootsFolders[i]);
                                RootDirectory myCustomRoot = new RootDirectory();
                                myCustomRoot.ShowRootIndex = false;
                                myCustomRoot.DirectoryPath = VirtualPathUtility.AppendTrailingSlash(mainRoot) + rootsFolders[i];
                                myCustomRoot.LargeImageUrl = VirtualPathUtility.AppendTrailingSlash(rootsImageFolder) + rootsLargeImages[i];
                                myCustomRoot.SmallImageUrl = VirtualPathUtility.AppendTrailingSlash(rootsImageFolder) + rootsLargeImages[i];
                                myCustomRoot.Text = rootsNames[i];
                                FileManager1.RootDirectories.Add(myCustomRoot);
                            }

                        }
                    }
                }
            }

            AccessMode fbAccessMode;

            if (MagicSession.Current.FileBrowserAccessMode == AccessMode.Default)
                fbAccessMode = FileManager1.DefaultAccessMode;
            else
                fbAccessMode = MagicSession.Current.FileBrowserAccessMode;
            Literal content;

            switch (fbAccessMode)
            {
                case AccessMode.ReadOnly:
                case AccessMode.Default:
                    FileManager1.Visible = true;
                    FileManager1.ReadOnly = true;
                    if (HideCommands)
                    {
                        FileManager1.EnableContextMenu = false;
                        FileManager1.ShowToolBar = true;
                        FileManager1.ShowSearchBox = false;
                        DND_message.InnerText = FileManager1.Controller.GetResourceString("No_Command_Help", "DoubleClick to open a folder. DoubleClick to download a file.");
                    }
                    break;
                case AccessMode.Write:
                    FileManager1.Visible = true;
                    FileManager1.ReadOnly = false;
                    FileManager1.AllowDelete = false;
                    FileManager1.AllowOverwrite = false;
                    break;
                default:
                    break;
            }
        }
        public void RaiseCallbackEvent(String eventArgument)
        {
            string[] cmds = eventArgument.Split(new char[] { ',' });
            ajaxResponse.command = cmds[0].ToLower();
            switch (cmds[0].ToLower())
            {
                case "showfile":
                    if (FileManager1.CurrentDirectory != null)
                        ajaxResponse.data = VirtualPathUtility.AppendTrailingSlash(FileManager1.CurrentDirectory.VirtualPath) + cmds[1];
                    break;
                case "upload":
                    if (FileManager1.CurrentDirectory != null)
                        ajaxResponse.data = VirtualPathUtility.AppendTrailingSlash(FileManager1.CurrentDirectory.VirtualPath);
                    break;
                default:
                    break;
            }
        }
        public String GetCallbackResult()
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(ajaxResponse);

        }
    }
}