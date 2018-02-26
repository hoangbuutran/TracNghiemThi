using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CT_BaiLam_CauHoi
    {
        TestDbContext db = null;
        public CT_BaiLam_CauHoi()
        {
            db = new TestDbContext();
        }

        public int ThemCT_BAIlAM_CAUHOI(CT_BAIlAM_CAUHOI model)
        {
            model.DIEM = 0;
            object[] parameter =
            {
                new SqlParameter("@IDCAUHOI", model.IDCAUHOI),
                new SqlParameter("@IDBAILAM", model.IDBAILAM),
                new SqlParameter("@TRALOI", model.TRALOI),
                new SqlParameter("@DIEM", model.DIEM),
                
            };
            return db.Database.ExecuteSqlCommand("CT_BaiLam_CauHoi_ThemCT_BAIlAM_CAUHOI @IDCAUHOI , @IDBAILAM , @TRALOI , @DIEM", parameter);

            //db.CT_BAIlAM_CAUHOI.Add(model);
            //db.SaveChanges();
            //return true;
        }
    }
}
