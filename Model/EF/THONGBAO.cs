namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGBAO")]
    public partial class THONGBAO
    {
        [Key]
        public int IDTHONGBAO { get; set; }

        [StringLength(200)]
        [Display(Name = "Tên thông báo")]
        [Required(ErrorMessage = "*")]
        public string TENTHONGBAO { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "*")]
        public string NOIDUNGTHONGBAO { get; set; }

        [Display(Name = "Ngày đăng")]
        [Required(ErrorMessage = "*")]
        public DateTime? NGAYDANG { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }
    }
}
