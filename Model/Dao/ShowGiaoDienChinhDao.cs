using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ShowGiaoDienChinhDao
    {
        private TestDbContext db = null;

        public ShowGiaoDienChinhDao()
        {
            db = new TestDbContext();
        }

        public List<CAPTHI> ListCapThi()
        {
            return db.CAPTHIs.Where(x => x.TRANGTHAI == true).ToList();
        }
        public List<MONTHI> ListMonThi()
        {
            return db.MONTHIs.Where(x => x.TRANGTHAI == true).ToList();
        }

    }
}
