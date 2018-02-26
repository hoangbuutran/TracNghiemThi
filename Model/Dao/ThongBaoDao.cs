using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ThongBaoDao
    {
        private TestDbContext db = null;

        public ThongBaoDao()
        {
            db = new TestDbContext();
        }

        public IOrderedEnumerable<THONGBAO> toList()
        {
            return db.THONGBAOs.Where(x => x.TRANGTHAI == true).ToList().OrderByDescending(x=>x.IDTHONGBAO);
        }
        public bool ThemThongBao(THONGBAO model)
        {
            db.THONGBAOs.Add(model);
            db.SaveChanges();
            return true;
        }

        public int SuaThongBao(THONGBAO model)
        {
            var thongbao = db.THONGBAOs.Find(model.IDTHONGBAO);
            thongbao.TENTHONGBAO = model.TENTHONGBAO;
            thongbao.NOIDUNGTHONGBAO = model.NOIDUNGTHONGBAO;
            thongbao.TRANGTHAI = model.TRANGTHAI;
            db.SaveChanges();
            return model.IDTHONGBAO;
        }

        public bool XoaThongBao(int id)
        {
            var thongbao = db.THONGBAOs.Find(id);
            db.THONGBAOs.Remove(thongbao);
            db.SaveChanges();
            return true;
        }

    }
}
