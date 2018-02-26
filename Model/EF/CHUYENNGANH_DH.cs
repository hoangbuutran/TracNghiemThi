namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUYENNGANH_DH
    {
        public CHUYENNGANH_DH()
        {
            CT_CHUYENNGANH_MON = new HashSet<CT_CHUYENNGANH_MON>();
        }

        [Key]
        public int IDCN_DH { get; set; }

        [StringLength(50)]
        public string TENCN_DH { get; set; }

        public int? IDCAPTHI { get; set; }

        public virtual CAPTHI CAPTHI { get; set; }

        public virtual ICollection<CT_CHUYENNGANH_MON> CT_CHUYENNGANH_MON { get; set; }
    }
}
