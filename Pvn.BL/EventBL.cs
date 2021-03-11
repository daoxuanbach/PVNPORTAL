using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.BL
{
    public class EventBL
    {
        #region Constructors
        EventDA objDA;
        public EventBL()
        {
            objDA = new EventDA();
        }

        #endregion Constructors

        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventAnnouncement(Guid categoryID, int totalItems)
        {
            try
            {
                DataTable dt = objDA.GetEventAnnouncement(categoryID, totalItems);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncement", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get Event search paging
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventAnnouncementSearchPaging(Guid categoryID, int pageIndex, int rowsInPage, ref int totalRecords)
        {
            try
            {
                DataTable dt = objDA.GetEventAnnouncementSearchPaging(categoryID, pageIndex, rowsInPage, ref totalRecords);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncementSearchPaging", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get Event by time and time
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventByTimeAndType(short eventType, DateTime beginDate, DateTime endDate)
        {
            try
            {
                DataTable dt = objDA.GetEventByTimeAndType(eventType, beginDate, endDate);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncementSearchPaging", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public DataSet GetEventByID(int eventID, int totalOtherItems)
        {
            try
            {
                DataSet dt = objDA.GetEventByID( eventID, totalOtherItems);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventByID", ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Get thong cao bao chi by type
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventByTypeWithSearchPaging(short eventType, int pageIndex, int rowsInPage, ref int totalRecords)
        {
            try
            {
                DataTable dt = objDA.GetEventByTypeWithSearchPaging(eventType, pageIndex, rowsInPage,ref totalRecords);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventByID", ex.Message);
                return null;
            }
        }
    }
}
