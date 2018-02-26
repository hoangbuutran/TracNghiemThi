namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIA")]
    public partial class DANHGIA
    {
        public DANHGIA()
        {
            CT_DANHGIA_DETHI = new HashSet<CT_DANHGIA_DETHI>();
        }

        [Key]
        public int IDDANHGIA { get; set; }

        [StringLength(20)]
        [Display(Name = "Đánh giá")]
        [Required(ErrorMessage = "*")]
        public string TENDANHGIA { get; set; }

        public virtual ICollection<CT_DANHGIA_DETHI> CT_DANHGIA_DETHI { get; set; }
    }
}
