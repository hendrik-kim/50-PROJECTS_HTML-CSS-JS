using AutoMapper;
using System;
using System.Collections.Generic;
using Talent.Data.Models;
using Talent.Web.ViewModels;

namespace Talent.Web.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsProcess { get; set; }
        public bool IsComplete { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
        public virtual IEnumerable<Tag> Tags { get; set; }
    }
}
