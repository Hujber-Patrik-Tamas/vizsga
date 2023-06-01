using System;
using System.Collections.Generic;

namespace RealEstateGUI.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Realestates = new HashSet<Ad>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Ad> Realestates { get; set; }
    }
}
