using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NguoiDungDao
    {
        TestDbContext db = null;
        public NguoiDungDao()
        {
            db = new TestDbContext();
        }
        public NGUOIDUNG getByMaNguoiDung(string tenDangNhap)
        {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.TENDANGNHAP == tenDangNhap);
        }

        public bool LoginAdmin(string tendangnhap, string matkhau)
        {
            var result = db.NGUOIDUNGs.Count(x => x.TENDANGNHAP == tendangnhap && x.MATKHAU == matkhau);
            if (result > 0)
            {
                if (getByMaNguoiDung(tendangnhap).IDLOAINGUOIDUNG == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool LoginClient(string tendangnhap, string matkhau)
        {
            var result = db.NGUOIDUNGs.Count(x => x.TENDANGNHAP == tendangnhap && x.MATKHAU == matkhau);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ThemNguoiDung(NGUOIDUNG model)
        {
            db.NGUOIDUNGs.Add(model);
            db.SaveChanges();
            return true;
        }

        public bool SuaNguoiDung(NGUOIDUNG model)
        {
            try
            {
                var nguoi = db.NGUOIDUNGs.Find(model.IDNGUOIDUNG);
                nguoi.IDLOAINGUOIDUNG = nguoi.IDLOAINGUOIDUNG;
                nguoi.DOTINCAY = nguoi.DOTINCAY;
                nguoi.TENNGUOIDUNG = model.TENNGUOIDUNG;
                nguoi.EMAIL = model.EMAIL;
                nguoi.TENDANGNHAP = model.TENDANGNHAP;
                nguoi.MATKHAU = nguoi.MATKHAU;
                nguoi.TRANGTHAI = nguoi.TRANGTHAI;
                db.SaveChanges();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public bool DoiMatKhau(string mkm, NGUOIDUNG model)
        {
            try
            {
                var nguoi = db.NGUOIDUNGs.Find(model.IDNGUOIDUNG);
                nguoi.IDLOAINGUOIDUNG = nguoi.IDLOAINGUOIDUNG;
                nguoi.DOTINCAY = nguoi.DOTINCAY;
                nguoi.TENNGUOIDUNG = model.TENNGUOIDUNG;
                nguoi.EMAIL = model.EMAIL;
                nguoi.TENDANGNHAP = model.TENDANGNHAP;
                nguoi.MATKHAU = mkm;
                nguoi.TRANGTHAI = nguoi.TRANGTHAI;
                db.SaveChanges();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }

        public bool PhanQuyenVaKhoa(NGUOIDUNG model)
        {
            try
            {
                var nguoi = db.NGUOIDUNGs.Find(model.IDNGUOIDUNG);
                nguoi.IDLOAINGUOIDUNG = model.IDLOAINGUOIDUNG;
                nguoi.TRANGTHAI = model.TRANGTHAI;
                nguoi.TENNGUOIDUNG = nguoi.TENNGUOIDUNG;
                nguoi.EMAIL = nguoi.EMAIL;
                nguoi.DOTINCAY = model.DOTINCAY;
                db.SaveChanges();
                return true;
            }
            catch (NullReferenceException)
            {

                return false;
            }

        }


        public bool XoaNguoiDung(int id)
        {
            var loai = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(loai);
            db.SaveChanges();
            return true;
        }
    }
}
