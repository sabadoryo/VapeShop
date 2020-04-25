using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;

namespace VapeShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Vape> VapesOfTheWeek { get; set; }
    }
}
