using SOH.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Repositories
{
    public interface IPostRepository
    {
        void Create(Post post);
        Post Get(Guid id);
        List<Post> GetAll();
    }
}
