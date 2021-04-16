namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderID { get; set; }

        public int? TransactionID { get; set; }

        public int? ProductID { get; set; }

        public int? QuantiyProduct { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "text")]
        public string Data { get; set; }

        public bool? Status { get; set; }
    }
}
