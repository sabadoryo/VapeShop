using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public class VapeRepository : IVapeRepository
    {
        private readonly AppDbContext _appDbContext;

        public VapeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Vape> AllVapes
        {
            get
            {
                return _appDbContext.Vapes.Include(c => c.Category);
            }
        }

        public IEnumerable<Vape> VapesOfTheWeek
        {
            get
            {
                return _appDbContext.Vapes.Include(c => c.Category).Where(p => p.IsVapeOfTheWeek);
            }
        }

        public Vape GetVapeById(int pieId)
        {
            return _appDbContext.Vapes.FirstOrDefault(p => p.VapeId == pieId);
        }

        public void Update(Vape pie)
        {
            _appDbContext.Vapes.Update(pie);
            _appDbContext.SaveChanges();
        }
    }
}
