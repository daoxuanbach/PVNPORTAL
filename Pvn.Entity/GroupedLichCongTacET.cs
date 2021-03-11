using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class LichCongTacDetailET
    {
        public int ManagerID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; } // Hoạt động
        public string BeginDate { get; set; }
        public string ToAddress { get; set; }
        public string MTime { get; set; }
    }
    public class GroupedLichCongTacET
    {
        public string Name { get; set; }
        public int ManagerID { get; set; }
        public List<LichCongTacDetailET> lstLichCongTac { get; set; }
    }

    
}
