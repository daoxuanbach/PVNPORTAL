using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class CommentDA : Pvn.DA.DataProvider
    {
        /// <summary>
        /// Add news comment
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="nameNoSign"></param>
        /// <param name="address"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        /// <param name="createdDate"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public int AddNewsComment(
             Guid newsId,
             string title,
             string content,
             string name,
             string nameNoSign,
             string address,
             string tel,
             string email,
             DateTime createdDate,
             int? createBy)
        {
            return ExecuteNonQuery("sp_Presentation_NewsRating_Add", 
                    newsId,
                    title,
                    content,
                    name,
                    nameNoSign,
                    address,
                    tel,
                    email,
                    createdDate,
                    createBy);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRows"></param>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public DataTable GetPaging(
            int pageIndex,
            int rowsInPage,
            ref int totalRows,
            Guid newsID)
        {
            try
            {
                DataTable dt =GetTableByProcedure( "sp_Presentation_NewsRating_GetPaging",
                        pageIndex,
                        rowsInPage,
                        newsID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
               // CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRows = 0;
                return null;
            }
        }
       
    }
}
