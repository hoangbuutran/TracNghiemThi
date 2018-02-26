using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class TinTucDao
    {
        private TestDbContext db = null;

        public TinTucDao()
        {
            db = new TestDbContext();
        }

        public TINTUC SingleTinTucID(int id)
        {
            return db.TINTUCs.SingleOrDefault(x => x.IDTINTUC == id);
        }

        public IOrderedEnumerable<TINTUC> listtintucsapxep()
        {
            return db.TINTUCs.ToList().OrderByDescending(x => x.THOIGIAN);
        }

        public TINTUC tintuctop1()
        {
            var res = db.Database.SqlQuery<TINTUC>("tintuctop1").SingleOrDefault();
            return res;
        }
        public bool ThemTinTuc(TINTUC model)
        {
            db.TINTUCs.Add(model);
            db.SaveChanges();
            return true;
        }

        public int SuaTinTuc(TINTUC model)
        {
            int i = 0;
            try
            {
                var tintuc = db.TINTUCs.Find(model.IDTINTUC);
                tintuc.THOIGIAN = DateTime.Now;
                tintuc.ANHBIA = model.ANHBIA;
                tintuc.NOIDUNG = model.NOIDUNG;
                tintuc.TIEUDE = model.TIEUDE;
                tintuc.TOMTAT = model.TOMTAT;
                tintuc.TRANGTHAI = model.TRANGTHAI;
                tintuc.NGUON = model.NGUON;
                db.SaveChanges();
                return model.IDTINTUC;
            }
            catch (Exception e)
            {
                return i;
            }
            return i;
        }

        public bool XoaTinTuc(int id)
        {
            try
            {
                var tintuc = db.TINTUCs.Find(id);
                db.TINTUCs.Remove(tintuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
