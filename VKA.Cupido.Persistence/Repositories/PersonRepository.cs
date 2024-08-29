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
    public class PersonRepository : IPersonRepository
    {
        private readonly CupidoContext _context;

        public PersonRepository(CupidoContext context)
        {
            _context = context;
        }

        public async Task<List<PersonEntity>> GetPersons()
        {
            return await _context.Persons.AsNoTracking().ToListAsync();
        }
    }
}
