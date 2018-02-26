namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUCDO")]
    public partial class MUCDO
    {
        public MUCDO()
        {
            DETHIs = new HashSet<DETHI>();
        }

        [Key]
        public int IDMUCDO { get; set; }

        [StringLength(50)]
        [Display(Name = "Mức độ")]
        [Required(ErrorMessage = "*")]
        public string TENMUCDO { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "*")]
        public bool? TRANGTHAI { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }
    }
}
