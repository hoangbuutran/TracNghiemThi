namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DETHI_CAUHOI
    {
        public int ID { get; set; }

        public int? IDDETHI { get; set; }

        public int? IDCAUHOI { get; set; }

        public bool ISSELECTED { get; set; }

        public virtual CAUHOI CAUHOI { get; set; }

        public virtual DETHI DETHI { get; set; }
    }
}
