using Allup.Models;
using System.Collections.Generic;

namespace Allup.ViewModels
{
    public class HeaderVM
    {
        public Bio Bio { get; set; }
        public List<Language> Languages { get; set; }
        public List<Category> Categories { get; set; }
        public Banner Banner { get; set; }
    }
}
