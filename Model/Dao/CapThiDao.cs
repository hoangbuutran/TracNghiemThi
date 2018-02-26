using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CapThiDao
    {
        private TestDbContext _db = null;
        public CapThiDao()
        {
            _db = new TestDbContext();
        }
        public List<CAPTHI> toList()
        {
            var res = _db.CAPTHIs.ToList();
            return res;
        }

        public CAPTHI CapThiSingle(int id)
        {
            object[] parameter =
            {
                new SqlParameter("@IDCAPTHI", id), 
            };
            return _db.Database.SqlQuery<CAPTHI>("CAPTHI_SINGLE @IDCAPTHI", parameter).SingleOrDefault();
        }

        public int ThemCapThi(CAPTHI model)
        {
            object[] parameters =
            {
                new SqlParameter("@TENCAPTHI", model.TENCAPTHI),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI)
            };
            var res = _db.Database.ExecuteSqlCommand("CAPTHI_ThemCapThi @TENCAPTHI, @TRANGTHAI", parameters);
            return res;
        }

        public int SuaCapThi(CAPTHI model)
        {
            object[] parameters =
            {
                new SqlParameter("@IDCAPTHI", model.IDCAPTHI),
                new SqlParameter("@TENCAPTHI", model.TENCAPTHI),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI)
            };
            var res = _db.Database.ExecuteSqlCommand("CAPTHI_SuaCapThi @IDCAPTHI, @TENCAPTHI, @TRANGTHAI", parameters);
            return res;
        }

        public int XoaCapThi(int id)
        {
            object[] parameters =
            {
                new SqlParameter("@IDCAPTHI", id)
            };
            var res = _db.Database.ExecuteSqlCommand("CAPTHI_XoaCapThi @IDCAPTHI", parameters);
            return res;
        }

    }
}
