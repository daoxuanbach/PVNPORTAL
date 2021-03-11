using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pvn.Utils
{
    [Serializable]
    public class MessageUtil
    {
        #region các biến
        private bool _Error;
        private string _Message;
        #endregion

        #region Thuộc tính
        public bool Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion

        #region Constructer
        public MessageUtil()
        {
            _Error = false;
            _Message = string.Empty;
        }

        public MessageUtil(bool error, string message)
        {
            this._Error = error;
            this._Message = message;
        }
        #endregion

        #region Method

        /// <summary>
        /// Trả lại thông báo cho client
        /// </summary>
        /// <param name="message"></param>
        public void RenderMessage(MessageUtil message, HttpContext context)
        {
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                new System.Web.Script.Serialization.JavaScriptSerializer();
            string strJsonMessage = oSerializer.Serialize(message);
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.Write(strJsonMessage);
            context.Response.End();
        }
        public void RenderMessage(MessageUtil renderObjMessage, System.Web.UI.Page page)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonMessage = jsSerializer.Serialize(renderObjMessage);
            page.Response.Clear();
            page.Response.ContentType = "application/json";
            page.Response.Write(jsonMessage);
            page.Response.End();
        }
        public void RenderHtml(string htmlContent, HttpContext context)
        {
            //System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
            //    new System.Web.Script.Serialization.JavaScriptSerializer();
            //string strJsonMessage = oSerializer.Serialize(message);
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.Write(htmlContent);
            context.Response.End();
        }
        #endregion
    }
}
