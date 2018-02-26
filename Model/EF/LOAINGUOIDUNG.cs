namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAINGUOIDUNG")]
    public partial class LOAINGUOIDUNG
    {
        public LOAINGUOIDUNG()
        {
            NGUOIDUNGs = new HashSet<NGUOIDUNG>();
        }

        [Key]
        [Display(Name = "Loại người dùng")]
        public int IDLOAINGUOIDUNG { get; set; }

        [StringLength(30)]
        [Display(Name = "Loại người dùng")]
        [Required(ErrorMessage = "*")]
        public string TENLOAINGUOIDUNG { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }

        public virtual ICollection<NGUOIDUNG> NGUOIDUNGs { get; set; }
    }
}
