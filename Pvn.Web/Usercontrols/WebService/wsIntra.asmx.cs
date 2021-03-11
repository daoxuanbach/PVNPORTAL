using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System.Data;
namespace Pvn.Web
{
    /// <summary>
    /// Summary description for wsIntra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsIntra : System.Web.Services.WebService
    {
        [WebMethod]
        public List<GroupedLichCongTacET> GetListScheduleForManager_ServiceMobile(DateTime? currentDate, string userid)
        {
            try
            {
                ScheduleBL objScheduleBL = new ScheduleBL();
                List<GroupedLichCongTacET> lst = objScheduleBL.GetScheduleForManager_ServiceMobile(currentDate, userid);
                return lst;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Service_WsIntraGet_", "GetListMeeting_ServiceMobile", ex.Message);
                return null;
            }


        }
        [WebMethod]
        public List<MeetingMobileET> GetListMeeting_ServiceMobile(DateTime? meetingDate)
        {
            try
            {
                MeetingBL objMeetingBL = new MeetingBL();
                List<MeetingMobileET> lst = objMeetingBL.GetMeeting_ServiceMobile(meetingDate);
                return lst;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Service_WsIntraGet_", "GetListMeeting_ServiceMobile", ex.Message);
                return null;
            }

        }

        [WebMethod]
        public List<WorkerDetailET> GetListSearchByKeyword(int CompanyID, string txtKeyWord)
        {
            try
            {
                WorkerBL objPVNWorkerBL = new WorkerBL();
                List<WorkerDetailET> dtWorker = objPVNWorkerBL.GetListSearchByKeywordMobile(CompanyID, txtKeyWord);
                return dtWorker;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Service_WsIntraGet_", "SearchByKeyword", ex.Message);
                return null;
            }
            
        }
        [WebMethod]
        public List<CMS_CompanyET> GetAllCompanyByLevelAndParent(int companyLevel, int? _parentID)//cap cong ty
        {
            try
            {
                CompanyBL objCompannyBl = new CompanyBL();
                List<CMS_CompanyET> lstCompany = objCompannyBl.GetAllLstCompanyByLevelAndParent(companyLevel, _parentID); //cap cong ty
                return lstCompany;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Service_WsIntraGet_", "SearchByKeyword", ex.Message);
                return null;
            }

        }
         [WebMethod]
        public List<WorkerDetailET> GetContactByCompanyLevel(int companyID, short companyLevel)//cap cong ty
        {
            try
            {
              
                WorkerBL objPVNWorkerBL = new WorkerBL();
                List<WorkerDetailET> dsWorker = objPVNWorkerBL.GetSearchPagingServiceMobile(companyID, companyLevel);
                if (dsWorker != null)
                {
                    return dsWorker;
                }
               else 
                return null;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Service_WsIntraGet_", "SearchByKeyword", ex.Message);
                return null;
            }

        }

         
        
        
    }
}
