using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ChuyenNganhDao
    {
        private TestDbContext db = null;

        public ChuyenNganhDao()
        {
            db = new TestDbContext();
        }

        public List<CHUYENNGANH_DH> toList()
        {
            return db.CHUYENNGANH_DH.ToList();
        }

        public List<CT_CHUYENNGANH_MON> toListCNDH(int id)
        {
            return db.CT_CHUYENNGANH_MON.Where(x=>x.IDCN_DH == id).ToList();
        }

        public bool ThemMoiChuyenNganh(CHUYENNGANH_DH model)
        {
            db.CHUYENNGANH_DH.Add(model);
            db.SaveChanges();
            return true;
        }

        public bool SuaChuyenNganh(CHUYENNGANH_DH model)
        {
            var chuyen = db.CHUYENNGANH_DH.Find(model.IDCN_DH);
            chuyen.TENCN_DH = model.TENCN_DH;
            chuyen.IDCAPTHI = chuyen.IDCAPTHI;
            chuyen.CAPTHI = chuyen.CAPTHI;
            db.SaveChanges();
            return true;
        }

        public bool XoaChuyenNganh(int id)
        {
            var dao = db.CHUYENNGANH_DH.Find(id);
            db.CHUYENNGANH_DH.Remove(dao);
            db.SaveChanges();
            return true;
        }

        public bool them_CTChuyenNganhMon(CT_CHUYENNGANH_MON model)
        {
            db.CT_CHUYENNGANH_MON.Add(model);
            db.SaveChanges();
            return true;
        }

    }
}
