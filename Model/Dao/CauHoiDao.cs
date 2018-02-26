using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CauHoiDao
    {
        TestDbContext db = null;
        public CauHoiDao()
        {
            db = new TestDbContext();
        }


        public List<CT_DETHI_CAUHOI> toListCauHoi(int idDeThi)
        {
            return db.CT_DETHI_CAUHOI.Where(x => x.IDDETHI == idDeThi).ToList();
        }

        public CAUHOI cauhoisingle(int idcauhoi)
        {
            //object[] parameter =
            //{
            //    new SqlParameter("@IDCAUHOI", idcauhoi), 
            //};
            //return db.Database.SqlQuery<CAUHOI>("CAUHOI_SINGLE @IDCAUHOI", parameter).SingleOrDefault();
            return db.CAUHOIs.SingleOrDefault(x => x.IDCAUHOI == idcauhoi);
        }

        public List<CAUHOI> ListcauhoiInDb()
        {
            return db.Database.SqlQuery<CAUHOI>("CAUHOI_listcauhoiInDB").ToList();
        }

        public List<CAUHOI> toListCauHoiMonThi(int idMonThi, int iddethi)
        {
            object[] parameter =
            {
                new SqlParameter("@IDMONTHI", idMonThi),
                new SqlParameter("@IDDETHI", iddethi),
            };
            return db.Database.SqlQuery<CAUHOI>("CAUHOI_toListCauHoiMonThi @IDMONTHI, @IDDETHI", parameter).ToList();
            //return db.CAUHOIs.Where(x => x.IDMON == idMonThi).ToList();
        }

        public int soCauHoiDangCo(int idDeThi)
        {
            object[] parameter =
            {
                new SqlParameter("@IDDETHI", idDeThi), 
            };
            return db.Database.ExecuteSqlCommand("CAUHOI_soCauHoiDangCo @IDDETHI", parameter);
            //int i = db.CT_DETHI_CAUHOI.Count(x => x.IDDETHI == idDeThi);
            //return i;
        }

        public int ThemCauHoi(CAUHOI model)
        {
            object[] parameter =
            {
                new SqlParameter("@NOIDUNGCAUHOI", model.NOIDUNGCAUHOI.Trim()),
                new SqlParameter("@DAPAN_A", model.DAPAN_A.Trim()),
                new SqlParameter("@DAPAN_B", model.DAPAN_C.Trim()),
                new SqlParameter("@DAPAN_C", model.DAPAN_C.Trim()),
                new SqlParameter("@DAPAN_D", model.DAPAN_D.Trim()),
                new SqlParameter("@DAPAN_DUNG", model.DAPAN_DUNG.Trim()),
                new SqlParameter("@DOTINCAY", model.DOTINCAY),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI),
                new SqlParameter("@IDMON", model.IDMON),
            };
            return db.Database.ExecuteSqlCommand("CAUHOI_ThemCauHoi @NOIDUNGCAUHOI, @DAPAN_A, @DAPAN_B, @DAPAN_C, @DAPAN_D, @DAPAN_DUNG, @DOTINCAY, @TRANGTHAI, @IDMON", parameter);

        }

        public int SuaCauHoi(CAUHOI model)
        {

            object[] parameter =
            {
                new SqlParameter("@IDCAUHOI", model.IDCAUHOI),
                new SqlParameter("@NOIDUNGCAUHOI", model.NOIDUNGCAUHOI.Trim()),
                new SqlParameter("@DAPAN_A", model.DAPAN_A.Trim()),
                new SqlParameter("@DAPAN_B", model.DAPAN_B.Trim()),
                new SqlParameter("@DAPAN_C", model.DAPAN_C.Trim()),
                new SqlParameter("@DAPAN_D", model.DAPAN_D.Trim()),
                new SqlParameter("@DAPAN_DUNG", model.DAPAN_DUNG.Trim()),
                new SqlParameter("@TRANGTHAI", model.TRANGTHAI),
                new SqlParameter("@IDMON", model.IDMON),
            };
            return db.Database.ExecuteSqlCommand("CAUHOI_SuaCauHoi @IDCAUHOI, @NOIDUNGCAUHOI, @DAPAN_A, @DAPAN_B, @DAPAN_C, @DAPAN_D, @DAPAN_DUNG, @TRANGTHAI, @IDMON", parameter);


        }

        public int XoaCauHoi(int id)
        {
            object[] parameter =
            {
                new SqlParameter("@IDCAUHOI", id), 
            };
            return db.Database.ExecuteSqlCommand("CAUHOI_XoaCauHoi @IDCAUHOI", parameter);

        }
    }
}
