using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public class Liquid
    {
        public int LiquidId { get; set; }
        public string name { get; set; }
        public List<VapeLiquid> VapeLiquid { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
