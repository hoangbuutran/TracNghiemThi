using System.ComponentModel.DataAnnotations;

namespace TrangWebThiTracNghiem.Areas.Admin.Models
{
    public class DoiMKModel
    {
        [Key]
        public int id { get; set; }
        public string matKhauCu { get; set; }
        public string matKhauMoi { get; set; }
    }
}