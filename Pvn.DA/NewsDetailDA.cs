using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class NewsDetailDA : Pvn.DA.DataProvider
    {
        /// <summary>
        /// Get all news detail data
        /// </summary>
        /// <param name="inputParameter"></param>
        /// <returns></returns>
        public DataSet GetNewsDetailDataV1(string language, int numberMain, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            DataSet ds = GetDatasetByProcedure("sp_Presentation_NewsDetail_GetNewsDetailData_V1", language, numberMain, newsID, numberNewsOther, numberTimeline);
            return ds;
        }

        /// <summary>
        /// Get all news detail data
        /// </summary>
        /// <param name="inputParameter"></param>
        /// <returns></returns>
        public DataSet GetNewsDetailData(string language, int numberMain, Guid? newsID, int numberNewsOther, int numberTimeline, ref string categoryName)
        {
            DataSet ds = GetDatasetByProcedure("sp_Presentation_NewsDetail_GetNewsDetailData", language, numberMain, newsID, numberNewsOther, numberTimeline);
            return ds;
        }

        /// <summary>
        /// Lay ra danh sach tin xem nhieu
        /// </summary>
        /// <param name="language">Ngon ngu</param>
        /// <param name="newsNum">So luong tin</param>
        /// <returns></returns>
        public DataTable GetListMostView(string language, int numberOfItems, Guid? newsPublishingID)
        {
            return GetTableByProcedure("sp_Presentation_NewsDetail_GetMostView",
                language, numberOfItems, newsPublishingID);
        }

        /// <summary>
        /// Lay ra danh sach tin lien quan
        /// </summary>
        /// <param name="language">Ngon ngu</param>
        /// <param name="newsNum">So luong tin</param>
        /// <returns></returns>
        public DataTable GetListRelatedNews(string language, int numberOfItems, Guid? newsPublishingID)
        {
            return GetTableByProcedure("sp_Presentation_NewsDetail_GetOtherRelatedNews",
                language, numberOfItems, newsPublishingID);
        }
    }
}
