using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Vape> Vapes { get; set; }
    }
}
