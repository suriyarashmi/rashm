namespace WinterwoodTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Batch")]
    public partial class Batch
    {
        [Key]
        public int BatchID { get; set; }

        [StringLength(50)]
        public string Fruit { get; set; }

        [StringLength(50)]
        public string Variety { get; set; }

        public int? Quantity { get; set; }
    }
}
