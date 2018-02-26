namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SOCAU")]
    public partial class SOCAU
    {
        public SOCAU()
        {
            DETHIs = new HashSet<DETHI>();
        }

        [Key]
        public int IDSOCAU { get; set; }

        [Column("SOCAU")]
        [Display(Name = "Số câu")]
        [Required(ErrorMessage = "*")]
        public int? SOCAU1 { get; set; }

        public virtual ICollection<DETHI> DETHIs { get; set; }
    }
}
