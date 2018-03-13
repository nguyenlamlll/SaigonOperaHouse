using SOH.Web.Data;
using SOH.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        void IPostService.Create(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                try
                {
                    postRepository.Create(post);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        List<Post> IPostService.GetAllPost()
        {
            throw new NotImplementedException();
        }
    }
}
