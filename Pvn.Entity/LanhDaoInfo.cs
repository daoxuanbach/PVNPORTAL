using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class LanhDaoInfo
    {
        public LanhDaoInfo(string ten, DataTable dtManagers)
        {
            TenNhom = ten;
            DSThanhvien = new List<LanhDaoItem>();

            //lanh dao cao nhat
            DataView dvTopManager = dtManagers.DefaultView;
            dvTopManager.RowFilter = "STT = 1";
            LanhDaoCaonhat = new LanhDaoItem(Convert.ToString(dvTopManager[0]["IconPath"]), Convert.ToString(dvTopManager[0]["Name"]),
                Convert.ToString(dvTopManager[0]["JobTitleName"]), string.Format("/pages/chartdetail.aspx?mid={0}", dvTopManager[0]["ManagerID"]));
            //other lanh dao
            DataView dvManagers = dtManagers.DefaultView;
            dvManagers.RowFilter = "STT > 1";
            for (int i = 0; i < dvManagers.Count; i++)
            {
                DSThanhvien.Add(new LanhDaoItem(Convert.ToString(dvManagers[i]["IconPath"]), Convert.ToString(dvManagers[i]["Name"]),
                Convert.ToString(dvManagers[i]["JobTitleName"]), string.Format("/pages/chartdetail.aspx?mid={0}", dvTopManager[i]["ManagerID"])));
            }
        }

        public string TenNhom
        {
            get;
            set;
        }

        public LanhDaoItem LanhDaoCaonhat
        {
            get;
            set;
        }

        public List<LanhDaoItem> DSThanhvien
        {
            get;
            set;
        }
    }

    public class LanhDaoItem
    {
        public LanhDaoItem(string anhdaidien, string ten, string chucvu, string urlchitiet)
        {
            AnhDaidien = anhdaidien;
            Ten = ten;
            Chucvu = chucvu;
            URLChitiet = urlchitiet;
        }

        public string AnhDaidien
        {
            get;
            private set;
        }

        public string Ten
        {
            get;
            private set;
        }

        public string Chucvu
        {
            get;
            private set;
        }

        public string URLChitiet
        {
            get;
            private set;
        }
    }
}
