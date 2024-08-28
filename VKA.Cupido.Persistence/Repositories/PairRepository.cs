using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKA.Cupido.Entities;
using VKA.Cupido.Persistence.Interfaces;

namespace VKA.Cupido.Persistence.Repositories
{
    public class PairRepository : IPairRepository
    {
        private readonly CupidoContext _context;

        public PairRepository(CupidoContext context)
        {
            _context = context;
        }

        public async Task<List<PairEntity>> GetPairs()
        {
            return await _context.Pairs.ToListAsync();
        }

        public async Task<List<PairEntity>> SavePairs(List<PairEntity> pairs)
        {
            await _context.Pairs.AddRangeAsync(pairs);
            return await GetPairs();
        }
    }
}
