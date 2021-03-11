<%@ WebHandler Language="C#" Class="GetImage" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.Web.UI.HtmlControls;
    using Pvn.Utils;

public class GetImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
		try
		{
			String sPhyPath = HttpContext.Current.Request.PhysicalApplicationPath;
            String virUrl = HttpContext.Current.Server.MapPath(".");
           
			String sFile = String.Empty;
			if (context.Request.QueryString["File"] != null)
				sFile = context.Request.QueryString["File"];

			String sWidth = String.Empty;
			if (context.Request.QueryString["Width"] != null)
				sWidth = context.Request.QueryString["Width"];
			
			String sNewFile = String.Empty;

            ImageHelper ctrlIamge = new ImageHelper();
			if (!String.IsNullOrEmpty(sFile) && !String.IsNullOrEmpty(sWidth))
				sNewFile = ctrlIamge.SaveFileImageVirtual(sFile, sPhyPath, sWidth);
				
			else if (!String.IsNullOrEmpty(sFile))
				sNewFile = ctrlIamge.SaveFileImageVirtual(sFile, sPhyPath);
			else
                sNewFile = "/Usercontrols/images/thumbnail.jpg";


            if (String.IsNullOrEmpty(sNewFile))
            {
                if (String.IsNullOrEmpty(sWidth))
                {
                    sWidth = SplitSize(sFile);
                    sNewFile = ctrlIamge.SaveFileImageVirtual("/Usercontrols/images/thumbnail.jpg", sPhyPath, sWidth);
                }
                if (String.IsNullOrEmpty(sNewFile))
                    sNewFile = "/Usercontrols/images/thumbnail.jpg";
            }
			
			context.Response.ContentType = "image/png";
			context.Response.WriteFile(sNewFile);
		}
        catch (Exception exc)
		{
		  Pvn.Utils.LogFile.WriteLogFile("ASHX", "ASHX", exc.Message);

		}       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    
    protected String GetFileNameWithSize(string sFileName, string sSize)
    {
        try
        {
            return String.Format("{0}_{1}{2}",
                                 sFileName.Substring(0, sFileName.LastIndexOf(".")),
                                 sSize,
                                 sFileName.Substring(sFileName.LastIndexOf(".")));
        }
        catch
        {
            return String.Empty;
        }

    }
    
    protected void SplitFileName(String sFileName, out String sRootName, out String sSize)
    {
        try
        {
            sRootName = String.Format("{0}{1}",
                                      sFileName.Substring(0, sFileName.LastIndexOf("_")),
                                      sFileName.Substring(sFileName.LastIndexOf(".")));
            sSize = String.Format("0", sFileName.Substring(sFileName.LastIndexOf("_"), sFileName.LastIndexOf(".")));
        }
        catch
        {
            sRootName = String.Empty;
            sSize = String.Empty;
        }
    }

    protected string SplitSize(string sFileName)
    {
        try
        {            
            return String.Format("0", sFileName.Substring(sFileName.LastIndexOf("_"), sFileName.LastIndexOf(".")));
        }
        catch
        {
            return "C130x80";
        }
    }
    
}