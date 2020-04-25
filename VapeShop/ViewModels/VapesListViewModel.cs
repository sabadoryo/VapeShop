using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;

namespace VapeShop.ViewModels
{
    public class VapesListViewModel
    {
        public IEnumerable<Vape> Vapes { get; set; }
        public string CurrentCategory { get; set; }
    }
}
