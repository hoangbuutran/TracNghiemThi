using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MonThiDao
    {
        TestDbContext db = null;
        public MonThiDao()
        {
            db = new TestDbContext();
        }

        public List<MONTHI> toList()
        {
            return db.MONTHIs.Where(x => x.TRANGTHAI == true).ToList();
        }

        public List<MONTHI> toListid(int id)
        {
            return db.MONTHIs.Where(x => x.TRANGTHAI == true && x.IDCAPTHI == id).ToList();
        }
        

        public bool ThemMonThi(MONTHI model)
        {
            db.MONTHIs.Add(model);
            db.SaveChanges();
            return true;
        }

        public int SuaMonThi(MONTHI model)
        {
            var de = db.MONTHIs.Find(model.IDMON);
            de.TENMON = model.TENMON;
            de.TRANGTHAI = model.TRANGTHAI;
            db.SaveChanges();
            return model.IDMON;
        }

        public bool XoaMOnThi(int id)
        {
            var cap = db.MONTHIs.Find(id);
            db.MONTHIs.Remove(cap);
            db.SaveChanges();
            return true;
        }
    }
}
