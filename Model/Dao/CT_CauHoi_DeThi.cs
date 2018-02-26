using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CT_CauHoi_DeThi
    {
        TestDbContext db = null;
        public CT_CauHoi_DeThi()
        {
            db = new TestDbContext();
        }

        public List<CT_DETHI_CAUHOI> toList()
        {
            return db.CT_DETHI_CAUHOI.Where(x => x.ISSELECTED == true).ToList();
        }

        public List<CT_DETHI_CAUHOI> toListCauHoi(int idDeThi)
        {
            return db.CT_DETHI_CAUHOI.Where(x => x.IDDETHI == idDeThi).ToList();
        }

        public List<CT_DETHI_CAUHOI> toListCauHoiMonThi(int idMonThi)
        {
            return db.CT_DETHI_CAUHOI.Where(x => x.DETHI.IDMON == idMonThi).ToList();
        }

        public int soCauHoiDangCo(int idDeThi)
        {
            int i = db.CT_DETHI_CAUHOI.Count(x => x.IDDETHI == idDeThi);
            return i;
        }

        public List<CT_DETHI_CAUHOI> ToListCauHoiDeThi(int idDeThi)
        {
            return db.CT_DETHI_CAUHOI.Where(x => x.ISSELECTED == true && x.IDDETHI == idDeThi).ToList();
        }

        public bool ThemCT_CAUHOI_DeThipara(int idDeThi, int idCauHoi)
        {
            CT_DETHI_CAUHOI result = new CT_DETHI_CAUHOI();
            result.IDCAUHOI = idCauHoi;
            result.IDDETHI = idDeThi;
            result.ISSELECTED = true;
            db.CT_DETHI_CAUHOI.Add(result);
            db.SaveChanges();
            return true;
        }

        public bool ThemCT_CAUHOI_DeThi(CT_DETHI_CAUHOI model)
        {
            db.CT_DETHI_CAUHOI.Add(model);
            db.SaveChanges();
            return true;
        }

        public int XoaCauHoiTrongDeDao(int id)
        {
            int i = 0;
            var ctDethiCauhoi = db.CT_DETHI_CAUHOI.SingleOrDefault(x => x.ID == id);
            if (ctDethiCauhoi != null)
            {
                i = (int) ctDethiCauhoi.IDDETHI;
                db.CT_DETHI_CAUHOI.Remove(ctDethiCauhoi);
                db.SaveChanges();
                return i;
            }
            return i;

        }

    }
}
