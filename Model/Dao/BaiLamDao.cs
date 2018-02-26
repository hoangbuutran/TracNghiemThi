using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class BaiLamDao
    {
        TestDbContext db = null;
        public BaiLamDao()
        {
            db = new TestDbContext();
        }

        public List<BAILAM> toList()
        {
            return db.BAILAMs.ToList();
        }
        public List<BAILAM> toListLichSuThi(int id)
        {
            return db.BAILAMs.Where(x => x.IDNGUOIDUNG == id).ToList();
        }

        public BAILAM getBaiLamSingle(int id)
        {
            return db.BAILAMs.SingleOrDefault(x => x.IDBAILAM == id);
        }

        public bool ThemBaiLam(BAILAM model)
        {
            model.NGAY = DateTime.Now;
            db.BAILAMs.Add(model);
            db.SaveChanges();
            return true;
        }

        public int SoSanhDapAn(int DeThiID, int BaiLamID)
        {
            var Tong = 0;
            var baiLamDao = new BaiLamDao().getBaiLamSingle(BaiLamID);
            var dsCauHoiDeThi = new CauHoiDao().toListCauHoi(DeThiID);
            var dsCauHoiBaiLam = baiLamDao.CT_BAIlAM_CAUHOI.ToList();

            foreach (var itemCha in dsCauHoiDeThi)
            {
                foreach (var itemCon in dsCauHoiBaiLam)
                {
                    if (itemCha.IDCAUHOI == itemCon.IDCAUHOI)
                    {
                        if (itemCha.CAUHOI.DAPAN_DUNG == itemCon.TRALOI)
                        {
                            itemCon.DIEM = 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            itemCon.DIEM = 0;
                            db.SaveChanges();
                        }
                    }
                }
            }

            foreach (var item in dsCauHoiBaiLam)
            {
                if (item.DIEM != null) Tong += item.DIEM.Value;
            }
            db.SaveChanges();
            return Tong;

        }
    }
}
