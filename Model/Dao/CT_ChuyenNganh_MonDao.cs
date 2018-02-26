using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CT_ChuyenNganh_MonDao
    {
        private TestDbContext _db = null;
        public CT_ChuyenNganh_MonDao()
        {
            _db = new TestDbContext();
        }

        public List<CT_CHUYENNGANH_MON> ToList()
        {
            return _db.CT_CHUYENNGANH_MON.ToList();
        }
    }
}
