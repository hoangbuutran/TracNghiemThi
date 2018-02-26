using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class HomeDao
    {
        TestDbContext db = null;
        public HomeDao()
        {
            db = new TestDbContext();
        }

        public int DemSoNguoiDung()
        {
            return db.NGUOIDUNGs.Count(x => x.TRANGTHAI == true);
        }
        public int DemSoDeThi()
        {
            return db.DETHIs.Count(x => x.TRANGTHAI == true);
        }
        public int DemSoCauHoi()
        {
            return db.CAUHOIs.Count(x => x.TRANGTHAI == true);
        }
        public int DemSoTinTuc()
        {
            return db.TINTUCs.Count(x => x.TRANGTHAI == true);
        }

    }
}
