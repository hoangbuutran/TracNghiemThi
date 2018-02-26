namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_CHUYENNGANH_MON
    {
        public int ID { get; set; }

        public int? IDMON { get; set; }

        public int? IDCN_DH { get; set; }

        public virtual CHUYENNGANH_DH CHUYENNGANH_DH { get; set; }

        public virtual MONTHI MONTHI { get; set; }
    }
}
