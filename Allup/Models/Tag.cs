using System.Collections.Generic;

namespace Allup.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TagProducts> TagProducts { get; set; }
    }
}
