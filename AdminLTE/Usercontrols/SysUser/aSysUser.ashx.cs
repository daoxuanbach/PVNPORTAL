
using Microsoft.SharePoint;
using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
namespace AdminLTE.Usercontrols.SysUser
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aSysUser : IHttpHandler, IReadOnlySessionState
    {
        Sys_UserBL objBL = new Sys_UserBL();
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
                case "upd":
                    Update(context);
                    break;
                case "userupd":
                    UserUpdate(context);
                    break;
                case "uppPass":
                    uppPass(context);
                    break;
                case "del":
                    Delete(context);
                    break;
                case "updaterole":
                    Updaterole(context);
                    break;
                case "updateuserfn":
                    UpdateUserFn(context);
                    break;
                case "phanquyen":
                    Phanquyen(context);
                    break;
                case "addUserSP":
                    InsertUserSP(context);
                    break;
                default:
                    break;


            }
        }
        protected void Phanquyen(HttpContext context)
        {

            SysUserRoleBL objBL = new SysUserRoleBL();
            string lstchucnang = string.Empty;
            int UserID = 0;
            string ListFunction = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["lstchucnang"]))
                lstchucnang = (context.Request["lstchucnang"]);
            if (!string.IsNullOrEmpty(context.Request["UserID"]))
                UserID = Convert.ToInt32(context.Request["UserID"]);
            List<string> listStrLineElements = lstchucnang.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //xóa quyền thuộc user
            if (objBL.DeleteRoleByUser(UserID))
            {
                foreach (string item in listStrLineElements)
                {
                    SysUserRoleET objET = new SysUserRoleET();
                    // Add quyền thuộc chức năng
                    List<string> lst = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    objET.FunctionID = new Guid(lst[0]);
                    objET.RoleID = Convert.ToInt32(lst[1]);
                    objET.UserID = UserID;
                    if (objBL.Insert(objET) > 0)
                    {
                        objMsg.Error = false;
                        objMsg.Message = "Cập nhật thành công";
                    }
                    else
                    {
                        objMsg.Error = true;
                        objMsg.Message = "Cập nhật không thành công";
                        break;
                    }

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
                    objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                    objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                    objLog.Note = objMsg.Message;
                    objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                }
                #endregion
            }
            objMsg.RenderMessage(objMsg, context);


        }
        protected void Delete(HttpContext context)
        {

            //bool catchException = SPSecurity.CatchAccessDeniedException;
            //SPSecurity.CatchAccessDeniedException = false;
            //SPSite site = SPContext.Current.Site;
            //SPWeb web = site.RootWeb;
            //web.AllowUnsafeUpdates = true;

            string PageID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["PageID"]))
                PageID = (context.Request["PageID"]);
            List<string> listStrLineElements = PageID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                // Sys_UserET objUser = objBL.GetInfo(item);
                if (objBL.Delete(Convert.ToInt32(item)))
                {
                    //SPUser user = web.EnsureUser(objUser.LoginNameSP);
                    //SPGroup oGroup = web.SiteGroups["GroupCMS "];
                    //oGroup.RemoveUser(user);
                    objMsg.Error = false;
                    objMsg.Message = "Xoá thành công";
                }
                else
                {
                    objMsg.Error = true;
                    objMsg.Message = "Xoá không thành công";
                }


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
            //web.AllowUnsafeUpdates = false;
            objMsg.RenderMessage(objMsg, context);

        }
        protected void Updaterole(HttpContext context)
        {
            string jsonRole = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["jsonRole"]))
                jsonRole = (context.Request["jsonRole"]);

            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Sys_UserET> lstReturn = oSerializer.Deserialize<List<Sys_UserET>>(jsonRole);
            foreach (Sys_UserET objET in lstReturn)
            {
                if (objBL.UpdateRole(objET))
                {
                    objMsg.Error = false;
                    objMsg.Message = "Cập nhật thành công";
                }
                else
                {
                    objMsg.Error = true;
                    objMsg.Message = "Cập nhật không thành công";
                }
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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.QuyenNguoiDung;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion
            objMsg.RenderMessage(objMsg, context);
        }


        protected void UpdateUserFn(HttpContext context)
        {
            string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
            int UsedState = 1;
            SysUserFunctionBL objBL = new SysUserFunctionBL();
            string listUserFn = string.Empty;
            int UserID = 0;
            string ListFunction = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["listuserfn"]))
                listUserFn = (context.Request["listuserfn"]);

            if (!string.IsNullOrEmpty(context.Request["UserID"]))
                UserID = Convert.ToInt32(context.Request["UserID"]);
            List<string> listStrLineElements = listUserFn.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<SysUserFunctionET> listAll = objBL.GetAll_SysUserFunction_Tree_ByUser(UserID, Language, UsedState);

            List<SysUserFunctionET> listUserFnDel = listAll.Where(p => !listStrLineElements.Contains(p.FunctionID.ToString())).ToList();
            List<SysUserFunctionET> listUserFnAdd = listAll.Where(p => listStrLineElements.Contains(p.FunctionID.ToString())).ToList();
            if (listUserFnDel != null && listUserFnDel.Count > 0)
            {
                List<SysUserFunctionET> listUserFnDelCheck = listUserFnDel.Where(p => p.CheckUserFunction == "checked").ToList();
                for (int i = listUserFnDelCheck.Count() - 1; i >= 0; i--)
                {
                    objMsg = objBL.Delete(listUserFnDelCheck[i].User_FunctionID);
                    if (objMsg.Error)
                        break;
                }

            }
            if (listUserFnAdd != null)
            {
                foreach (SysUserFunctionET objET in listUserFnAdd.Where(p => p.CheckUserFunction != "checked"))
                {
                    objET.UserID = UserID.ToString();
                    if (objBL.Insert(objET))
                    {
                        objMsg.Error = false;
                        objMsg.Message = "Cập nhật thành công";
                    }
                    else
                    {
                        objMsg.Error = true;
                        objMsg.Message = "Cập nhật không thành công";
                    }
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
                    objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ChucNangNguoiDung;
                    objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                    objLog.Note = objMsg.Message;
                    objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                }
                #endregion
            }



            objMsg.RenderMessage(objMsg, context);
        }
        protected void Update(HttpContext context)
        {
            Sys_UserET objET = RequestEntity(context);

            if (objBL.Update(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật mật khẩu thành công";

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
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Cập nhật mật khẩu không thành công"; 
            }

            objMsg.RenderMessage(objMsg, context);
        }
        protected void UserUpdate(HttpContext context)
        {
            Sys_UserET objET = RequestEntity(context);

            if (objBL.UserUpdate(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Cập nhật không thành công";
            }

            objMsg.RenderMessage(objMsg, context);
        }
        protected void uppPass(HttpContext context)
        {
            Sys_UserET objET = RequestEntity(context);

            if (objBL.uppPass(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Cập nhật không thành công";
            }

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Insert(HttpContext context)
        {
            Sys_UserET objET = RequestEntity(context);
            if (objBL.Insert(objET))
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

        protected void InsertUserSP(HttpContext context)
        {
            bool catchException = SPSecurity.CatchAccessDeniedException;
            SPSecurity.CatchAccessDeniedException = false;
            SPSite site = SPContext.Current.Site;
            SPWeb web = site.RootWeb;
            web.AllowUnsafeUpdates = true;
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Sys_UserET> sData = js.Deserialize<List<Sys_UserET>>(context.Request["listUser"]);
            string AccountDouble = string.Empty;
            foreach (Sys_UserET objET in sData)
            {
                if (!string.IsNullOrEmpty(objET.LoginName))
                {
                    SPUser user = web.EnsureUser(objET.LoginName);

                    objET.LoginName = user.LoginName.Substring(user.LoginName.IndexOf("\\") + 1);
                    if (!objBL.CheckAccountLoginName(objET.LoginName))
                    {
                        objET.UserID = user.ID;
                        objET.Email = user.Email;
                        objET.LoginNameSP = user.LoginName;
                        if (objBL.Insert(objET))
                        {
                            SPGroup oGroup = web.SiteGroups["GroupCMS"];
                            oGroup.AddUser(user);
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
                            break;
                        }
                    }
                    else
                    {
                        AccountDouble = AccountDouble + objET.LoginName + ", ";
                        objMsg.Error = true;
                        objMsg.Message = "Tên đăng nhập đã tồn tại.";
                    }

                }

            }
            if (!string.IsNullOrEmpty(AccountDouble))
            {
                objMsg.Error = true;
                objMsg.Message = "Tên đăng nhập: " + AccountDouble + " đã tồn tại.";
            }
            web.AllowUnsafeUpdates = false;
            objMsg.RenderMessage(objMsg, context);
        }
        private Sys_UserET RequestEntity(HttpContext context)
        {
            Sys_UserET objET = new Sys_UserET();
            if (!string.IsNullOrEmpty(context.Request["UserID"]))
                objET.UserID = Convert.ToInt32(context.Request["UserID"]);
            if (!string.IsNullOrEmpty(context.Request["UnitID"]))
                objET.UnitID = new Guid(context.Request["UnitID"]);
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["LoginName"]))
                objET.LoginName = context.Request["LoginName"].Trim();
            if (!string.IsNullOrEmpty(context.Request["UserName"]))
                objET.UserName = context.Request["UserName"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Checksum"]))
                objET.Checksum = Pvn.Utils.Common.GetMD5HashData(context.Request["Checksum"]);
            if (!string.IsNullOrEmpty(context.Request["Tel"]))
                objET.Tel = (string)(context.Request["Tel"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["Email"]))
                objET.Email = (string)(context.Request["Email"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = (string)(context.Request["Note"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["listValueAnhAttach"]))
            {
                string strListFileAttach = context.Request["listValueAnhAttach"];
                objET.ImagePath = strListFileAttach;
            }

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