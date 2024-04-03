using Server.Library.Infrastructer.Implementation;
using Server.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace Server.Library.Context
{
    public class ApplicationDbContext: BaseApplicationDbContext<ApplicationDbContext>
    {
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Human> Human { get; set; }
    }
}
