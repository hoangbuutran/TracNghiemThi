namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAPTHI")]
    public partial class CAPTHI
    {
        public CAPTHI()
        {
            CHUYENNGANH_DH = new HashSet<CHUYENNGANH_DH>();
            DETHIs = new HashSet<DETHI>();
            MONTHIs = new HashSet<MONTHI>();
        }

        [Key]
        public int IDCAPTHI { get; set; }

        [StringLength(20)]
        [Display(Name = "Cấp thi")]
        [Required(ErrorMessage = "*")]
        public string TENCAPTHI { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }

        public virtual ICollection<CHUYENNGANH_DH> CHUYENNGANH_DH { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }

        public virtual ICollection<MONTHI> MONTHIs { get; set; }
    }
}
