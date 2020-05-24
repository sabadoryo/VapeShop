using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public class VapeLiquid
    {
        public int ID { get; set; }
        public int LiquidId { get; set; }
        public int VapeId { get; set; }
        public Vape Vape { get; set; }
        public Liquid Liquid { get; set; }
    }
}
