using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VapeShop.Models
{
    public class LiquidRepository
    {
        private readonly AppDbContext _appDbContext;

        public LiquidRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Liquid> AllLiquids => _appDbContext.Liquids;
    }
}
