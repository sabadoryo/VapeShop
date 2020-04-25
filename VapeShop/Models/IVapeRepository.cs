using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public interface IVapeRepository
    {
        IEnumerable<Vape> AllVapes { get; }
        IEnumerable<Vape> VapesOfTheWeek { get; }
        Vape GetVapeById(int pieId);
        void Update(Vape p);
    }
}
