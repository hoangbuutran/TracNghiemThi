using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DeThiDao
    {
        TestDbContext db = null;
        public DeThiDao()
        {
            db = new TestDbContext();
        }
        public List<DETHI> toList()
        {
            return db.DETHIs.Where(x => x.TRANGTHAI == true).ToList();
        }

        public DETHI getDeThiSingle(int id)
        {
            return db.DETHIs.SingleOrDefault(x => x.IDDETHI == id);
        }

        public IOrderedQueryable<DETHI> ListDeThiMoi()
        {
            return db.DETHIs.OrderByDescending(x => x.NGAYTAODE);
        }

        public List<DETHI> toListID(int id)
        {
            return db.DETHIs.Where(x => x.TRANGTHAI == true && x.IDCAPTHI == id).ToList();
        }

        public List<DETHI> toListDeThiID(int id)
        {
            return db.DETHIs.Where(x => x.TRANGTHAI == true && x.IDMON == id).ToList();
        }



        public bool ThemDeThi(DETHI model)
        {
            db.DETHIs.Add(model);
            db.SaveChanges();
            CapNhatDeThiMoi(model.IDDETHI);
            return true;
        }

        public void CapNhatDeThiMoi(int id)
        {
            var model = db.DETHIs.Find(id);
            var timlaitenmon = db.MONTHIs.Find(model.IDMON);
            var timlaicap = db.CAPTHIs.Find(model.IDCAPTHI);
            model.TENDETHI = "Đề Thi Số: " + model.IDDETHI + " - " + model.TENDETHI + " - " + timlaitenmon.TENMON;
            db.SaveChanges();
        }

        public int SuaDeThi(DETHI model)
        {
            var de = db.DETHIs.Find(model.IDDETHI);
            de.TENDETHI = model.TENDETHI;
            de.IDMUCDO = model.IDMUCDO;
            de.IDMON = model.IDMON;
            de.IDTHOIGIAN = model.IDTHOIGIAN;
            de.IDSOCAU = model.IDSOCAU;
            de.NGAYTAODE = DateTime.Now;
            de.DOTINCAY = model.DOTINCAY;
            de.TRANGTHAI = model.TRANGTHAI;
            db.SaveChanges();
            return model.IDDETHI;
        }

        public int XoaDeThi(int id)
        {

            object[] parameter =
            {
                new SqlParameter("@IDDETHI", id), 
            };
            return db.Database.ExecuteSqlCommand("DETHI_XOADETHI @IDDETHI", parameter);
            //var de = db.DETHIs.Find(id);
            //db.DETHIs.Remove(de);
            //db.SaveChanges();
            //return true;
        }
    }
}
