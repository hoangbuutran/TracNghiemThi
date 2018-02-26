namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAILIEU")]
    public partial class TAILIEU
    {
        [Key]
        public int IDTAILIEU { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "*")]
        public string NOIDUNG { get; set; }

        public int? IDMON { get; set; }

        [Display(Name = "Ngày soạn")]
        [Required(ErrorMessage = "*")]
        public DateTime? NGAY { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tên bài")]
        [Required(ErrorMessage = "*")]
        public string TENBAI { get; set; }

        public virtual MONTHI MONTHI { get; set; }
    }
}
