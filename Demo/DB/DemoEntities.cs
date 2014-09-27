using Demo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Demo.DB
{
    public class DemoEntities: DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DemoEntities>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}