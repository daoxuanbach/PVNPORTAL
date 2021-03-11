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
    public class MeetingBL
    {
         #region Constructors
         MeetingDA objDA;
        public MeetingBL()
        {
            objDA = new MeetingDA();
        }

        #endregion Constructors
        public DataTable GetSearchPaging(DateTime? meetingDate)
        {
            try
            {
                return objDA.GetSearchPaging(meetingDate);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("MeetingBL", "GetSearchPaging", ex.Message);
                return null;
            }
        }
        public List<MeetingMobileET> GetMeeting_ServiceMobile(DateTime? meetingDate)
        {
            try
            {
                List<MeetingMobileET> lst = new List<MeetingMobileET>();
                DataTable dt = objDA.GetMeeting_ServiceMobile(meetingDate);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(setPropertiesMobile(dt.Rows[i]));
                }
                return lst;

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("MeetingBL", "GetMeeting_ServiceMobile", ex.Message);
                return null;
            }
        }
        private MeetingMobileET setPropertiesMobile(DataRow oReader)
        {
            try
            {
                MeetingMobileET objCMSET = new MeetingMobileET();
                if (oReader["RoomID"] != DBNull.Value)
                    objCMSET.RoomID = Convert.ToInt32(oReader["RoomID"]);
                if (oReader["RoomName"] != DBNull.Value)
                    objCMSET.RoomName = Convert.ToString(oReader["RoomName"]);
                if (oReader["RoomAddress"] != DBNull.Value)
                    objCMSET.RoomAddress = Convert.ToString(oReader["RoomAddress"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMSET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["MeetingDate"] != DBNull.Value)
                    objCMSET.MeetingDate = Convert.ToDateTime(oReader["MeetingDate"]);
                if (oReader["MTime"] != DBNull.Value)
                    objCMSET.MTime = Convert.ToString(oReader["MTime"]);

                return objCMSET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
                throw ex;
            }
        }
    }
}
