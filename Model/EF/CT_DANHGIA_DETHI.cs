namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DANHGIA_DETHI
    {
        public int ID { get; set; }

        public int? IDDANHGIA { get; set; }

        public int? IDDETHI { get; set; }

        public virtual DANHGIA DANHGIA { get; set; }

        public virtual DETHI DETHI { get; set; }
    }
}
