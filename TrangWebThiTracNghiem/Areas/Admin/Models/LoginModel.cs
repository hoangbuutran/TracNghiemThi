using System.ComponentModel.DataAnnotations;

namespace TrangWebThiTracNghiem.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string tenDangNhap { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string matKhau { get; set; }
        public bool nhoMatKhau { get; set; }
    }
}