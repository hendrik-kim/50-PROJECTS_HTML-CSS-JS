using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Talent.Data.Models;
using Talent.Web.ViewModels;

namespace Talent.Web.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }

        [Key]
        public int Id { get; set; }
        public string CategName { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
