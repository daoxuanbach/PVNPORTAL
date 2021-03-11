using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class WorkerDA: Pvn.DA.DataProvider
    {
        public WorkerDA() { }
        public bool TestFun()
        {
            
            //DataTable tblDMChucVu = GetDatasetByProcedure("sproc_TestFun", new object[] { "DMChucVu", String.Empty }).Tables[0];
            DataTable tblDMChucVu = GetDatasetByProcedure("sp_Presentation_Menu_GetTree", "vi",0,true,0).Tables[0];
            //using (SqlConnection con = GetConnection())
            //{
            //    SqlCommand sqlCmd = new SqlCommand("sproc_TestFun", con);
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    List<NguoiDungET> listNguoiDung = new List<NguoiDungET>();
            //    using (IDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection))
            //    {
            //        return true;
            //    }
            //}
            return true;
        }
        /// <summary>
        /// Get Worker
        /// </summary>
        /// <param name="WorkerDate"></param>
        /// <returns></returns>
        public DataTable GetBirthdayAnnouncement(int companyID)
        {
            try
            {
                DataTable dt = GetDatasetByProcedure("sp_Presentation_Worker_BirthdayAnnouncement", companyID).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

       
        /// <summary>
        /// Get worker by condition
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public DataSet GetSearchPaging(int companyID, short companyLevel)
        {
            try
            {
                DataSet dt = GetDatasetByProcedure("sp_Presentation_Worker_Search", companyID, companyLevel);
                //DataSet dt = new DataHelper(new CommonLib.Application.ApplicationInfo().DataProviderType).ExecuteDataset(ConnectionString, "sp_Presentation_Worker_Search", companyID, companyLevel);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        public DataTable GetSearchPagingServiceMobile(int companyID, short companyLevel)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_ServiceMobile_Worker", companyID, companyLevel);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        
        /// <summary>
        /// Get worker by condition
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public DataTable GetSearchByKeyword(string keyword)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Worker_SearchByCondition", keyword);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

         public DataTable GetSearchByKeywordMobile(int CompanyID, string keyword)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Worker_SearchServiceMobile",CompanyID, keyword);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        
        /// <summary>
        /// Get list manager for displaying on chart
        /// </summary>
        /// <returns></returns>
        public DataSet GetListManagerForChart()
        {
            try
            {
                DataSet dt = GetDatasetByProcedure("sp_Presentation_GetManagerChart");
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Get manager by ID
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        public DataTable GetManagerByID(int managerID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetManagerByID", managerID);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
    }
}
