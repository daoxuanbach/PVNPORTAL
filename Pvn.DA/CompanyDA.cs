using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class CompanyDA: Pvn.DA.DataProvider
    {
        public CompanyDA() { }
    
        /// <summary>
        /// Get Company by level
        /// </summary>
        /// <param name="CompanyDate"></param>
        /// <returns></returns>
        public DataTable GetCompanyByLevel(short companyLevel)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetCompanyByLevel", companyLevel);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CompanyDA", "GetCompanyByLevel", ex.Message);           
                return null;
            }
        }

        /// <summary>
        /// Get company by level and parent
        /// </summary>
        /// <param name="companyLevel"></param>
        /// <param name="_parentID"></param>
        /// <returns></returns>
        public DataTable GetAllCompanyByLevelAndParent(int? companyLevel, int? _parentID)
        {
            DataTable dt;
            try
            {
                return dt = GetTableByProcedure("sp_Presentation_GetCompanyByLevelAndParentID", companyLevel, _parentID);

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CompanyDA", "GetAllCompanyByLevelAndParent", ex.Message);
                return null;
            }

        }

       }
}
