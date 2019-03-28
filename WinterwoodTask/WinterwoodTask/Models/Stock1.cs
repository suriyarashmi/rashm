namespace WinterwoodTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public int StockID { get; set; }

        [StringLength(50)]
        public string Fruit { get; set; }

        [StringLength(50)]
        public string Variety { get; set; }

        public int? Quantity { get; set; }
    }
}
