using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOH.Web.Data;

namespace SOH.Web.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        void IPostRepository.Create(Post post)
        {
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
        }

        Post IPostRepository.Get(Guid id)
        {
            return dbContext.Posts.Find(id);
        }

        List<Post> IPostRepository.GetAll()
        {
            return dbContext.Posts
                .Include(p => p.ApplicationUser.Id).Include(p => p.ApplicationUser.UserName)
                .ToList();
        }
    }
}
