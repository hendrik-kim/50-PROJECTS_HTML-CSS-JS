using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Talent.Data.Models
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2)]
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
