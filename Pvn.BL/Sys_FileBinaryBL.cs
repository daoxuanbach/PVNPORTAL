using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.BL
{
    public class Sys_FileBinaryBL
    {
        #region Constructors
        Sys_FileBinaryDA objDA;
        public Sys_FileBinaryBL()
        {
            objDA = new Sys_FileBinaryDA();
        }

        #endregion Constructors
        public void GetItemByPK(ref Sys_FileBinary sfInfo)
        {
            objDA.GetItemByPK(ref sfInfo);
        }
    }
}
