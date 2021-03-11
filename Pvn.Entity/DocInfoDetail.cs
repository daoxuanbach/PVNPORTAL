using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
   public class DocInfoDetail
    {
        public string STT { get; set; }
        public string TieuDe { get; set; }
        public string SoVanBan { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public Dictionary<string, string> FileAttach { get; set; }
    }
}
