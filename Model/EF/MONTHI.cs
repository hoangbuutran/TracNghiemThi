namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONTHI")]
    public partial class MONTHI
    {
        public MONTHI()
        {
            CAUHOIs = new HashSet<CAUHOI>();
            CT_CHUYENNGANH_MON = new HashSet<CT_CHUYENNGANH_MON>();
            DETHIs = new HashSet<DETHI>();
            TAILIEUx = new HashSet<TAILIEU>();
        }

        [Key]
        public int IDMON { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Tên môn thi")]
        [Required(ErrorMessage = "*")]
        public string TENMON { get; set; }

        public int? IDCAPTHI { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }

        public virtual CAPTHI CAPTHI { get; set; }

        public virtual ICollection<CAUHOI> CAUHOIs { get; set; }

        public virtual ICollection<CT_CHUYENNGANH_MON> CT_CHUYENNGANH_MON { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }

        public virtual ICollection<TAILIEU> TAILIEUx { get; set; }
    }
}
