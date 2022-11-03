using HumansAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HumansAPI.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        public DbSet<Human> Humans { get; set; }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HumanConnection>()
                .HasOne(x => x.FirstHuman)
                .WithMany(x => x.Connections)
                .HasForeignKey(x => x.FirstHumanId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<HumanConnection>()
                .HasOne(x => x.SecondHuman)
                .WithMany()
                .HasForeignKey(x => x.SecondHumanId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }

    }
}
