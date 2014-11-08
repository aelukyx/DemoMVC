using Demo.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Demo.DB.Map
{
    public class PostConfiguration: EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Post", "dbo");
            HasKey(o => o.Id);
            Property(o => o.Title).HasColumnName("Title");

            HasOptional(o => o.Category)
                .WithMany(o => o.Posts)
                .HasForeignKey(o => o.CategoryId);
        }
    }
}
