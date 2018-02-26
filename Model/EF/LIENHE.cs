namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENHE")]
    public partial class LIENHE
    {
        [Key]
        public int IDLIENHE { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "*")]
        public string NOIDUNG { get; set; }

        [StringLength(30)]
        public string EMAIL { get; set; }

        [Display(Name = "Ngày gửi liên hệ")]
        public DateTime? NGAYGUIYKIEN { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANGTHAI { get; set; }
    }
}
