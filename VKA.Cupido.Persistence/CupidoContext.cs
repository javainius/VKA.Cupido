using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKA.Cupido.Entities;

namespace VKA.Cupido.Persistence
{
    public class CupidoContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<PairEntity> Pairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VKA.Cupido;Integrated Security=True;");
        }
    }
}
