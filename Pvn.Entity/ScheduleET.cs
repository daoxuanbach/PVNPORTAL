using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class ScheduleET
    {
        public string Ngay { get; set; }
        public List<ScheduleForManagerET> ListScheduleDetail { get; set; }
    }
}
