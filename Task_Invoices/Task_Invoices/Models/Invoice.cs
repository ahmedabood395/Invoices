namespace Task_Invoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [Key]
        [Column("ID_ Invoice")]
        public int ID__Invoice { get; set; }

        [StringLength(50)]
        public string Product { get; set; }

        [StringLength(50)]
        public string Quantity { get; set; }

        public int? Price { get; set; }

        public int? Id_User { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
