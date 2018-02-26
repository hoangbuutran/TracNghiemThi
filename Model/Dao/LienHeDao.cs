using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class LienHeDao
    {
        private TestDbContext db = null;
        public LienHeDao()
        {
            db = new TestDbContext();
        }

        public List<LIENHE> toList()
        {
            return db.LIENHEs.ToList();
        }

        public bool ThemLienHe(LIENHE model)
        {
            db.LIENHEs.Add(model);
            db.SaveChanges();
            return true;
        }

        public int ThayDoiLienHe(LIENHE model)
        {
            var lien = db.LIENHEs.Find(model.IDLIENHE);
            lien.TRANGTHAI = model.TRANGTHAI;
            db.SaveChanges();
            return model.IDLIENHE;
        }

        public bool XoaLienHe(int id)
        {
            var lien = db.LIENHEs.Find(id);
            db.LIENHEs.Remove(lien);
            db.SaveChanges();
            return true;
        }

    }
}
