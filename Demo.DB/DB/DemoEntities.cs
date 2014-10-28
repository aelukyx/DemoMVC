using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Demo.Models.Models;

namespace Demo.DB.DB
{
    public class DemoEntities : DbContext
    {
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DemoEntities>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}