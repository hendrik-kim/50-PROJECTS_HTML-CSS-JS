using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;

namespace Talent.Web.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public string CategName { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
