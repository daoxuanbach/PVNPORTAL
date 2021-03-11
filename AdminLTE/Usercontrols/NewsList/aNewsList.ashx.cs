using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.NewsList
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aNewsList : IHttpHandler
    {
        CMS_NewsDA objDA = new CMS_NewsDA();
        MessageUtil objMsg = new MessageUtil();
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (context.Request["hidAction"])
            {
                case "add":
                    Insert(context);
                    break;
                case "addPublich":
                    InsertPublich(context);
                    break;
                case "upd":
                    Update(context);
                    break;
                case "updNewsAndNewsPublich":
                    UpdateNewsAndNewsPublich(context);
                    break;
               
                case "del":
                    Delete(context);
                    break;
                default:
                    break;
            }
        }

        

        protected void Delete(HttpContext context)
        {
            string NewsID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["NewsID"]))
                NewsID = (context.Request["NewsID"]);
            List<string> listStrLineElements = NewsID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                objMsg = objDA.Delete(new Guid(item));
                if (objMsg.Error)
                    break;
            }

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Xoa;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            CMS_NewsET objET = RequestEntity(context);
            objET.Version += 1;
            objET.ModifiedBy = new Pvn.BL.Sys_UserBL().GetUserLogin();
            objET.ModifiedDate = DateTime.Now;
            objMsg = objDA.Update(objET);

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }

            #endregion
            objMsg.RenderMessage(objMsg, context);
        }
        private void UpdateNewsAndNewsPublich(HttpContext context)
        {
            CMS_NewsET objET = RequestEntity(context);
            objET.Version += 1;
            objET.ModifiedBy = new Pvn.BL.Sys_UserBL().GetUserLogin();
            objET.ModifiedDate = DateTime.Now;
            //Neu tin dang xuat ban thi chuyen thanh tin dang cho xuat ban
            if (objET.NewsState == (short)Pvn.Utils.Parameter.NewsState.TinDangXuatBan)
            {
                objET.NewsState = (short)Pvn.Utils.Parameter.NewsState.TinDangChoXuatBan;
            }
            else // neeu tin dang cho xuat ban thi chuyen thanh tin xuat ban
            {
                objET.NewsState = (short)Pvn.Utils.Parameter.NewsState.TinDangXuatBan;
            }
            
            objMsg = objDA.Update(objET);

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }

        private void UpdatePublich(HttpContext context)
        {
            CMS_NewsET objET = RequestEntity(context);
            objET.Version += 1;
            objET.ModifiedBy = new Pvn.BL.Sys_UserBL().GetUserLogin();
            objET.ModifiedDate = DateTime.Now;
            objMsg = objDA.Update(objET);

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.UpdateAndPublich;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion
            objMsg.RenderMessage(objMsg, context);
        }

        protected void InsertPublich(HttpContext context)
        {
            CMS_NewsET objInfo = RequestEntity(context);
            objInfo.Version = 1;
            objInfo.NewsState = (short)(Pvn.Utils.Parameter.NewsState.TinDangXuatBan);
            objInfo.NewsUsedState = 1;//Dang su dung                
            objInfo.DataAccess = (short?)Parameter.DataAccess.ChoPhepNguoiDocTruyCap;
            objInfo.RatingState = (short?)Parameter.RatingState.ChoKiemDuyetDanhGia;
            objInfo.CreatedBy = new Pvn.BL.Sys_UserBL().GetUserLogin();
            objInfo.CreatedDate = DateTime.Now;
            if (objDA.Insert(objInfo))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";

                #region addLog
                Sys_LogDA objLogDA = new Sys_LogDA();
                Sys_LogET objLog = new Sys_LogET();
                string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
                if (!string.IsNullOrEmpty(FnID))
                {
                    Guid FunID = Guid.Empty;
                    if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                    {
                        objLog.FunctionID = FunID;
                    }
                    objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ThemMoiAndPublich;
                    objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                    objLog.Note = objMsg.Message;
                    objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                }
                #endregion
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }
        protected void Insert(HttpContext context)
        {
            CMS_NewsET objInfo = RequestEntity(context);
            objInfo.Version = 1;
            objInfo.NewsState =(short)(Pvn.Utils.Parameter.NewsState.TinDangChoXuatBan);
            objInfo.NewsUsedState = 1;//Dang su dung                
            objInfo.DataAccess = (short?)Parameter.DataAccess.ChoPhepNguoiDocTruyCap;
            objInfo.RatingState = (short?)Parameter.RatingState.ChoKiemDuyetDanhGia;
            objInfo.CreatedBy = new Pvn.BL.Sys_UserBL().GetUserLogin();
            objInfo.CreatedDate = DateTime.Now;
            if (objDA.Insert(objInfo))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";

                #region addLog
                Sys_LogDA objLogDA = new Sys_LogDA();
                Sys_LogET objLog = new Sys_LogET();
                string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
                if (!string.IsNullOrEmpty(FnID))
                {
                    Guid FunID = Guid.Empty;
                    if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                    {
                        objLog.FunctionID = FunID;
                    }
                    objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ThemMoi;
                    objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                    objLog.Note = objMsg.Message;
                    objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                }
                #endregion
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }

        private CMS_NewsET RequestEntity(HttpContext context)
        {
            CMS_NewsET objET = new CMS_NewsET();
            if (!string.IsNullOrEmpty(context.Request["NewsID"]))
                objET.NewsID = new Guid(context.Request["NewsID"]);
            if (!string.IsNullOrEmpty(context.Request["NewsState"]))
                objET.NewsState = Convert.ToInt32(context.Request["NewsState"]);
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Summary"]))
                objET.Summary = context.Request["Summary"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Version"]))
                  objET.Version = Convert.ToInt32(context.Request["Version"].Trim());
            if (!string.IsNullOrEmpty(context.Request["ListCategory"]))
            {
                string ListCategory = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["ListCategory"]))
                    ListCategory = (context.Request["ListCategory"]);
                objET.ListCategory = ListCategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //Thêm bản CMS_NewsPublishing
            }
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
            {
                objET.CategoryID = new Guid(context.Request["CategoryID"]);
                objET.ListCategory.Add(objET.CategoryID.ToString());
            }
           
            if (!string.IsNullOrEmpty(context.Request["ImageURL"]))
                objET.ImageURL = context.Request["ImageURL"].Trim();
            if (!string.IsNullOrEmpty(context.Request["ImageTitle"]))
                objET.ImageTitle = context.Request["ImageTitle"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Author"]))
                objET.Author = context.Request["Author"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Reference"]))
                objET.Reference = context.Request["Reference"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["PublishedDate"]))
            {
                objET.PublishedDate = formatUtils.FormatDateTime(context.Request["PublishedDate"]);
            }

            if (!string.IsNullOrEmpty(context.Request["PriorityPublishing"]))
                objET.PriorityPublishing = Convert.ToInt32(context.Request["PriorityPublishing"]);
            if (!string.IsNullOrEmpty(context.Request["BeginPriority"]))
            {
                objET.BeginPriority = formatUtils.FormatDateTime(context.Request["BeginPriority"]);
            }
            if (!string.IsNullOrEmpty(context.Request["EndPriority"]))
            {
                objET.EndPriority = formatUtils.FormatDateTime(context.Request["EndPriority"]);
            }
            if (!string.IsNullOrEmpty(context.Request["Information"]))
                objET.Information = context.Request["Information"];
            if (!string.IsNullOrEmpty(context.Request["NewsKeyword"]))
            {
                string NewsKeyword = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["NewsKeyword"]))
                    NewsKeyword = (context.Request["NewsKeyword"]);
                objET.NewsKeyword = NewsKeyword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            //if (!string.IsNullOrEmpty(context.Request["UserID"]))
            //{
            //    objET.CreatedBy = Convert.ToInt32(context.Request["UserID"]);
            //    //objET.ModifiedBy = Convert.ToInt32(context.Request["UserID"]);
            //}
            return objET;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}