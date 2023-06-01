using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public string LatLong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public Seller Seller { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public static List<Ad> LoadFromCsv(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var ads = JsonConvert.DeserializeObject<Ad[]>(json);
            if (ads != null)
            {
                return ads.ToList();
            }
            throw new ArgumentException();

        }

        public double DistanceTo(string fromLatLong)
        {
            //47.5410485803319,19.1516419487702
            double fromX = Convert.ToDouble(fromLatLong.Split(',')[0].Replace('.',','));
            double fromY = Convert.ToDouble(fromLatLong.Split(',')[1].Replace('.', ','));

            double x = Convert.ToDouble(this.LatLong.Split(',')[0].Replace('.', ','));
            double y = Convert.ToDouble(this.LatLong.Split(',')[1].Replace('.', ','));

            return Math.Sqrt( (fromX - x) * (fromX - x) + (fromY - y) * (fromY - y) );
        }
    }
}
