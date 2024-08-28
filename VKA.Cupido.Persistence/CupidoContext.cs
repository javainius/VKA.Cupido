using Microsoft.EntityFrameworkCore;
using VKA.Cupido.Entities;

namespace VKA.Cupido.Persistence
{
    public class CupidoContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<PairEntity> Pairs { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }

        public CupidoContext(DbContextOptions<CupidoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VKA.Cupido;Integrated Security=True;");
        }
    }
}
