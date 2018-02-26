using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class TaiLieuDao
    {
        private TestDbContext _db = null;
        public TaiLieuDao()
        {
            _db = new TestDbContext();
        }

        public List<TAILIEU> ToList()
        {
            return _db.TAILIEUx.ToList();
        }


        public List<TAILIEU> ToListidMon(int id)
        {
            return _db.TAILIEUx.Where(x => x.IDMON == id).ToList();
        }


        public bool ThemThemTaiLieu(TAILIEU model)
        {
            _db.TAILIEUx.Add(model);
            _db.SaveChanges();
            return true;
        }

        public int SuaTaiLieu(TAILIEU model)
        {
            var taiLieu = _db.TAILIEUx.Find(model.IDTAILIEU);
            taiLieu.TENBAI = model.TENBAI;
            taiLieu.NOIDUNG = model.NOIDUNG;
            taiLieu.IDMON = taiLieu.IDMON;
            taiLieu.NGAY = DateTime.Now;
            _db.SaveChanges();
            return model.IDTAILIEU;
        }

        public bool XoaTaiLieu(int id)
        {
            var taiLieu = _db.TAILIEUx.Find(id);
            _db.TAILIEUx.Remove(taiLieu);
            _db.SaveChanges();
            return true;
        }
    }
}
