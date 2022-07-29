using Allup.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Allup.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string ImgUrl { get; set; }

        public IFormFile Photo { get; set; }

        public Nullable<int> ParentId { get; set; }
        public string ParentName { get; set; }
        public List<string> AllParent { get; set; }
        public List<string> ChildNames { get; set; }
        public List<string> AllChildNames { get; set; }

    }
}
