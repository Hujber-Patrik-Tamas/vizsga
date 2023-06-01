using System;
using System.Collections.Generic;

namespace RealEstateGUI.Models
{
    public partial class Category
    {
        public Category()
        {
            Realestates = new HashSet<Ad>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Ad> Realestates { get; set; }
    }
}
