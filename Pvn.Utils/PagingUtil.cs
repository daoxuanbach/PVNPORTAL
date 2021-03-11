using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
    public class PagingUtil
    {
        #region Các biến xử dụng
        private int _PageStep;
        private int _CurrentPage;
        private string _LinkPage;
        private int _TotalPage;
        private string _LinkPageExt;
        #endregion

        #region Các thuộc tính
        public int PageStep
        {
            get { return _PageStep; }
            set { _PageStep = value; }
        }

        public int TotalPage
        {
            get { return _TotalPage; }
            set { _TotalPage = value; }
        }
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }

        public string LinkPage
        {
            get { return _LinkPage; }
            set { _LinkPage = value; }
        }
        public string LinkPageExt
        {
            get { return _LinkPageExt; }
            set { _LinkPageExt = value; }
        }
        #endregion

        /// <summary>
        /// Hàm Constructer
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Thuanld     10/11/2009      Tạo mới
        /// </Modified>
        public PagingUtil()
        {
            CurrentPage = 1;
            LinkPage = string.Empty;
            TotalPage = 1;
            PageStep = 3;
            LinkPageExt = "";
        }

        /// <summary>
        /// Hàm lấy về mã html phân trang
        /// </summary>
        /// <param name="_LinkPage">đường link của trang</param>
        /// <param name="_CurrentPage">Trang hiện tại</param>
        /// <param name="_RowPerPage">Số bản ghi trên trang</param>
        /// <param name="_TotalRow">Tổng số bản ghi</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Thuanld     10/11/2009      Tạo mới
        /// </Modified>
        public string getHtmlPage(string _LinkPage, int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            LinkPage = _LinkPage;
            if (_RowPerPage == 0)
                _RowPerPage = 5;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPage();
        }

        /// <summary>
        /// Hàm lấy về phân trang, hỗ trợ cho urlRewrite
        /// </summary>
        /// <param name="_LinkPage">đường link của trang - Phía trước page</param>
        /// <param name="_LinkPageExt">đường link của trang - Phía sau page</param>
        /// <param name="_CurrentPage">Trang hiện tại</param>
        /// <param name="_RowPerPage">Số bản ghi trên trang</param>
        /// <param name="_TotalRow">Tổng số bản ghi</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Thuanld     10/11/2009      Tạo mới
        /// </Modified>
        public string getHtmlPage(string _LinkPage, string _LinkPageExt, int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            LinkPage = _LinkPage;
            LinkPageExt = _LinkPageExt;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPage();
        }

        /// <summary>
        /// Hàm write mã HTML phân trang
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Thuanld     10/11/2009      Tạo mới
        /// </Modified>
        private string WriteHTMLPage()
        {
            string strPageHTML = "<ul class=\"paginate\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHTML += "<li><a href=\"" + LinkPage + 1 + LinkPageExt + "\">« Đầu</a></li>";
                strPageHTML += "<li><a href=\"" + LinkPage + (CurrentPage - 1) + LinkPageExt + "\">Trước</a></li>";
                //strPageHTML += "<span>...</span>";
            }

            int BeginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            int EndFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (int pNumber = BeginFor; pNumber <= EndFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHTML += "<li class=\"current\">" + pNumber + "</li>";
                else
                    strPageHTML += "<li><a href=\"" + LinkPage + pNumber + LinkPageExt + "\">" + pNumber + "</a></li>";
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                //strPageHTML += "<span>...</span>";
                strPageHTML += "<li><a href=\"" + LinkPage + (CurrentPage + 1) + LinkPageExt + "\">Sau</a></li>";
                strPageHTML += "<li><a href=\"" + LinkPage + TotalPage + LinkPageExt + "\">Cuối »</a></li>";

            }
            strPageHTML += "</ul>";
            if (TotalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }


        public string getHtmlPagingJS(int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            if (_RowPerPage == 0)
                _RowPerPage = 5;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPagingJS();
        }
        public string getHtmlPagingJS2(int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow, string customParameter)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            if (_RowPerPage == 0)
                _RowPerPage = 5;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPagingJS2(customParameter);
        }
        private string WriteHTMLPagingJS2(string customParamenter)
        {
            string strPageHTML = "<ul class=\"paginate\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHTML += string.Format("<li><a href=\"javascript:LoadContentPagging(1,{0})\">« Đầu</a></li>", customParamenter);
                strPageHTML += string.Format("<li><a href=\"javascript:LoadContentPagging(" + (CurrentPage - 1) + ",{0})\">Trước</a></li>", customParamenter);
                //strPageHTML += "<span>...</span>";
            }

            int BeginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            int EndFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (int pNumber = BeginFor; pNumber <= EndFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHTML += "<li class=\"current\">" + pNumber + "</li>";
                else
                    strPageHTML += string.Format("<li><a href=\"javascript:LoadContentPagging(" + pNumber + ",{0})\">" + pNumber + "</a></li>", customParamenter);
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                //strPageHTML += "<span>...</span>";
                strPageHTML += string.Format("<li><a href=\"javascript:LoadContentPagging(" + (CurrentPage + 1) + ",{0})\">Sau</a></li>", customParamenter);
                strPageHTML += string.Format("<li><a href=\"javascript:LoadContentPagging(" + TotalPage + ",{0})\">Cuối »</a></li>", customParamenter);

            }
            strPageHTML += "</ul>";
            if (TotalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }
        public string getHtmlPagingJSCustomAll(int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow, string functionName, string viewPage)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            if (_RowPerPage == 0)
                _RowPerPage = 5;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPagingJSCustomAll(functionName, viewPage);
        }

        private string WriteHTMLPagingJSCustomAll(string functionName, string viewPage)
        {
            string strPageHTML = "<ul class=\"pagination\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHTML += string.Format("<li class='paginate_button'><a href=\"javascript:{0}(1,{1})\">« Đầu</a></li>", functionName, viewPage);
                strPageHTML += string.Format("<li class='paginate_button'><a href=\"javascript:{0}(" + (CurrentPage - 1) + ",{1})\">Trước</a></li>", functionName, viewPage);
                //strPageHTML += "<span>...</span>";
            }

            int BeginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            int EndFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (int pNumber = BeginFor; pNumber <= EndFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    //strPageHTML += "<li class=\"paginate_button active\">" + pNumber + "</li>";
                       strPageHTML += "<li class='paginate_button active'><a href=\"javascript:void(0);\">" + pNumber + "</a></li>";
                else
                    strPageHTML += string.Format("<li class='paginate_button'><a href=\"javascript:{0}(" + pNumber + ",{1})\">" + pNumber + "</a></li>", functionName, viewPage);
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                //strPageHTML += "<span>...</span>";
                strPageHTML += string.Format("<li class='paginate_button'><a href=\"javascript:{0}(" + (CurrentPage + 1) + ",{1})\">Sau</a></li>", functionName, viewPage);
                strPageHTML += string.Format("<li class='paginate_button'><a href=\"javascript:{0}(" + TotalPage + ",{1})\">Cuối »</a></li>", functionName, viewPage);

            }
            strPageHTML += "</ul>";
            if (TotalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }
        private string WriteHTMLPagingJS()
        {
            string strPageHTML = "<ul class=\"paginate\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHTML += "<li><a href=\"javascript:LoadContentPagging(1)\">« Đầu</a></li>";
                strPageHTML += "<li><a href=\"javascript:LoadContentPagging(" + (CurrentPage - 1) + ")\">Trước</a></li>";
                //strPageHTML += "<span>...</span>";
            }

            int BeginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            int EndFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (int pNumber = BeginFor; pNumber <= EndFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHTML += "<li class=\"current\">" + pNumber + "</li>";
                else
                    strPageHTML += "<li><a href=\"javascript:LoadContentPagging(" + pNumber + ")\">" + pNumber + "</a></li>";
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                //strPageHTML += "<span>...</span>";
                strPageHTML += "<li><a href=\"javascript:LoadContentPagging(" + (CurrentPage + 1) + ")\">Sau</a></li>";
                strPageHTML += "<li><a href=\"javascript:LoadContentPagging(" + TotalPage + ")\">Cuối »</a></li>";

            }
            strPageHTML += "</ul>";
            if (TotalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }
        public string getHtmlPagingJSCustom(int _PageStep, int _CurrentPage, int _RowPerPage, int _TotalRow, string pagingName)
        {
            this.PageStep = _PageStep;
            CurrentPage = _CurrentPage;
            if (_RowPerPage == 0)
                _RowPerPage = 5;
            TotalPage = (_TotalRow % _RowPerPage == 0) ? _TotalRow / _RowPerPage : ((_TotalRow - (_TotalRow % _RowPerPage)) / _RowPerPage) + 1;
            return WriteHTMLPagingJSCustom(pagingName);
        }

        private string WriteHTMLPagingJSCustom(string pagingName)
        {
            string strPageHTML = "<ul class=\"paginate\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHTML += string.Format("<li><a href=\"javascript:{0}(1)\">« Đầu</a></li>", pagingName);
                strPageHTML += string.Format("<li><a href=\"javascript:{0}({1})\">Trước</a></li>", pagingName, CurrentPage - 1);
                //strPageHTML += "<span>...</span>";
            }

            int BeginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            int EndFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (int pNumber = BeginFor; pNumber <= EndFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHTML += "<li class=\"current\">" + pNumber + "</li>";
                else
                    strPageHTML += string.Format("<li><a href=\"javascript:{0}({1})\">{1}</a></li>",
                        pagingName, pNumber);
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                //strPageHTML += "<span>...</span>";
                strPageHTML += string.Format("<li><a href=\"javascript:{0}({1})\">Sau</a></li>", pagingName, CurrentPage + 1);
                strPageHTML += string.Format("<li><a href=\"javascript:{0}({1})\">Cuối »</a></li>", pagingName, TotalPage);

            }
            strPageHTML += "</ul>";
            if (TotalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }
        public string RenderPaged(long totalRows, int rowsNum, int currentPage, int pageStep)
        {

            long totalPage = (totalRows % rowsNum == 0) ? totalRows / rowsNum : ((totalRows - (totalRows % rowsNum)) / rowsNum) + 1;
            string strPageHTML = "<ul class='pagination' id=\"pagination\">";

            if (currentPage > pageStep + 1)
            {
                strPageHTML += "<li class='paginate_button'><a class='pageOnclick' href=\"javascript:void(0);\" pnumber=\"" + 1 + "\">««« Đầu</a></li>";
                strPageHTML += "<li class='paginate_button'><a class='pageOnclick' href=\"javascript:void(0);\" pnumber=\"" + (currentPage - 1) + "\">« Trước</a></li>";
                strPageHTML += "<li class='paginate_button'><a href=\"javascript:void(0);\"><span>...</span></a></li>";
            }

            int intFirstPage = ((currentPage - pageStep) > 1) ? (currentPage - pageStep) : 1;
            long intLastPage = ((currentPage + pageStep) > totalPage) ? totalPage : (currentPage + pageStep);

            for (int intPage = intFirstPage; intPage <= intLastPage; intPage++)
            {
                if (intPage == currentPage)
                    strPageHTML += "<li class='paginate_button active'><a  class='pageOnclick' href=\"javascript:void(0);\">" + intPage + "</a></li>";
                else
                    strPageHTML += "<li class='paginate_button'><a class='pageOnclick' href=\"javascript:void(0);\" pnumber=\"" + intPage + "\">" + intPage + "</a></li>";
            }

            if (currentPage < (totalPage - pageStep))
            {
                strPageHTML += "<li class='paginate_button'><a href=\"javascript:void(0);\"><span>...</span></a>";
                strPageHTML += "<li class=\"paginate_button next\"><a class='pageOnclick' href=\"javascript:void(0);\" pnumber=\""  + (currentPage + 1) + "\">Sau »</a></li>";
                strPageHTML += "<li class=\" paginate_button next\"><a class='pageOnclick' href=\"javascript:void(0);\"  pnumber=\""  + totalPage + "\">Cuối »»»</a></li>";

            }
            strPageHTML += "</ul>";
            if (totalPage > 1)
                return strPageHTML;
            else
                return string.Empty;
        }

       
    }
}
