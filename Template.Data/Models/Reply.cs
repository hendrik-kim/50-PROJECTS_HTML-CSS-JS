using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Talent.Data.Models
{
    public class PostReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public DateTime CreatedOn { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
