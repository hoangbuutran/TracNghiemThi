using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MucDoDao
    {
        TestDbContext db = null;
        public MucDoDao()
        {
            db = new TestDbContext();
        }

        public List<MUCDO> toList()
        {
            return db.MUCDOes.Where(x => x.TRANGTHAI == true).ToList();
        }
    }
}
