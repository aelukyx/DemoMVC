using Demo.DB.DB;
using Demo.Interfaces.Services;
using Demo.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Demo.Services.Services
{
    public class PostService: IPostService
    {
        private readonly DemoEntities entities;

        public PostService(DemoEntities entities)
        {
            this.entities = entities;
        }
        
        public IList<Post> All()
        {
            return entities.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return entities.Posts.First(x => x.Id == id);
        }

        public void Insert(Post post)
        {
            entities.Posts.Add(post);
            entities.SaveChanges();
        }

        public void Update(Post post)
        {

        }
    }
}
