using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;

namespace Talent.Web.ViewModels
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTimeKind CreatedOn { get; set; }
        public DateTimeKind UpdatedOn { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
