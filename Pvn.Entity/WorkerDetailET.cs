using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
   public class WorkerDetailET
    {
        public string GioiTinh { get; set; }
        public string HoTen { get; set; }
        public string Contact { get; set; }
        public string SDTLienHe { get; set; }
        public List<ContactET> LstContact { get; set; }
        public string ImageURL { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
    }
}
