using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoaiNguoiDungDao
    {
        private readonly TestDbContext _db = null;
        public LoaiNguoiDungDao()
        {
            _db = new TestDbContext();
        }

        public List<LOAINGUOIDUNG> toList()
        {
            var res = _db.Database.SqlQuery<LOAINGUOIDUNG>("Xem_DsLoaiNguoiDung").ToList();
            return res;
        }

        public LOAINGUOIDUNG NGUOIDUNGSINGLE(int idloainguoidung)
        {
            object[] parameters =
            {
                new SqlParameter("@IDLOAINGUOIDUNG", idloainguoidung)
            };
            var res = _db.Database.SqlQuery<LOAINGUOIDUNG>("LOAINGUOIDUNG_NGUOIDUNGSINGLE @IDLOAINGUOIDUNG", parameters).SingleOrDefault();
            return res;
        }

        public int ThemLoaiNguoiDung(LOAINGUOIDUNG model)
        {
            object[] parameters =
            {
                new SqlParameter("@TENLOAINGUOIDUNG", model.TENLOAINGUOIDUNG),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI)
            };
            var res = _db.Database.ExecuteSqlCommand("LOAINGUOIDUNG_ThemLoaiNguoiDung @TENLOAINGUOIDUNG, @TRANGTHAI", parameters);
            return res;
        }

        public int SuaLoaiNguoiDung(LOAINGUOIDUNG model)
        {
            object[] parameters =
            {
                new SqlParameter("@IDLOAINGUOIDUNG", model.IDLOAINGUOIDUNG),
                new SqlParameter("@TENLOAINGUOIDUNG", model.TENLOAINGUOIDUNG),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI)
            };
            var res = _db.Database.ExecuteSqlCommand("SUALOAINGUOIDUNG @IDLOAINGUOIDUNG, @TENLOAINGUOIDUNG, @TRANGTHAI", parameters);
            return res;
        }

        public int XoaLoaiNguoiDung(int id)
        {
            object[] parameters =
            {
                new SqlParameter("@IDLOAINGUOIDUNG", id)
            };
            var res = _db.Database.ExecuteSqlCommand("KHOALOAINGUOIDUNG @IDLOAINGUOIDUNG", parameters);
            return res;
        }

    }
}
