namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETHI")]
    public partial class DETHI
    {
        public DETHI()
        {
            BAILAMs = new HashSet<BAILAM>();
            CT_DANHGIA_DETHI = new HashSet<CT_DANHGIA_DETHI>();
            CT_DETHI_CAUHOI = new HashSet<CT_DETHI_CAUHOI>();
            YKIEN_DETHI = new HashSet<YKIEN_DETHI>();
        }

        [Key]
        public int IDDETHI { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên đề thi")]
        [Required(ErrorMessage = "*")]
        public string TENDETHI { get; set; }

        public int? IDMUCDO { get; set; }

        public int? IDMON { get; set; }

        public int? IDTHOIGIAN { get; set; }

        public int? IDSOCAU { get; set; }

        public int? IDNGUOIDUNG { get; set; }

        [Display(Name = "Ngày tạo đề")]
        public DateTime? NGAYTAODE { get; set; }

        [Display(Name = "Độ tin cậy")]
        public int? DOTINCAY { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANGTHAI { get; set; }

        public int? IDCAPTHI { get; set; }

        public virtual ICollection<BAILAM> BAILAMs { get; set; }

        public virtual CAPTHI CAPTHI { get; set; }

        public virtual ICollection<CT_DANHGIA_DETHI> CT_DANHGIA_DETHI { get; set; }

        public virtual ICollection<CT_DETHI_CAUHOI> CT_DETHI_CAUHOI { get; set; }

        public virtual MONTHI MONTHI { get; set; }

        public virtual MUCDO MUCDO { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual SOCAU SOCAU { get; set; }

        public virtual THOIGIAN THOIGIAN { get; set; }

        public virtual ICollection<YKIEN_DETHI> YKIEN_DETHI { get; set; }
    }
}
