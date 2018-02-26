namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAILAM")]
    public partial class BAILAM
    {
        public BAILAM()
        {
            CT_BAIlAM_CAUHOI = new HashSet<CT_BAIlAM_CAUHOI>();
        }

        [Key]
        public int IDBAILAM { get; set; }

        public int? IDDETHI { get; set; }

        public int? IDNGUOIDUNG { get; set; }

        [Display(Name = "Điểm")]
        public double? DIEM { get; set; }

        [Display(Name = "Ngày Thi")]
        public DateTime? NGAY { get; set; }

        public virtual DETHI DETHI { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual ICollection<CT_BAIlAM_CAUHOI> CT_BAIlAM_CAUHOI { get; set; }
    }
}
