using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ThoiGianDao
    {
        TestDbContext db = null;
        public ThoiGianDao()
        {
            db = new TestDbContext();
        }
        public List<THOIGIAN> toList()
        {
            return db.THOIGIANs.ToList();
        }
    }
}
