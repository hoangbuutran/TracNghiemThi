using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SoCauDao
    {
        TestDbContext db = null;
        public SoCauDao()
        {
            db = new TestDbContext();
        }
        public List<SOCAU> toList()
        {
            return db.SOCAUs.ToList();
        }
    }
}
