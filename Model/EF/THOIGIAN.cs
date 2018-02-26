namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THOIGIAN")]
    public partial class THOIGIAN
    {
        public THOIGIAN()
        {
            DETHIs = new HashSet<DETHI>();
        }

        [Key]
        public int IDTHOIGIAN { get; set; }

        [Column("THOIGIAN")]
        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "*")]
        public TimeSpan? THOIGIAN1 { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }
    }
}
