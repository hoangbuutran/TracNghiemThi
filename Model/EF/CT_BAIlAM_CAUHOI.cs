namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BAIlAM_CAUHOI
    {
        [Key]
        public int IDCT_BAIlAM_CAUHOI { get; set; }

        public int? IDCAUHOI { get; set; }

        public int? IDBAILAM { get; set; }

        [StringLength(1)]
        public string TRALOI { get; set; }

        public int? DIEM { get; set; }

        public virtual BAILAM BAILAM { get; set; }

        public virtual CAUHOI CAUHOI { get; set; }
    }
}
