using System.Collections.Generic;
using Demo.Models.Models;

namespace Demo.Interfaces.Services
{
    public interface IPostService
    {
        IList<Post> All();
        Post GetById(int id);
        void Insert(Post post);
        void Update(Post post);
    }
}
