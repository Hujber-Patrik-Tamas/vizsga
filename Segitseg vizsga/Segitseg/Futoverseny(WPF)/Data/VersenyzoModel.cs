using Jedlik.EntityFramework.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoverseny.Data
{
    public class VersenyzoModel
    {
        public int Id { get; set; }
        [Unique]
        public int Rajtszam { get; set; }
        [Required]
        public string Nev { get; set; } = null!;
        public DateTime? SzuletesiDatum { get; set; }
        [Required]
        public string Neme { get; set; } = null!;
        [Required]
        public TavolsagModel Tavolsag { get; set; } = null!;
        public int TavolsagId { get; set; }
        public string Korosztaly { get; set; } = null!;
    }
}
