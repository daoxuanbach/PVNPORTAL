using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class AdvertismentDA : Pvn.DA.DataProvider
    {
        public DataTable getAdvertismentByPosition(string language, short numberOfItems, short position)
        {
            try
            {
                DataTable tblCMS_ImageET = GetTableByProcedure("sp_Presentation_AdvertisementGetByPosition", language, numberOfItems, position);
                return tblCMS_ImageET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_ImageDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
    }
}
