namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [Key]
        public int IDTINTUC { get; set; }

        [StringLength(300)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "*")]
        public string TIEUDE { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tóm tắt")]
        [Required(ErrorMessage = "*")]
        public string TOMTAT { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "*")]
        public string NOIDUNG { get; set; }

        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "*")]
        public DateTime? THOIGIAN { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }

        [StringLength(300)]
        [Display(Name = "Ảnh bìa")]
        [Required(ErrorMessage = "*")]
        public string ANHBIA { get; set; }

        [StringLength(200)]
        [Display(Name = "Nguồn")]
        [Required(ErrorMessage = "*")]
        public string NGUON { get; set; }
    }
}
