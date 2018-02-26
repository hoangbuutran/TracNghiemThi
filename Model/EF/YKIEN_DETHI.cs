namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YKIEN_DETHI
    {
        [Key]
        public int IDYKIENDETHI { get; set; }

        public int? IDNGUOIDUNG { get; set; }

        public int? IDDETHI { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        public DateTime? NGAYYKIEN { get; set; }

        public bool? TRANGTHAI { get; set; }

        public virtual DETHI DETHI { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
