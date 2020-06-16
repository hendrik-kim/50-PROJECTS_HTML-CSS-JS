using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;

namespace Talent.Web.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Location { get; set; }
        public bool IsComplete { get; set; }

        public IList<Tag> Tags { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
