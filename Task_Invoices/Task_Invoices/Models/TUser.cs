namespace Task_Invoices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUser")]
    public partial class TUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUser()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }

        [StringLength(100)]

        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
