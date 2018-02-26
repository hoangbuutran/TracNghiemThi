namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAUHOI")]
    public partial class CAUHOI
    {
        public CAUHOI()
        {
            CT_BAIlAM_CAUHOI = new HashSet<CT_BAIlAM_CAUHOI>();
            CT_DETHI_CAUHOI = new HashSet<CT_DETHI_CAUHOI>();
        }

        [Key]
        public int IDCAUHOI { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung: ")]
        [Required(ErrorMessage = "*")]
        public string NOIDUNGCAUHOI { get; set; }

        [StringLength(300)]
        [Display(Name = "Đáp án A")]
        [Required(ErrorMessage = "*")]
        public string DAPAN_A { get; set; }

        [StringLength(300)]
        [Display(Name = "Đáp án B")]
        [Required(ErrorMessage = "*")]
        public string DAPAN_B { get; set; }

        [StringLength(300)]
        [Display(Name = "Đáp án C")]
        [Required(ErrorMessage = "*")]
        public string DAPAN_C { get; set; }

        [StringLength(300)]
        [Display(Name = "Đáp án D")]
        [Required(ErrorMessage = "*")]
        public string DAPAN_D { get; set; }

        [StringLength(1)]
        [Display(Name = "Đáp án đúng")]
        [Required(ErrorMessage = "*")]
        public string DAPAN_DUNG { get; set; }

        [Display(Name = "Độ tin cậy")]
        public int? DOTINCAY { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANGTHAI { get; set; }

        public int? IDMON { get; set; }

        public virtual MONTHI MONTHI { get; set; }

        public virtual ICollection<CT_BAIlAM_CAUHOI> CT_BAIlAM_CAUHOI { get; set; }

        public virtual ICollection<CT_DETHI_CAUHOI> CT_DETHI_CAUHOI { get; set; }
    }
}
