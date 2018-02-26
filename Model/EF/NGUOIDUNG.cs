namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        public NGUOIDUNG()
        {
            BAILAMs = new HashSet<BAILAM>();
            DETHIs = new HashSet<DETHI>();
            YKIEN_DETHI = new HashSet<YKIEN_DETHI>();
        }

        [Key]
        public int IDNGUOIDUNG { get; set; }

        [StringLength(30)]
        [Display(Name = "Tên Người Dùng")]
        
        public string TENNGUOIDUNG { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên đăng nhập")]
        public string TENDANGNHAP { get; set; }

        [StringLength(15)]
        [Display(Name = "Mật khẩu")]
        public string MATKHAU { get; set; }

        [StringLength(30)]
        public string EMAIL { get; set; }

        [Display(Name = "Độ tin cậy")]
        public int? DOTINCAY { get; set; }

        [Display(Name = "Loại người dùng")]
        public int? IDLOAINGUOIDUNG { get; set; }

        [Display(Name = "Tình trạng")]
        public bool? TRANGTHAI { get; set; }

        public virtual ICollection<BAILAM> BAILAMs { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }

        public virtual LOAINGUOIDUNG LOAINGUOIDUNG { get; set; }

        public virtual ICollection<YKIEN_DETHI> YKIEN_DETHI { get; set; }
    }
}
