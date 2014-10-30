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

        public PostService()
        {
            this.entities = new DemoEntities();
        }
        public IList<Post> All()
        {
            return entities.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return entities.Posts.Find(id);
        }
    }
}
