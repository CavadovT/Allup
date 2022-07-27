using System;
using System.Collections.Generic;

namespace Allup.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; } //sekili categoryde olan productlardan sece bilerik
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
